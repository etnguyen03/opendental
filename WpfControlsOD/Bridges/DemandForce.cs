﻿using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using System.Xml;
using System.Collections.Generic;
using System.Threading;
using CodeBase;
using OpenDental.UI;

namespace OpenDental.Bridges {
	///<summary></summary>
	public class DemandForce {
		private static string _path;

		///<summary></summary>
		public DemandForce() {
		}

		///<summary></summary>
		public static void SendData(Program ProgramCur,Patient pat) {
			_path=Programs.GetProgramPath(Programs.GetCur(ProgramName.DemandForce));
			if(!File.Exists(_path)) {
				MessageBox.Show(_path+" could not be found.");
				return;
			}
			if(MessageBox.Show(Lang.g("DemandForce","This may take 20 minutes or longer")+".  "+Lang.g("DemandForce","Continue")+"?","",MessageBoxButtons.OKCancel)!=DialogResult.OK) {
				return;
			}
			ProgressWin progressWin=new ProgressWin();
			progressWin.ActionMain=() => InstanceBridgeExport();
			progressWin.ShowDialog();
			if(progressWin.IsCancelled){
				MessageBox.Show(Lang.g("DemandForce","Export cancelled")+". "+Lang.g("DemandForce","Partially created file has been deleted")+".");
				CheckCreatedFile(CodeBase.ODFileUtils.CombinePaths(Path.GetDirectoryName(_path),"extract.xml"));
				return;
			}
			MessageBox.Show(Lang.g("DemandForce","Export complete")+". "+Lang.g("DemandForce","Press OK to launch DemandForce")+".");
			try {
				ODFileUtils.ProcessStart(_path);//We might have to add extract.xml to launch command in the future.
			}
			catch {
				MessageBox.Show(_path+" is not available.");
			}
		}


