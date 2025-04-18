## FAQ  

Q1: 為什麼要在既有應用程式內整合 LLM？  
A1: LLM 具備語意理解與推理能力，可彈性處理傳統 rule‑based 難以覆蓋的「常識」與「上下文」。在結帳、風險評估、客服等關鍵環節導入，可即時產生個人化建議或自動完成多步作業，改善體驗並降低人工干預。  

Q2: 文章提出的四階段智慧化路徑是什麼？  
A2: (1) 純傳統操作；(2) 關鍵流程以 LLM 做語意風險提示；(3) Copilot 式側錄操作歷程並即時建議；(4) 透過 Function Calling 讓 LLM 直接呼叫 API，使用者僅需自然語言。此路徑可循序導入 AI，兼顧成熟度與風險。  

Q3: Copilot 式輔助與一般「提示訊息」有何不同？  
A3: Copilot 並非被動彈出說明，而是持續監聽使用者操作，將每步動作摘要成 prompt 送 LLM。模型若偵測異常即回 HINT，否則回 OK 隱身執行，因此用戶無學習成本、流程不中斷，體驗類似 IDE 的 GitHub Copilot。  

Q4: 什麼是 Function Calling？它如何讓 AI 執行指令？  
A4: 開發者以 JSON/Swagger 或 KernelFunction 描述 API 名稱、參數與說明；LLM 收到自然語言後自行比對說明、填參數並要求執行。框架（如 Semantic Kernel）負責安全地呼叫該函式並把結果回傳給模型，形成「理解→執行→回覆」閉環。  

Q5: RAG 與向量資料庫的角色是什麼？  
A5: RAG（Retrieval Augmented Generation）先把問題嵌入為向量，在 Vector DB 找到語意最相近的文件片段，再把片段與原問題一併送入 LLM。如此無須重訓模型即可查私有知識，實現「長期記憶」，同時節省 token 成本。  

Q6: Skill／Plugin 與傳統 API 有何差異？  
A6: Skill 不僅是函式呼叫，更包含人類可閱讀的自然語言說明，使 LLM 能「理解」用途並自動決定何時、以何參數觸發。Skill 強調語義可發現性，過多或描述不清都會降低命中率，因此需精挑細選並反覆調 prompt。  

Q7: Semantic Kernel 提供哪些核心能力？  
A7: SK 抽象化 Model、Memory、Plugins 三大件：可混用多家 LLM；支援多種向量庫做記憶；以 attribute 或 YAML 將本地函式註冊成插件；Planner 可將複雜需求拆解成多步執行流。開發者因而能專注 Prompt 與業務邏輯。  

Q8: 在這種新模式下，開發者的關鍵技術將變成什麼？  
A8: 1) Prompt Engineering：精準控制模型行為、收斂成本；2) Plugin/Skill 設計：定義語義清晰且安全的可調用能力；3) Orchestration：理解模型輸出並整合多步流程；4) 基本 AI 基礎：RAG、Embedding、治理與監控。  

Q9: LLM 的不可預測性與錯誤要怎麼控管？  
A9: 可透過多層檢驗（rule + LLM）、設定信心水準、多模型交叉驗證、人類監督與可回溯日誌降低風險。作者比喻企業雇用新人也會犯錯，只要流程允許糾正並帶來整體效率提升，就值得採用。  

Q10: 想快速體驗文中範例該怎麼做？  
A10: 先閱讀 GitHub 上的 AndrewDemo.NetConf2023 原始碼；在 Azure 申請 OpenAI 並將金鑰填入設定；執行 Console App 觀察四個階段行為；若有 ChatGPT Plus，可點連結試用「安德魯小舖 GPTs」並比較平台與自建框架差異。