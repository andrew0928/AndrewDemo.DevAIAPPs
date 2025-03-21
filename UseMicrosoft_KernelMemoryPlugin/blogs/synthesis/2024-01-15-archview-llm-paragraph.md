## 段落1, 安德魯小舖 GPTs - Demo
本段作者透過 Azure App Service、Swagger 等工具，實作出自己的線上商店 API，並結合 OpenAI 的 GPTs 功能，嘗試打造可用自然語言進行完整購物流程的對話式體驗。示範中，GPTs 能解讀使用者口語化需求，並自動轉為 API 呼叫，如取得商品清單、折扣計算、結帳流程與訂單查詢等。整個過程技術門檻不高，但挑戰在於「整合應用」：如何善用 LL​M 的推理能力，在不違背 API 邏輯下，協助使用者完成各式購物需求。作者也透過多次呼叫與對談測試，展現 GPTs 可以「腦補」解決傳統 Chat Bot 難以達成的使用者意圖解析與多步驟操作。同時示範 API First 與標準化設計的重要性，讓店長（GPTs）得以自主正確呼叫 API，顯示未來軟體或後端服務必須更注重 AI 友善的結構。

---

## 段落2, 軟體開發的改變
在 AI 與大型語言模型（LLM）發展下，作者認為以往需要人手精準操作的電腦指令，如今可由 LLM 直接「理解」使用者意圖並執行任務。傳統 UX 主要透過介面設計簡化操作；而 LLM 則能摘取使用者隱含的需求，主動提出最佳解，顛覆使用者與軟體互動的模式。真正的改變在於 LL​M 不僅可回應文字，還能解析多元上下文並呼叫後端 API，等於扮演「中控」角色，在收納指令後決定執行順序與方法。未來所有應用都可能圍繞 AI 做設計，從自然語言到 API 呼叫，將成為主流的軟體運作邏輯。API 也要因應這轉變，而被要求更一致且明確，才能被 AI 有效運用。

---

## 段落3, 看懂 Microsoft 的 AI 技術布局
Microsoft 投資 OpenAI，率先取得 GPT-4 等先進模型支援，同時推出一系列 AI 服務與工具，如 Azure OpenAI Service、Copilot 與 Semantic Kernel，形成自雲端到用戶端的完整生態。作者解釋 Copilot 不僅是一個開發輔助，而會演進成作業系統層級的「主入口」，可管理各應用並理解使用者需求；搭配 LLM 運算，透過作業系統一體化，讓 AI 成為核心的控制中心。Semantic Kernel 則提供開發框架，使應用程式能真正掛載 LLM，並藉由 Plugins、Memory、Planner 等機制實作對話、檔案讀取或呼叫外部服務。作者也預測未來 OS 將與 AI 深度整合，硬體端會有更強力運算或 NPU 支援，並且搭配雲端大規模模型，讓使用者在單機也能透過 AI 得到即時回應，逐步形塑「AI PC」與「AI OS」的新時代。

---

## 段落4, 架構師、資深人員該怎麼看待 AI ?
作者指出，資深人員與架構師應該從 API、流程與領域邏輯的角度重新審視服務架構。由於 LLM 呼叫 API 的模式，開發團隊無法預測 AI 會如何運用這些介面，意味著 API 設計需更精準、強韌及符合領域模型，以免出現錯誤或邏輯混亂。同時必須區分哪些任務宜透過「計算」精確處理，哪些宜交給 LLM 靈活理解。例如交易或數值運算具高正確度需求，就不該全交給 LLM；而意圖猜測與動態決策則可交給 AI 輔助。架構師也需懂得選用對應的開發框架，如 Azure 或 Semantic Kernel，並思考如何在未來將更多功能置於 AI 中樞，同時保障關鍵域領域的穩定性。

---

## 段落5, 開發人員該怎麼看待 AI ?
面對 AI 逐漸滲透所有軟體領域，作者建議開發者先從工具著手，善用 GitHub Copilot、ChatGPT 等協助撰寫程式或文件，提升日常工作效率；同時亦不可忽視基礎功，應於理解程式脈絡的前提下運用 AI 輔助，而非盲目貼上建議程式碼。此外，因應未來軟體後端可能全面走向 API First，開發者宜加強領域驅動設計（DDD）、向量資料庫，以及熟悉 Prompt Engineering 和 Semantic Kernel 等技術，養成能開發「AI Friendly」之服務的能力。這將確保當軟體架構師將關鍵流程交由 AI 管理時，具備足夠技能在後端與資料層完成精準、高品質的系統設計與實作。

---

## 段落6, 結論
作者回顧自己從 2016 年撰寫開發觀點，一路觀察到 AI 技術新浪潮，認為 2023 年後，LLM 가능已帶來非同小可的改革契機。從實際 PoC 經驗看來，LLM + API 不僅可以取代傳統 Chat Bot，還引領新一波應用模式：以對話或自然語言為核心，進行複雜多步驟的操控與推理。未來幾年，作業系統、開發框架與使用者體驗都將因 AI 成熟而洗牌。作者呼籲開發者與團隊領導者務必開始思考 AI 如何重組軟體定位，並透過累積業界經驗與基礎設計能力，使自身技術走向更具競爭力的 AI 生態。AI 雖難以一步到位地取代人，但會顛覆底層架構，從而改寫程式與技術現狀，值得所有人提早準備並積極投入。