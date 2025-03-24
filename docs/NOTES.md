# Microsoft Kernel Memory & Semantic Kernel ����X����




# Day 1, LLM - Structured Output

Link: [²��](https://www.facebook.com/share/p/1DcJTse4C6/)

![alt text](image.png)


�o�O�ڦb .NET Conf 2024 ���䤤�@�i²��, ���ѷQ��@�U�o�D..

>
> Developer ���ӫ�˵��� AI?
>

�O�~�|�F�A�ڨS���n�� GitHub Copilot / Cursor �g code ���h�F�`, ���Ӥj�a������F, �ڨ����èS������F�`, �ϥ��� AI ���U coding ���N���i�f�F, �δN��F�C�ڭn�ͪ��O, �p�G�� LLM ��@�A���i�ήM��άO�A�Ȥ��@, �A�|������Φb�A�� Application? �� LLM �b�U��}�o�H����W, �U��A���D�A��W���Z�����h�j���¤O��?
�o��²���A�ͪ��O���i�� LLM ( �ڮ� GPT4o-mini ����� )�A�}�l�����䴩 Json Schema. �Ϥ����Ҥl�O�n�q�@�q���, �^���X��ܤ����Ϊ����a tea shop ���T�� address .. �p�G�o�O�O�H�ݧڪ����D�A�ڲĤ@�ɶ����Ϯg�ʧ@�@�w�O:

>
> ChatGPT, �i�D�ڤU�C��ܴ��Ϊ��a�}...
> (�K�W��ܤ��e)
>

�p�G���٦���L���C���K���n�D�A�ڤ@�w�@�_�ᵹ ChatGPT ���ڳB�z�A�Ҧp��X���񪺴��I�A�άO�h�i�D�ڨ��Ӧa�I��������T�����C���O ( �N�O�o�� BUT )�A�p�G�o�\��O�n�I�b�A�Y�� application ���O? �p�G�A���X�ʸU�ճo�˪���ܡA�A���n��X�a�}��T�O?
�Ϯg���^��: ���N call chat-completion api �N�n�F��...
���L�A�A�O Developer, �A���i�H�Q�o��h�@�I�C�ڸյۦh�C�X�ӫ���D:

1. 1. �A�n LLM �Τ���榡�^���A?
2. �p�G�� 1% �����v LLM �^�����X�ӡA�A�{������P�_?
3. �A�ٸ��� LLM �B�z���C���K���n�D��? �q�q�g�b prompt �� AI �@���������n? �٬O���o�a�}��ۤv�� google map api �B�z����n?

