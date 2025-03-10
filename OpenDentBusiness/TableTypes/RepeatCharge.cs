using System;

namespace OpenDentBusiness{

	/// <summary>Each row represents one charge that will be added. Usually monthly, but quarterly and annually are allowed.</summary>
	[Serializable]
	public class RepeatCharge:TableBase {
		/// <summary>Primary key</summary>
		[CrudColumn(IsPriKey=true)]
		public long RepeatChargeNum;
		/// <summary>FK to patient.PatNum.</summary>
		public long PatNum;
		///<summary>FK to procedurecode.ProcCode.  The code that will be added to the account as a completed procedure.</summary>
		public string ProcCode;
		///<summary>The amount that will be charged.  The amount from the procedurecode will not be used.  This way, a repeating charge cannot be accidentally altered.</summary>
		public double ChargeAmt;
		///<summary>The date of the first charge if UseBillingCycleDays is not enabled.  Charges will always be added on the same day of the frequency start date. 
		/// If UseBillingCycleDays is enabled, repeat charges will be applied on billing cycle day instead. 
		/// If more than one frequency cycle goes by without applying repeating charges, then multiple procedures will be added.</summary>
		public DateTime DateStart;
		///<summary>The last date on which a charge is allowed. Can be blank (0001-01-01) to represent a perpetual repeating charge.</summary>
		public DateTime DateStop;
		///<summary>Any note for internal use.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.IsText)]
		public string Note;
		///<summary>Indicates that the note should be copied to the corresponding procedure billing note.</summary>
		public bool CopyNoteToProc;
		///<summary>Set to true to have a claim automatically created for the patient with the procedure that is attached to this repeating charge.</summary>
		public bool CreatesClaim;
		///<summary>Set to false to disable the repeating charge.  This allows patients to have repeating charges in their history that are not active.  Used mainly for repeating charges with notes that should not be deleted.</summary>
		public bool IsEnabled;
		///<summary>Set to true to use prepayments for repeating charges.</summary>
		public bool UsePrepay;
		///<summary>Stores the NPI of the provider on this repeating charge for Erx.  This used to be stored in the Note field but got moved over to its own column in 17.2.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.IsText)]
		public string Npi;
		///<summary>Stores the Erx Account ID on this repeating charge for Erx.  This used to be stored in the Note field but got moved over to its own column in 17.2.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.IsText)]
		public string ErxAccountId;
		///<summary>Stores the name of the provider on this repeating charge for Erx.  Value is received directly from NewCrop.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.IsText)]
		public string ProviderName;
		///<summary>HQ Only. An alternate amount to be charged for this RepeatCharge in some cases. 
		///Should always defaul to -1 as -1 will be used as a flag to indicate it has not been set.
		///A value of 0 means ChargeAmtAlt has been intentionally set to 0.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.Double, DecimalPlaces=4)]
		public double ChargeAmtAlt;
		///<summary>If UsePrepay is true, when the procedure is created from this repeat charge, it will allocate payments from these unearned types.
		///Stored as a comma separated list of DefNums of Category PaySplitUnearnedType. If empty, then all unearned types will be considered.</summary>
		public string UnearnedTypes;
		///<summary>Enum:EnumRepeatChargeFrequency 0-Monthly, 1-Quarterly, 2-Annually.</summary>
		public EnumRepeatChargeFrequency Frequency;

		///<summary></summary>
		public RepeatCharge Copy(){
			return (RepeatCharge)MemberwiseClone();
		}

		public RepeatCharge() {
			//See summary for ChargeAmtAlt.
			ChargeAmtAlt=-1;
		}

		

		


	}

	///<summary></summary>
	public enum EnumRepeatChargeFrequency {
		///<summary>0 - Monthly</summary>
		Monthly,
		///<summary>1 - Quarterly</summary>
		Quarterly,
		///<summary>2 - Annually</summary>
		Annually,
	}
	


}










