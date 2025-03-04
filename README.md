# AndrewDemo.DevAIAPPs

�o�O�ڤ��Цb�A���A�Ȥ��ϥ� AI (API) �Ϊk�������d�ҡC
�b APP ���ϥ� AI ���X�ر`���� design pattern, �o�̧ڷ|���дX�ر`�����Ϊk�A�]�t:

1. ������: chat completion
1. ���c�ƿ�X: json mode
1. �I�s�~���{��: tool use / function calling
1. ��X����: RAG

�o�����ήרҡA���F�����I��B�@���覡�A�ڤ��O�ΤF�T�ؤ��P���ϥΤ覡:


**Project**: UseOpenAI_SDK  

1. ������ http request �I�s [openai chatcompletion api](https://platform.openai.com/docs/api-reference/chat)
1. �ϥ� [openai .net sdk](https://github.com/openai/openai-dotnet)

**Project**: UseMicrosoft_SemanticKernel  

1. �ϥ� [microsoft semantic kernel](https://github.com/microsoft/semantic-kernel/)

**Project**: UseMicrosoft_KernelMemoryPlugin  

RAG ���i������, �]�t [microsoft kernel memory](https://github.com/microsoft/kernel-memory) ���ѵ� semantic kernel �ϥΪ� memory plugin, �ڿW�ߤ@�ӱM�רӥܽd
�ڤ]���ѤF�@�ӹ�ӲաA�� plugins �өI�s [Bing Web Search API](https://learn.microsoft.com/en-us/bing/search-apis/bing-web-search/overview)







# ���ҳ]�m Setup - User Secrets

�o���d�ҡA�ڳ��ϥ� OpenAI API ��@ LLM provider. ������ APIKEY �Цۦ�]�w user secret.
�H�U�O�ݭn�]�w������:

�T�� project(s) �ڥΪ� user secret �W�ٳ������@��, �A�i�H�@�ΦP�@�� user secret �S���D�C
�H�U�O�ڽd�ҷ|�Ψ쪺���c:

```json

{
  "OpenAI:ApiKey": "sk-XXXXXXXXXXXXX",
  "OpenAI:OrgId": "org-XXXXXXXXXXXXX",
  "KernelMemory:ApiKey": "XXXXXXXXXXXXXXX",
  "BingSearch:ApiKey": "XXXXXXXXXXXXXX"
}

```

���Ӷ��ǻ���:

**OpenAI:ApiKey**:  
�s�� openai api �ϥ�. �|�Ψ� 4o, 4o-mini, o1 �o�T�Ӽҫ��C  

- [X] Project: UseOpenAI_SDK
- [X] Project: UseMicrosoft_SemanticKernel
- [X] Project: UseMicrosoft_KernelMemoryPlugin

**OpenAI:OrgId**:  
Optional, �޲z�γ~�A�s�� OpenAI �A�ȮɡA�Х� OrgID�A�i�Ψӫ��Ӥ��P orgid ���� quota�C  

- [ ] Project: UseOpenAI_SDK
- [ ] Project: UseMicrosoft_SemanticKernel
- [ ] Project: UseMicrosoft_KernelMemoryPlugin

**KernelMemory:ApiKey**:  
�s���A�ۤv�[�] Microsoft Kernel Memory �ɻݭn�ϥΪ� APIKEY  
- [ ] Project: UseOpenAI_SDK
- [ ] Project: UseMicrosoft_SemanticKernel
- [X] Project: UseMicrosoft_KernelMemoryPlugin


**BingSearch:ApiKey**:  
�s�� Bing Search Service �ϥΪ� APIKEY�C  
�Y�n���� Example02, �Х��� Azure �ӽ� Bing Search Service APIKEY.  

- [ ] Project: UseOpenAI_SDK
- [ ] Project: UseMicrosoft_SemanticKernel
- [X] Project: UseMicrosoft_KernelMemoryPlugin
	- [X] Example02: RAG with Search Plugins


# �A�Ȭ[�]: Microsoft Kernel Memory

�u�n��ӨB�J�A�A�N�i�H�[�]�ۤv�� Microsoft Kernel Memory �A�ȡC
(1), ���� [�x�誺����](https://github.com/microsoft/kernel-memory/tree/main?tab=readme-ov-file#kernel-memory-docker-image), ���� setup, �ݵ��L�{�������쪺�]�w��T, ���|�s�b appsettings.json�C�� docker run �N�i�H�ҰʪA��
(2), �ѩ��٭n�f�t qdrant �V�q��Ʈw, �]���ڦۤv�ˤF�@�� docker-compose.yaml, ��K�̦��ظm��M����, ���ݭn���B�ͥi�H�ĥΧڪ��i�H�]�C

���˦b WSL2 ���ҤU����, �o�˥i�H�קK�@�����ҳ]�w�����D�C���L�o�ӽd�ҷ|�Ψ�V�q��Ʈw qdrant, �קK��� WSL2 �� IO �į���D���a�p (IO �į�t�Z�� 20x ����), �аѦҧڪ��峹�����㻡��:

* [�� WSL + VSCode ���s���y Linux �}�o����](https://columns.chicken-house.net/2024/11/11/working-with-wsl/)