## Problem Solving  

Case 1: API 被 AI 誤用，資料遭破壞  
- Problem: GPTs/Agent 呼叫 CRUD 介面，直接改寫關鍵欄位，造成訂單狀態不一致與資料遺失。  
- RootCause: API 沒有狀態機設計與權限邊界，只圖方便支援 UI，一旦 AI 依「常理」操作即踩到例外。  
- Resolution: 依 Domain 建立狀態機，API 採最小原子轉移；精確定義 Scope、Key；以 OpenAPI 與 Error Schema 提升 AI DX。  
- Analysis:  

|層次/面向|技術|流程|人員/文化|  
|---|---|---|---|  
|Why 1|無驗證欄位關聯|缺少設計審查|UI Team 私下加欄位|  
|Why 2|只暴露 CRUD|未做 API First 流程|追求開發速度|  
|Why 3|沒有狀態機|缺少設計規範|未受 API 設計訓練|  
|Why 4|權限粗放|未做 Threat Modeling|覺得內網安全|  
|Why 5|無測試覆蓋|CI 不驗證 Side Effect|測試人力不足|  
- Example: PoC 初版讓 GPTs 直接 PATCH 訂單，AI 將「出貨中」改回「建立中」，後台需人工修復。重構後僅允許 /orders/{id}/ship 轉移，問題消失。  

---  

Case 2: 對話式 UX 難以量化滿意度  
- Problem: 傳統問卷/指標無法即時捕捉顧客情緒，導致個人化推薦效果差。  
- RootCause: 依賴事後統計與誘導性問卷，缺乏對話上下文的細顯訊息。  
- Resolution: 使用 LLM 於交易流程即時抽取情緒與偏好，寫回會員註記與訂單分數，再供推薦引擎使用。  
- Analysis:  

|層次/面向|技術|流程|人員/文化|  
|---|---|---|---|  
|Why 1|無情緒模型|流程只在結帳後發問卷|KPI 只看轉換率|  
|Why 2|資料粒度粗|缺即時管道|習慣量化硬指標|  
|Why 3|存量資料不足|無整合對話記錄|部門牆分割|  
|Why 4|算力限制|RTA 流程未定|AI 懷疑論|  
|Why 5|缺 API 入口|無事件驅動|不清楚用途|  
- Example: 第二段 DEMO 讓 GPTs 自動給出「滿意度=2, 原因=價格誤報」並寫入訂單，後台客服即時補償，客訴率下降。  

---  

Case 3: Copilot 整合成本高，反而拖慢使用者  
- Problem: 全對話替代 UI，導致簡單操作變慢、Token 成本過高。  
- RootCause: 未區分何時該用 LLM，何時用傳統 Controller；界面選擇錯誤。  
- Resolution: 採 MVC+Copilot 架構，Controller 主導精算流程，Copilot 僅在卡關或複雜決策時接手。  
- Analysis:  

|層次/面向|技術|流程|人員/文化|  
|---|---|---|---|  
|Why 1|所有指令走 ChatCompletion|缺 UX 研究|只想炫技|  
|Why 2|高 Token 費|無成本試算|不懂計費模式|  
|Why 3|GPT 回應延遲|無 SLA 監控|對 AI 期望過高|  
|Why 4|缺快取|流程未分層|重複查詢|  
|Why 5|無 fallback UI|沒有 A/B 驗證|不願承認失敗|  
- Example: Console Copilot DEMO 保留指令式菜單，Copilot 只在偵測多次 help 或預算運算時介入，操作時間縮短 40%，Token 花費降 70%。  

---  

Case 4: 知識庫搜尋不準，RAG 仍產生幻覺  
- Problem: 部落格 GPTs 回答引用錯誤段落或無關文章，信任度下降。  
- RootCause: 分段粒度過大、向量維度不足，Ranking 缺失，Prompt 未限制來源。  
- Resolution: 重新切 Chunk（≤2 KB）、改高維 Embedding、加入 MMR 排序與來源 cite，並在 Prompt 要求僅用檢索結果回答。  
- Analysis:  

|層次/面向|技術|流程|人員/文化|  
|---|---|---|---|  
|Why 1|Chunk 過長|無質量驗收|急部署|  
|Why 2|低維度模型|算力省成本|缺 Benchmarks|  
|Why 3|未做 Ranking|Pipeline 缺步驟|趕時程|  
|Why 4|Prompt 沒限制|缺回測|信心幻覺未意識|  
|Why 5|資料更新慢|無 CI 觸發|維運責任不清|  
- Example: 上線首日回答「API First Workshop 日期」誤引 2022 文，改用新 Pipeline 後引文精準、使用者好評上升。  

---  

Case 5: AI 佈署流程未納管，影響發布速度  
- Problem: 模型版本、GPU 配置、人為變更散落手動流程，導致回滾困難與成本失控。  
- RootCause: 現有 GitOps 只管 App/Config/Env，缺 AI Data/Model/Compute pipeline。  
- Resolution: 新增 AI Pipeline：Data→Model→Compute 皆版控與 CI；模型發布採 Canary，GPU/NPU 透過 K8s Operator 彈性調度。  
- Analysis:  

|層次/面向|技術|流程|人員/文化|  
|---|---|---|---|  
|Why 1|模型手動上傳|無自動化|Data Scientist 與 DevOps 斷層|  
|Why 2|GPU 靜態綁定|缺資源排程|以為只有訓練用|  
|Why 3|無版本標籤|沒 ML Registry|只存檔案|  
|Why 4|回滾靠重佈署|缺 Canary 策略|風險低估|  
|Why 5|成本難估|計費資料分散|財務/技術缺共語|  
- Example: 引入 MLflow+ArgoCD，自動化資料清洗與模型推送，平均上線時間由 3 週縮至 2 天，月度 GPU 花費下降 25%。