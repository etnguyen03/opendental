using System;
using CodeBase;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Linq;
using OpenDentBusiness.Crud;
using Google.Apis.Gmail.v1.Data;

namespace OpenDentBusiness {
	///<summary></summary>
	public class InsBlueBooks {
		#region Get Methods
		///<summary>Gets all insbluebooks that have an AllowedOverride that isn't -1 for the carrier group. Limits by ProcDate and claimType.</summary>
		public static List<InsBlueBook> GetAllForCarrierGroupLimitByDateAndClaimType(long carrierGroupName,DateTime dateLimit,string claimType,List<long> listProcCodeNums) {
			if(listProcCodeNums.IsNullOrEmpty()) {
				return new List<InsBlueBook>();
			}
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				return Meth.GetObject<List<InsBlueBook>>(MethodBase.GetCurrentMethod(),carrierGroupName,dateLimit,claimType,listProcCodeNums);
			}
			string command=$@"
				SELECT insbluebook.*
				FROM carrier
				INNER JOIN insbluebook
				ON carrier.CarrierNum=insbluebook.CarrierNum
				AND insbluebook.ProcDate >= {POut.Date(dateLimit)}
				AND insbluebook.ClaimType='{POut.String(claimType)}'
				AND insbluebook.AllowedOverride!=-1
				INNER JOIN procedurecode
				ON insbluebook.ProcCodeNum=procedurecode.CodeNum
				AND procedurecode.CodeNum IN({string.Join(",",listProcCodeNums.Select(x => POut.Long(x)))})
				WHERE carrier.CarrierGroupName={POut.Long(carrierGroupName)}";
			return InsBlueBookCrud.SelectMany(command);
		}

