## Problem Solving  

Case 1: 部落格內容龐大，讀者難以快速取得所需資訊  
- Problem: 20 年、400 萬字的文章無法用傳統目錄或關鍵字有效檢索，讀者常因資訊碎片化而放棄。  
- RootCause: 關鍵字比對無法捕捉語意；全文閱讀成本高；作者持續新增文章使問題擴大。  
- Resolution: 以 RAG 架構（Kernel Memory + GPT‑4）建立「安德魯的部落格 GPTs」，讓使用者以自然語言對談檢索並取得摘要與連結。  
- Analysis (3×5 Why)  

| 面向\Why | 第1層 | 第2層 | 第3層 | 第4層 | 第5層 |
|---|---|---|---|---|---|
| 技術 | 關鍵字依賴字面匹配 | 無語意模型 | 無向量索引 | 缺乏 embedding pipeline | 研究門檻高 |  
| 成本 | 文章持續成長 | 人力整理耗時 | 無自動化工具 | 手動維護不具規模經濟 | → |  
| 體驗 | 讀者找不到答案 | 閱讀負擔大 | 缺乏摘要 | 放棄使用 | 影響部落格價值 |  
- Example: Demo 中以「微服務資料一致性」問題，GPTs 回傳方法原則與文章連結，大幅優於 Google 搜尋零散結果。  

---  

Case 2: 傳統搜尋不精準，需語意檢索  
- Problem: 關鍵字或 SQL like 查詢無法處理同義詞、上下文與長句需求。  
- RootCause: 缺乏多維語意向量；資料庫僅支援字面比對；缺向量資料庫。  
- Resolution: 使用 OpenAI text‑embedding‑3‑large 將段落轉 3072 維向量，存 SimpleVectorDB，檢索時用 Cosine Similarity 取 Top‑K。  
- Analysis  

| 面向 | Why1 | Why2 | Why3 | Why4 | Why5 |
| 技術 | 無 embedding | 無模型選型 | 未切 chunk | 超過 token 限制 | → |
| 成本 | 自建模型昂貴 | 雲服務價格未知 | 開發時間長 | → | → |
| 精確度 | 同音異義混淆 | 無上下文 | → | → | → |
- Example: 「Home NAS 服務」查詢，GPTs 正確抓出多篇家用網路與容器文章，而非僅憑關鍵字列 NAS 廠商廣告。  

---  

Case 3: 建置 RAG 的工程複雜度高  
- Problem: 必須同時處理 Chunking、Embedding、Indexing、API 整合與 LLM 回應。  
- RootCause: 缺少一站式框架；開發者需手寫大量 Glue code。  
- Resolution: 採 Microsoft Kernel Memory；Serverless 匯入程式負責 Ingestion，Service 模式提供 /search、/ask API；GPTs 透過 Swagger Function Calling 直接調用。  
- Analysis  

| 面向 | Why1 | Why2 | Why3 | Why4 | Why5 |
| 技術 | 無現成 SDK | 開發者需理解 RAG | 需串兩種模型 | API 安全性 | → |
| 效率 | 手寫程式重複 | 部署流程繁雜 | CI/CD 未整合 | → | → |
| 可靠度 | 多服務相依 | 測試困難 | → | → | → |
- Example: 90 行 C# 匯入程式將 markdown 批次轉向量並寫入 memories；部署至 Azure App Service 即成線上檢索服務。  

---  

Case 4: LLM 推論成本過高，誰來付錢？  
- Problem: 每次 /ask 需將數千 token 傳 GPT‑4，單次成本可達 0.15 USD。  
- RootCause: Top‑K 段落過多；GPT‑4 價格高；服務端吸收費用導致商業不可行。  
- Resolution: 將 Synthesis 交由 GPTs 平台，費用由訂閱用戶負擔；服務端僅負責向量檢索（低 token 成本）。  
- Analysis  

| 面向 | Why1 | Why2 | Why3 | Why4 | Why5 |
| 成本 | GPT‑4 單價高 | Token 數量大 | 上下文冗長 | → | → |
| 業務 | 免費使用者多 | 收費難推動 | → | → | → |
| 技術 | 缺節流機制 | 未做 Top‑K 最佳化 | → | → | → |
- Example: 相同問題在 ChatGPT Plus 端執行，由用戶的 40/3hr 額度消耗；作者端僅產生 30 token 檢索費用約 0.000004 USD。  

---  

Case 5: 向量資料庫缺原生權限控管  
- Problem: Vector DB 無 record‑level ACL，機敏文件可能被未授權查詢命中。  
- RootCause: 服務專注 ANN 演算法，未考量安全。  
- Resolution: 於 Ingestion 階段加 Tag (user‑id / domain 等)；查詢時必帶 Filter 實現 ABAC。  
- Analysis  

| 面向 | Why1 | Why2 | Why3 | Why4 | Why5 |
| 安全 | DB 不支援 ACL | 需應用層處理 | Tag 設計缺失 | → | → |
| 成本 | 加密/分庫複雜 | → | → | → | → |
| 法規 | 敏感資料外洩風險 | → | → | → | → |
- Example: 給定 filters: `[{"user-tags":["架構師觀點"]}]` 即只返回授權分類文章，其他段落不會進入 GPT‑4 回覆上下文。  

---  

Case 6: Function Calling 整合門檻  
- Problem: 若 API Schema 不合標準，GPTs 可能無法正確組裝呼叫。  
- RootCause: Swagger 描述不完整或未加說明文字，導致語意判定失敗。  
- Resolution: 依 OpenAPI 3.0 撰寫 /search description，註明 query/minRelevance/limit 意義；GPTs 即能自動填參數並生成答案。  
- Analysis  

| 面向 | Why1 | Why2 | Why3 | Why4 | Why5 |
| 技術 | 缺 Swagger | GPTs 無映射 | 參數命名含糊 | → | → |
| 體驗 | 使用者需手動重試 | → | → | → | → |
| 維運 | API 版本變動 | 未同步檔 | → | → | → |
- Example: GPTs 依說明把口語「微服務資料一致性作法」轉成 `{"query":"微服務 資料一致性 維持作法","limit":5}` 並成功呼叫 Kernel Memory。