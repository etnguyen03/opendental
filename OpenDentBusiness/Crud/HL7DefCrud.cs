//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class HL7DefCrud {
		///<summary>Gets one HL7Def object from the database using the primary key.  Returns null if not found.</summary>
		public static HL7Def SelectOne(long hL7DefNum) {
			string command="SELECT * FROM hl7def "
				+"WHERE HL7DefNum = "+POut.Long(hL7DefNum);
			List<HL7Def> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one HL7Def object from the database using a query.</summary>
		public static HL7Def SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<HL7Def> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of HL7Def objects from the database using a query.</summary>
		public static List<HL7Def> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<HL7Def> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<HL7Def> TableToList(DataTable table) {
			List<HL7Def> retVal=new List<HL7Def>();
			HL7Def hL7Def;
			foreach(DataRow row in table.Rows) {
				hL7Def=new HL7Def();
				hL7Def.HL7DefNum            = PIn.Long  (row["HL7DefNum"].ToString());
				hL7Def.Description          = PIn.String(row["Description"].ToString());
				hL7Def.ModeTx               = (OpenDentBusiness.ModeTxHL7)PIn.Int(row["ModeTx"].ToString());
				hL7Def.IncomingFolder       = PIn.String(row["IncomingFolder"].ToString());
				hL7Def.OutgoingFolder       = PIn.String(row["OutgoingFolder"].ToString());
				hL7Def.IncomingPort         = PIn.String(row["IncomingPort"].ToString());
				hL7Def.OutgoingIpPort       = PIn.String(row["OutgoingIpPort"].ToString());
				hL7Def.FieldSeparator       = PIn.String(row["FieldSeparator"].ToString());
				hL7Def.ComponentSeparator   = PIn.String(row["ComponentSeparator"].ToString());
				hL7Def.SubcomponentSeparator= PIn.String(row["SubcomponentSeparator"].ToString());
				hL7Def.RepetitionSeparator  = PIn.String(row["RepetitionSeparator"].ToString());
				hL7Def.EscapeCharacter      = PIn.String(row["EscapeCharacter"].ToString());
				hL7Def.IsInternal           = PIn.Bool  (row["IsInternal"].ToString());
				string internalType=row["InternalType"].ToString();
				if(internalType=="") {
					hL7Def.InternalType       =(OpenDentBusiness.HL7InternalType)0;
				}
				else try{
					hL7Def.InternalType       =(OpenDentBusiness.HL7InternalType)Enum.Parse(typeof(OpenDentBusiness.HL7InternalType),internalType);
				}
				catch{
					hL7Def.InternalType       =(OpenDentBusiness.HL7InternalType)0;
				}
				hL7Def.InternalTypeVersion  = PIn.String(row["InternalTypeVersion"].ToString());
				hL7Def.IsEnabled            = PIn.Bool  (row["IsEnabled"].ToString());
				hL7Def.Note                 = PIn.String(row["Note"].ToString());
				hL7Def.HL7Server            = PIn.String(row["HL7Server"].ToString());
				hL7Def.HL7ServiceName       = PIn.String(row["HL7ServiceName"].ToString());
				hL7Def.ShowDemographics     = (OpenDentBusiness.HL7ShowDemographics)PIn.Int(row["ShowDemographics"].ToString());
				hL7Def.ShowAppts            = PIn.Bool  (row["ShowAppts"].ToString());
				hL7Def.ShowAccount          = PIn.Bool  (row["ShowAccount"].ToString());
				hL7Def.IsQuadAsToothNum     = PIn.Bool  (row["IsQuadAsToothNum"].ToString());
				hL7Def.LabResultImageCat    = PIn.Long  (row["LabResultImageCat"].ToString());
				hL7Def.SftpUsername         = PIn.String(row["SftpUsername"].ToString());
				hL7Def.SftpPassword         = PIn.String(row["SftpPassword"].ToString());
				hL7Def.SftpInSocket         = PIn.String(row["SftpInSocket"].ToString());
				hL7Def.HasLongDCodes        = PIn.Bool  (row["HasLongDCodes"].ToString());
				hL7Def.IsProcApptEnforced   = PIn.Bool  (row["IsProcApptEnforced"].ToString());
				retVal.Add(hL7Def);
			}
			return retVal;
		}

		///<summary>Converts a list of HL7Def into a DataTable.</summary>
		public static DataTable ListToTable(List<HL7Def> listHL7Defs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="HL7Def";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("HL7DefNum");
			table.Columns.Add("Description");
			table.Columns.Add("ModeTx");
			table.Columns.Add("IncomingFolder");
			table.Columns.Add("OutgoingFolder");
			table.Columns.Add("IncomingPort");
			table.Columns.Add("OutgoingIpPort");
			table.Columns.Add("FieldSeparator");
			table.Columns.Add("ComponentSeparator");
			table.Columns.Add("SubcomponentSeparator");
			table.Columns.Add("RepetitionSeparator");
			table.Columns.Add("EscapeCharacter");
			table.Columns.Add("IsInternal");
			table.Columns.Add("InternalType");
			table.Columns.Add("InternalTypeVersion");
			table.Columns.Add("IsEnabled");
			table.Columns.Add("Note");
			table.Columns.Add("HL7Server");
			table.Columns.Add("HL7ServiceName");
			table.Columns.Add("ShowDemographics");
			table.Columns.Add("ShowAppts");
			table.Columns.Add("ShowAccount");
			table.Columns.Add("IsQuadAsToothNum");
			table.Columns.Add("LabResultImageCat");
			table.Columns.Add("SftpUsername");
			table.Columns.Add("SftpPassword");
			table.Columns.Add("SftpInSocket");
			table.Columns.Add("HasLongDCodes");
			table.Columns.Add("IsProcApptEnforced");
			foreach(HL7Def hL7Def in listHL7Defs) {
				table.Rows.Add(new object[] {
					POut.Long  (hL7Def.HL7DefNum),
					            hL7Def.Description,
					POut.Int   ((int)hL7Def.ModeTx),
					            hL7Def.IncomingFolder,
					            hL7Def.OutgoingFolder,
					            hL7Def.IncomingPort,
					            hL7Def.OutgoingIpPort,
					            hL7Def.FieldSeparator,
					            hL7Def.ComponentSeparator,
					            hL7Def.SubcomponentSeparator,
					            hL7Def.RepetitionSeparator,
					            hL7Def.EscapeCharacter,
					POut.Bool  (hL7Def.IsInternal),
					POut.Int   ((int)hL7Def.InternalType),
					            hL7Def.InternalTypeVersion,
					POut.Bool  (hL7Def.IsEnabled),
					            hL7Def.Note,
					            hL7Def.HL7Server,
					            hL7Def.HL7ServiceName,
					POut.Int   ((int)hL7Def.ShowDemographics),
					POut.Bool  (hL7Def.ShowAppts),
					POut.Bool  (hL7Def.ShowAccount),
					POut.Bool  (hL7Def.IsQuadAsToothNum),
					POut.Long  (hL7Def.LabResultImageCat),
					            hL7Def.SftpUsername,
					            hL7Def.SftpPassword,
					            hL7Def.SftpInSocket,
					POut.Bool  (hL7Def.HasLongDCodes),
					POut.Bool  (hL7Def.IsProcApptEnforced),
				});
			}
			return table;
		}

		///<summary>Inserts one HL7Def into the database.  Returns the new priKey.</summary>
		public static long Insert(HL7Def hL7Def) {
			return Insert(hL7Def,false);
		}

		///<summary>Inserts one HL7Def into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(HL7Def hL7Def,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				hL7Def.HL7DefNum=ReplicationServers.GetKey("hl7def","HL7DefNum");
			}
			string command="INSERT INTO hl7def (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="HL7DefNum,";
			}
			command+="Description,ModeTx,IncomingFolder,OutgoingFolder,IncomingPort,OutgoingIpPort,FieldSeparator,ComponentSeparator,SubcomponentSeparator,RepetitionSeparator,EscapeCharacter,IsInternal,InternalType,InternalTypeVersion,IsEnabled,Note,HL7Server,HL7ServiceName,ShowDemographics,ShowAppts,ShowAccount,IsQuadAsToothNum,LabResultImageCat,SftpUsername,SftpPassword,SftpInSocket,HasLongDCodes,IsProcApptEnforced) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(hL7Def.HL7DefNum)+",";
			}
			command+=
				 "'"+POut.String(hL7Def.Description)+"',"
				+    POut.Int   ((int)hL7Def.ModeTx)+","
				+"'"+POut.String(hL7Def.IncomingFolder)+"',"
				+"'"+POut.String(hL7Def.OutgoingFolder)+"',"
				+"'"+POut.String(hL7Def.IncomingPort)+"',"
				+"'"+POut.String(hL7Def.OutgoingIpPort)+"',"
				+"'"+POut.String(hL7Def.FieldSeparator)+"',"
				+"'"+POut.String(hL7Def.ComponentSeparator)+"',"
				+"'"+POut.String(hL7Def.SubcomponentSeparator)+"',"
				+"'"+POut.String(hL7Def.RepetitionSeparator)+"',"
				+"'"+POut.String(hL7Def.EscapeCharacter)+"',"
				+    POut.Bool  (hL7Def.IsInternal)+","
				+"'"+POut.String(hL7Def.InternalType.ToString())+"',"
				+"'"+POut.String(hL7Def.InternalTypeVersion)+"',"
				+    POut.Bool  (hL7Def.IsEnabled)+","
				+    DbHelper.ParamChar+"paramNote,"
				+"'"+POut.String(hL7Def.HL7Server)+"',"
				+"'"+POut.String(hL7Def.HL7ServiceName)+"',"
				+    POut.Int   ((int)hL7Def.ShowDemographics)+","
				+    POut.Bool  (hL7Def.ShowAppts)+","
				+    POut.Bool  (hL7Def.ShowAccount)+","
				+    POut.Bool  (hL7Def.IsQuadAsToothNum)+","
				+    POut.Long  (hL7Def.LabResultImageCat)+","
				+"'"+POut.String(hL7Def.SftpUsername)+"',"
				+"'"+POut.String(hL7Def.SftpPassword)+"',"
				+"'"+POut.String(hL7Def.SftpInSocket)+"',"
				+    POut.Bool  (hL7Def.HasLongDCodes)+","
				+    POut.Bool  (hL7Def.IsProcApptEnforced)+")";
			if(hL7Def.Note==null) {
				hL7Def.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(hL7Def.Note));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramNote);
			}
			else {
				hL7Def.HL7DefNum=Db.NonQ(command,true,"HL7DefNum","hL7Def",paramNote);
			}
			return hL7Def.HL7DefNum;
		}

		///<summary>Inserts one HL7Def into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(HL7Def hL7Def) {
			return InsertNoCache(hL7Def,false);
		}

		///<summary>Inserts one HL7Def into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(HL7Def hL7Def,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO hl7def (";
			if(!useExistingPK && isRandomKeys) {
				hL7Def.HL7DefNum=ReplicationServers.GetKeyNoCache("hl7def","HL7DefNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="HL7DefNum,";
			}
			command+="Description,ModeTx,IncomingFolder,OutgoingFolder,IncomingPort,OutgoingIpPort,FieldSeparator,ComponentSeparator,SubcomponentSeparator,RepetitionSeparator,EscapeCharacter,IsInternal,InternalType,InternalTypeVersion,IsEnabled,Note,HL7Server,HL7ServiceName,ShowDemographics,ShowAppts,ShowAccount,IsQuadAsToothNum,LabResultImageCat,SftpUsername,SftpPassword,SftpInSocket,HasLongDCodes,IsProcApptEnforced) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(hL7Def.HL7DefNum)+",";
			}
			command+=
				 "'"+POut.String(hL7Def.Description)+"',"
				+    POut.Int   ((int)hL7Def.ModeTx)+","
				+"'"+POut.String(hL7Def.IncomingFolder)+"',"
				+"'"+POut.String(hL7Def.OutgoingFolder)+"',"
				+"'"+POut.String(hL7Def.IncomingPort)+"',"
				+"'"+POut.String(hL7Def.OutgoingIpPort)+"',"
				+"'"+POut.String(hL7Def.FieldSeparator)+"',"
				+"'"+POut.String(hL7Def.ComponentSeparator)+"',"
				+"'"+POut.String(hL7Def.SubcomponentSeparator)+"',"
				+"'"+POut.String(hL7Def.RepetitionSeparator)+"',"
				+"'"+POut.String(hL7Def.EscapeCharacter)+"',"
				+    POut.Bool  (hL7Def.IsInternal)+","
				+"'"+POut.String(hL7Def.InternalType.ToString())+"',"
				+"'"+POut.String(hL7Def.InternalTypeVersion)+"',"
				+    POut.Bool  (hL7Def.IsEnabled)+","
				+    DbHelper.ParamChar+"paramNote,"
				+"'"+POut.String(hL7Def.HL7Server)+"',"
				+"'"+POut.String(hL7Def.HL7ServiceName)+"',"
				+    POut.Int   ((int)hL7Def.ShowDemographics)+","
				+    POut.Bool  (hL7Def.ShowAppts)+","
				+    POut.Bool  (hL7Def.ShowAccount)+","
				+    POut.Bool  (hL7Def.IsQuadAsToothNum)+","
				+    POut.Long  (hL7Def.LabResultImageCat)+","
				+"'"+POut.String(hL7Def.SftpUsername)+"',"
				+"'"+POut.String(hL7Def.SftpPassword)+"',"
				+"'"+POut.String(hL7Def.SftpInSocket)+"',"
				+    POut.Bool  (hL7Def.HasLongDCodes)+","
				+    POut.Bool  (hL7Def.IsProcApptEnforced)+")";
			if(hL7Def.Note==null) {
				hL7Def.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(hL7Def.Note));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramNote);
			}
			else {
				hL7Def.HL7DefNum=Db.NonQ(command,true,"HL7DefNum","hL7Def",paramNote);
			}
			return hL7Def.HL7DefNum;
		}

		///<summary>Updates one HL7Def in the database.</summary>
		public static void Update(HL7Def hL7Def) {
			string command="UPDATE hl7def SET "
				+"Description          = '"+POut.String(hL7Def.Description)+"', "
				+"ModeTx               =  "+POut.Int   ((int)hL7Def.ModeTx)+", "
				+"IncomingFolder       = '"+POut.String(hL7Def.IncomingFolder)+"', "
				+"OutgoingFolder       = '"+POut.String(hL7Def.OutgoingFolder)+"', "
				+"IncomingPort         = '"+POut.String(hL7Def.IncomingPort)+"', "
				+"OutgoingIpPort       = '"+POut.String(hL7Def.OutgoingIpPort)+"', "
				+"FieldSeparator       = '"+POut.String(hL7Def.FieldSeparator)+"', "
				+"ComponentSeparator   = '"+POut.String(hL7Def.ComponentSeparator)+"', "
				+"SubcomponentSeparator= '"+POut.String(hL7Def.SubcomponentSeparator)+"', "
				+"RepetitionSeparator  = '"+POut.String(hL7Def.RepetitionSeparator)+"', "
				+"EscapeCharacter      = '"+POut.String(hL7Def.EscapeCharacter)+"', "
				+"IsInternal           =  "+POut.Bool  (hL7Def.IsInternal)+", "
				+"InternalType         = '"+POut.String(hL7Def.InternalType.ToString())+"', "
				+"InternalTypeVersion  = '"+POut.String(hL7Def.InternalTypeVersion)+"', "
				+"IsEnabled            =  "+POut.Bool  (hL7Def.IsEnabled)+", "
				+"Note                 =  "+DbHelper.ParamChar+"paramNote, "
				+"HL7Server            = '"+POut.String(hL7Def.HL7Server)+"', "
				+"HL7ServiceName       = '"+POut.String(hL7Def.HL7ServiceName)+"', "
				+"ShowDemographics     =  "+POut.Int   ((int)hL7Def.ShowDemographics)+", "
				+"ShowAppts            =  "+POut.Bool  (hL7Def.ShowAppts)+", "
				+"ShowAccount          =  "+POut.Bool  (hL7Def.ShowAccount)+", "
				+"IsQuadAsToothNum     =  "+POut.Bool  (hL7Def.IsQuadAsToothNum)+", "
				+"LabResultImageCat    =  "+POut.Long  (hL7Def.LabResultImageCat)+", "
				+"SftpUsername         = '"+POut.String(hL7Def.SftpUsername)+"', "
				+"SftpPassword         = '"+POut.String(hL7Def.SftpPassword)+"', "
				+"SftpInSocket         = '"+POut.String(hL7Def.SftpInSocket)+"', "
				+"HasLongDCodes        =  "+POut.Bool  (hL7Def.HasLongDCodes)+", "
				+"IsProcApptEnforced   =  "+POut.Bool  (hL7Def.IsProcApptEnforced)+" "
				+"WHERE HL7DefNum = "+POut.Long(hL7Def.HL7DefNum);
			if(hL7Def.Note==null) {
				hL7Def.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(hL7Def.Note));
			Db.NonQ(command,paramNote);
		}

		///<summary>Updates one HL7Def in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(HL7Def hL7Def,HL7Def oldHL7Def) {
			string command="";
			if(hL7Def.Description != oldHL7Def.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(hL7Def.Description)+"'";
			}
			if(hL7Def.ModeTx != oldHL7Def.ModeTx) {
				if(command!="") { command+=",";}
				command+="ModeTx = "+POut.Int   ((int)hL7Def.ModeTx)+"";
			}
			if(hL7Def.IncomingFolder != oldHL7Def.IncomingFolder) {
				if(command!="") { command+=",";}
				command+="IncomingFolder = '"+POut.String(hL7Def.IncomingFolder)+"'";
			}
			if(hL7Def.OutgoingFolder != oldHL7Def.OutgoingFolder) {
				if(command!="") { command+=",";}
				command+="OutgoingFolder = '"+POut.String(hL7Def.OutgoingFolder)+"'";
			}
			if(hL7Def.IncomingPort != oldHL7Def.IncomingPort) {
				if(command!="") { command+=",";}
				command+="IncomingPort = '"+POut.String(hL7Def.IncomingPort)+"'";
			}
			if(hL7Def.OutgoingIpPort != oldHL7Def.OutgoingIpPort) {
				if(command!="") { command+=",";}
				command+="OutgoingIpPort = '"+POut.String(hL7Def.OutgoingIpPort)+"'";
			}
			if(hL7Def.FieldSeparator != oldHL7Def.FieldSeparator) {
				if(command!="") { command+=",";}
				command+="FieldSeparator = '"+POut.String(hL7Def.FieldSeparator)+"'";
			}
			if(hL7Def.ComponentSeparator != oldHL7Def.ComponentSeparator) {
				if(command!="") { command+=",";}
				command+="ComponentSeparator = '"+POut.String(hL7Def.ComponentSeparator)+"'";
			}
			if(hL7Def.SubcomponentSeparator != oldHL7Def.SubcomponentSeparator) {
				if(command!="") { command+=",";}
				command+="SubcomponentSeparator = '"+POut.String(hL7Def.SubcomponentSeparator)+"'";
			}
			if(hL7Def.RepetitionSeparator != oldHL7Def.RepetitionSeparator) {
				if(command!="") { command+=",";}
				command+="RepetitionSeparator = '"+POut.String(hL7Def.RepetitionSeparator)+"'";
			}
			if(hL7Def.EscapeCharacter != oldHL7Def.EscapeCharacter) {
				if(command!="") { command+=",";}
				command+="EscapeCharacter = '"+POut.String(hL7Def.EscapeCharacter)+"'";
			}
			if(hL7Def.IsInternal != oldHL7Def.IsInternal) {
				if(command!="") { command+=",";}
				command+="IsInternal = "+POut.Bool(hL7Def.IsInternal)+"";
			}
			if(hL7Def.InternalType != oldHL7Def.InternalType) {
				if(command!="") { command+=",";}
				command+="InternalType = '"+POut.String(hL7Def.InternalType.ToString())+"'";
			}
			if(hL7Def.InternalTypeVersion != oldHL7Def.InternalTypeVersion) {
				if(command!="") { command+=",";}
				command+="InternalTypeVersion = '"+POut.String(hL7Def.InternalTypeVersion)+"'";
			}
			if(hL7Def.IsEnabled != oldHL7Def.IsEnabled) {
				if(command!="") { command+=",";}
				command+="IsEnabled = "+POut.Bool(hL7Def.IsEnabled)+"";
			}
			if(hL7Def.Note != oldHL7Def.Note) {
				if(command!="") { command+=",";}
				command+="Note = "+DbHelper.ParamChar+"paramNote";
			}
			if(hL7Def.HL7Server != oldHL7Def.HL7Server) {
				if(command!="") { command+=",";}
				command+="HL7Server = '"+POut.String(hL7Def.HL7Server)+"'";
			}
			if(hL7Def.HL7ServiceName != oldHL7Def.HL7ServiceName) {
				if(command!="") { command+=",";}
				command+="HL7ServiceName = '"+POut.String(hL7Def.HL7ServiceName)+"'";
			}
			if(hL7Def.ShowDemographics != oldHL7Def.ShowDemographics) {
				if(command!="") { command+=",";}
				command+="ShowDemographics = "+POut.Int   ((int)hL7Def.ShowDemographics)+"";
			}
			if(hL7Def.ShowAppts != oldHL7Def.ShowAppts) {
				if(command!="") { command+=",";}
				command+="ShowAppts = "+POut.Bool(hL7Def.ShowAppts)+"";
			}
			if(hL7Def.ShowAccount != oldHL7Def.ShowAccount) {
				if(command!="") { command+=",";}
				command+="ShowAccount = "+POut.Bool(hL7Def.ShowAccount)+"";
			}
			if(hL7Def.IsQuadAsToothNum != oldHL7Def.IsQuadAsToothNum) {
				if(command!="") { command+=",";}
				command+="IsQuadAsToothNum = "+POut.Bool(hL7Def.IsQuadAsToothNum)+"";
			}
			if(hL7Def.LabResultImageCat != oldHL7Def.LabResultImageCat) {
				if(command!="") { command+=",";}
				command+="LabResultImageCat = "+POut.Long(hL7Def.LabResultImageCat)+"";
			}
			if(hL7Def.SftpUsername != oldHL7Def.SftpUsername) {
				if(command!="") { command+=",";}
				command+="SftpUsername = '"+POut.String(hL7Def.SftpUsername)+"'";
			}
			if(hL7Def.SftpPassword != oldHL7Def.SftpPassword) {
				if(command!="") { command+=",";}
				command+="SftpPassword = '"+POut.String(hL7Def.SftpPassword)+"'";
			}
			if(hL7Def.SftpInSocket != oldHL7Def.SftpInSocket) {
				if(command!="") { command+=",";}
				command+="SftpInSocket = '"+POut.String(hL7Def.SftpInSocket)+"'";
			}
			if(hL7Def.HasLongDCodes != oldHL7Def.HasLongDCodes) {
				if(command!="") { command+=",";}
				command+="HasLongDCodes = "+POut.Bool(hL7Def.HasLongDCodes)+"";
			}
			if(hL7Def.IsProcApptEnforced != oldHL7Def.IsProcApptEnforced) {
				if(command!="") { command+=",";}
				command+="IsProcApptEnforced = "+POut.Bool(hL7Def.IsProcApptEnforced)+"";
			}
			if(command=="") {
				return false;
			}
			if(hL7Def.Note==null) {
				hL7Def.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(hL7Def.Note));
			command="UPDATE hl7def SET "+command
				+" WHERE HL7DefNum = "+POut.Long(hL7Def.HL7DefNum);
			Db.NonQ(command,paramNote);
			return true;
		}

		///<summary>Returns true if Update(HL7Def,HL7Def) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(HL7Def hL7Def,HL7Def oldHL7Def) {
			if(hL7Def.Description != oldHL7Def.Description) {
				return true;
			}
			if(hL7Def.ModeTx != oldHL7Def.ModeTx) {
				return true;
			}
			if(hL7Def.IncomingFolder != oldHL7Def.IncomingFolder) {
				return true;
			}
			if(hL7Def.OutgoingFolder != oldHL7Def.OutgoingFolder) {
				return true;
			}
			if(hL7Def.IncomingPort != oldHL7Def.IncomingPort) {
				return true;
			}
			if(hL7Def.OutgoingIpPort != oldHL7Def.OutgoingIpPort) {
				return true;
			}
			if(hL7Def.FieldSeparator != oldHL7Def.FieldSeparator) {
				return true;
			}
			if(hL7Def.ComponentSeparator != oldHL7Def.ComponentSeparator) {
				return true;
			}
			if(hL7Def.SubcomponentSeparator != oldHL7Def.SubcomponentSeparator) {
				return true;
			}
			if(hL7Def.RepetitionSeparator != oldHL7Def.RepetitionSeparator) {
				return true;
			}
			if(hL7Def.EscapeCharacter != oldHL7Def.EscapeCharacter) {
				return true;
			}
			if(hL7Def.IsInternal != oldHL7Def.IsInternal) {
				return true;
			}
			if(hL7Def.InternalType != oldHL7Def.InternalType) {
				return true;
			}
			if(hL7Def.InternalTypeVersion != oldHL7Def.InternalTypeVersion) {
				return true;
			}
			if(hL7Def.IsEnabled != oldHL7Def.IsEnabled) {
				return true;
			}
			if(hL7Def.Note != oldHL7Def.Note) {
				return true;
			}
			if(hL7Def.HL7Server != oldHL7Def.HL7Server) {
				return true;
			}
			if(hL7Def.HL7ServiceName != oldHL7Def.HL7ServiceName) {
				return true;
			}
			if(hL7Def.ShowDemographics != oldHL7Def.ShowDemographics) {
				return true;
			}
			if(hL7Def.ShowAppts != oldHL7Def.ShowAppts) {
				return true;
			}
			if(hL7Def.ShowAccount != oldHL7Def.ShowAccount) {
				return true;
			}
			if(hL7Def.IsQuadAsToothNum != oldHL7Def.IsQuadAsToothNum) {
				return true;
			}
			if(hL7Def.LabResultImageCat != oldHL7Def.LabResultImageCat) {
				return true;
			}
			if(hL7Def.SftpUsername != oldHL7Def.SftpUsername) {
				return true;
			}
			if(hL7Def.SftpPassword != oldHL7Def.SftpPassword) {
				return true;
			}
			if(hL7Def.SftpInSocket != oldHL7Def.SftpInSocket) {
				return true;
			}
			if(hL7Def.HasLongDCodes != oldHL7Def.HasLongDCodes) {
				return true;
			}
			if(hL7Def.IsProcApptEnforced != oldHL7Def.IsProcApptEnforced) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one HL7Def from the database.</summary>
		public static void Delete(long hL7DefNum) {
			string command="DELETE FROM hl7def "
				+"WHERE HL7DefNum = "+POut.Long(hL7DefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many HL7Defs from the database.</summary>
		public static void DeleteMany(List<long> listHL7DefNums) {
			if(listHL7DefNums==null || listHL7DefNums.Count==0) {
				return;
			}
			string command="DELETE FROM hl7def "
				+"WHERE HL7DefNum IN("+string.Join(",",listHL7DefNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}