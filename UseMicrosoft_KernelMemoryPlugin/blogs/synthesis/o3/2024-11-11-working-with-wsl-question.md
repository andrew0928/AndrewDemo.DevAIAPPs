## FAQ  

Q1: 為什麼作者決定捨棄 Docker Desktop，改用 WSL2 + Docker？  
A1: Docker Desktop 在 Windows 上需要額外授權、佔用資源且 Volume 掛載效能極差；WSL2 本身就是輕量 VM，可直接執行 Linux Docker，省去中介層並避開授權問題，同時能用系統封裝管理多個發行版，對開發者更彈性。

Q2: 為什麼在 Windows 掛載 Volume 的 I/O 會慢到不可用？  
A2: Windows 容器存取 NTFS→WSL ext4 需經 9P 協定與 Hyper‑V 虛擬硬碟轉譯；WSL 容器存取 /mnt/c 需經 DrvFS。多層轉譯造成隨機 4 KB 讀寫僅剩原生 NTFS 的 3–7%，作者實測 Qdrant 啟動時間從 1.5 秒暴增到 38 秒。

Q3: 提升容器 I/O 的最佳做法是什麼？  
A3: 1) 把 Volume 放在 WSL 根檔系統 (ext4) 或專用 SSD ext4 分割區；2) 使用 mklink 把該目錄對映回 Windows，以保留檔案總管與 VS Code 操作方便；3) 若需求更高，直接將實體 SSD 掛載給 WSL，可獲得與 Windows 原生相當甚至更好的效能。

Q4: 如何在 WSL 下同時使用 Windows 工具與 Linux 環境？  
A4: WSL 透過 binfmt_misc 註冊「WSLInterop」，可在 bash 直接呼叫 *.exe（例如 explorer.exe）；VS Code Remote‑WSL 則自動安裝 vscode‑server，將 UI 留在 Windows、背景作業留在 Linux，實現無縫跨系統工作流。

Q5: VS Code Remote‑WSL 帶來哪些具體好處？  
A5: ‑ 檔案、終端、除錯全在 Linux 執行，不受 DrvFS 限制；  
‑ CTRL‑O/按鍵操作皆針對 Linux 路徑；  
‑ Container、Git、Build 速度與原生一致；  
‑ 透過 Port Forward 即時預覽 Jekyll 等服務；  
‑ 本機關網也能離線開發，不需額外 SSH。

Q6: 如何讓 Docker 容器在 WSL 使用 GPU/CUDA？  
A6: (1) Windows 安裝新版 NVIDIA Driver (WDDM 2.9+)。  
(2) WSL distro 安裝 nvidia‑container‑toolkit。  
(3) 在 /etc/docker/daemon.json 指定 "default‑runtime":"nvidia"，執行 docker run 時加 --gpus=all。完成後容器內可用 nvidia‑smi，作者成功跑 Ollama + Open‑WebUI。

Q7: WSL GPU 虛擬化的原理是什麼？  
A7: Host Driver 啟動 GPU Paravirtualization，Guest 透過 /dev/dxg 介面與 dxgkrnl 通訊，DxCore 轉譯 DirectX、DirectML、CUDA、OpenCL 調用。對應函式庫已由 Microsoft 與 NVIDIA 重新編譯並內建於 WSL，故無需在 Linux 端裝專用 GPU Driver。

Q8: 專用 SSD 掛載到 WSL 時，實體 vs. 虛擬磁碟效能差多少？  
A8: 若顆粒為 MLC/TLC、高負載情境下實體 ext4 可達 Windows NTFS 120%，虛擬 .vhdx 約 100%；QLC SSD 在虛擬化情境掉到 60% 左右。結論：用好顆粒 SSD＋直接 ext4 最穩妥，虛擬化則視硬體與 CPU 富裕度決定。

Q9: DrvFS 還能用來做什麼？  
A9: 由於效能受限（~35 MB/s），DrvFS 建議只做「檔案搬運」或零星編輯，如在 Windows Explorer 檢視 WSL 檔案、交付成果給 Windows 程式；大量 I/O（資料庫、編譯、docker volume）應避免。

Q10: 建置此環境需要哪些最小硬體與軟體條件？  
A10: Windows 11 (22H2+)、支援虛擬化的 CPU、至少一顆 NVMe SSD；若需 GPU 運算，需 NVIDIA RTX 20 系列以上 + 最新官方 Driver。軟體則安裝 WSL2、Ubuntu 22.04/24.04、Docker Engine、VS Code 及 Remote Development 擴充套件，選配 nvidia‑container‑toolkit。

Q11: 用戶遷移到 WSL + VS Code 工作流最常見的陷阱？  
A11: 1) Docker Volume 仍放 /mnt/c；2) 在 WSL 安裝 Linux 版 GPU Driver 與 Host Driver 衝突；3) 忘記在 Windows 防火牆放行 VS Code Server Port；4) VS Code 未安裝 Remote‑WSL 擴充導致 code . 無作用；5) 拿 DrvFS 作熱資料庫或大型編譯。

Q12: 若想讓 Linux GUI 應用在 Windows 顯示，應如何設定？  
A12: WSLg 已內建 Wayland/X11 + RDP 協定，Windows 11 開啟 WSLg 預覽版即可。只要在 WSL 執行 gedit、Firefox 等 GUI 程式，Windows 會自動彈出視窗並支援 Alt‑Tab、剪貼簿與 Hi‑DPI。