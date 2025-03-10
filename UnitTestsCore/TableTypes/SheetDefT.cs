﻿using OpenDentBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCore {
	///<summary>Has methods for both SheetDef and SheetFieldDef. Use SheetT for sheets.</summary>
	public class SheetDefT {
		///<summary>Deletes everything from the sheetdef and sheetfielddef table.  Does not truncate the table so that PKs are not reused on accident.</summary>
		public static void ClearSheetDefAndSheetFieldDefTable() {
			string command="DELETE FROM sheetdef WHERE sheetdefnum > 0";
			DataCore.NonQ(command);
			command="DELETE FROM sheetfielddef WHERE sheetfielddefnum > 0";
			DataCore.NonQ(command);
			command="DELETE FROM eclipboardsheetdef WHERE eclipboardsheetdefnum > 0";
			DataCore.NonQ(command);
		}

		///<summary>Creates a simple SheetDef and inserts it into the database.</summary>
		public static SheetDef CreateSheetDef(SheetTypeEnum sheetType,string description="") {
			SheetDef sheetDef=new SheetDef();
			sheetDef.IsNew=true;
			sheetDef.SheetType=sheetType;
			sheetDef.Description=description;
			sheetDef.SheetFieldDefs=new List<SheetFieldDef>();
			SheetDefs.InsertOrUpdate(sheetDef);
			SheetDefs.RefreshCache();
			return sheetDef;
		}

		///<summary>ClinicNum of 0 creates a default rule for all clinics.</summary>
		public static SheetDef CreateCustomSheet(SheetInternalType sheetInternalType,bool createEClipboardRule = true,long clinicNum = 0,int days = 30,
			int minAge = -1,int maxAge = -1) 
		{
			var sheetDef=SheetDefs.GetInternalOrCustom(sheetInternalType);
			sheetDef.IsNew=true;
			SheetDefs.InsertOrUpdate(sheetDef);
			if(!createEClipboardRule) {
				return sheetDef;
			}
			var existingAll=EClipboardSheetDefs.Refresh().FindAll(x => x.SheetDefNum > 0);
			var existingClinic=existingAll.FindAll(x => x.ClinicNum==clinicNum);
			int items=0;
			existingClinic.ForEach(x => { x.ItemOrder=++items; });
			existingAll.Add(new EClipboardSheetDef(){
				ClinicNum=clinicNum,
				ResubmitInterval=TimeSpan.FromDays(days),
				SheetDefNum=sheetDef.SheetDefNum,
				EFormDefNum=0, //Always 0 for Sheets
				ItemOrder=++items,
				PrefillStatus=PrefillStatuses.New,
				MinAge=minAge,
				MaxAge=maxAge,
			});
			//Removes any EClipboardSheetDefs that are not Sheets (that means EForms rules will be deleted).
			EClipboardSheetDefs.Sync(existingAll,EClipboardSheetDefs.Refresh());
			EFormDefs.RefreshCache();
			EFormFieldDefs.RefreshCache();
			SheetDefs.RefreshCache();
			SheetFieldDefs.RefreshCache();
			return sheetDef;
		}
	}
}
