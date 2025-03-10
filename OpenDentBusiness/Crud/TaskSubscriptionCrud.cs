//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class TaskSubscriptionCrud {
		///<summary>Gets one TaskSubscription object from the database using the primary key.  Returns null if not found.</summary>
		public static TaskSubscription SelectOne(long taskSubscriptionNum) {
			string command="SELECT * FROM tasksubscription "
				+"WHERE TaskSubscriptionNum = "+POut.Long(taskSubscriptionNum);
			List<TaskSubscription> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one TaskSubscription object from the database using a query.</summary>
		public static TaskSubscription SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TaskSubscription> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of TaskSubscription objects from the database using a query.</summary>
		public static List<TaskSubscription> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TaskSubscription> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<TaskSubscription> TableToList(DataTable table) {
			List<TaskSubscription> retVal=new List<TaskSubscription>();
			TaskSubscription taskSubscription;
			foreach(DataRow row in table.Rows) {
				taskSubscription=new TaskSubscription();
				taskSubscription.TaskSubscriptionNum= PIn.Long  (row["TaskSubscriptionNum"].ToString());
				taskSubscription.UserNum            = PIn.Long  (row["UserNum"].ToString());
				taskSubscription.TaskListNum        = PIn.Long  (row["TaskListNum"].ToString());
				taskSubscription.TaskNum            = PIn.Long  (row["TaskNum"].ToString());
				retVal.Add(taskSubscription);
			}
			return retVal;
		}

		///<summary>Converts a list of TaskSubscription into a DataTable.</summary>
		public static DataTable ListToTable(List<TaskSubscription> listTaskSubscriptions,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="TaskSubscription";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("TaskSubscriptionNum");
			table.Columns.Add("UserNum");
			table.Columns.Add("TaskListNum");
			table.Columns.Add("TaskNum");
			foreach(TaskSubscription taskSubscription in listTaskSubscriptions) {
				table.Rows.Add(new object[] {
					POut.Long  (taskSubscription.TaskSubscriptionNum),
					POut.Long  (taskSubscription.UserNum),
					POut.Long  (taskSubscription.TaskListNum),
					POut.Long  (taskSubscription.TaskNum),
				});
			}
			return table;
		}

		///<summary>Inserts one TaskSubscription into the database.  Returns the new priKey.</summary>
		public static long Insert(TaskSubscription taskSubscription) {
			return Insert(taskSubscription,false);
		}

		///<summary>Inserts one TaskSubscription into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(TaskSubscription taskSubscription,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				taskSubscription.TaskSubscriptionNum=ReplicationServers.GetKey("tasksubscription","TaskSubscriptionNum");
			}
			string command="INSERT INTO tasksubscription (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TaskSubscriptionNum,";
			}
			command+="UserNum,TaskListNum,TaskNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(taskSubscription.TaskSubscriptionNum)+",";
			}
			command+=
				     POut.Long  (taskSubscription.UserNum)+","
				+    POut.Long  (taskSubscription.TaskListNum)+","
				+    POut.Long  (taskSubscription.TaskNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				taskSubscription.TaskSubscriptionNum=Db.NonQ(command,true,"TaskSubscriptionNum","taskSubscription");
			}
			return taskSubscription.TaskSubscriptionNum;
		}

		///<summary>Inserts one TaskSubscription into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TaskSubscription taskSubscription) {
			return InsertNoCache(taskSubscription,false);
		}

		///<summary>Inserts one TaskSubscription into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TaskSubscription taskSubscription,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO tasksubscription (";
			if(!useExistingPK && isRandomKeys) {
				taskSubscription.TaskSubscriptionNum=ReplicationServers.GetKeyNoCache("tasksubscription","TaskSubscriptionNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="TaskSubscriptionNum,";
			}
			command+="UserNum,TaskListNum,TaskNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(taskSubscription.TaskSubscriptionNum)+",";
			}
			command+=
				     POut.Long  (taskSubscription.UserNum)+","
				+    POut.Long  (taskSubscription.TaskListNum)+","
				+    POut.Long  (taskSubscription.TaskNum)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				taskSubscription.TaskSubscriptionNum=Db.NonQ(command,true,"TaskSubscriptionNum","taskSubscription");
			}
			return taskSubscription.TaskSubscriptionNum;
		}

		///<summary>Updates one TaskSubscription in the database.</summary>
		public static void Update(TaskSubscription taskSubscription) {
			string command="UPDATE tasksubscription SET "
				+"UserNum            =  "+POut.Long  (taskSubscription.UserNum)+", "
				+"TaskListNum        =  "+POut.Long  (taskSubscription.TaskListNum)+", "
				+"TaskNum            =  "+POut.Long  (taskSubscription.TaskNum)+" "
				+"WHERE TaskSubscriptionNum = "+POut.Long(taskSubscription.TaskSubscriptionNum);
			Db.NonQ(command);
		}

		///<summary>Updates one TaskSubscription in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(TaskSubscription taskSubscription,TaskSubscription oldTaskSubscription) {
			string command="";
			if(taskSubscription.UserNum != oldTaskSubscription.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(taskSubscription.UserNum)+"";
			}
			if(taskSubscription.TaskListNum != oldTaskSubscription.TaskListNum) {
				if(command!="") { command+=",";}
				command+="TaskListNum = "+POut.Long(taskSubscription.TaskListNum)+"";
			}
			if(taskSubscription.TaskNum != oldTaskSubscription.TaskNum) {
				if(command!="") { command+=",";}
				command+="TaskNum = "+POut.Long(taskSubscription.TaskNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE tasksubscription SET "+command
				+" WHERE TaskSubscriptionNum = "+POut.Long(taskSubscription.TaskSubscriptionNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(TaskSubscription,TaskSubscription) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(TaskSubscription taskSubscription,TaskSubscription oldTaskSubscription) {
			if(taskSubscription.UserNum != oldTaskSubscription.UserNum) {
				return true;
			}
			if(taskSubscription.TaskListNum != oldTaskSubscription.TaskListNum) {
				return true;
			}
			if(taskSubscription.TaskNum != oldTaskSubscription.TaskNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one TaskSubscription from the database.</summary>
		public static void Delete(long taskSubscriptionNum) {
			string command="DELETE FROM tasksubscription "
				+"WHERE TaskSubscriptionNum = "+POut.Long(taskSubscriptionNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many TaskSubscriptions from the database.</summary>
		public static void DeleteMany(List<long> listTaskSubscriptionNums) {
			if(listTaskSubscriptionNums==null || listTaskSubscriptionNums.Count==0) {
				return;
			}
			string command="DELETE FROM tasksubscription "
				+"WHERE TaskSubscriptionNum IN("+string.Join(",",listTaskSubscriptionNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}