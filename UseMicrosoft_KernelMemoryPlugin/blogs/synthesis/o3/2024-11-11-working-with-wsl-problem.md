## Problem Solving  

Case 1: Docker Volume I/O 極度緩慢  
- Problem: 在 Windows Docker Desktop 掛載本機 Volume，Qdrant 或 Jekyll Build 需數十秒～數分鐘，無法正常開發。  
- RootCause: 多層檔案系統轉譯（DrvFS＋9P＋Hyper‑V）造成隨機 4 KB I/O 只剩原生 3 %–7 % 效能。  
- Resolution: 將 Volume 直接放入 WSL ext4；如需 Windows 操作，使用 mklink 對映；高負載再配專用 SSD 直接掛載 ext4。  
- Analysis (3×5 Why)  

| 為何(技術) | 為何(流程) | 為何(人) |
|------------|-----------|---------|
|1. 9P 協定封包往返延遲高|1. 開發者沿用預設 -v C:\..|1. 想求方便未量測|
|2. Hyper‑V vhdx 另加轉寫|2. 教學文件皆示範 Win Volume|2. 未理解 WSL 架構|
|3. DrvFS 權限/屬性轉換耗時|3. 沒制定 I/O 基準測試流程|3. 團隊缺 I/O 性能意識|
|4. 隨機 4K I/O 對 SSD 最敏感|4. 部署與測試混用同路徑|4. 誤以為 SSD 足夠快|
|5. 實體 disk 未直通 guest|5. 沒有磁碟分層策略|5. 缺專責維運角色|

- Example: 將 Qdrant 資料換到 /opt/docker (ext4) 後，啟動時間由 38 s 降到 1.5 s，Build Jekyll 也縮至原 1/18。  

---

Case 2: VS Code 編輯與容器同步延遲  
- Problem: 在 Windows VS Code 編輯，GitHub Pages 容器無法即時偵測檔案異動，需手動重啟或 Polling。  
- RootCause: NTFS → inotify 事件於 DrvFS 不轉譯；再加低 I/O 導致輪詢效能雪上加霜。  
- Resolution: 採用 VS Code Remote‑WSL；vscode‑server 在 Linux 端直接接收 inotify，UI 留 Windows，消除跨層問題。  
- Analysis  

| 技術 | 流程 | 人 |
|------|------|----|
|1. DrvFS 不支援 inotify|1. 仍以 Win 端啟動 VS Code|1. 不了解 Remote 功能|
|2. 文件系統延遲高|2. 預設 LiveReload 依賴輪詢|2. 未評估需求場景|
|3. Polling 相乘 CPU/IO|3. 沒有本機 / WSL 分離策略|3. 只跟隨教學步驟|
|4. VS Code 有 server/client 架構未被利用|4. 缺少環境自動化腳本|4. 缺跨平台經驗|
|5. WSL binfmt 可直呼 code 未善用|5. 缺明確效能驗收|5. 心理抗拒「遠端」|

- Example: 在 WSL 目錄 git pull 後執行 code .，vscode‑server 自動部署；Jekyll 容器 Build 時即時監聽成功，預覽延遲 <1 s。  

---

Case 3: 容器無法使用 GPU/CUDA  
- Problem: Windows 主機插 RTX4060 Ti，容器跑 LLM 時無 GPU，被迫 CPU 推論或安裝繁雜 Linux 驅動。  
- RootCause: 不清楚 WSL GPU 虛擬化流程；Docker 缺少 nvidia‑container‑runtime 設定。  
- Resolution:  
  1) Windows 更新 WDDM 2.9+ Driver  
  2) WSL 安裝 nvidia‑container‑toolkit  
  3) Docker daemon 設 "default‑runtime": "nvidia"，執行 ‑‑gpus=all  
- Analysis  

| 技術 | 流程 | 人 |
|------|------|----|
|1. Guest 端需 /dev/dxg|1. toolkit 安裝步驟缺口|1. 對 GPU 虛擬化陌生|
|2. runtime 不指定就 fallback runc|2. 未更新 daemon.json|2. 低估 CUDA 相依|
|3. 未啟用 paravirtual channel|3. 容器映像沒 --gpus 旗標|3. 把 Linux 驅動裝進 WSL|
|4. CUDA libs 版本不符|4. 無測試 nvidia-smi 流程|4. Documentation 未細讀|
|5. Security 限制阻擋 device map|5. 防火牆/群組政策未調|5. 缺 GPU DevOps SOP|

- Example: 按流程完成後執行 `docker run -d --gpus=all ollama/ollama`，nvidia‑smi 監測 GPU 佔用 1.5 GB，問 Llama 3 每句僅 1 s 回應。  

---

Case 4: 同顆 SSD 不同掛載方式效能落差  
- Problem: 升級 Gen4 SSD 仍感覺 WSL 讀寫慢。  
- RootCause: 與系統共用 .vhdx；vhdx 內層再走 ext4；CPU 消耗與背景 Service 干擾。  
- Resolution: 拆分專用分割區直接以 ext4 掛入 WSL，或獨立 .vhdx 並停用多餘背景服務。  
- Analysis  

| 技術 | 流程 | 人 |
|------|------|----|
|1. vhdx 需二次寫入|1. 系統與開發共用 I/O|1. 認為虛擬碟=靈活|
|2. NTFS Metadata 轉換|2. 無磁碟分層策略|2. 只關注介面規格|
|3. TLC/QLC SLC Cache 易掉速|3. 未量測顆粒影響|3. 省成本買 QLC|
|4. CPU Context Switch 上升|4. 缺背景服務清單|4. 不熟 wsl --shutdown|
|5. Cache Bypass 測試不一致|5. 無固定 benchmark 腳本|5. 迷信「最新最快」|

- Example: 在 Samsung 970 Pro 直接掛 ext4，fio 隨機 4 K 讀寫提升到 780 MB/s（原 Windows NTFS 646 MB/s 的 121%），虛擬 vhdx 僅 650 MB/s。  