## 段落1, 寫在前面  
作者回顧自己長年寫部落格的經驗與痛點：累積 20 年、400 萬字內容雖具價值，卻因篇幅龐大難以搜尋與消化；藉由 GPTs 與 RAG，他期望讓讀者可用自然語言快速取用文章知識，完成本篇研究動機鋪陳。

## 段落2, GPTs Demo 總覽  
透過自製「安德魯的部落格 GPTs」，作者展示使用者對談如何被 GPTs 轉為檢索請求，再結合自建 API 取回文章摘要、條列及連結，高效回答技術問題，示範 RAG 帶來的應用體驗。

## 段落3, 示範：整理部落格發展史  
以「幫我回顧部落格系統演變」為例，GPTs 能自動搜尋並生成含摘要與超連結的 15 篇相關文章列表，證實 AI 可處理跨年份、無統一標籤的資訊彙整。

## 段落4, 示範：主題彙整  
詢問微服務 API 與報表議題，GPTs 先給原則與摘要，再追問補充連結；過程顯示 RAG 檢索精準且不亂編，亦突顯需透過 prompt 微調才能一次取得完整回覆。

## 段落5, 示範：經驗分享彙整  
針對「家用 NAS 適合部署哪些服務」提問，GPTs 提供建議與文章對應；再加條件（Web 開發者場景）亦能更新答案，佐證向量搜尋配合上下文可細緻化解答。

## 段落6, 部落格檢索服務架構  
PoC 採三層：前端 GPTs 負責對談與彙整；中層自建 Kernel Memory Service 提供 /search API 做向量檢索；底層離線 Ingestion 程序負責 chunk、embedding 與索引。

## 段落7, Synthesis：RAG 回應流程  
Synthesis 階段將 Query 與檢索結果合併，透過 GPT‑4 生成自然語言答案。作者示範 GPTs 如何依 Swagger 定義自動決定參數與呼叫時機，再將 JSON 結果寫入回答。

## 段落8, Retrieval：向量搜尋概念  
Retrieval 步驟含 Query 向量化、相似度計算、Top‑K 過濾及原文回傳。核心是 embedding 空間內比較 cosine 距離；API 只需 query 與條件即可回傳相關段落串列。

## 段落9, Text Embedding 基礎  
說明 embedding 將語意映射到多維空間，圖解兩維範例；向量越近表示語意越相似。使用 OpenAI text‑embedding‑3‑large（3072 維），並解析 token 成本計算。

## 段落10, Retrieval 實作流程  
展示 /search 請求與回應 JSON；解析如何以 minRelevance、limit 與自訂 filters 控制結果，並比較轉向 /ask API 讓 Kernel Memory 直接完成 Synthesis 的替代方案。

## 段落11, Start Coding 範例  
透過 C# Serverless 模式呼叫 MemoryServerless.Search/Ask；列出 prompt 範本、實際 GPT‑4 回覆及 cost 分析，說明開發者可用 ChatGPT 做 playground 先驗證 prompt。

## 段落12, Ingestion：索引建立  
詳述 chunking、embedding、indexing 三步；展示匯入單篇文章後產生的 46 個 JSON chunk 與 3072 維向量；說明選用 SimpleVectorDB 免外部服務、便於 CI/CD 發佈。

## 段落13, Tags 與安全過濾  
解釋 Kernel Memory TagCollection 結構與 ABAC 應用；示範 user‑tags、categories 等標籤及 AND/OR 過濾語法，可實現 record‑level 權限與主題篩選。

## 段落14, AI 改變搜尋方式  
指出 embedding + vector search 讓「用嘴巴找資料」成真；展示 Spotify 個人化推薦與電商 two‑tower 模型案例，說明語意索引已成主流，資料與應用模式將翻轉。

## 段落15, RDB：表格為主  
回顧傳統關聯式 DB 以 table/SQL 為核心，強調 storage 效率與精確結構，但 schema 正規化導致開發端需頻繁 join，與語意檢索距離遠。

## 段落16, NoSQL：文件為主  
NoSQL 以 entity/json 對應程式物件，減少 join、提升分散式彈性；查詢多採投影＋串流過濾 pipeline，更貼近業務模型，但仍缺語意層理解。

## 段落17, VectorDB：向量索引  
VectorDB 儲存語意向量成為 AI 世界索引，結合 NoSQL 可同時保存狀態與語意；查詢僅需比對向量相似度，語意搜尋標準化，開發門檻大幅降低。

## 段落18, 資料庫世代改變  
RDB→NoSQL→VectorDB 是資料操作層級躍升：欄位→物件→語意。開發者需掌握 embedding、向量、LLM，才能在新世代做正確技術組合。

## 段落19, 從條件到語意查詢  
SQL 專屬語言→NoSQL 串流→Vector 檢索＋LLM 濃縮；真正困難已轉向選對模型與成本控管，查詢介面則可回歸自然語言或 prompt，貼近使用者習慣。

## 段落20, App vs Agent 與成本考量  
探討選擇 GPTs、獨立 UI 或本地 LLM 的差異：對談上下文、誰負擔 token 費用、個人化資料掌握等；預測未來 Copilot/Siri 等 Agent 將主導使用者入口。

## 段落21, 結論  
AI 時代基本功已升級為 Prompt、Function Calling、Embedding、Vector Search；架構師不應與 AI 競爭，而應善用其成為強大武器，做出正確技術決策與系統設計，文章三篇即為作者自我精進與經驗分享。