1. �}�o���ε{���N�O�o�ˡA�̾a�}�o�ζ����g��A��B�z�L�{�g�����ε{���A�ϥΪ̴N�௸�b�A���ӻH�W���ΦA��@���a�p�C�p�G�A���A�Ȩϥζq���j�A�A���@���������M�w�i��v�T�ۥ��j���Ĳv����..
�o�~�O���� Developer ��¾�d�A�]�O���� Developer ���u�աC�o�@�ɦ���h�o�طs���A�Ȼݭn�}�o�A�n�� AI �Ӷ}�o AI �����ε{���A�{���q�]�٨S����e���A�o�|�O Developer �j�㨭�⪺�a��C�^��o�D�ӬݡA�A�|�o�{�A���`�b ChatGPT �U�� prompt, �������o�A�X��������{�����ϥΡC
������ˤ~�O Developer ���@�k?
�W�������D�A�ڪ����׬O:

1. �� Json output  
�̦n�ٯ�w�q Json Schema, ���쵲�G��ߨ� deserialize �� C# object, �H�Q�������D AI ���{���X��L�_������B�z�C
2. �����b output �N "���T" �Щ����浲�G���\�Υ���  
(�N�� HTTP status code �@��)�A���n�βq���A��A�n�A�� LLM �]�n�C���T���� AI ��X��_�P�w���� (��X�a�})�A��_�A�ۤv parsing ��A��X exception �u�����h�CLLM ����ı�򤣽T�w�ʤw�g���h�F�A���ݭn�h�p�@��..
3. ��@¾�d�A�u�� LLM �B�z�D�L���i�����ȴN�n�C  
��l���ȡA�u�n�� json �ǥX���n��T�A�ε{���X�ӳB�z�N���F�C�����դ@�I�A�j�M�A�榡�ഫ�A�ƭȭp�ⵥ���A�o�ǳ��O code �ӳB�z�����j�L LLM �����C�A���ݭn���F�֥����X�� code (���i�H AI coding �F)�A���G�쥻�X�ʭ� CPU instructions ��B�z�������Ʊ��A�ܦ��C������O�X�ʭ� tokens �~��B�z... �A���D�@�� Azure Function Call ���O�ΡA��@�� ChatCompletion API Call ���O�ήt�h�ֶ�? �O�ѤF�p���M�w�|�Q��j 100 �U��....
�ҥH�A�^��o�i²���A�A���D����A�ӤF�� LLM �� Json Mode �F��? ��ڪ� code �ڴN���K�F�A�o�O�ڦb 03/25 �������e�b�q�|���Ϊ� AI APPs �}�o�򥻧ޥ������e XDD�A�]���ڥ�����N���L�A�ڤ~�����j�a�R������ڭn�ͪ��D��: Microsoft Kernel Memory �� ...

��ѡA�o�Ӯר� (�٥]�t���U�ӧڨC�ѷ|�K�@�h�ר�)�A�ڷ|�� OpenAI �� ChatCompletion API ���¦�A�ڷ|����:
- �� Http Client �ܽd
- �� OpenAI .NET SDK �ܽd
- �� Microsoft Semantic Kernel �ܽd

�Τ��P�覡�g�o�q code... ��꦳�ܤj���t�O�CSDK �̩ۨm�����ˡA��a�Ӫ��K�Q�A�A�n���o�������t�O�C�O�H���u�O call API �N�����A�p�G�A�ݨ�A call api �n�ۤv�g json schema, �ӥ� semantic kernel ���ɭԥu�ݭn�� C# type, �A���Q�k�N�|���ܤF...

## Demo

1. Simple Chat
- HTTP Client
- OpenAI .NET SDK
- Microsoft Semantic Kernel

2. Structured Output
- HTTP Client
- OpenAI .NET SDK
- Microsoft Semantic Kernel




# Day 2, LLM - Function Calling (Basic)

Link: [²��](https://www.facebook.com/share/p/1BozfZzzov/)

![alt text](image-1.png)

�Q�Ѳ᧹ Json Mode, �����~��Ӳ�� Function Calling... �P�ˬO�ڦb .NET Conf 2024 ��²��...
Function Calling (�κ٬� Tool Use), ��ı�o�o�O LLM ���ΥH��, �¤O�̤j���\��F�C�N�]�� LLM ���F�o��O�A�~�}�ҤF�U�� Agent �H�γz�L AI �ӥD���U�Ӷg��t�Ϊ���O�C�Ҧ��Q�n�b�A�� App ������ LLM �� Developer, �аȥ��n�d�M�� Function Calling �O���^��, �o�ڻ{���O�U�ӥ@�N�̭��n����¦���ѤF�C
�ڥ����Ѱʧ@�A���ѥu��򥻰ʧ@�A���ѦA�ӽͳs��ʧ@...�C�Q�Ѳ�� Json Mode, ��A�� LLM ���D�A���w LLM �n�ΧA���Ѫ� Json Schema ��X Json Object, �o��O���O�}�ҤF LLM �� code ���� (�� json) ��ƥ洫���q�T��¦�F�C�� Function Calling, �h�}�ҤF LLM �� code ��������ƩI�s ( ���O Function Calling ) ���q�T��¦�C�O�@�U�̪񤣪��D�b������ MCP, ���N�u�O Function Calling ������Ƴq�T��w�C
Function Calling �O�b��ܶ}�l���e, �w���i�� LLM �A������ "Function" �i�H�ϥ�? �M��b��͹L�{���A�� LLM �ۤv�M�w�L�n�i�D User ���G ( Text ), �άO�L�n��������O ( Function ) �ìݬݵ��G��A�M�w ( �~�������O Function , �άO���������G Text ) ?
����²�ƹL���򥻫��A�N�p�o��²���A�@�}�l�� system prompt, �ڧi�D LLM:

```text

Based on the following conversation, manage the shopping list, 
write your response in JSON using the following format:

[
  { "action": "add", "item": string,  "quantity": string },
  { "action": "delete", "item": string }
]

```

�i�������ǰʧ@ ( action + parameters ) �i�H�ΨӺ��@�ʪ��M���A���۴N�O���L�ݨD:

```text

Mmm, remember to buy some butter and a pair of zucchinis. 
But I already bought bread.

```

���z��O���n�� LLM �N�����Ū�o�q��ܪ��N�ϡC���D�o�q��ܭn�����A�O�o�R���o�A����ͥ� (�ڤ��Ѥ~���D�o�r���N�� XDDD)�A�ѥ]�ڤw�g���F���ΦA�R�C
�̾a�j�j�����z��O�A��e��� (���o�̤]�]�t�F�Q�Ѥ��� Json Mode ����O)�ALLM �w�g��N�o�q��ܪ��N�ϡA�ΧA���L�����O����F�X�ӡC�Y�ص{�סA�w�g�O�۵M�y����A���L�����O�����sĶ���F�C�o�ǹ�ܡA�A�K�b�X�ӥD�y�� LLM ����o��@�˪�����:


```json

[
  { "action": "add", "item": "butter", "quantity": "1" },
  { "action": "add", "item": "zucchinis", "quantity": "2" },
  { "action": "delete", "item": "bread" },
]

```

�򥻤W�o�ˤw�g�����@�j�b�F, ���w�g�� Json �i�D�A���U�ӸӨ̧ǰ��樺�ǫ��O�F, �ѤU���u�n�g�@�q code, �̧ǯu������o�ǫ��O�N��u���������ȤF�C
�o�N�O Function Calling ���򥻭�z, ��M������Τ��ݭn�o��g��, API / Framework �h�ų������K�ϥΪ��Ҧ�, ���L LLM �ܤƧֳt, �ڰ��׫�ĳ�j�a�٬O�n�d���o��z�C�Y�Ǳ��p�U (�Ҧp�A�P�ɭn call �e�ݸ��ݪ� function)�A�A�S��k�Τ��ت�����ӹB�@�A�άO�A�n�B�z�󰪼h�Ū� Planning ��, �A���|�ݭn�ۤv��ʤU�o�˪� Prompt..
�^�� Function Calling, ����o�̬���, �A�u�����F "Call", �٨S���� "Return" ... �󧹾㪺���ήרҡA�گd����ѲĤT��²���A�Ӳ�~


## Demo

1. Extract Address
- HTTP Client
- Microsoft Semantic Kernel



# Day 3, LLM - Function Calling (Case Study)

Link: [²��](https://www.facebook.com/share/p/12GFiqp8MnL/)

![alt text](image-2.png)


�Q�ѽͧ� Function Calling ���򥻫��A, ���ѨӬݬݹ�ڤW�i�H���X�������������Χa~
²�檺���A���z��O���n�� LLM, �w�g����k�q:

1. �i�Ϊ����O�W��
2. �A���N��

�������ͲŦX (1) �� (2) ���ﵥ "���O���涶��" ..., �p�Q�ѩһ�, �o�O�N��r�ԭz���N��, ½Ķ�����O�����涶�Ǫ��sĶ���F�C�o�b�L�h���a AI �O���������쪺�Ʊ��A�ڤ~�|���Ҧ� AI ���_�����ΡA�j�b���O�q Function Calling ����O�ֿn�ӨӪ��C

���L�A�Q�ѥu�ͤF�@�b�A��Ķ�X "���O���涶��(�t�Ѽ�)"�A�u�� "Calling" �ڡAFunction ���ӬO�� Return ���G���A�ӥB�������ӭn�����Ǭۨ����Y�� (�A�n���槹 Func1, ���쵲�G��~�M�w������ Func2 ..)

��O�A�Ӭݬݳo��²�� (�P�ˬO�Ӧ� .NET Conf 2024 �ڨ�����²��) �a�C�o���ҬO:

User: find a 30 min slot for a run tomorrow morning
(���ڧ���� 30min ����, �ڭn�C�])
���ٲ������L�{�A�ڴ��� AI �����ڳB�z�n�Ҧ��Ʊ� ( ���ӭn�D Booking ��ƾ� )�A�åB�^�Чڳo�q�T��:

AI: Morning run scheduled for tomorrow at 9am !
(�w�g���z�w���n���� 9:00 �C�])

�o���_�����G�A�O���a Function Calling ��쪺? �ڴN�C�X�i���W & �i���U����͹L�{�A�A�j���N��z�ѳo���ƪ����s�h�ߤF�C

1. system: tools: [ "check_schedules", "add_event" ]
1. user: find a 30 min slot for a run tomorrow morning  
�e�X�o�q���{��, �Ĥ@�� AI �|�^��:
1. tool: [ check_schedule( 03/21 06:00, 03/21 12:00 )]  
����o�q�^����, �N�� AI �ݭn�s�� check_schedule �o�u��, �åB���L�ɶ��d��, ���� (03/21) �� 06:00 ~ 12:00...  
��A�����ε{��, �N�� AI ���槹�o�q���O, �åB�^�е��G ( append ��ܬ��� )
1. tool-result: [ "07:00-08:00, �_�ɴ���", "08:00-09:00, �Y���\", "10:00~12:00, ��P�Ƶ��T�|ĳ" ]  
�e�X��, AI �o�쵲�G�A�P�w��ҫ�A�|�A���e�X�o�^��:
1. tool: [ add_event( 03/21 09:00 - 09:30 )]  
�P�W�����L�{�AAI ��F�L�ݭn�ϥ� add_event �o�u��C�A�����ε{�����Ӵ��L����åB�� AI ���浲�G:
1. tool-result: [ "success" ]  
�A���e�X���G�� AI�A�̫� AI �P�w���ȧ����A�N�J��W�����L�{�A�̫᪽���^���o�T��:
1. assistant: morning run scheduled for tomorrow at 9am!

�H�W�N�O���㪺��ܹL�{�C�o��d�N�A�ڼХܪ� (1) ~ (7), �O chat history ���Ǹ��򤺮e�C�C���I�s AI Chat Completion�A���O�� history ��U����Ҧ����e (�q 0 �}�l) ���e�X�h�C

- system �N�� system prompt, �̰��u���v, �I���]�w��
- user �h�N��ϥΪ̪�����J���T��
- assistant �h�N�� AI �n�^�����ϥΪ̪��T��

�䤤 tool �N�� AI �^���� APP ���T��, �ݭn APP �i���U���L����o���O�A�� tool-result �h�O APP �����b�i���U�^�� AI ���浲�G����دS�� message. �C���I�s AI Chat Completion, AI �N����ھڥثe���e��尵�X�U�@�B���M�w�A���짹�����Ȭ���C


�O�_�ܯ��_? ��ӳo�@�s�ꤣ�i��ĳ���ʧ@�A����ѤU�Ӥ]�ܴ��q�A�N�u���O�Q�Ѥ��Ъ��򥻫��A function calling, �H�Ϋe�Ѥ��Ъ� structure output ���զX���ΦӤw�C��ڤW�����p�O�A�A�n�g�o�����ε{�����Ψ��򨯭W�A��ڤ@�ˤg���o��ӹL�{... �o�L�{�D�n�O��s�ΡA��A�d�M����A���ܦh������ framework �i�H���A²�Ƴo�@�s�ꪺ�ʧ@�C

�o�����ڴN�����˪����ϥ� Http, �]�����˪����� OpenAI SDK �F, �]���A�{���X�n�B�z���Ӹ`�Ӧh, �A�i�H������ܦ������ج[ ( �Ҧp: Semantic Kernel )�A������ No Code ���x ( �Ҧp: n8n, dify )�A�άO������ LLM Client + MCP server ( �Ҧp: Claude Desktop, Cursor ... ), ��곣�O�b���P�˪��Ʊ��C

�s��T�ѡA�ݨ�o��A�O�_���Ѷ}�@�Ǻð�? �O�_�Q�q�F AI �o�ǯ��_����O�O���Q�гy�X�Ӫ�? �o�T�����A�ڱ`�`���٥L�� AI �ɥN���}�o��¦�ޥ��A�������n�ʤ��ȩ��~�ڭ�}�l�Ǽg�{���ɡA�ѤW�浹�ڪ��򥻬y�{����ޥ� ( �Ҧp: If, For Loop ���� )�C�ڱj�P��ĳ�Ҧ��� Developer, ���ӧ�o�����Τ覡��@��¦��O, �T�ꪺ�x���M����A�ӾǦU�خج[�άO�ֳt�}�o���ޯ�C

## Demo

1. Schedle Event Assistant
- HTTP Client
- Microsoft Semantic Kernel



# Day 4, LLM - RAG with Function Calling

Link: [²��](https://www.facebook.com/share/p/16HVPbinAY/)

![alt text](image-3.png)



���� Json Mode, Function Calling ����, ���Ѫ��D�D�O: RAG
�P�˺I�F�i�ڦb .NET Conf 2024 ���@��²��, RAG ( �˯��W�j�ͦ�, Retrieval Augmented Generation ), ���N�O���˯����޳N, �� LLM �̾ڳo���˯������G�ӥͦ����e (�^��) ���ϥΪ̪��ޥ��C�Y�S�� RAG, LLM �h�|�ΥL�Q�V�m�o���Ǫ��ѨӦ^���C�o�Ǩӷ��q�`�|���X�Ӥ�H�W���ɶ��t�A�ӥB�|�]���V�m���e�����P�Ӧ��Ұ��t...
�o��ڧ� RAG ������q�ӬݡA�@�ӬO RAG �������B�z�y�{�A�t�@�ӬO�p��Ĳ�o RAG ���B�@����C�B�z�y�{���ä����� (�����O���ձШ��� & ���N)�A�����X�ӨB�J:
1. ������ "���D"�A��o�ഫ���˯����e������άd��
2. �˯��X�������e (�@��Ө����O��V�q��Ʈw�A���O�D���n�A�A�n������˯��t�ΡA�άO�j�M�������]�i�H)
3. �N�W�z�o�Ǹ�T�զX�� prompt, �� LLM �̾ڧA���Ѫ����e (2), �f�t (1) �����D�A�� LLM ���A�J��ͦ��̫᪺����
���o�N�O RAG ���򥻬y�{�F�C���L�ڨ�N�� RAG �\�b Function Calling, ���o�N�O Function Calling ���@�����ΰ�..
�յ۬ݤ@�U�o�q system prompt:


```
�A�����ȬO��U�ϥΪ̡A�N���L�� xxxxxx �˯���ơA�åB�̾ڳo���˯������G�Ӧ^���ϥΪ̪����D�C�^�����D�ɽЪ��W�˯����ӷ����}�A�åB�ФŦ^���˯����e�S�����Ϊ����e
```

�p�G�A�S�ܭ�n���A�����L�o�� "tools" ���w�q����.. ( �^�Q�e���� Function Calling �ר� )�A���� LLM �N�|�۰ʱN�A���ݪ����D�A��Ū���n�� "�˯�" �A�M��A�^�����e�C�ӳo��ӹL�{�A���N�O�a Function Calling Ĳ�o���C
�ܩ�n���j�M����������P�Ѽ� ( �Ҧp query, limit, tags �����L�o���� )�A���N�O�a Json Mode, �N�I�s�o Function �ݭn���U�ذѼơA�q�e������X�� ( �ٰO�o�� Json Mode ��, �q��ܤ�����榡�ƪ��a�}��T�o�Ҥl��? )�C�o�Ǹ�T���ƻ��ALLM �N���H�ɫ��ܧA�� AI APPs, �Ӵ� AI �h�I�s�j�M�����F ( ���O��Ѽ� LLM �����A�ǳƦn�F )
�p���@�ӡA�A����ͤ��e�A��M�N�n���@�ܡA�q�쥻�u��^�� LLM ���U���ӴN�����@�ɸ�T���~�A�L�ϩ��}�l���o�ϥ� Google �F�@��A��A�ݤF�L�����D�A�άO�L�P�_���ӥh DB �˯����ɭԡA�L�N�|�۰ʩI�s�j�M�����A�åB�ۤv�ͦ����n���d�߰ѼơA��쵲�G����Ƨl���A�A�ܦ����צ^�е��A�C�Pı�ܼ��x��? �S���A�o�N�O Search GPT �o���\�઺�u�@��z�A����������A�A�]����O�ۤv��@�@�˪��\��A�åB�i�H�� Search ����H�����ۤv�����Ѯw�C
�ݨ�o��A�p�G�A���x Function Calling ���ϥΧޥ��A�n���X Search GPT ���O���ө��|���Ʊ��C03/25 �ڦ��ǳƤ@�ӽd�ҵ{���A�ڥ� BingSearch ( �H�a���{���� API + SDK, �ڬ��F��K demo �N���ӥΤF ) ��@ Plugins ���W Semantic Kernel, �P�ɤ]���W�F�X�Ө�L�� Plugins ( �Ҧp�^���ڲ{�b�b���̡A�{�b���Ѯ��T�� )�A�A�N�i�H�o�˰ݥL:
"�аݧڲ{�b�o�䦳���ǭȱo�}�}�����I? �H�δ����ڥX���e���ӷǳƭ��ǪF��"
���z��O���n�� LLM�A�N�|�o�����R���B�ΥL��W�Ҧ����u��A�|���h�d�A�b���� (�ڥu�^���� City)�A�|�d�A��a�{�b�Ѯ�A�M��ھڦa�I�h�j�M�������T�A�åB�����A�n���n�a�ʡA�άO��~�M���C
�A�|�o�{�A��̫�A�u�n��ܤ@�Ӱ��i�a���˯��A�ȴN���F (�A���@�w�n�q�s�}�l�A�ۤv�ΦV�q��Ʈw�C�C���y)�A�u�n�L����Q�� Semantic Kernel �� Plugins, �N��Q LLM �ǤJ�L���u��c���A�ݭn���H�ɨ��ΤF�C�����˯��A�ȳ̦X�A? �ھQ��Q����[�A�D���ש��{���F�A�N�O Microsoft Kernel Memory ... , ���ѴN�Ӳ�o�ӪA�ȯ�F�� ?


## Demo

(Semantic Kernel ONLY)

1. RAG Basic ( custom prompt )
1. RAG with Bing Search







# Day 5, RAG as a Service, Microsoft Kernel Memory

Link: [²��](https://www.facebook.com/share/p/162CgFvQs8/)

![alt text](image-4.png)

![alt text](image-5.png)

�Q�F�|�Ѫ���, �Ĥ��Ѳש�Ө쥿�D, ���ѴN�����Ӳ�� Microsoft Kernel Memory �o�� open source project �a~
Microsoft Kernel Memory ( �H�U²�� MSKM ), �I�᪺�}�o�ζ��� Semantic Kernel ( �H�U²�� SK ) �O�P�@�ӹζ��A�]�����X�Ӧa��, �O .NET �H���i�H���ݪ��C�����[�c�]�p�W�槽���j�A�i�H��V�X�R�췥�j���W�ҡA�]�i�H�p�칳 SQLite ���ˤ��O�b�A�����ε{�����C�ӳn��\�઺�X�R�ʤ]�ܴΡA���F���U�� AI service ���s�������~�A���פJ MSKM �� pipeline, �A�]�i�H�����ۭq�ۤv�� handler, �N�ۤv���޿褺�ئb MSKM ��..
�o���ںI�F�⭶²���A���O�N��F MSKM ��������Τ覡�C�Ĥ@�ӬO as web service, �A�i�H�z�L http api �Ӧs�� MSKM, �άO�A�]�i�H�� serverless ���Ҧ�, �������M MSKM �֤߾�������O�b�A�����Τ� (���O�]�� localhost �A�� http api �����k��)�A�򥻤W�w�g�U�Ψ�U�سW�Ҹ����Ϊ��覡�F�C
�^�� MSKM �o�M�ץ����A�L�n�ѨM�����`�A�D�n�N�O AI APP �̴Ƥ⪺ " long term memory " ���޲z���D�C�b SK ���A�u���O�ЬO�� Chat History �ӳB�z���A�Ӫ����O�Хu�O�w�q�F Memory ( Vector Store ) �ӳB�z�C���L�A�J�ӬݥL�������A�A�|�o�{ Memory ��������O��H�ƪ��V�q��Ʈw�A���I�� EF (Entity Framework) �������p����Ʈw�AVector Store �N�O���A�w�q�A�� Vector Store ���c�A��K�A CRUD�A�åB�����w�q�n�ۦ����˯��� interface ..
���O�p�G�A�z�� RAG ( �ר�O document ingestion ) ��˶פJ��󤺮e���ܡA�A�|�o�{�A�q���e����r�ơA���e�����q�A�X���A�K���ҡA�V�q�ơA�g�J�A�d��... �o�@�j�q���y�{�ASK Memory �u�B�z�F�̫�@�p�q�Ӥw
�ҥH�AMSKM �o�M�״N�]���o�ˡA�Q�W�ߥX�ӤF�C�ѩ�A�n���j�q��r���B�z�A�q�`�]�ܦY�A�����ɶ����ȳB�z������O�_���� (�j���N�����������ȳB�z���������D)�A�]���P�乳�O SK ���˥� Framework ���覡�o��AMSKM �h��ܥΤF "�W�ߪA��" + SDK ���覡�ӵo��C�A�i�H������ source code ( �q github clone ) �ӨϥΡA�A�]�i�H�����q docker hub �� image �^�Ӫ������p ( ���μg code )�A�b�I�s�ݧA�i�H�����ΥL�� NuGet Package ... ���O���F�o�ӥت��ӳ]�p��
�ӳQ���W�ߪA�ȨӬݫݡA�� MSKM �� SK �N��O�P�@�ӹζ��}�o���A�n���]�S������S�O�����p... �o�˷Q�A�N���F�A�ڦb�o��S�O����Ӧa��A�S�O�A�X��̷f�t�ϥΪ�����:
1. MSKM ���ؤ䴩 SK �� Memory Plugin
MSKM �w�g�b�L�� NuGet package ���ǳƦn SK �ϥΪ� Memory Plugins �F�A�A�i�H�����N�L���W SK Plugins ���ϥΪ��C�@�����W�h����A���A�N����� AI �l�[�F�@�կઽ���ާ@ MSKM �� tools �F�C�e����쪺 Function Calling, �A�i�H�Q�� MSKM �䴩���\��]����Q AI �P�_�P�I�s�ϥΤF
2. MSKM �����]�P�ˬO�� SK �}�o���ASK �䴩���U�� connector �A�����ξ�ߡA���i�H�b MSKM �W�����ϥΡC�Ҧp LLM / Embedding �� AI �A�� ( openai, azure openai, ollama, claude ... ���� ) �q�q���䴩
�o�@���o�˲զX�_�ӡA��ı�o�O�ثe .NET ���̦������զX�F�AMSKM ���A�X���ض}�c�Y�ΡA�ݭn�t�M�� UI ��޲z�u�㪺�׺ݪA�ȡA�o��A�X���O���}�o�H���ϥΪ��W�ߪA�ȡC�J�M��H�O Developer, �������ư�¦�� AI APP �}�o���ѬO���n���C�o�]�O����ڷ|���w�� #1 ~ #4, ��F�ǽg�T�����Ыe������¦���ѡA�]���A�x���F�o�ǡA�~��R����| MSKM �]�p���맮���B
--
�P�ˤS�Ө츭�t�ɶ� XDD
�o�ǳ]�p���맮�A�ܦh����A�S�u���ݨ� code ��������|���A03/25 �������ڴN���j�A����²�������e�F�A�����a�j�a�ݺ����� sample code. �����쪺�аO�o�ѥ[ 03/25 ������, �s���ک�b�Ĥ@�ӯd��
--
�w�i #6, �p�G�A�o�ǧޯೣ�ƻ��F, ���ѧڭn�Ӳ��� SK + MSKM �ܽd�@�Ƕi���� RAG ���Τ覡, �д��ݩ��Ѫ����ؤ� ?


## Demo

1. RAG with Kernel Memory Plugins
1. RAG with Kernel Memory Custom Plugins
1. Demo from Kernel Memory Offical Repo
1. 


# Day 6, �i�� RAG ����, �ͦ��˯��M�Ϊ���T

Link: [²��](https://www.facebook.com/share/p/1AUSLJBR6Q/)

![alt text](image-6.png)

![alt text](image-7.png)

![alt text](image-8.png)

![alt text](image-9.png)

���F SK ( Semantic Kernel ) �� MSKM ( Microsoft Kernel Memory ), ��� RAG �o�˪�����, �ڭ̶}�l���F���@�h�������O�F�C���ѴN�Ӳ�᭱�� RAG �����ή�, �����Ǧb�]�p����N��ﵽ�˯��ĪG���ޥ��a
�j�����Ь��, ���O�ЧA�n�⤺�e���q (���q���ܦh����, ����, ���q�Ÿ�, ���|�d�򵥵�)�A���L�ڹ�ڮ��ڦۤv������峹�Ӵ��աA�ѹ껡�ĪG�èS���ܦn.. ���̰򥻪� MSKM �w�]�]�w ( pipeline )�A�y�{�j�P�W�O�o��:
1. ��r�� ( content extraction )
�p�G�A�����e���O�¤�r, �|�����@�� handler �ӳB�z�C�Ҧp PDF ���ন��r, �άO�Ϥ����i�� OCR ����
2. ���q ( chunking )
RAG �D�n�˯��Ϊ��ޥ�, �N�O�⤺�e�V�q�ơC�V�q�ƪ��ҫ��q�`�����̾A�X�����e�j�p�C�H�ڨϥΪ� OpenAI text-embedding-large3 �ӻ�, ��ĳ��J�O 512 tokens, �W���O 8191 tokens .. ��r�Ӫ����ܴN�ݭn�����q, �]�N�O chunking �b�����Ʊ�
3. �V�q�� ( vectorization )
�N�O�� (2) ���q�᪺��r�A�v�q���浹�ҫ��ন�V�q�C�o�L�{�����a��|�٥L�� "���O" (embedding)
4. �x�s ( store )
��ª���e���B�z����T, ��l���e, meta data, �٦��V�q�q�q���s�_�ӡC�@��|�����s��䴩�V�q�j�M�� database, �@�������˯��d�ߨϥΪ���ƨӷ�
�M�ӡA�ڹ�ڮ��ڳ�����峹���աA���˯�����٤����A���O��ڰ��D�ݪ����@�I�N���V�|�F�C���b�ݧڤ峹���H�A�j�������D�A�ڤ峹�g�o�ܪ�... ��B�έp�@�U�A�ڳ����檺 .md �ɮײέp:
- �`�@�� 330 �g�峹 ( ������O .md , ������ .html )
- ��g�峹�¤�r���e, ���b 50k ~ 100k
�ӦV�q�˯����򥻰ʧ@�A�O��A���߰ݤ]�ഫ���V�q, �M�᮳�۳o�V�q (query) ���Ʈw���D�X�����װ������e�A�̫��o�Ǹ�ƥ浹 LLM �X���̲׵��סC�p�G�A����A�ۤv���˯����e������վ�A����@�g�峹�����|�Q���� 100+ �Ӥ��q ( partitions )�A�A���d�ߡA�|�q�o�Ǥ��q����X�����װ����ӨϥΡC���O�A��T���K�׮ڥ��藍���A�����|�o����Y���ﰨ�L�����p�C
�|�X�ӨҤl�A�ڼg�F�g WSL �����ΡA��F�ܦh�g�T���� WSL ���Ϊ��Ӹ`�����ê��a�p�A�M�ᦳ�H�ݤF "WSL ��F��" ���ɭԡA�A�Ʊ�V�q��Ʈw���A���Ǥ��q?
�򥻤W�o�O�L�Ѫ��D�ءA�]�������@�q�������... ���D�ڦۤv�g�峹�ɭԲߺD�ܦn�A�̫e����²���N�g�o�ܦn�A���g�峹���K�n���@�Y�b�@�Ӥ��q���A���� RAG �˯��ɭԳo²�����ӷ|�ƨ����������ơA�|�Q���ӥͦ����סC
���M���Ѫk�F (�ڦۤv���C�g�峹�ɤW�@�q 1000 �r�H�����K�n..)�A���L�o�ɥN�� LLM�A�����Ӥ��Ψ��򨯭W�~��C�]���A�ڶ}�l���աA�ण��b��峹�e�i�h�˯��e�A�ڦۤv���a LLM �ͦ��ڤ�ʪ�����? (�K�n)
�G�M�ĪG�n���h�A�ӥB MSKM �� pipeline �]���سo����F�A�A�u�n�b ImportText �ɫ��w�ۭq�� pipeline, �[�W Summarization �o�� handler �N���F�C
���L�ڷQ����h���աA�]���ڥ���ܦb MSKM �~�����ۤv�B�z�n���e�A�ȮɨS�������h�i MSKM �� Handlers. ���F�e�������K�n ( summarization ) ���~�A�ڦh���F�n�X�ع��աA�]�t:
1. ���峹���K�n ( abstract )
2. �峹�C�Ӭq�����K�n ( paragraph-abstract )
3. �ন FAQ �M�� ( question / answer )
4. �ন�ѨM��׮ר� ( problem / root cause / resolution / example )
��l�٦��O�����աA�ڴN���@�@�C�X�F�C�o�ĪG��_���e�L���� RAG �n�o�h�A�]���ܦh�d�ߪ����סA�ڥi�H�o��y�N�󥿽T���˯����G�F�C���F�e�����쪺�K�n���~�A�ڮ� FAQ ��ѨM��׷�Ҥl
�ڪ��峹�g�F�ܦh�ڸ��D������A���O�j�a���ӳ��O��۰��D�ӧ䵪�ת��A�ҥH���X���d�����ӳ��O�H���D���D ( �]�t: question, �]�]�t problem, ���峣�s�� "���D"�A���N�q�W���Ϲj )�C
�o�O���������D�A�ϥΪ̥ΥL�������Ӹ߰ݡA�ӧڥΧڪ������Ӽg�峹���e�C����䪺�������@�P���ɭԡA��¦V�q�ƪ��ۦ��ʬO�D���X��̪����p���C�]���ڥD�n���D����V�N�O�A�a LLM �}�n�����z�P�J���O�A�N�ڤ峹���e�ͦ����������������e (�ڦC�F���|���N�O�|�ص���)�A�A��o�Ǥ��e�ФW�X�A�� tags, �q�q�V�q�ƥ[�J�˯��C
�]���A���Ϊ��覡�}�l���F���]�󦳽�F�C�ѩ�o�ǬO�峹���ͩβ��ʮɳB�z�@���N�n�����ȡA��ϥΪ̬d�F�X���L���A�]���ڬD�F�Q�@�I���ҫ��Ӵ��� ( �ڥ� OpenAI �� o1 )�A�ĪG�٤����A�� SK ���ͦ��o���˯��Ϊ����e��A�A�浹 MSKM �˯��B�z�C�̫��� AI APPs, ChatBot, Agent ���e�ݤ��������� MSKM �d�߬�����T�A�� RAG �ӥͦ��̲׵��צ^���ϥΪ�
��ڷd���o�@����A�ڤ~�oı RAG �����ӬO�@�M "�t��"�A�άO "���~" �~��A�o�󹳬O design patterns ���˪��]�p�Ҧ��A�i�D�A AI �������˯��ӫ�򰵡CRAG �רs�ݭn���Y�ص{�ת��Ȼs�ƽվ�~�|�n�ΡA�]���A�p�G�Q���n RAG�A���ӭn���������ޯ�A�]�n��A�n�˯������e�A����Q�d�ߪ��覡���Ҵx���C�̫�A�������ӭn���@�ǧA�x���װ����u��c�A���n�ɯ��H�ɮ��X�����ΡC�o�� SK, MSKM, �٦���L No Code �� AI APPs ���x�A���|�O�A���n����C