		///<summary>Gets all insbluebooks that have an AllowedOverride that isn't -1 for the carrier. Limits by ProcDate and claimType.</summary>
		public static List<InsBlueBook> GetAllForCarrierLimitByDateAndClaimType(long carrierNum,DateTime dateLimit,string claimType,List<long> listProcCodeNums) {
			if(listProcCodeNums.IsNullOrEmpty()) {
				return new List<InsBlueBook>();
			}
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				return Meth.GetObject<List<InsBlueBook>>(MethodBase.GetCurrentMethod(),carrierNum,dateLimit,claimType,listProcCodeNums);
			}
			string command=$@"
				SELECT insbluebook.*
				FROM insbluebook
				INNER JOIN procedurecode
				ON insbluebook.ProcCodeNum=procedurecode.CodeNum
				AND procedurecode.CodeNum IN({string.Join(",",listProcCodeNums.Select(x => POut.Long(x)))})
				WHERE insbluebook.CarrierNum={POut.Long(carrierNum)}
				AND insbluebook.ProcDate >= {POut.Date(dateLimit)}
				AND insbluebook.ClaimType='{POut.String(claimType)}'
				AND insbluebook.AllowedOverride!=-1";
			return InsBlueBookCrud.SelectMany(command);
		}
		#endregion Get Methods

		#region Modification Methods
		///<summary>Deletes, Inserts, and Updates insbluebook entries as needed. insbluebook entries will only be inserted, updated, or avoid deletion if one or more received or supplemental claimprocs for a procedure on a primary or secondary claim of a category percentage plan can be found. To make a valid insbluebook, the sum of InsPayAmt for these claimprocs must be zero or greater but cannot exceed the total proc fee of the procedure.</summary>
		public static void SynchForClaimNums(params long[] claimNumArray) {
			claimNumArray=FilterArrayPrimaryKeysHelper(claimNumArray);
			if(claimNumArray.IsNullOrEmpty()) {
				return;
			}
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),claimNumArray);
				return;
			}
			//Generate a list of all insbluebooks that should be in the database right now for the array of ClaimNums.
			//If an insbluebook for a given claim and procedure combination is already in the DB, the object in the resulting list will have its 
			//InsBlueBookNum. If not, the InsBlueBookNum will be zero so that it gets inserted when we sync.
			string command=$@"
				SELECT COALESCE(insbluebook.InsBlueBookNum,0) 'InsBlueBookNum',_result.CodeNum 'ProcCodeNum',_result.CarrierNum,_result.PlanNum,
					_result.GroupNum,_result.InsPayAmt,
					CASE WHEN _result.AllowedOverride=-1 THEN -1
						ELSE ROUND(_result.AllowedOverride/(_result.UnitQty+_result.BaseUnits),2) END 'AllowedOverride',
					COALESCE(insbluebook.DateTEntry,NOW()) 'DateTEntry',_result.ProcNum,_result.ProcDate,_result.ClaimType,_result.ClaimNum
				FROM (
					SELECT procedurelog.CodeNum,insplan.CarrierNum,insplan.PlanNum,insplan.GroupNum,SUM(claimproc1.InsPayAmt) 'InsPayAmt',
						MAX(claimproc2.AllowedOverride) 'AllowedOverride',procedurelog.ProcNum,MAX(claimproc2.ProcDate) 'ProcDate',
						claim.ClaimType,claim.ClaimNum,procedurelog.ProcFee,procedurelog.UnitQty,procedurelog.BaseUnits
					FROM claim
					INNER JOIN insplan
						ON claim.PlanNum=insplan.PlanNum
							AND insplan.PlanType=''
							AND insplan.IsBlueBookEnabled
					INNER JOIN claimproc claimproc1
						ON claim.ClaimNum=claimproc1.ClaimNum
							AND claimproc1.Status IN ({POut.Int((int)ClaimProcStatus.Received)},{POut.Int((int)ClaimProcStatus.Supplemental)})
							AND claimproc1.ProcNum!=0
					INNER JOIN procedurelog
						ON claimproc1.ProcNum=procedurelog.ProcNum
					LEFT JOIN claimproc claimproc2
						ON claimproc1.ClaimProcNum=claimproc2.ClaimProcNum
							AND claimproc1.Status={POut.Int((int)ClaimProcStatus.Received)}
					WHERE claim.ClaimNum IN ({string.Join(",",claimNumArray.Select(x => POut.Long(x)))})
						AND claim.ClaimType IN ('P','S')
					GROUP BY claim.ClaimNum,procedurelog.ProcNum
				) _result
				LEFT JOIN insbluebook
					ON _result.ClaimNum=insbluebook.CLaimNum
						AND _result.ProcNum=insbluebook.ProcNum
				WHERE _result.ProcFee*(_result.UnitQty+_result.BaseUnits) >= _result.InsPayAmt
					AND _result.InsPayAmt >= 0";
			List<InsBlueBook> listInsBlueBooksNew=InsBlueBookCrud.SelectMany(command);
			//Get a list of the insbluebooks that are currently in the DB for the array of ClaimNums.
			command=$"SELECT insbluebook.* FROM insbluebook WHERE insbluebook.ClaimNum IN ({string.Join(",",claimNumArray.Select(x => POut.Long(x)))})";
			List<InsBlueBook> listInsBlueBooksOld=InsBlueBookCrud.SelectMany(command);
			InsBlueBookCrud.Sync(listInsBlueBooksNew,listInsBlueBooksOld);
		}

		///<summary>Deletes any insbluebook entries from the db that have any of the given ClaimNums.</summary>
		public static void DeleteByClaimNums(params long[] claimNumArray) {
			claimNumArray=FilterArrayPrimaryKeysHelper(claimNumArray);
			if(claimNumArray.IsNullOrEmpty()) {
				return;
			}
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),claimNumArray);
				return;
			}
			string command=$"DELETE FROM insbluebook WHERE insbluebook.ClaimNum IN ({string.Join(",",claimNumArray.Select(x => POut.Long(x)))})";
			Db.NonQ(command);
		}

		///<summary>Deletes any insbluebook entries from the db that have any of the given PlanNums.</summary>
		public static void DeleteByPlanNums(params long[] planNumArray) {
			planNumArray=FilterArrayPrimaryKeysHelper(planNumArray);
			if(planNumArray.IsNullOrEmpty()) {
				return;
			}
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),planNumArray);
				return;
			}
			string command=$"DELETE FROM insbluebook WHERE insbluebook.PlanNum IN ({string.Join(",",planNumArray.Select(x => POut.Long(x)))})";
			Db.NonQ(command);
		}

		///<summary>Used to update the GroupNum and CarrierNum for insbluebook entries when these fields have changed for the insplan.</summary>
		public static void UpdateByInsPlan(InsPlan insPlan) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),insPlan);
				return;
			}
			string command=$@"UPDATE insbluebook
				SET insbluebook.GroupNum='{POut.String(insPlan.GroupNum)}',insbluebook.CarrierNum={POut.Long(insPlan.CarrierNum)}
				WHERE insbluebook.PlanNum={POut.Long(insPlan.PlanNum)}";
			Db.NonQ(command);
		}
		#endregion Modification Methods

		#region Misc Methods
		///<summary>Returns null if the passed in array is null, otherwise returns the array with any zeros and duplicates removed.</summary>
		private static long[] FilterArrayPrimaryKeysHelper(long[] primaryKeyArray) {
			if(primaryKeyArray==null) {
				return null;
			}
			return primaryKeyArray.Where(x => x != 0).Distinct().ToArray();
		}
		#endregion Misc Methods
		/*
		Only pull out the methods below as you need them.  Otherwise, leave them commented out.
		#region Get Methods
		///<summary></summary>
		public static List<InsBlueBook> Refresh(long patNum){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				return Meth.GetObject<List<InsBlueBook>>(MethodBase.GetCurrentMethod(),patNum);
			}
			string command="SELECT * FROM insbluebook WHERE PatNum = "+POut.Long(patNum);
			return Crud.InsBlueBookCrud.SelectMany(command);
		}
		#endregion Get Methods
		#region Modification Methods
		///<summary></summary>
		public static long Insert(InsBlueBook insBlueBook){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT){
				insBlueBook.InsBlueBookNum=Meth.GetLong(MethodBase.GetCurrentMethod(),insBlueBook);
				return insBlueBook.InsBlueBookNum;
			}
			return Crud.InsBlueBookCrud.Insert(insBlueBook);
		}
		///<summary></summary>
		public static void Update(InsBlueBook insBlueBook){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT){
				Meth.GetVoid(MethodBase.GetCurrentMethod(),insBlueBook);
				return;
			}
			Crud.InsBlueBookCrud.Update(insBlueBook);
		}
		///<summary></summary>
		public static void Delete(long insBlueBookNum) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),insBlueBookNum);
				return;
			}
			Crud.InsBlueBookCrud.Delete(insBlueBookNum);
		}
		#endregion Modification Methods
		*/
	}

	///<summary>Helper class that stores all data needed to make estimates with the blue book feature.</summary>
	[Serializable]
	public class BlueBookEstimateData {
		///<summary>The patients primary dental insurance plan. May be null if they don't have one.</summary>
		public InsPlan InsPlanPrimaryDental;
		///<summary>All of the InsBlueBookRules in the database. Currently, there are always six of these.</summary>
		public List<InsBlueBookRule> ListInsBlueBookRules;
		///<summary>Carrier of the primary dental insurance plan.</summary>
		public Carrier CarrierPri;
		///<summary>All of the InsBlueBooks that are relevant given current rules settings and carrier.</summary>
		public List<InsBlueBook> ListInsBlueBooks;
		///<summary>Dictionary that stores actual DateTime values for each rule's limit type and limit value. Key: InsBlueBookRule.InsBlueBookRuleNum  Value: DateTime, NOW minus increment dictated by the rule (e.g. NOW - 1 years).</summary>
		public SerializableDictionary<long,DateTime> DictRuleLimits=new SerializableDictionary<long,DateTime>();
		///<summary>Log that will be saved as an InsBlueBookLog if blue book is used to calculate an estimate and changes are saved to db.</summary>
		public string LogText;
		///<summary>Flag used to check if this BlueBookEstimateData was used to calculate an estimate.</summary>
		public bool WasBlueBookUsed;

		///<summary>Do not use this constructor. Necessary for middle tier serialization.</summary>
		public BlueBookEstimateData() {
			//necessary for middle tier serialization
		}

		///<summary>The listPatPlans and listProcedures parameters cannot be null.</summary>
		public BlueBookEstimateData(List<InsPlan> listInsPlans,List<InsSub> listInsSubs,List<PatPlan> listPatPlans,List<Procedure> listProcedures,List<SubstitutionLink> listSubstitutionLinks) {
			Meth.NoCheckMiddleTierRole();
			int ordinalPrimary=PatPlans.GetOrdinal(PriSecMed.Primary,listPatPlans,listInsPlans,listInsSubs);
			long insSubNumPrimary=PatPlans.GetInsSubNum(listPatPlans,ordinalPrimary);
			InsSub insSub=InsSubs.GetSub(insSubNumPrimary,listInsSubs);
			InsPlanPrimaryDental=InsPlans.GetPlan(insSub.PlanNum,listInsPlans);
			Initialize(listProcedures,listSubstitutionLinks);
		}

		///<summary>Only initializes other member variables if Blue Book feature is turned on and patient has a category percent primary dental insurance plan.</summary>
		private void Initialize(List<Procedure> listProcedures,List<SubstitutionLink> listSubstitutionLinks) {
			Meth.NoCheckMiddleTierRole();
			//No need to get other data if patient doesn't have a cat percentage primary dental plan, no fee schedule attached, or the Blue Book feature is not
			//on because blue book estimates won't be created unless these conditions are met.
			if(InsPlanPrimaryDental==null){
				return;
			}
			if(InsPlanPrimaryDental.PlanType!=""){
				return;
			}
			if(!InsPlanPrimaryDental.IsBlueBookEnabled) {
				return;
			}
			if(PrefC.GetEnum<AllowedFeeSchedsAutomate>(PrefName.AllowedFeeSchedsAutomate)!=AllowedFeeSchedsAutomate.BlueBook){
				return;
			}
			if(listSubstitutionLinks==null) {
				listSubstitutionLinks=SubstitutionLinks.GetAllForPlans(InsPlanPrimaryDental.PlanNum);
			}
			List<long> listProcCodeNums=new List<long>();
			for(int i=0;i<listProcedures.Count;i++) {
				listProcCodeNums.Add(listProcedures[i].CodeNum);
				string procCode=ProcedureCodes.GetProcCode(listProcedures[i].CodeNum).ProcCode;
				long codeNumSubstitution=ProcedureCodes.GetSubstituteCodeNum(procCode,listProcedures[i].ToothNum,InsPlanPrimaryDental.PlanNum,listSubstitutionLinks);
				if(codeNumSubstitution!=0 && codeNumSubstitution!=listProcedures[i].CodeNum) {
					listProcCodeNums.Add(codeNumSubstitution);
				}
			}
			listProcCodeNums=listProcCodeNums.Distinct().ToList();
			ListInsBlueBookRules=InsBlueBookRules.GetAll().OrderBy(x => x.ItemOrder).ToList();
			DateTime dateOldestLimit=FillDictRuleLimits();
			CarrierPri=Carriers.GetCarrier(InsPlanPrimaryDental.CarrierNum);
			GetInsBlueBooksNeeded(dateOldestLimit,listProcCodeNums);
		}

		///<summary>Fills DictRuleLimits with actual DateTime values for each rules limit type and value. Also returns the DateTime for the oldest limit among rules.</summary>
		private DateTime FillDictRuleLimits() {
			Meth.NoCheckMiddleTierRole();
			DateTime dateOldestLimit=DateTime.Today;
			for(int i=0;i<ListInsBlueBookRules.Count;i++) {
				InsBlueBookRule insBlueBookRule=ListInsBlueBookRules[i];
				DateTime dateLimit=DateTime.MinValue;
				switch(insBlueBookRule.LimitType) {
					case InsBlueBookRuleLimitType.Years:
						dateLimit=DateTimeOD.CalculateForEndOfMonthOffset(DateTime.Today,insBlueBookRule.LimitValue*12);
						break;
					case InsBlueBookRuleLimitType.Months:
						dateLimit=DateTimeOD.CalculateForEndOfMonthOffset(DateTime.Today,insBlueBookRule.LimitValue);
						break;
					case InsBlueBookRuleLimitType.Days:
						dateLimit=DateTime.Today.AddDays(0-insBlueBookRule.LimitValue);
						break;
					default://LimitType is None, do nothing.
						break;
				}
				DictRuleLimits.Add(insBlueBookRule.InsBlueBookRuleNum,dateLimit);
				if(insBlueBookRule.RuleType.In(InsBlueBookRuleType.ManualBlueBookSchedule,InsBlueBookRuleType.UcrFee)) {
					continue;
				}
				else if(dateOldestLimit > dateLimit) {
					dateOldestLimit=dateLimit;
				}
			}
			return dateOldestLimit;
		}

		///<summary>Gets InsBlueBooks for carrier group if plan's carrier belongs to one. Otherwise returns InsBlueBooks for carrier. Limits by rule with oldest limit date and only gets insbluebooks for primary claims for now.</summary>
		private void GetInsBlueBooksNeeded(DateTime dateOldestLimit,List<long> listProcCodeNums) {
			Meth.NoCheckMiddleTierRole();
			if(CarrierPri.CarrierGroupName==0) {
				ListInsBlueBooks=InsBlueBooks.GetAllForCarrierLimitByDateAndClaimType(CarrierPri.CarrierNum,dateOldestLimit,"P",listProcCodeNums);
			}
			else {
				ListInsBlueBooks=InsBlueBooks.GetAllForCarrierGroupLimitByDateAndClaimType(CarrierPri.CarrierGroupName,dateOldestLimit,"P",listProcCodeNums);
			}
		}

		///<summary>Returns true if the patient has a category percentage primary dental plan, has a fee schedule attached, the Blue Book feature is on, and the claimProc passed in is for the primary dental plan.</summary>
		public bool IsValidForEstimate(ClaimProc claimProc,bool canSetBlueBookUsed=true) {
			Meth.NoCheckMiddleTierRole();
			if(canSetBlueBookUsed) {
				WasBlueBookUsed=false;
			}
			if(InsPlanPrimaryDental==null) {
				return false;
			}
			if(InsPlanPrimaryDental.PlanType!="") {
				return false;
			}
			if(!InsPlanPrimaryDental.IsBlueBookEnabled) {
				return false;
			}
			if(PrefC.GetEnum<AllowedFeeSchedsAutomate>(PrefName.AllowedFeeSchedsAutomate)!=AllowedFeeSchedsAutomate.BlueBook) {
				return false;
			}
			if(claimProc.PlanNum!=InsPlanPrimaryDental.PlanNum) {
				return false;
			}
			return true;
		}

		///<summary>IsValidForEstimate() must return true before calling this. Loop through rules until one returns an allowed amount. If no rule applies, return -1.</summary>
		public double GetAllowed(Procedure procedure,Lookup<FeeKey2,Fee> lookupFees,bool isCodeSubstNone,List<SubstitutionLink> listSubstitutionLinks=null) {
			Meth.NoCheckMiddleTierRole();
			long codeNum=procedure.CodeNum;
			if(!isCodeSubstNone) {
				codeNum=ProcedureCodes.GetSubstituteCodeNum(ProcedureCodes.GetProcCode(codeNum).ProcCode,procedure.ToothNum,InsPlanPrimaryDental.PlanNum,listSubstitutionLinks);
			}
			LogText="";
			double allowed=-1;
			InsBlueBookRule insBlueBookRule=null;
			for(int i=0;i<ListInsBlueBookRules.Count;i++) {//Already ordered by InsBlueBookRule.ItemOrder.
				insBlueBookRule=ListInsBlueBookRules[i];
				List<InsBlueBook> listInsBlueBooksFiltered;
				List<Fee> listFees=null;
				if(InsBlueBookRules.IsDateLimitedType(insBlueBookRule)) {
					//Rule does not apply if carrier for claimProc has no CarrierGroupName.
					if(insBlueBookRule.RuleType==InsBlueBookRuleType.InsuranceCarrierGroup && CarrierPri.CarrierGroupName==0) {
						continue;
					}
					//Skip if this rule is deactivated.
					if(insBlueBookRule.RuleType==InsBlueBookRuleType.InsurancePlan && !PrefC.GetBool(PrefName.InsBlueBookUsePlanNumOverride)) {
						continue;
					}
					listInsBlueBooksFiltered=FilterInsBlueBooksByRuleType(codeNum,insBlueBookRule);
					if(listInsBlueBooksFiltered.Count==0) {
						LogText+=" Not enough blue book data.";
						continue;
					}
					allowed=CalcAllowedByInsBlueBookAllowedFeeMethod(listInsBlueBooksFiltered);
				}
				else if(insBlueBookRule.RuleType==InsBlueBookRuleType.ManualBlueBookSchedule) {
					if(InsPlanPrimaryDental.ManualFeeSchedNum==0) {
						continue;
					}
					if(lookupFees!=null) {
						listFees=lookupFees[new FeeKey2(codeNum,InsPlanPrimaryDental.ManualFeeSchedNum)].ToList();
					}
					LogText="Rule Type: Manual Blue Book Fee Schedule.";
					allowed=Fees.GetAmount(codeNum,InsPlanPrimaryDental.ManualFeeSchedNum,procedure.ClinicNum,procedure.ProvNum,listFees);
				}
				else {//InsBlueBookRuleType.UcrFee
					long feeSchedNum;
					LogText="Rule Type: UCR Fee";
					//Logic here mimics InsPlans.GetAllowed()
					if(procedure.ProvNum==0) {//slight corruption, so we get the FeeSched for default practice provider.
						LogText+=" (Practice Default Provider).";
						feeSchedNum=Providers.GetProv(PrefC.GetLong(PrefName.PracticeDefaultProv)).FeeSched;
					}
					else {
						LogText+=".";
						feeSchedNum=Providers.GetProv(procedure.ProvNum).FeeSched;
					}
					if(lookupFees!=null) {
						listFees=lookupFees[new FeeKey2(codeNum,feeSchedNum)].ToList();
					}
					allowed=Fees.GetAmount(codeNum,feeSchedNum,procedure.ClinicNum,procedure.ProvNum,listFees);
					if(allowed!=-1) {//Only calculate percentage of the UCR fee if one was found.
						allowed=allowed*PrefC.GetInt(PrefName.InsBlueBookUcrFeePercent)/100;
					}
				}
				if(allowed!=-1) {//We have found a valid allowed fee, so we break the for loop.
					break;
				}
			}
			WasBlueBookUsed=true;
			allowed=Math.Round(allowed,2);//If no rule could find a valid fee, this will be -1.
			//Finish creating log
			if(allowed==-1) {
				LogText="No rule applied. Last attempted "+LogText;
				if(insBlueBookRule.RuleType.In(InsBlueBookRuleType.UcrFee,InsBlueBookRuleType.ManualBlueBookSchedule)) {
					LogText+=$" No fee for code in fee schedule.";
				}
			}
			else if(allowed*procedure.Quantity > procedure.ProcFeeTotal) {
				LogText+=" Allowed amount was greater than procedure's fee.";
			}
			if(allowed==-1 || allowed*procedure.Quantity > procedure.ProcFeeTotal) {
				LogText+=$" Procedure's fee used as allowed amount: {Math.Round(procedure.ProcFeeTotal,2).ToString("f")}.";
			}
			else {
				LogText+=$" Allowed amount: {Math.Round(allowed*procedure.Quantity,2).ToString("f")}";
				if(insBlueBookRule.RuleType==InsBlueBookRuleType.UcrFee) {
					LogText+=$" ({PrefC.GetInt(PrefName.InsBlueBookUcrFeePercent).ToString()}% of UCR fee)";
				}
				LogText+=".";
			}
			return allowed;
		}

		private List<InsBlueBook> FilterInsBlueBooksByRuleType(long codeNum,InsBlueBookRule insBlueBookRule) {
			DictRuleLimits.TryGetValue(insBlueBookRule.InsBlueBookRuleNum,out DateTime dateLimit);
			switch(insBlueBookRule.RuleType) {
				case InsBlueBookRuleType.InsuranceCarrierGroup:
					LogText="Rule Type: Allowed fees from received claims with matching Insurance Carrier Group.";
					return ListInsBlueBooks.FindAll(x => x.ProcDate>=dateLimit && x.ProcCodeNum==codeNum);
				case InsBlueBookRuleType.InsuranceCarrier:
					LogText="Rule Type: Allowed fees from received claims with matching Insurance Carrier.";
					return ListInsBlueBooks.FindAll(x =>	x.ProcDate>=dateLimit && x.ProcCodeNum==codeNum && x.CarrierNum==CarrierPri.CarrierNum);
				case InsBlueBookRuleType.GroupNumber:
					LogText="Rule Type: Allowed fees from received claims with matching Insurance Group Number.";
					return ListInsBlueBooks.FindAll(x =>	x.ProcDate>=dateLimit && x.ProcCodeNum==codeNum && x.CarrierNum==CarrierPri.CarrierNum
						&& x.GroupNum==InsPlanPrimaryDental.GroupNum);
				default://InsBlueBookRuleType.InsurancePlan:
					LogText="Rule Type: Allowed fees from received claims with matching Insurance Plan.";
					return ListInsBlueBooks.FindAll(x =>	x.ProcDate>=dateLimit	&& x.ProcCodeNum==codeNum && x.PlanNum==InsPlanPrimaryDental.PlanNum);
			}
		}

		#region AllowedFeeMethod
		///<summary>Returns the average, median, or most recent AllowedOverride from the list of InsBlueBooks passed in. MostRecent must find a value at least twice to return it, otherwise -1 is returned.</summary>
		private double CalcAllowedByInsBlueBookAllowedFeeMethod(List<InsBlueBook> listInsBlueBooks) {
			Meth.NoCheckMiddleTierRole();
			switch(PrefC.GetEnum<InsBlueBookAllowedFeeMethod>(PrefName.InsBlueBookAllowedFeeMethod)) {
				case InsBlueBookAllowedFeeMethod.Average:
					LogText+=" Method: Average.";
					return listInsBlueBooks.Select(x => x.AllowedOverride).ToList().Average();
				case InsBlueBookAllowedFeeMethod.Median:
					LogText+=" Method: Median.";
					return GetMedian(listInsBlueBooks);
				default://InsBlueBookAllowedFeeMethod.MostRecent
					LogText+=" Method: Most Recent.";
					return GetMostRecent(listInsBlueBooks);
			}
		}

		#region Median
		///<summary>O(n) algorithm to find median. References: https://en.wikipedia.org/wiki/Selection_algorithm, https://stackoverflow.com/questions/4140719/calculate-median-in-c-sharp, Introduction to Algorithms 3rd Edition, Corman et al, pp 216</summary>
		private double GetMedian(List<InsBlueBook> listInsBlueBooks) {
			Meth.NoCheckMiddleTierRole();
			int start=0;
			int end=listInsBlueBooks.Count-1;
			int medianIndex=(listInsBlueBooks.Count-1)/2;
			while(true) {
				int pivotIndex=PartitionHelper(listInsBlueBooks,start,end);
				if(pivotIndex==medianIndex) {
					return listInsBlueBooks[pivotIndex].AllowedOverride;
				}
				if(medianIndex < pivotIndex) {
					end=pivotIndex-1;
				}
				else {
					start=pivotIndex+1;
				}
			}
		}

		///<summary>Reference: Introduction to Algorithms 3rd Edition, Corman et al, pp 171</summary>
		private int PartitionHelper(List<InsBlueBook> listInsBlueBooks,int start,int end) {
			Meth.NoCheckMiddleTierRole();
			double pivot=listInsBlueBooks[end].AllowedOverride;
			int lastLow=start-1;
			for(int i=start;i<end;i++) {
				if(listInsBlueBooks[i].AllowedOverride.CompareTo(pivot)<=0) {
					lastLow++;
					SwapHelper(listInsBlueBooks,i,lastLow);
				}
			}
			lastLow++;
			SwapHelper(listInsBlueBooks,end,lastLow);
			return lastLow;
		}

		private void SwapHelper(List<InsBlueBook> listInsBlueBooks,int i,int j) {
			Meth.NoCheckMiddleTierRole();
			if(i==j) {
				return;
			}
			InsBlueBook insBlueBookTemp=listInsBlueBooks[i].Copy();
			listInsBlueBooks[i]=listInsBlueBooks[j];
			listInsBlueBooks[j]=insBlueBookTemp;
		}
		#endregion Median

		///<summary>Returns the most recent AllowedOverride or -1 if listInsBlueBooks is empty.</summary>
		private double GetMostRecent(List<InsBlueBook> listInsBlueBooks) {
			InsBlueBook insBlueBookMostRecent=null;
			for(int i=0;i<listInsBlueBooks.Count;i++) {
				InsBlueBook insBlueBookCur=listInsBlueBooks[i];
				if(insBlueBookMostRecent==null || insBlueBookCur.ProcDate > insBlueBookMostRecent.ProcDate) {
					insBlueBookMostRecent=insBlueBookCur;
				}
			}
			if(insBlueBookMostRecent==null) {
				LogText+=" Not enough blue book data.";
				return -1;
			}
			return insBlueBookMostRecent.AllowedOverride;
		}
		#endregion AllowedFeeMethod

		///<summary>Creates an InsBlueBookLog for the last allowed amount generated. Returns null if InsEstTotal hasn't changed or blue book wasn't used to generate estimate.</summary>
		public InsBlueBookLog CreateInsBlueBookLog(ClaimProc claimProc,bool canSetBlueBookUsed=true) {
			Meth.NoCheckMiddleTierRole();
			InsBlueBookLog insBlueBookLogLast=InsBlueBookLogs.GetMostRecentForClaimProc(claimProc.ClaimProcNum);
			InsBlueBookLog insBlueBookLog=null;
			//Don't make a log if Blue Book was not used to calculate the new estimate or the InsEstTotal has not changed since last log.
			if(WasBlueBookUsed){
				if(insBlueBookLogLast==null || !CompareDouble.IsEqual(insBlueBookLogLast.AllowedFee,claimProc.InsEstTotal)){
					insBlueBookLog=new InsBlueBookLog();
					insBlueBookLog.AllowedFee=claimProc.InsEstTotal;
					insBlueBookLog.ClaimProcNum=claimProc.ClaimProcNum;
					insBlueBookLog.Description=LogText;
				}
			}
			if(canSetBlueBookUsed) {
				WasBlueBookUsed=false;
			}
			return insBlueBookLog;
		}


	}


}