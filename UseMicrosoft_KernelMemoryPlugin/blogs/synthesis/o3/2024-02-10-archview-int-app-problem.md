## Problem Solving  

Case 1: 結帳流程無法辨識未成年購酒風險  
- Problem: 傳統應用程式只做 rule‑based 檢查，若客戶備註中隱含「小孩生日」，系統仍允許含酒精商品結帳，造成法規與品牌風險。  
- RootCause: 系統缺乏語意理解與常識推理能力。  
- Resolution: 在結帳環節注入 LLM，利用 System Prompt 建立「店長」角色與 FAQ；以 User Prompt 提供購物車內容與備註，讓模型回 OK/HINT。  
- Analysis (3×5 Why)  

| People | Process | Technology |
|---|---|---|
|1. 使用者未主動意識風險|1. 結帳檢查只覆蓋固定欄位|1. 沒有語意解析模組|
|2. 開發者忽略隱含語意|2. SOP 未列常識檢核|2. LLM 未整合|
|3. 架構師沿用舊思維|3. 缺少內容抽取機制|3. 無向量檢索|
|4. 法遵人員未參與設計|4. 測試案例不足|4. Prompt 不存在|
|5. 教育不足，無意回饋|5. 缺持續監控與修正|5. API 與模型沒串接|
- Example: 購物車含 10 歲生日派對 + 生啤酒，LLM 回 `HINT:` 提醒年齡與酒駕限制並要求再次確認。  

---  

Case 2: 使用者操作繁瑣且易誤觸  
- Problem: 需連續輸入多組選單指令才能完成購物，導致誤刪、重複新增。  
- RootCause: UI 缺乏即時語意監測與引導。  
- Resolution: 實作 Copilot 模式，對每一步操作產生「我已進行操作: X」Prompt；LLM 偵測異常回 HINT，其餘回 OK 並靜默。  
- Analysis (3×5 Why)  

| People | Process | Technology |
|---|---|---|
|1. 使用者不熟流程|1. 缺使用歷程回饋|1. 無持續對話|
|2. 客服難以即時支援|2. 沒例外監聽節點|2. 沒有 Streaming 判斷|
|3. 開發者僅設靜態提示|3. 沒統計異常模式|3. Prompt 缺少歷程|
|4. 測試人員覆蓋不足|4. SLA 未要求建議機制|4. 無 Copilot 邏輯|
|5. PM 未量化 UX 成本|5. 無 KPI 監控改善|5. 缺行為日誌|
- Example: 連續五次加入/移除啤酒後，Copilot 自動提示「是否需要協助？」並提醒酒精規定。  

---  

Case 3: 私有知識量大，Prompt 超出 Token 限制  
- Problem: 將全部 FAQ/SOP 塞進 Prompt 導致成本高、回應慢。  
- RootCause: 長期知識與短期對話未分離。  
- Resolution: 採 RAG：知識先做 Embedding 存 Vector DB，查詢時僅檢索相關片段加進 Prompt。  
- Analysis (3×5 Why)  

| People | Process | Technology |
|---|---|---|
|1. 團隊不懂 Token 成本|1. 知識管理碎片化|1. 無向量資料庫|
|2. 架構師未評估頻率|2. 沒有檢索流程|2. 缺 Embedding Model|
|3. 文件撰寫無標準|3. 缺維運知識庫|3. 無 RAG 管線|
|4. 運維無成本監控|4. 部署流程忽視費用|4. Prompt 全量塞入|
|5. 訓練缺迭代改善|5. 缺效能基準|5. API 無批次查詢|
- Example: 購物規定、活動折扣等 3000 行 SOP 嵌入向量庫，查詢童酒案例時只取 5 條相關段落，Prompt 大小由 30K Token 降至 2K。  

---  

Case 4: AI 能理解但不會「動手」  
- Problem: 模型能解讀「幫我把預算剩餘用於綠茶」卻無法對後端系統下指令。  
- RootCause: 缺少可被模型呼叫的結構化技能層。  
- Resolution: 以 Semantic Kernel 將 Domain API 標註為 KernelFunction，外加 Description；模型透過 Function Calling 自動選 API、填參數並執行。  
- Analysis (3×5 Why)  

| People | Process | Technology |
|---|---|---|
|1. 開發者只關注 UI|1. API 未對 LLM 開放|1. 無 Function Schema|
|2. 架構師未定義邊界|2. 缺授權驗證流程|2. 沒有 Plugins Layer|
|3. PM 不懂技能粒度|3. 無錯誤回滾策略|3. LLM 無 JSON 解析|
|4. QA 未驗證參數安全|4. 缺參數校驗|4. 無 Kernel Runtime|
|5. 運維未設監控點|5. 缺審計日誌|5. 無安全 Sandbox|
- Example: 使用者一句話下單，GPT‑4 內部依描述連續呼叫 `AddItemToCart`, `EstimatePrice`, `ShowMyCartItems` 並回報籃內 32 件商品，節省 8 次手動輸入。  

---  

Case 5: 老經驗者對 AI 架構轉型反應遲緩  
- Problem: 資深團隊慣於三層架構與函式呼叫模式，低估 Prompt 與插件的重要性。  
- RootCause: 心智模型停留在「精準程式＝好系統」。  
- Resolution: 以降級 PoC 演練 Semantic Kernel 全流程，從 Chatbot→RAG→Copilot→Autonomous 逐步體感差異，重塑架構觀念。  
- Analysis (3×5 Why)  

| People | Process | Technology |
|---|---|---|
|1. 資深人員路徑依賴|1. 沒有探索時段|1. 不熟 LLM 架構|
|2. 培訓聚焦舊技術|2. 缺 Proof of Concept|2. 工具鏈陌生|
|3. KPI 評估僅看交付|3. 未設創新指標|3. 缺快速實驗環境|
|4. 管理層怕風險|4. 預算僵化|4. 缺 SDK / Framework|
|5. 團隊溝通語言不同|5. 知識搬運成本高|5. 缺範例程式|
- Example: 作者於春節七天實做安德魯小舖四階段，讓整隊高層親眼見到 Console App 迅速升級至全對話，下季度即啟動正式專案。