//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class EduResourceCrud {
		///<summary>Gets one EduResource object from the database using the primary key.  Returns null if not found.</summary>
		public static EduResource SelectOne(long eduResourceNum) {
			string command="SELECT * FROM eduresource "
				+"WHERE EduResourceNum = "+POut.Long(eduResourceNum);
			List<EduResource> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EduResource object from the database using a query.</summary>
		public static EduResource SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EduResource> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EduResource objects from the database using a query.</summary>
		public static List<EduResource> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EduResource> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EduResource> TableToList(DataTable table) {
			List<EduResource> retVal=new List<EduResource>();
			EduResource eduResource;
			foreach(DataRow row in table.Rows) {
				eduResource=new EduResource();
				eduResource.EduResourceNum  = PIn.Long  (row["EduResourceNum"].ToString());
				eduResource.DiseaseDefNum   = PIn.Long  (row["DiseaseDefNum"].ToString());
				eduResource.MedicationNum   = PIn.Long  (row["MedicationNum"].ToString());
				eduResource.LabResultID     = PIn.String(row["LabResultID"].ToString());
				eduResource.LabResultName   = PIn.String(row["LabResultName"].ToString());
				eduResource.LabResultCompare= PIn.String(row["LabResultCompare"].ToString());
				eduResource.ResourceUrl     = PIn.String(row["ResourceUrl"].ToString());
				eduResource.SmokingSnoMed   = PIn.String(row["SmokingSnoMed"].ToString());
				retVal.Add(eduResource);
			}
			return retVal;
		}

		///<summary>Converts a list of EduResource into a DataTable.</summary>
		public static DataTable ListToTable(List<EduResource> listEduResources,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EduResource";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EduResourceNum");
			table.Columns.Add("DiseaseDefNum");
			table.Columns.Add("MedicationNum");
			table.Columns.Add("LabResultID");
			table.Columns.Add("LabResultName");
			table.Columns.Add("LabResultCompare");
			table.Columns.Add("ResourceUrl");
			table.Columns.Add("SmokingSnoMed");
			foreach(EduResource eduResource in listEduResources) {
				table.Rows.Add(new object[] {
					POut.Long  (eduResource.EduResourceNum),
					POut.Long  (eduResource.DiseaseDefNum),
					POut.Long  (eduResource.MedicationNum),
					            eduResource.LabResultID,
					            eduResource.LabResultName,
					            eduResource.LabResultCompare,
					            eduResource.ResourceUrl,
					            eduResource.SmokingSnoMed,
				});
			}
			return table;
		}

		///<summary>Inserts one EduResource into the database.  Returns the new priKey.</summary>
		public static long Insert(EduResource eduResource) {
			return Insert(eduResource,false);
		}

		///<summary>Inserts one EduResource into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EduResource eduResource,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				eduResource.EduResourceNum=ReplicationServers.GetKey("eduresource","EduResourceNum");
			}
			string command="INSERT INTO eduresource (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EduResourceNum,";
			}
			command+="DiseaseDefNum,MedicationNum,LabResultID,LabResultName,LabResultCompare,ResourceUrl,SmokingSnoMed) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(eduResource.EduResourceNum)+",";
			}
			command+=
				     POut.Long  (eduResource.DiseaseDefNum)+","
				+    POut.Long  (eduResource.MedicationNum)+","
				+"'"+POut.String(eduResource.LabResultID)+"',"
				+"'"+POut.String(eduResource.LabResultName)+"',"
				+"'"+POut.String(eduResource.LabResultCompare)+"',"
				+"'"+POut.String(eduResource.ResourceUrl)+"',"
				+"'"+POut.String(eduResource.SmokingSnoMed)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				eduResource.EduResourceNum=Db.NonQ(command,true,"EduResourceNum","eduResource");
			}
			return eduResource.EduResourceNum;
		}

		///<summary>Inserts one EduResource into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EduResource eduResource) {
			return InsertNoCache(eduResource,false);
		}

		///<summary>Inserts one EduResource into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EduResource eduResource,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO eduresource (";
			if(!useExistingPK && isRandomKeys) {
				eduResource.EduResourceNum=ReplicationServers.GetKeyNoCache("eduresource","EduResourceNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EduResourceNum,";
			}
			command+="DiseaseDefNum,MedicationNum,LabResultID,LabResultName,LabResultCompare,ResourceUrl,SmokingSnoMed) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(eduResource.EduResourceNum)+",";
			}
			command+=
				     POut.Long  (eduResource.DiseaseDefNum)+","
				+    POut.Long  (eduResource.MedicationNum)+","
				+"'"+POut.String(eduResource.LabResultID)+"',"
				+"'"+POut.String(eduResource.LabResultName)+"',"
				+"'"+POut.String(eduResource.LabResultCompare)+"',"
				+"'"+POut.String(eduResource.ResourceUrl)+"',"
				+"'"+POut.String(eduResource.SmokingSnoMed)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				eduResource.EduResourceNum=Db.NonQ(command,true,"EduResourceNum","eduResource");
			}
			return eduResource.EduResourceNum;
		}

		///<summary>Updates one EduResource in the database.</summary>
		public static void Update(EduResource eduResource) {
			string command="UPDATE eduresource SET "
				+"DiseaseDefNum   =  "+POut.Long  (eduResource.DiseaseDefNum)+", "
				+"MedicationNum   =  "+POut.Long  (eduResource.MedicationNum)+", "
				+"LabResultID     = '"+POut.String(eduResource.LabResultID)+"', "
				+"LabResultName   = '"+POut.String(eduResource.LabResultName)+"', "
				+"LabResultCompare= '"+POut.String(eduResource.LabResultCompare)+"', "
				+"ResourceUrl     = '"+POut.String(eduResource.ResourceUrl)+"', "
				+"SmokingSnoMed   = '"+POut.String(eduResource.SmokingSnoMed)+"' "
				+"WHERE EduResourceNum = "+POut.Long(eduResource.EduResourceNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EduResource in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EduResource eduResource,EduResource oldEduResource) {
			string command="";
			if(eduResource.DiseaseDefNum != oldEduResource.DiseaseDefNum) {
				if(command!="") { command+=",";}
				command+="DiseaseDefNum = "+POut.Long(eduResource.DiseaseDefNum)+"";
			}
			if(eduResource.MedicationNum != oldEduResource.MedicationNum) {
				if(command!="") { command+=",";}
				command+="MedicationNum = "+POut.Long(eduResource.MedicationNum)+"";
			}
			if(eduResource.LabResultID != oldEduResource.LabResultID) {
				if(command!="") { command+=",";}
				command+="LabResultID = '"+POut.String(eduResource.LabResultID)+"'";
			}
			if(eduResource.LabResultName != oldEduResource.LabResultName) {
				if(command!="") { command+=",";}
				command+="LabResultName = '"+POut.String(eduResource.LabResultName)+"'";
			}
			if(eduResource.LabResultCompare != oldEduResource.LabResultCompare) {
				if(command!="") { command+=",";}
				command+="LabResultCompare = '"+POut.String(eduResource.LabResultCompare)+"'";
			}
			if(eduResource.ResourceUrl != oldEduResource.ResourceUrl) {
				if(command!="") { command+=",";}
				command+="ResourceUrl = '"+POut.String(eduResource.ResourceUrl)+"'";
			}
			if(eduResource.SmokingSnoMed != oldEduResource.SmokingSnoMed) {
				if(command!="") { command+=",";}
				command+="SmokingSnoMed = '"+POut.String(eduResource.SmokingSnoMed)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE eduresource SET "+command
				+" WHERE EduResourceNum = "+POut.Long(eduResource.EduResourceNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(EduResource,EduResource) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EduResource eduResource,EduResource oldEduResource) {
			if(eduResource.DiseaseDefNum != oldEduResource.DiseaseDefNum) {
				return true;
			}
			if(eduResource.MedicationNum != oldEduResource.MedicationNum) {
				return true;
			}
			if(eduResource.LabResultID != oldEduResource.LabResultID) {
				return true;
			}
			if(eduResource.LabResultName != oldEduResource.LabResultName) {
				return true;
			}
			if(eduResource.LabResultCompare != oldEduResource.LabResultCompare) {
				return true;
			}
			if(eduResource.ResourceUrl != oldEduResource.ResourceUrl) {
				return true;
			}
			if(eduResource.SmokingSnoMed != oldEduResource.SmokingSnoMed) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EduResource from the database.</summary>
		public static void Delete(long eduResourceNum) {
			string command="DELETE FROM eduresource "
				+"WHERE EduResourceNum = "+POut.Long(eduResourceNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many EduResources from the database.</summary>
		public static void DeleteMany(List<long> listEduResourceNums) {
			if(listEduResourceNums==null || listEduResourceNums.Count==0) {
				return;
			}
			string command="DELETE FROM eduresource "
				+"WHERE EduResourceNum IN("+string.Join(",",listEduResourceNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}