using CodeBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenDentBusiness {
	public class EFormInternal {

		public static List<EFormDef> GetAllInternal() {
			List<EFormDef> listEFormDefs=new List<EFormDef>();
			listEFormDefs.Add(GetEFormDef(EnumEFormInternalType.PatientRegistration));
			listEFormDefs.Add(GetEFormDef(EnumEFormInternalType.MedicalHist));
			listEFormDefs.Add(GetEFormDef(EnumEFormInternalType.Consent));
			//Only show the internal Demo EForm in Debug mode.
			//I think maybe this is no longer useful.
			//if(ODBuild.IsDebug()) {
			//	listEFormDefs.Add(GetEFormDef(EnumEFormInternalType.Demo));
			//}
			return listEFormDefs;
		}

		public static EFormDef GetEFormDef(EnumEFormInternalType eformInternalType) {
			switch(eformInternalType) {
				case EnumEFormInternalType.Demo:
					return GetEFormFromResource(Properties.Resources.EFormDemo);
				case EnumEFormInternalType.PatientRegistration:
					return GetEFormFromResource(Properties.Resources.EFormPatientRegistration);
				case EnumEFormInternalType.MedicalHist:
					return GetEFormFromResource(Properties.Resources.EFormMedicalHistory);
				case EnumEFormInternalType.Consent:
					return GetEFormFromResource(Properties.Resources.EFormExtractionConsent);
				default:
					throw new ApplicationException("Invalid EnumEFormInternalType:"+eformInternalType.ToString());
			}
		}

		private static EFormDef GetEFormFromResource(string xmlDoc) {
			EFormDef eFormDef=new EFormDef();
			XmlSerializer xmlSerializer=new XmlSerializer(typeof(EFormDef));
			using TextReader textReader = new StringReader(xmlDoc);
			eFormDef=(EFormDef)xmlSerializer.Deserialize(textReader);
			for(int i=0;i<eFormDef.ListEFormFieldDefs.Count;i++){
				eFormDef.ListEFormFieldDefs[i].EFormDefNum=0;
				eFormDef.ListEFormFieldDefs[i].EFormFieldDefNum=0;
				//XML parsers are required to normalize \r\n to just \n.
				//That's a problem, because without the \r, it will display improperly in textboxes.
				//So, we convert \n that are by themselves to \r\n.
				//In the XML, line feeds (\n) within tag values simply show as white space, but we could theoretically use &#10; if we want.
				//In sheets, we were missing this for a while, so lone \n's snuck in and we have tricks to deal with those.
				//In EForms, the textbox where this would be a problem is the one in the field editor, like FrmEFormLabelEdit.cs.
				string pattern=@"(?<!\r)"//Negative lookbehind assertion. It looks for absence of \r before any \n
					+"\n";
				eFormDef.ListEFormFieldDefs[i].ValueLabel=Regex.Replace(eFormDef.ListEFormFieldDefs[i].ValueLabel,pattern,"\r\n");
			}
			eFormDef.EFormDefNum=0;
			return eFormDef;
		}
	}
}
