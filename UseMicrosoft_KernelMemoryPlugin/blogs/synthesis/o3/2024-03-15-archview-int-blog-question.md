## FAQ  

Q1: 什麼是 RAG？  
A1: RAG（Retrieval‑Augmented Generation）是在 LLM 生成答案前，先對外部知識庫做資料檢索（Retrieval），再把 Query 與檢索結果送回 LLM 進行彙整（Synthesis）的流程。它不需微調模型即可將專域知識引入回答，三步驟為 Ingestion（文件切段、Embedding、索引）、Retrieval（向量比對＋條件過濾）、Synthesis（LLM 生成回應）。

Q2: 為什麼作者要替部落格導入 RAG？  
A2: 作者累積 20 年、400 萬字文章，傳統關鍵字搜尋難以精準找出相對應內容。RAG 讓使用者只需自然語言提問，系統就能用語意向量比對定位相關段落，並由 GPT‑4 自動產生摘要與連結，提高知識重用與閱讀效率。

Q3: GPTs 在整體架構中扮演什麼角色？  
A3: GPTs 提供對談介面、上下文維護與 Function Calling。使用者問題先進入 GPTs，依 Swagger 描述自動決定是否呼叫作者自建的 /search API；取得檢索結果後再由 GPT‑4 生成最終答覆。

Q4: Kernel Memory 的功能？  
A4: 這是 Microsoft 開源 RAG 套件，可 Serverless 嵌入程式或部署為 Web 服務。主要職責：文件切 Chunk、使用選定 Embedding Model 產生向量、儲存到向量資料庫（SimpleVectorDB/AI Search/Qdrant…），並提供 /search 與 /ask API 供外部查詢。

Q5: 什麼是 Embedding？  
A5: Embedding 把一段文字映射到多維度向量空間，每個維度代表隱含語意特徵。向量越近表示語意越相似。作者選用 OpenAI text‑embedding‑3‑large（3072 維），計費以 token 數量計；每 100 萬 token 約 0.13 美元。

Q6: Retrieval 階段如何運作？  
A6: 先將 Query 文字用同一 Embedding Model 向量化，再在向量資料庫計算 Cosine Similarity，取 Top‑K 結果；之後可再用 Tag Filter 做 AND/OR 條件過濾，降低權限或主題不符的段落。

Q7: Ingestion 要注意哪些重點？  
A7: (1) Chunking：不得超過模型 Max Token；可重疊或摘要化減少斷句錯誤。  
(2) Tagging：匯入時加上 user‑tags、categories、post‑date… 方便之後授權與篩選。  
(3) 選擇向量儲存：小型 PoC 可用 SimpleVectorDB；正式環境可選 Azure AI Search、Qdrant 等。

Q8: RAG 成本如何估算？  
A8: 主要兩段：Embedding（一次性，建索引）與 Synthesis（每次回答）。範例問題向量化僅 30 token ≈ 0.000004 美元；但把 30 段檢索結果送 GPT‑4 需約 15k token，花 0.15 美元。若用 GPTs，這部分轉嫁給 ChatGPT Plus 用戶；若自建 /ask，費用由服務端承擔。

Q9: Tag/Filter 可以解決什麼安全議題？  
A9: 透過 ABAC 思維將 Document 打上 UserID 或區域等標籤，檢索時自動加上對應 Filter，即可實現 Record‑level 權限控制，而不必依賴向量資料庫本身的權限機制。

Q10: 為何作者採 SimpleVectorDB？  
A10: 部落格僅 300 多篇、2 千餘 chunk，資料量小且 Read‑Only。SimpleVectorDB 用純檔案儲存，易與 Git + CI/CD 整合部署至 Azure App Service，免外部 DB 成本。

Q11: RAG 對傳統資料庫與查詢語言的衝擊？  
A11: 由 RDB（表格/SQL）→ NoSQL（文件/串流）→ VectorDB（向量/語意）。透過向量索引，查詢重點不再是寫複雜 SQL，而是選擇合適 Embedding Model 與控制 Token 成本，並用自然語言或 prompt 取得結果。

Q12: 架構師應從此案例學到什麼？  
A12: 未來基礎能力需包含 Prompt Engineering、Function Calling、Embedding、Vector Search。重點是組合對的元件而非與 AI 競爭；專注設計權限、成本與體驗，讓 AI 成為系統智慧化的槓桿。