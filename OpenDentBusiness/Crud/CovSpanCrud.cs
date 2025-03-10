//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class CovSpanCrud {
		///<summary>Gets one CovSpan object from the database using the primary key.  Returns null if not found.</summary>
		public static CovSpan SelectOne(long covSpanNum) {
			string command="SELECT * FROM covspan "
				+"WHERE CovSpanNum = "+POut.Long(covSpanNum);
			List<CovSpan> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one CovSpan object from the database using a query.</summary>
		public static CovSpan SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CovSpan> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of CovSpan objects from the database using a query.</summary>
		public static List<CovSpan> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CovSpan> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<CovSpan> TableToList(DataTable table) {
			List<CovSpan> retVal=new List<CovSpan>();
			CovSpan covSpan;
			foreach(DataRow row in table.Rows) {
				covSpan=new CovSpan();
				covSpan.CovSpanNum= PIn.Long  (row["CovSpanNum"].ToString());
				covSpan.CovCatNum = PIn.Long  (row["CovCatNum"].ToString());
				covSpan.FromCode  = PIn.String(row["FromCode"].ToString());
				covSpan.ToCode    = PIn.String(row["ToCode"].ToString());
				retVal.Add(covSpan);
			}
			return retVal;
		}

		///<summary>Converts a list of CovSpan into a DataTable.</summary>
		public static DataTable ListToTable(List<CovSpan> listCovSpans,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="CovSpan";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("CovSpanNum");
			table.Columns.Add("CovCatNum");
			table.Columns.Add("FromCode");
			table.Columns.Add("ToCode");
			foreach(CovSpan covSpan in listCovSpans) {
				table.Rows.Add(new object[] {
					POut.Long  (covSpan.CovSpanNum),
					POut.Long  (covSpan.CovCatNum),
					            covSpan.FromCode,
					            covSpan.ToCode,
				});
			}
			return table;
		}

		///<summary>Inserts one CovSpan into the database.  Returns the new priKey.</summary>
		public static long Insert(CovSpan covSpan) {
			return Insert(covSpan,false);
		}

		///<summary>Inserts one CovSpan into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(CovSpan covSpan,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				covSpan.CovSpanNum=ReplicationServers.GetKey("covspan","CovSpanNum");
			}
			string command="INSERT INTO covspan (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CovSpanNum,";
			}
			command+="CovCatNum,FromCode,ToCode) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(covSpan.CovSpanNum)+",";
			}
			command+=
				     POut.Long  (covSpan.CovCatNum)+","
				+"'"+POut.String(covSpan.FromCode)+"',"
				+"'"+POut.String(covSpan.ToCode)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				covSpan.CovSpanNum=Db.NonQ(command,true,"CovSpanNum","covSpan");
			}
			return covSpan.CovSpanNum;
		}

		///<summary>Inserts one CovSpan into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(CovSpan covSpan) {
			return InsertNoCache(covSpan,false);
		}

		///<summary>Inserts one CovSpan into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(CovSpan covSpan,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO covspan (";
			if(!useExistingPK && isRandomKeys) {
				covSpan.CovSpanNum=ReplicationServers.GetKeyNoCache("covspan","CovSpanNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="CovSpanNum,";
			}
			command+="CovCatNum,FromCode,ToCode) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(covSpan.CovSpanNum)+",";
			}
			command+=
				     POut.Long  (covSpan.CovCatNum)+","
				+"'"+POut.String(covSpan.FromCode)+"',"
				+"'"+POut.String(covSpan.ToCode)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				covSpan.CovSpanNum=Db.NonQ(command,true,"CovSpanNum","covSpan");
			}
			return covSpan.CovSpanNum;
		}

		///<summary>Updates one CovSpan in the database.</summary>
		public static void Update(CovSpan covSpan) {
			string command="UPDATE covspan SET "
				+"CovCatNum =  "+POut.Long  (covSpan.CovCatNum)+", "
				+"FromCode  = '"+POut.String(covSpan.FromCode)+"', "
				+"ToCode    = '"+POut.String(covSpan.ToCode)+"' "
				+"WHERE CovSpanNum = "+POut.Long(covSpan.CovSpanNum);
			Db.NonQ(command);
		}

		///<summary>Updates one CovSpan in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(CovSpan covSpan,CovSpan oldCovSpan) {
			string command="";
			if(covSpan.CovCatNum != oldCovSpan.CovCatNum) {
				if(command!="") { command+=",";}
				command+="CovCatNum = "+POut.Long(covSpan.CovCatNum)+"";
			}
			if(covSpan.FromCode != oldCovSpan.FromCode) {
				if(command!="") { command+=",";}
				command+="FromCode = '"+POut.String(covSpan.FromCode)+"'";
			}
			if(covSpan.ToCode != oldCovSpan.ToCode) {
				if(command!="") { command+=",";}
				command+="ToCode = '"+POut.String(covSpan.ToCode)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE covspan SET "+command
				+" WHERE CovSpanNum = "+POut.Long(covSpan.CovSpanNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(CovSpan,CovSpan) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(CovSpan covSpan,CovSpan oldCovSpan) {
			if(covSpan.CovCatNum != oldCovSpan.CovCatNum) {
				return true;
			}
			if(covSpan.FromCode != oldCovSpan.FromCode) {
				return true;
			}
			if(covSpan.ToCode != oldCovSpan.ToCode) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one CovSpan from the database.</summary>
		public static void Delete(long covSpanNum) {
			string command="DELETE FROM covspan "
				+"WHERE CovSpanNum = "+POut.Long(covSpanNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many CovSpans from the database.</summary>
		public static void DeleteMany(List<long> listCovSpanNums) {
			if(listCovSpanNums==null || listCovSpanNums.Count==0) {
				return;
			}
			string command="DELETE FROM covspan "
				+"WHERE CovSpanNum IN("+string.Join(",",listCovSpanNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}