## Demo

1. Multiple Plugins Demo
1. Synthesize Content for RAG



# 7, MSKM �P��L�t�Ϊ���X����

Link: [²��]()

![alt text](claude1.jpg)
> MSKM MCPServer �������W Claude Desktop, �� LLM �����j�M�ڪ��������T���ܽd

![alt text](claude2.jpg)
> �I�} Claude Desktop �I�s MCPServer ���L�{�A�i�H�ݨ� MCPServer �q MSKM ��F���Ǹ�T���� LLM


�e����F�ܦh function calling �����ΡA���O�D�n�� demo �覡���O�z�L SK + Plugins.

��ڤW LLM �� function calling ��O���ܦh�ؤ��P�޹D����ϥΪ��A���Ӥ��P�� LLM ���ε{���ӰϤ��A���o�ǥΪk:

1. �z�L Chat GPT (plus): �ڦb������峹, �٦� DevOpsDays Taipei 2024 ���Ъ��O�� GPTs + Custom Action ( �z�L OpenAPI Specs + OAuth )
1. �z�L No Code Platform: �ڦb .NET Conf 2024 ���Ъ��O�� Dify + Custom Tools ( �]�O�z�L OpenAPI Specs )
1. �z�L Claude Desktop ���䴩 MCP �� Host: �o���|�ܽd�� ModelContextProtocol �x�誺 csharp-sdk, �N MSKM �ʸ˦� MCPServer �ϥ�
1. �ۤv coding, �z�L Semantic Kernel �N MSKM ���W Kernel, �� LLM ���X�ʨåB�i�楻�a�ݪ� (Native) Function Calling

�o�Ǥ覡�A�I��B�@���y�{��곣�@�ˡC�A���ݭn�b�@�}�l�i�� LLM ������ function �i�H�ϥ� (�����W��A�Ѽ�)�C�� LLM �b��ܹL�{���|���׭n�������Ȼݭn�̿਺�� function, 
�ǵۦ^���o�� function calling ���n�D����o���^��, �ӳv�B�������ȡC�ӳo�Ǥ��P���u����q�A����F�u�O�Τ��P���覡�b�� LLM ���q�Ӥw�C

�u�}�ӬݡA�C�ؤ覡�������a���ѤF����:

1. �i�� LLM �i�Ϊ� function specs
1. Host �঳�Τ@���覡�N�� LLM �Ӱ�����w�� function �æ^�� function result

�^�Y�ݬ�, OpenAPI Spec ( swagger ), ���N�O���R�A�ɮ� ( json / yaml ) �Ӱ���Ĥ@��ƶ�? ���D�W���g�ӳq�Ϊ� Http Client �өI�s�]���O���ơC�o�ا@�k�AChat GPT, �� Semantic Kernel ���䴩 ( SK �䴩�����`�J Swagger )
�ǵ۳o�����|�A�ڤ]��s�F�@�U MCP �o�зǳW�d�A�L�ι���q�T��w���@�k�A�W�d�F�o�Ǿާ@:

- initialize
- noticication
- tools/list, tools/invoke
- resources/list, ...
- prompts/list, ...

�ӳo protocol, ���ؤ䴩��سq�T�覡, �@�ӬO stdio, �t�@�ӬO http ( based on SSE, server side event, ��V����y���� )�C�o�˪��]�p�A���A�i�H�Υ���y��, ���󥭥x, ����q�T�覡, �Ӹ� LLM �i��q�T�C
�ҥH�]���H�� MCP �N�O AI �� USB-C �]�����L�C�o�����D�D�A�ڳ̫�N demo �@�U MCP �x�誺 csharp-sdk �ӹ�@ MCPserver, ��X Claude Desktop �� MSKM �Ӱ� RAG ������...

���L�A�u�n�A�n live demo �N�|���]�G...  XDD, �o���� demo ����Ӧa��n�`�N:

1. MSKM �x�� docker image �аh���h�� 0.96.x, 2025/02 release ���������g�L chunking ���{���X, ���� token �N���e���q, ���G���媺�����S�B�z�n, �|�ܦ� "������" XDD (�|���|�r)�C�ڤw�g�o�F issue, ���L�٨S�ѨM���ˤl...
1. MCP/csharp-sdk �]�O, �^���� json-rpc �]�t���媺 json ���, ����Ū���S���D, ���O Cloud Desktop ���G�L�k�ܦn���B�z�a����r�� json data, �����N�s�X�ର \u1234\u1234 �o�˪��覡�~���... �P�˪��ڤ]�o issue �F�A�o�� demo �ڥ��ۤv build sdk, ��ʴ��� JsonSerializationOption ��Ȯɯ�ѨM, �U��i�H���x�� SDK ���ץ�...

�ڷ|�i�ܪ����� console + stdio �Ӿާ@ MCP server, ���j�a�F�ѳq�T�L�{
�]�|�u���� Claude Desktop �ӥܽd, ��ڨϥ� RAG ���P��



--
�o�O�̫�@�g���ض��F :D
FB �ڥu���Чڭn�ǹF�����e�A��� demo �� code �аѥ[���� 03/25 ������
�����s���ک�b�Ĥ@�h�d��