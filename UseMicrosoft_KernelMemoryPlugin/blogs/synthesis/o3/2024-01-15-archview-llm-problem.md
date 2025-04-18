## Problem Solving  

Case 1: API 被 LLM 誤用，對話流程頻頻失敗  
- Problem: GPTs 無法穩定呼叫購物 API，常出現參數缺漏、順序錯亂，導致流程卡關或回傳錯誤。  
- RootCause: API 端點命名不一致、缺乏嚴謹狀態機與標準驗證描述，LLM 難以「望文生義」推理正確用法。  
- Resolution: 重新依業務語意設計 REST 介面、補上 OAuth2 與 Swagger 描述，並用 Prompt 說明每支 API 目的。  
- Analysis (3×5 Why)  

| Why層級 | 技術面 | 流程面 | 管理面 |
|---|---|---|---|
| 1 | LLM 傳錯參數 | 對話流程中斷 | 無 API 設計規範 |
| 2 | 端點語意含混 | 沒定義狀態遷移 | 缺 API Review |
| 3 | 缺 OpenAPI 範例 | 驗證步驟混雜邏輯 | 專案趕時程 |
| 4 | 無錯誤碼對應 | 需求反覆變動 | 缺 AI 友善指引 |
| 5 | 無一致資源模型 | 沒有測試腳本 | 未指派架構負責 |
- Example: 作者初版 API 無 OAuth 與一致名稱，GPTs 屢次掛單；改為 `/api/carts/{id}/estimate`、OAuth Flow 後，一次通過。  

---

Case 2: 把精確折扣計算交給 LLM，結果不穩定  
- Problem: 要在 NT$1000 內買均衡飲料並套用「啤酒第二件六折」，GPTs 有時給出非最省方案。  
- RootCause: 折扣邏輯屬「計算型任務」，LLM 使用隨機推理，無法保證最優。  
- Resolution: 把折扣規則寫成後端 `POST /cart/optimize`，LLM 僅決定要不要呼叫此端點。  
- Analysis  

| Why層級 | 技術面 | 流程面 | 管理面 |
|---|---|---|---|
| 1 | 回傳價格偏差 | 使用者抱怨 | 無 SLA 定義 |
| 2 | GPT4 有隨機性 | 欠缺演算法 API | 視 AI 為萬能 |
| 3 | 缺動態規劃程式 | LLM 無歷史數據 | 未設 KPI |
| 4 | Token 成本限制 | 缺驗算機制 | 無審核流程 |
| 5 | 未區分精算需求 | 誤把意圖交 AI | 缺角色分工 |
- Example: 作者新增 `optimize-cart` API 後，GPTs 先呼叫該端點取得最省明細，再回復使用者，零誤差。  

---

Case 3: 自訂驗證機制導致授權難整合  
- Problem: GPTs 需先登入才能下單，但自製 Login/Token 無標準流程，Prompt 填寫帳密仍頻繁失敗。  
- RootCause: Flow 不符 OAuth2，也缺 refresh／scope 說明，LLM 無法自己串流程。  
- Resolution: 改用 OAuth2 Authorization Code + PKCE，並在 Swagger 加入 `securitySchemes`。  
- Analysis  

| Why層級 | 技術面 | 流程面 | 管理面 |
|---|---|---|---|
| 1 | Token 不被接受 | LLM 重複嘗試 | 安全規範缺失 |
| 2 | Header 欄位混用 | 無標準授權步驟 | 專案技術債 |
| 3 | 缺 scope 描述 | 缺失效提醒 | 無資安審查 |
| 4 | 無 RFC 依據 | 文件不完整 | 缺 DevSecOps |
| 5 | 研發自行加料 | 設計未評審 | 缺資安角色 |
- Example: 作者用一天實作 OAuth2，重新註冊 Action，GPTs 首次對談即成功登入並下單。  

---

Case 4: 團隊生產力無法提升，擔憂被 AI 取代  
- Problem: 開發者手動查文件、重複樣板工作多，產出慢，且對 AI 攻勢不安。  
- RootCause: 未導入 Copilot/ChatGPT、缺 Prompt 掌握，錯把 AI 視為威脅非助力。  
- Resolution: 全員開通 GitHub Copilot、設週期性 Prompt Workshop，並檢討生成碼後 commit。  
- Analysis  

| Why層級 | 技術面 | 流程面 | 管理面 |
|---|---|---|---|
| 1 | 重寫樣板 | 工時過長 | 無工具預算 |
| 2 | 不會 Prompt | 卡在 StackOverflow | 缺培訓計畫 |
| 3 | 生成碼看不懂 | 缺 Code Review | 心理排斥變革 |
| 4 | 測試覆蓋低 | 缺用例指導 | 無績效量化 |
| 5 | 知識斷層 | 舊流程僵化 | 領導未示範 |
- Example: 導入 Copilot 後，CRUD 範本由 AI 生成，人員專注核心 API；兩週後 PR 量增 25%、缺陷率下降。  

---

Case 5: 系統難以擴充為 AI‑Ready，因缺統一框架  
- Problem: 各模組自行串 GPT API，無記憶共享、成本失控，導致維運混亂。  
- RootCause: 沒採用 Orchestration 框架，Kernel、Memory、Plugin 概念不清。  
- Resolution: 全線轉移至 Microsoft Semantic Kernel；統一對接模型、向量庫，並將功能拆成 Plugins。  
- Analysis  

| Why層級 | 技術面 | 流程面 | 管理面 |
|---|---|---|---|
| 1 | 重複請求模型 | Token 花費爆 | 缺治理策略 |
| 2 | 沒全域 Memory | UX 不連貫 | 各模組各做 |
| 3 | 無觀測指標 | Debug 困難 | 缺平台團隊 |
| 4 | 插件接口不統一 | 整合耗時 | 沒路線圖 |
| 5 | 先上先贏思維 | 缺標準架構 | 投入點零散 |
- Example: 整併至 SK 後，LLM 使用率下降 30%，共用記憶庫讓客服與結帳場景可互相調用上下文，使用者體驗大幅提升。