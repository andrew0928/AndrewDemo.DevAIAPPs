## FAQ  
Q1: LLM 與傳統軟體最大差異是什麼？  
A1: 傳統程式須明確指令才能執行；LLM 能解析自然語言與上下文，推斷「意圖」後自行規劃 API 呼叫與資料整理，讓「操作」退居次位、對話成為主介面。這種「意圖驅動」顛覆了 UI／UX、流程設計與開發分工。  

Q2: 為何作者用 GPTs 做線上商店 PoC？  
A2: GPTs 允許在 ChatGPT 基底上給角色、知識庫與 OpenAPI Action。作者可零新模型訓練，僅靠 Swagger 與 Prompt，就測試 LLM 能否取代店員、理解折扣規則並完成購物流程，快速驗證 AI 對系統整合的衝擊。  

Q3: PoC 得到哪些關鍵結論？  
A3: 1) LLM 可「腦補」BL 缺口，搭配簡單 API 即能完成複雜任務。2) API 若命名不一致或驗證混亂，LLM 失準率高；調回標準 OAuth 與語意化路徑後即穩定。3) 整合門檻在思維而非技術，核心是 AI‑Friendly API 與清晰 Prompt。  

Q4: AI‑Friendly API 設計要點？  
A4: (1) 對應真實業務語意，命名一看即懂；(2) 狀態機有限且可驗證，避免隱性特殊流程；(3) 使用標準認證如 OAuth2、API Key；(4) 完整 OpenAPI 描述與範例；(5) 以最小但不可或缺的核心功能為主，讓 LLM 自行組裝高階邏輯。  

Q5: 為何說 Copilot 將成主要介面？  
A5: Copilot 結合 OS 內建 LLM、搜尋與本地／雲端 API，可依語音、文字需求自動挑選資源執行。當使用者習慣「對話→結果」模式，傳統多層選單與表單將被精簡，Copilot 成為統一入口，UI 僅承載特殊互動。  

Q6: Semantic Kernel 在開發中的角色？  
A6: 它提供 Kernel（Orchestrator）、Skill/Plugin（API 封裝）、Planner（任務拆解）、Memory（上下文）、Connector（模型對接）等抽象，讓開發者可插拔外部服務並保留 LLM 推理優勢，形塑 AI‑Native 應用的 MVC。  

Q7: 架構師應如何劃分「計算」與「意圖」？  
A7: 高精度、低延遲、可驗證的邏輯（交易、結帳）仍以傳統程式實現；開放式決策、組合、摘要可交給 LLM。先梳理業務流程，再決定哪些步驟轉成 Plugin 供 LLM 調度，哪些維持嚴格 API，避免「全丟 AI」或「完全不用 AI」。  

Q8: 開發者必修技能清單？  
A8: 1) Prompt 編寫與調優；2) OpenAPI 與 Swagger；3) OAuth2、JWT；4) 向量資料庫與 RAG；5) Semantic Kernel/LangChain 基礎；6) 測試與觀測 AI 流程；7) 持續深化 DDD/事件驅動，產出高質量核心服務。  

Q9: 使用 AI 工具時要注意什麼？  
A9: Copilot 生成的程式碼需理解再採用，避免安全與效能隱患；Prompt 中勿洩漏機密；控管 Token 與推理成本；對關鍵邏輯仍撰寫單元測試；監控 LLM 回應偏差並設回退機制。  

Q10: Microsoft 的三層布局如何互補？  
A10: Azure OpenAI Service 提供雲端與 Edge 模型算力；Copilot 擔任 OS 及工作流程入口；Semantic Kernel 則是把模型、記憶與外部 API 編排起來的 SDK。三者串聯，形成從雲到端的完整 AI 生態。  

Q11: AI 會取代程式設計師嗎？  
A11: 低價值、模板式開發將被自動化；真正懂業務、能設計 AI‑Friendly API、編排 LLM 工作流、確保安全與可靠性的工程師需求只會增加。重點是升級職能，扮演 AI 的設計者與導入者，而非單純碼農。  

Q12: 現在就該採取的第一步？  
A12: 1) 立即試用 ChatGPT、GitHub Copilot 等工具，體會 AI 提升生產力；2) 為現有服務補齊 OpenAPI 與一致命名；3) 選一個小流程，以 GPTs 或 Semantic Kernel 做 PoC；4) 在團隊內分享學到的設計準則，循序推動系統 AI‑Ready。