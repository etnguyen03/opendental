//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class FamAgingCrud {
		///<summary>Gets one FamAging object from the database using the primary key.  Returns null if not found.</summary>
		public static FamAging SelectOne(long patNum) {
			string command="SELECT * FROM famaging "
				+"WHERE PatNum = "+POut.Long(patNum);
			List<FamAging> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one FamAging object from the database using a query.</summary>
		public static FamAging SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<FamAging> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of FamAging objects from the database using a query.</summary>
		public static List<FamAging> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<FamAging> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<FamAging> TableToList(DataTable table) {
			List<FamAging> retVal=new List<FamAging>();
			FamAging famAging;
			foreach(DataRow row in table.Rows) {
				famAging=new FamAging();
				famAging.PatNum    = PIn.Long  (row["PatNum"].ToString());
				famAging.Bal_0_30  = PIn.Double(row["Bal_0_30"].ToString());
				famAging.Bal_31_60 = PIn.Double(row["Bal_31_60"].ToString());
				famAging.Bal_61_90 = PIn.Double(row["Bal_61_90"].ToString());
				famAging.BalOver90 = PIn.Double(row["BalOver90"].ToString());
				famAging.InsEst    = PIn.Double(row["InsEst"].ToString());
				famAging.BalTotal  = PIn.Double(row["BalTotal"].ToString());
				famAging.PayPlanDue= PIn.Double(row["PayPlanDue"].ToString());
				retVal.Add(famAging);
			}
			return retVal;
		}

		///<summary>Converts a list of FamAging into a DataTable.</summary>
		public static DataTable ListToTable(List<FamAging> listFamAgings,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="FamAging";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PatNum");
			table.Columns.Add("Bal_0_30");
			table.Columns.Add("Bal_31_60");
			table.Columns.Add("Bal_61_90");
			table.Columns.Add("BalOver90");
			table.Columns.Add("InsEst");
			table.Columns.Add("BalTotal");
			table.Columns.Add("PayPlanDue");
			foreach(FamAging famAging in listFamAgings) {
				table.Rows.Add(new object[] {
					POut.Long  (famAging.PatNum),
					POut.Double(famAging.Bal_0_30),
					POut.Double(famAging.Bal_31_60),
					POut.Double(famAging.Bal_61_90),
					POut.Double(famAging.BalOver90),
					POut.Double(famAging.InsEst),
					POut.Double(famAging.BalTotal),
					POut.Double(famAging.PayPlanDue),
				});
			}
			return table;
		}

		///<summary>Inserts one FamAging into the database.  Returns the new priKey.</summary>
		public static long Insert(FamAging famAging) {
			return Insert(famAging,false);
		}

		///<summary>Inserts one FamAging into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(FamAging famAging,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				famAging.PatNum=ReplicationServers.GetKey("famaging","PatNum");
			}
			string command="INSERT INTO famaging (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PatNum,";
			}
			command+="Bal_0_30,Bal_31_60,Bal_61_90,BalOver90,InsEst,BalTotal,PayPlanDue) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(famAging.PatNum)+",";
			}
			command+=
				 		 POut.Double(famAging.Bal_0_30)+","
				+		 POut.Double(famAging.Bal_31_60)+","
				+		 POut.Double(famAging.Bal_61_90)+","
				+		 POut.Double(famAging.BalOver90)+","
				+		 POut.Double(famAging.InsEst)+","
				+		 POut.Double(famAging.BalTotal)+","
				+		 POut.Double(famAging.PayPlanDue)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				famAging.PatNum=Db.NonQ(command,true,"PatNum","famAging");
			}
			return famAging.PatNum;
		}

		///<summary>Inserts many FamAgings into the database.</summary>
		public static void InsertMany(List<FamAging> listFamAgings) {
			InsertMany(listFamAgings,false);
		}

		///<summary>Inserts many FamAgings into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<FamAging> listFamAgings,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(FamAging famAging in listFamAgings) {
					Insert(famAging);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listFamAgings.Count) {
					FamAging famAging=listFamAgings[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO famaging (");
						if(useExistingPK) {
							sbCommands.Append("PatNum,");
						}
						sbCommands.Append("Bal_0_30,Bal_31_60,Bal_61_90,BalOver90,InsEst,BalTotal,PayPlanDue) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(famAging.PatNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Double(famAging.Bal_0_30)); sbRow.Append(",");
					sbRow.Append(POut.Double(famAging.Bal_31_60)); sbRow.Append(",");
					sbRow.Append(POut.Double(famAging.Bal_61_90)); sbRow.Append(",");
					sbRow.Append(POut.Double(famAging.BalOver90)); sbRow.Append(",");
					sbRow.Append(POut.Double(famAging.InsEst)); sbRow.Append(",");
					sbRow.Append(POut.Double(famAging.BalTotal)); sbRow.Append(",");
					sbRow.Append(POut.Double(famAging.PayPlanDue)); sbRow.Append(")");
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Db.NonQ(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listFamAgings.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one FamAging into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(FamAging famAging) {
			return InsertNoCache(famAging,false);
		}

		///<summary>Inserts one FamAging into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(FamAging famAging,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO famaging (";
			if(!useExistingPK && isRandomKeys) {
				famAging.PatNum=ReplicationServers.GetKeyNoCache("famaging","PatNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="PatNum,";
			}
			command+="Bal_0_30,Bal_31_60,Bal_61_90,BalOver90,InsEst,BalTotal,PayPlanDue) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(famAging.PatNum)+",";
			}
			command+=
				 	   POut.Double(famAging.Bal_0_30)+","
				+	   POut.Double(famAging.Bal_31_60)+","
				+	   POut.Double(famAging.Bal_61_90)+","
				+	   POut.Double(famAging.BalOver90)+","
				+	   POut.Double(famAging.InsEst)+","
				+	   POut.Double(famAging.BalTotal)+","
				+	   POut.Double(famAging.PayPlanDue)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				famAging.PatNum=Db.NonQ(command,true,"PatNum","famAging");
			}
			return famAging.PatNum;
		}

		///<summary>Updates one FamAging in the database.</summary>
		public static void Update(FamAging famAging) {
			string command="UPDATE famaging SET "
				+"Bal_0_30  =  "+POut.Double(famAging.Bal_0_30)+", "
				+"Bal_31_60 =  "+POut.Double(famAging.Bal_31_60)+", "
				+"Bal_61_90 =  "+POut.Double(famAging.Bal_61_90)+", "
				+"BalOver90 =  "+POut.Double(famAging.BalOver90)+", "
				+"InsEst    =  "+POut.Double(famAging.InsEst)+", "
				+"BalTotal  =  "+POut.Double(famAging.BalTotal)+", "
				+"PayPlanDue=  "+POut.Double(famAging.PayPlanDue)+" "
				+"WHERE PatNum = "+POut.Long(famAging.PatNum);
			Db.NonQ(command);
		}

		///<summary>Updates one FamAging in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(FamAging famAging,FamAging oldFamAging) {
			string command="";
			if(famAging.Bal_0_30 != oldFamAging.Bal_0_30) {
				if(command!="") { command+=",";}
				command+="Bal_0_30 = "+POut.Double(famAging.Bal_0_30)+"";
			}
			if(famAging.Bal_31_60 != oldFamAging.Bal_31_60) {
				if(command!="") { command+=",";}
				command+="Bal_31_60 = "+POut.Double(famAging.Bal_31_60)+"";
			}
			if(famAging.Bal_61_90 != oldFamAging.Bal_61_90) {
				if(command!="") { command+=",";}
				command+="Bal_61_90 = "+POut.Double(famAging.Bal_61_90)+"";
			}
			if(famAging.BalOver90 != oldFamAging.BalOver90) {
				if(command!="") { command+=",";}
				command+="BalOver90 = "+POut.Double(famAging.BalOver90)+"";
			}
			if(famAging.InsEst != oldFamAging.InsEst) {
				if(command!="") { command+=",";}
				command+="InsEst = "+POut.Double(famAging.InsEst)+"";
			}
			if(famAging.BalTotal != oldFamAging.BalTotal) {
				if(command!="") { command+=",";}
				command+="BalTotal = "+POut.Double(famAging.BalTotal)+"";
			}
			if(famAging.PayPlanDue != oldFamAging.PayPlanDue) {
				if(command!="") { command+=",";}
				command+="PayPlanDue = "+POut.Double(famAging.PayPlanDue)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE famaging SET "+command
				+" WHERE PatNum = "+POut.Long(famAging.PatNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(FamAging,FamAging) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(FamAging famAging,FamAging oldFamAging) {
			if(famAging.Bal_0_30 != oldFamAging.Bal_0_30) {
				return true;
			}
			if(famAging.Bal_31_60 != oldFamAging.Bal_31_60) {
				return true;
			}
			if(famAging.Bal_61_90 != oldFamAging.Bal_61_90) {
				return true;
			}
			if(famAging.BalOver90 != oldFamAging.BalOver90) {
				return true;
			}
			if(famAging.InsEst != oldFamAging.InsEst) {
				return true;
			}
			if(famAging.BalTotal != oldFamAging.BalTotal) {
				return true;
			}
			if(famAging.PayPlanDue != oldFamAging.PayPlanDue) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one FamAging from the database.</summary>
		public static void Delete(long patNum) {
			string command="DELETE FROM famaging "
				+"WHERE PatNum = "+POut.Long(patNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many FamAgings from the database.</summary>
		public static void DeleteMany(List<long> listPatNums) {
			if(listPatNums==null || listPatNums.Count==0) {
				return;
			}
			string command="DELETE FROM famaging "
				+"WHERE PatNum IN("+string.Join(",",listPatNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}