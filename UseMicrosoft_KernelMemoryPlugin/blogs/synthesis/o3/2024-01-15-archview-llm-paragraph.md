## 段落1, 1. 安德魯小舖 GPTs ‑ Demo
作者用 GPTs + 自建線上商店 API 做 PoC，展示 LLM 可藉 OpenAPI 描述自行決定何時呼叫端點，完成「列出商品→依預算組合折扣→加購→結帳→查詢訂單」完整流程。過程中 GPTs 能摘要商品資料、推敲第二件六折規則、理解口語同義詞，並自動重算訂單；也能取回多張訂單後自行統計商品數量、以 Markdown 表格輸出。技術門檻在於「整合思維」而非寫程式：需提供乾淨的 REST＋OAuth、良好 Swagger、清楚 Prompt。若 API 設計不合理（如驗證流程凌亂），LLM 會誤判或頻繁失敗；當作者補上標準 OAuth 與一致的資源路徑後，GPTs 立刻穩定。PoC 證明：1) LLM 能把缺漏的 BL 邏輯「腦補」出來，介面設計須更語意化；2) API 是 AI 與傳統系統唯一橋梁，其可讀性與正規性決定體驗；3) 過往 UI／Chatbot 難以達成的「理解意圖」與「資訊重組」可交給 GPTs 完成。

## 段落2, 2. 軟體開發的改變
傳統 UX 著重「簡化操作」，仍要求使用者知道指令；LLM 則直接理解意圖、生成行動，形成降維打擊。未來架構將以 LLM 為「Orchestrator」：所有輸入（語音、文字、影像）先轉為自然語言，由 LLM 決定呼叫哪支 API、怎麼組參數，並整理回傳。結果：1) UI 角色減輕，Copilot 式對話將滲透應用；2) API First 不再面向人類開發者，而是面向 AI，需要高度一致性、可推理的命名與狀態機；3) 系統會圍繞 AI 打造，中控是語言模型，傳統 MVC 正被 Semantic Kernel 類型的「LLM + Plugins + Memory」框架替代。不能被 AI 理解或易出錯的 API 終將被淘汰。

## 段落3, 3. 看懂 Microsoft 的 AI 技術布局
Microsoft 以「Azure OpenAI Service（模型）＋Copilot（入口）＋Semantic Kernel（SDK）」三箭齊發。模型端：持 GPT4 先機，可雲端推理也可 Edge 微型化，預示 AI PC 與 Windows 12 將內建 NPU 與系統級 LLM。入口端：Copilot 成 OS 層總控，統合本地 App、雲端功能與搜尋。框架端：Semantic Kernel 提供 Orchestration、Memory、Planner、Connector 等抽象，讓開發者用 Plugins 擴充 LLM 技能，未來會向 OS（註冊行為）與雲端 PaaS（分散式 workflow）延伸。對應層級：SDK→OS→PaaS→SaaS，Microsoft 已完成首尾布局，中段規格將陸續落位。開發者若提早熟悉 SK、LangChain 等生態，日後可無縫升級至 AI Native 架構。

## 段落4, 4. 架構師／資深人員的應對
1) 釐清「計算 vs. 意圖」邊界：精準必須寫死在程式；模糊決策交給 LLM。2) API 設計要 AI Friendly：符合業務語意、嚴謹狀態機、標準 OAuth、完善描述，否則花大量 Prompt 仍難解。3) UI 以 Task 拆分並暴露給 Copilot；繁瑣驗證與流程應封裝為獨立端點。4) 精通 Semantic Kernel 架構，規劃 Kernel‑Skill‑Memory‑Planner 分層，把現有系統逐步模組化為 Plugins。架構師需推動團隊重構與測試，確保服務可被 AI 拉起來：從 Swagger、RAG 知識庫到觀測／費用控管，都要制定標準。

## 段落5, 5. 開發者的技能升級
短期：善用 GitHub Copilot、ChatGPT 等工具提升產能，但須理解生成碼意圖避免「看不懂就套用」。中期：掌握 Prompt 編寫、RAG 與向量 DB、OAuth 與 OpenAPI、自動測試；熟練 Semantic Kernel 或 LangChain，在專案內累積 Plugins、Planner。長期：深化 DDD／API First／事件導向等基礎，因為核心 Domain 服務將成為 AI Orchestration 的唯一支點；會寫 UI 不再稀缺，能設計「可推理 API」與「可觀測流程」才具競爭力。最終目標：把重複樣板交給 AI、把判斷和工藝留給自己。

## 段落6, 6. 結論
AI 變革已至，工具層先行、架構層翻轉在即。作者因聽 .NET Conf 演講而茅塞頓開，實作 PoC 後確信：LLM+API 可立刻創造新形態服務，未來系統必須 AI Ready。建議：現階段盡量投資 AI 生產力工具；同步重構 API、流程與知識庫，為 Copilot 介入鋪路；持續關注 OS／PaaS 級 AI Framework 的進展。唯有擁抱改變、主動累積新資產，才能在 AI 世代保持價值，不被取代。