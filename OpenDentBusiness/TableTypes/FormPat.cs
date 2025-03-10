using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenDentBusiness{

	///<summary>This is an old table that isn't really used anymore. We used to have a "questionnaire" that could be filled out by a patient, and this is it.  Each patient can have multiple questionnaires.</summary>
	[Serializable]
	public class FormPat:TableBase {
		///<summary>Primary key.</summary>
		[CrudColumn(IsPriKey=true)]
		public long FormPatNum;
		///<summary>FK to patient.PatNum.</summary>
		public long PatNum;
		///<summary>The date and time that this questionnaire was filled out.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime FormDateTime;
		///<summary>Not a database field.</summary>
		[CrudColumn(IsNotDbColumn=true)]
		public List<Question> QuestionList;

		///<summary>Constructor</summary>
		public FormPat(){
			QuestionList=new List<Question>();
		}
		
		///<summary></summary>
		public FormPat Copy(){
			FormPat f=new FormPat();
			f=(FormPat)this.MemberwiseClone();
			f.QuestionList=new List<Question>(QuestionList);
			return f;
		}
	}

	
	

}




















