using System;

namespace OpenDentBusiness {
	[Serializable]
	[CrudTable(IsMissingInGeneral=true,CrudExcludePrefC=true)]
	public class WebChatAiAssistant:TableBase {
		///<summary>Primary key.</summary>
		[CrudColumn(IsPriKey=true)]
		public long WebChatAiAssistantNum;
		///<summary>The ID associated to the AI assistant used to generate a response.
		///For example: asst_0rU2su3oJYUU0bzC6R3FlL78</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.IsText)]
		public string AssistantId;

		public WebChatAiAssistant Copy() {
			return new WebChatAiAssistant() { 
				WebChatAiAssistantNum=WebChatAiAssistantNum,
				AssistantId=AssistantId
			};
		}
	}
	//CREATE TABLE webchataiassistant(
	//	WebChatAiAssistantNum bigint NOT NULL auto_increment PRIMARY KEY,
	//	AssistantId text NOT NULL
	//) DEFAULT CHARSET = utf8;

	//ALTER TABLE webchatmessage
	//	ADD COLUMN AiAssistantIdNum BIGINT(20) NOT NULL AFTER NeedsFollowUp,
	//	ADD KEY WEBCHATSESSION_WEBCHATAIASSISTANTNUM(AiAssistantIdNum);
}