		private static void InstanceBridgeExport() {
			string dir=Path.GetDirectoryName(_path);
			string extract=CodeBase.ODFileUtils.CombinePaths(dir,"extract.xml");
			CheckCreatedFile(extract);
			double linesProcessedCount=0;
			string licenseKey=ProgramProperties.GetPropVal(Programs.GetProgramNum(ProgramName.DemandForce),"Enter your DemandForce license key (required)");
			string versionCur=new Version(Application.ProductVersion).ToString();
			string extractDateTime=DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffK");
			Dictionary<long,DateTime> dateLastVisit=Appointments.GetDateLastVisit();
			Dictionary<long,List<Appointment>> allPatApts=Appointments.GetAptsForPats(DateTime.Now.ToUniversalTime(),DateTime.Now.AddDays(210).ToUniversalTime());//appointments from todays date forward 210 days
			Dictionary<long,List<long>> allAptProcNums=Appointments.GetCodeNumsAllApts();
			long[] arrayPatNums=Patients.GetAllPatNums(false);
			Patient patient;
			Appointment apt;
			List<Appointment> listApts;
			List<long> listProcNums;
			double totalLines=CalculateTotalLinesOfCode(arrayPatNums,allAptProcNums,allPatApts);
			ODEvent.Fire(ODEventType.ProgressBar,"Executing the bridge to DemandForce");
			try {
				StringBuilder strb=new StringBuilder();
				XmlWriterSettings settings=new XmlWriterSettings();
				settings.Encoding=Encoding.UTF8;
				settings.Indent=true;
				settings.IndentChars="   ";
				settings.NewLineChars="\r\n";
				settings.OmitXmlDeclaration=true;
				XmlWriter writer=XmlWriter.Create(strb,settings);
				writer.WriteRaw("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
				writer.WriteStartElement("DemandForce");
				writer.WriteAttributeString("licenseKey",licenseKey);
				writer.WriteAttributeString("scope","full");
				writer.WriteStartElement("Business");
				writer.WriteStartElement("Extract");
				writer.WriteAttributeString("extractDateTime",extractDateTime);
				writer.WriteAttributeString("managementSystemName","Open Dental");
				writer.WriteAttributeString("managementSystemVersion",versionCur);
				writer.WriteEndElement();//Extract
				for(int i=0;i<arrayPatNums.Length;i++) {
					patient=Patients.GetPat(arrayPatNums[i]);
					writer.WriteStartElement("Customer");
					writer.WriteAttributeString("id",patient.PatNum.ToString());
					if(patient.ChartNumber!="") {
						writer.WriteAttributeString("chartId",patient.ChartNumber);
					}
					if(dateLastVisit.ContainsKey(patient.PatNum)) {//Need input. Will it ever be null? Or will it check empty string? 
						writer.WriteAttributeString("lastVisit",dateLastVisit[patient.PatNum].ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
					}
					else {
						writer.WriteAttributeString("lastVisit",PIn.DateT("0001-01-01 00:00:00").ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
					}
					writer.WriteStartElement("Demographics");
					if(patient.FName!="") {
						writer.WriteAttributeString("firstName",patient.FName);
					}
					else {
						writer.WriteAttributeString("firstName","X");//need input on what to do with patients who don't have a FName.
					}
					writer.WriteAttributeString("lastName",patient.LName);
					if(patient.Gender.ToString()=="Female") {
						writer.WriteAttributeString("gender","Female");
					}
					else {
						writer.WriteAttributeString("gender","Male");
					}
					if(patient.Birthdate.Year>1880) {
						writer.WriteAttributeString("birthday",patient.Birthdate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
					}
					if(patient.Address!="") {
						writer.WriteAttributeString("address1",patient.Address);
					}
					if(patient.City!="") {
						writer.WriteAttributeString("city",patient.City);
					}
					if(patient.State!="") {
						writer.WriteAttributeString("State",patient.State);
					}
					if(patient.Zip!="") {
						writer.WriteAttributeString("Zip",patient.Zip);
					}
					if(patient.Email!="") {
						writer.WriteAttributeString("Email",patient.Email);
					}
					writer.WriteEndElement();//Demographics
					if(allPatApts.ContainsKey(patient.PatNum)) {
						listApts=allPatApts[patient.PatNum];
						for(int j=0;j<listApts.Count;j++) {
							apt=listApts[j];
							writer.WriteStartElement("Appointment");
							writer.WriteAttributeString("id",apt.AptNum.ToString());
							if(apt.AptStatus.ToString()=="Complete") {
								writer.WriteAttributeString("status","1");
							}
							else {
								writer.WriteAttributeString("status","3");
							}
							if(Defs.GetDef(DefCat.ApptConfirmed,apt.Confirmed).ItemName.ToLower()=="unconfirmed") {
								writer.WriteAttributeString("confirmed","0");
							}
							else {
								writer.WriteAttributeString("confirmed","1");
							}
							writer.WriteAttributeString("date",apt.AptDateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
							writer.WriteAttributeString("duration",(apt.Pattern.Length*5).ToString());
							if(allAptProcNums.ContainsKey(apt.AptNum)) {
								listProcNums=allAptProcNums[apt.AptNum];
								string codes="";
								for(int k=0;k<listProcNums.Count;k++) {
									codes+=ProcedureCodes.GetStringProcCode(listProcNums[k]);
									if(k<listProcNums.Count-1) {
										codes+=", ";
									}
									if(linesProcessedCount<totalLines) {//this avoids setting progress bar to max, which would close the dialog.
										string strProg="Creating export file: "
											+(linesProcessedCount/totalLines*100).ToString("f")
											+" % of 100 % completed";
										ODEvent.Fire(ODEventType.ProgressBar,strProg);
									}
									linesProcessedCount+=2;
								}
								if(codes!="") {
									writer.WriteAttributeString("code",codes);
								}
							}
							writer.WriteEndElement();//Appointment
							if(linesProcessedCount<totalLines) {//this avoids setting progress bar to max, which would close the dialog.
								string strProg="Creating export file: "
									+(linesProcessedCount/totalLines*100).ToString("f")
									+" % of 100 % completed";
								ODEvent.Fire(ODEventType.ProgressBar,strProg);
							}
							linesProcessedCount+=12;
						}
					}
					writer.WriteEndElement();//Customer
					if(linesProcessedCount<totalLines) {//this avoids setting progress bar to max, which would close the dialog.
						string strProg="Creating export file: "
							+(linesProcessedCount/totalLines*100).ToString("f")
							+" % of 100 % completed";
						ODEvent.Fire(ODEventType.ProgressBar,strProg);
					}
					linesProcessedCount+=20;
				}
				writer.WriteEndElement();//Business
				writer.WriteEndElement();//DemandForce
				writer.Flush();
				writer.Close();
				ODFileUtils.WriteAllText(extract,strb.ToString());
			}
			catch {
				MessageBox.Show(Lang.g("DemandForce","Export file creation failed")+". "+Lang.g("DemandForce","User may not have sufficient permissions")+".");
			}
			MsgBox.Show("Done");
		}

		///<summary>Checks to see if the file about to be created/recreated already exists and deletes it if it does exist.</summary>
		private static void CheckCreatedFile(string fileloc) {
			if(File.Exists(fileloc)) {
				try {
					File.Delete(fileloc);
				}
				catch(Exception ex) {
					ex.DoNothing();
				}
			}
		}

		///<summary>Calculates how many total lines of code the program will go through when creating the export.xml file.</summary>
		private static double CalculateTotalLinesOfCode(long[] patNums,Dictionary<long,List<long>> allAptProcNums,Dictionary<long,List<Appointment>> allPatApts) {
			double totalLines=0;
			Patient patient;
			Appointment apt;
			List<Appointment> listApts;
			List<long> procNums;
			for(int i=0;i<patNums.Length;i++) {
				patient=Patients.GetPat(patNums[i]);
				if(allPatApts.ContainsKey(patient.PatNum)) {
					listApts=allPatApts[patient.PatNum];
					for(int j=0;j<listApts.Count;j++) {
						apt=listApts[j];
						if(allAptProcNums.ContainsKey(apt.AptNum)) {
							procNums=allAptProcNums[apt.AptNum];
							for(int k=0;k<procNums.Count;k++) {
								totalLines+=2;
							}
						}
					}
					totalLines+=12;
				}
				totalLines+=20;
			}
			return totalLines;
		}

		///<summary>Removes semicolons and spaces.</summary>
		private static string Tidy(string input) {
			string retVal=input.Replace(";","");//get rid of any semicolons.
			retVal=retVal.Replace(" ","");
			return retVal;
		}

		//private static void PassPercentProgressToDialog(double currentVal,string displayText,double maxVal,string errorMessage) {
		//	_formProg.CurrentVal=currentVal;
		//	_formProg.DisplayText=displayText;
		//	_formProg.MaxVal=maxVal;
		//	_formProg.ErrorMessage=errorMessage;
		//}

		//private delegate void PassPercentProgressDelegate(double newCurVal,string newDisplayText,double newMaxVal,string errorMessage);

	}
}


