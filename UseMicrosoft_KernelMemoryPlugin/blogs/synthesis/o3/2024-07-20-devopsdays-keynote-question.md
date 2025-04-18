## FAQ  

Q1: 什麼是「從 API First 到 AI First」？  
A1: API First 強調先把 Domain 能力封裝成高品質 API，再開發 UI 或整合；AI First 則是在此基礎上，把 LLM 視為主要消費者與協作者。當 LLM 具備意圖推理與工具調用能力，API 不只給人用，也要讓 AI「看得懂、用得對」。因此良好的狀態機、Scope、權限與文件成為「AI DX」關鍵；反之，雜亂 CRUD 介面只會放大 AI 失誤與維運風險。  

Q2: 為何生成式 AI 會改變使用者體驗（UX）？  
A2: LLM 能直接理解自然語言中的意圖並呼叫 API 完成任務，等於用「對話」替代繁瑣流程。例如安德魯小舖 GPTs 讓顧客只說「預算 600 幫我買啤酒」即可自動搜尋、計算、結帳。它降維解決「意圖猜測」問題，較傳統 UI 訪談、A/B 測試更直觀，也能涵蓋小眾需求。  

Q3: 什麼是 AI DX？  
A3: Developer Experience for AI。指 API 規格、文件、錯誤處理、Scope 設計等是否符合「LLM 的常識與推理模式」。若格式命名、權限邊界與狀態轉移清晰，LLM 幾乎零提示就能準確呼叫；若介面混亂，就需大量 prompt 補丁甚至產生風險。  

Q4: Prompt Engineering 核心技巧有哪些？  
A4: (1) 基本模板：以角色、目標、限制條列說明。  
(2) JSON Mode：要求模型輸出結構化資料，程式好解析。  
(3) Function Calling / Tool Use：描述可用 API 與參數，讓 LLM 自選並生成呼叫。  
(4) Workflow：允許模型規劃多步驟計畫，逐步執行並回報。善用這些模式可把語言輸入轉成可靠動作。  

Q5: Copilot 與 Agent 有何差別？  
A5: Copilot 為「副駕駛」：UI 與 Controller 仍主導流程，LLM 只在需要時協助解答或代操；適合模型尚不穩定、成本高的階段。Agent 為「全自動駕駛」：LLM 規劃並執行完整任務，Controller 僅提供精算或受控資源。當模型推理力、成本、治理機制成熟，Copilot 可無縫升級為 Agent。  

Q6: 何時應讓 AI 介入，何時保留傳統演算法？  
A6: 精確、可枚舉的邏輯（計價、庫存、權限）交給程式；模糊、多義或需語境推理（客訴情緒、意圖判斷、文字摘要）交給 LLM。切分原則是「是否需要語言與常識推論」，這也是架構師必須做的關鍵決策。  

Q7: RAG 是什麼，為何重要？  
A7: Retrieval‑Augmented Generation：先用向量搜尋把知識庫相關片段撈出，再連同問題給 LLM 生成答案。可在不改動基礎模型的情況注入私有知識，提高正確率、降低幻覺。常見元件：Embedding、VectorDB、Ranking Model。安德魯部落格 GPTs 即以 RAG 讓 GPT 充當專屬小編。  

Q8: 在 DevOps 流程中，要新增哪些 AI Pipeline？  
A8: 除 App、Config、Env 三條傳統 GitOps 流程外，再加一條 AI 流程：  
• Data Pipeline：收集、清洗、上傳訓練資料。  
• Model Pipeline：訓練或微調後自動版本化、測試、部署。  
• Compute Pipeline：GPU/NPU 資源佈建與彈性調度。三者都需自動化與監控才能安全迭代。  

Q9: 開發者該如何開始練基本功？  
A9: (1) 用狀態機重構現有 API，完善 OpenAPI/Swagger；  
(2) 實際寫一個 GPTs 或 Copilot PoC，練 Prompt 與 Function Calling；  
(3) 架一座小型 RAG（開源 Llama + VectorDB）了解 Embedding；  
(4) 練習把模型佈署納入 CI/CD；  
(5) 持續關注模型成本與治理策略。基礎扎實，未來模型升級才能直接受益。  

Q10: 若擔心被 AI 取代，應聚焦哪裡？  
A10: 重點不在速度而在質量：抽象能力、架構決策、跨域整合、風險治理、人機協作設計。AI 可量產程式碼與接口，但無法取代對業務本質的洞察與系統性思考。投資這些高層次技能，可在 AI 時代維持不可替代性。