//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class AutomationConditionCrud {
		///<summary>Gets one AutomationCondition object from the database using the primary key.  Returns null if not found.</summary>
		public static AutomationCondition SelectOne(long automationConditionNum) {
			string command="SELECT * FROM automationcondition "
				+"WHERE AutomationConditionNum = "+POut.Long(automationConditionNum);
			List<AutomationCondition> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one AutomationCondition object from the database using a query.</summary>
		public static AutomationCondition SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<AutomationCondition> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of AutomationCondition objects from the database using a query.</summary>
		public static List<AutomationCondition> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<AutomationCondition> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<AutomationCondition> TableToList(DataTable table) {
			List<AutomationCondition> retVal=new List<AutomationCondition>();
			AutomationCondition automationCondition;
			foreach(DataRow row in table.Rows) {
				automationCondition=new AutomationCondition();
				automationCondition.AutomationConditionNum= PIn.Long  (row["AutomationConditionNum"].ToString());
				automationCondition.AutomationNum         = PIn.Long  (row["AutomationNum"].ToString());
				automationCondition.CompareField          = (OpenDentBusiness.AutoCondField)PIn.Int(row["CompareField"].ToString());
				automationCondition.Comparison            = (OpenDentBusiness.AutoCondComparison)PIn.Int(row["Comparison"].ToString());
				automationCondition.CompareString         = PIn.String(row["CompareString"].ToString());
				retVal.Add(automationCondition);
			}
			return retVal;
		}

		///<summary>Converts a list of AutomationCondition into a DataTable.</summary>
		public static DataTable ListToTable(List<AutomationCondition> listAutomationConditions,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="AutomationCondition";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("AutomationConditionNum");
			table.Columns.Add("AutomationNum");
			table.Columns.Add("CompareField");
			table.Columns.Add("Comparison");
			table.Columns.Add("CompareString");
			foreach(AutomationCondition automationCondition in listAutomationConditions) {
				table.Rows.Add(new object[] {
					POut.Long  (automationCondition.AutomationConditionNum),
					POut.Long  (automationCondition.AutomationNum),
					POut.Int   ((int)automationCondition.CompareField),
					POut.Int   ((int)automationCondition.Comparison),
					            automationCondition.CompareString,
				});
			}
			return table;
		}

		///<summary>Inserts one AutomationCondition into the database.  Returns the new priKey.</summary>
		public static long Insert(AutomationCondition automationCondition) {
			return Insert(automationCondition,false);
		}

		///<summary>Inserts one AutomationCondition into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(AutomationCondition automationCondition,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				automationCondition.AutomationConditionNum=ReplicationServers.GetKey("automationcondition","AutomationConditionNum");
			}
			string command="INSERT INTO automationcondition (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="AutomationConditionNum,";
			}
			command+="AutomationNum,CompareField,Comparison,CompareString) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(automationCondition.AutomationConditionNum)+",";
			}
			command+=
				     POut.Long  (automationCondition.AutomationNum)+","
				+    POut.Int   ((int)automationCondition.CompareField)+","
				+    POut.Int   ((int)automationCondition.Comparison)+","
				+"'"+POut.String(automationCondition.CompareString)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				automationCondition.AutomationConditionNum=Db.NonQ(command,true,"AutomationConditionNum","automationCondition");
			}
			return automationCondition.AutomationConditionNum;
		}

		///<summary>Inserts one AutomationCondition into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AutomationCondition automationCondition) {
			return InsertNoCache(automationCondition,false);
		}

		///<summary>Inserts one AutomationCondition into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AutomationCondition automationCondition,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO automationcondition (";
			if(!useExistingPK && isRandomKeys) {
				automationCondition.AutomationConditionNum=ReplicationServers.GetKeyNoCache("automationcondition","AutomationConditionNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="AutomationConditionNum,";
			}
			command+="AutomationNum,CompareField,Comparison,CompareString) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(automationCondition.AutomationConditionNum)+",";
			}
			command+=
				     POut.Long  (automationCondition.AutomationNum)+","
				+    POut.Int   ((int)automationCondition.CompareField)+","
				+    POut.Int   ((int)automationCondition.Comparison)+","
				+"'"+POut.String(automationCondition.CompareString)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				automationCondition.AutomationConditionNum=Db.NonQ(command,true,"AutomationConditionNum","automationCondition");
			}
			return automationCondition.AutomationConditionNum;
		}

		///<summary>Updates one AutomationCondition in the database.</summary>
		public static void Update(AutomationCondition automationCondition) {
			string command="UPDATE automationcondition SET "
				+"AutomationNum         =  "+POut.Long  (automationCondition.AutomationNum)+", "
				+"CompareField          =  "+POut.Int   ((int)automationCondition.CompareField)+", "
				+"Comparison            =  "+POut.Int   ((int)automationCondition.Comparison)+", "
				+"CompareString         = '"+POut.String(automationCondition.CompareString)+"' "
				+"WHERE AutomationConditionNum = "+POut.Long(automationCondition.AutomationConditionNum);
			Db.NonQ(command);
		}

		///<summary>Updates one AutomationCondition in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(AutomationCondition automationCondition,AutomationCondition oldAutomationCondition) {
			string command="";
			if(automationCondition.AutomationNum != oldAutomationCondition.AutomationNum) {
				if(command!="") { command+=",";}
				command+="AutomationNum = "+POut.Long(automationCondition.AutomationNum)+"";
			}
			if(automationCondition.CompareField != oldAutomationCondition.CompareField) {
				if(command!="") { command+=",";}
				command+="CompareField = "+POut.Int   ((int)automationCondition.CompareField)+"";
			}
			if(automationCondition.Comparison != oldAutomationCondition.Comparison) {
				if(command!="") { command+=",";}
				command+="Comparison = "+POut.Int   ((int)automationCondition.Comparison)+"";
			}
			if(automationCondition.CompareString != oldAutomationCondition.CompareString) {
				if(command!="") { command+=",";}
				command+="CompareString = '"+POut.String(automationCondition.CompareString)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE automationcondition SET "+command
				+" WHERE AutomationConditionNum = "+POut.Long(automationCondition.AutomationConditionNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(AutomationCondition,AutomationCondition) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(AutomationCondition automationCondition,AutomationCondition oldAutomationCondition) {
			if(automationCondition.AutomationNum != oldAutomationCondition.AutomationNum) {
				return true;
			}
			if(automationCondition.CompareField != oldAutomationCondition.CompareField) {
				return true;
			}
			if(automationCondition.Comparison != oldAutomationCondition.Comparison) {
				return true;
			}
			if(automationCondition.CompareString != oldAutomationCondition.CompareString) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one AutomationCondition from the database.</summary>
		public static void Delete(long automationConditionNum) {
			string command="DELETE FROM automationcondition "
				+"WHERE AutomationConditionNum = "+POut.Long(automationConditionNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many AutomationConditions from the database.</summary>
		public static void DeleteMany(List<long> listAutomationConditionNums) {
			if(listAutomationConditionNums==null || listAutomationConditionNums.Count==0) {
				return;
			}
			string command="DELETE FROM automationcondition "
				+"WHERE AutomationConditionNum IN("+string.Join(",",listAutomationConditionNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}