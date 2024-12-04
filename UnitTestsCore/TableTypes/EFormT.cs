﻿using CodeBase;
using OpenDentBusiness;
using System;
using System.Collections.Generic;

namespace UnitTestsCore {
	///<summary>Has methods for both Sheet and SheetField. Use SheetDefT for defs.</summary>
	public class EFormT {

		///<summary>Allows for the creation of a new EForms with control over key fields, does insert to the DB.</summary>
		public static EForm CreateEForm(long eFormDefNum,List<EFormField> listEFormFields, long patNum,EnumEFormStatus status,EnumEFormType formType=EnumEFormType.PatientForm,string description="") {
			EForm eForm=new EForm {
				EFormDefNum=eFormDefNum,
				ListEFormFields=listEFormFields,
				DateTEdited=DateTime_.Now,
				DateTimeShown=DateTime_.Now,
				FormType=formType,
				Status=status,
				PatNum=patNum,
				Description=description,
			};
			eForm.EFormNum=EForms.Insert(eForm);
			return eForm;
		}

		///<summary>Creates a list of EFormFields for a given EFormFieldDef List and sets their EFormNum and PatNum.</summary>
		public static List<EFormField> CreateFieldListForEForm(List<EFormFieldDef> eFormFieldDefList,long eFormNum,long patNum) {
				List<EFormField> retVal=new List<EFormField>();
				EFormField field;
				foreach(EFormFieldDef eFormFieldDef in eFormFieldDefList) {
					field=new EFormField {
						IsNew=true,
						EFormNum=eFormNum,
						DbLink=eFormFieldDef.DbLink,
						ValueLabel=eFormFieldDef.ValueLabel,
						ValueString="",
						PickListVis=eFormFieldDef.PickListVis,
						PickListDb=eFormFieldDef.PickListDb,
						ConditionalParent=eFormFieldDef.ConditionalParent,
						ConditionalValue=eFormFieldDef.ConditionalValue,
						SpaceBelow=eFormFieldDef.SpaceBelow,
						ReportableName=eFormFieldDef.ReportableName,
						SpaceToRight=eFormFieldDef.SpaceToRight,
						Border=eFormFieldDef.Border,
						EFormFieldDefNum=eFormFieldDef.EFormFieldDefNum,
						FontScale=eFormFieldDef.FontScale,
						IsHorizStacking=eFormFieldDef.IsHorizStacking,
						IsTextWrap=eFormFieldDef.IsTextWrap,
						IsWidthPercentage=eFormFieldDef.IsWidthPercentage,
						ItemOrder=eFormFieldDef.ItemOrder,
						LabelAlign=eFormFieldDef.LabelAlign,
						MinWidth=eFormFieldDef.MinWidth,
						PatNum=patNum,
						WidthLabel=eFormFieldDef.WidthLabel,
					};
					EFormFields.Insert(field);
					retVal.Add(field);
				}
				return retVal;
			}

		///<summary>Deletes everything from the EForm and EFormField table.  Does not truncate the table so that PKs are not reused on accident.</summary>
		public static void ClearEFormAndEFormFieldTable() {
			string command="DELETE FROM eform WHERE eformnum > 0";
			DataCore.NonQ(command);
			command="DELETE FROM eformfield WHERE eformfieldnum > 0";
			DataCore.NonQ(command);
		}
	}
}