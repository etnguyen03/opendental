//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class LetterMergeFieldCrud {
		///<summary>Gets one LetterMergeField object from the database using the primary key.  Returns null if not found.</summary>
		public static LetterMergeField SelectOne(long fieldNum) {
			string command="SELECT * FROM lettermergefield "
				+"WHERE FieldNum = "+POut.Long(fieldNum);
			List<LetterMergeField> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one LetterMergeField object from the database using a query.</summary>
		public static LetterMergeField SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LetterMergeField> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of LetterMergeField objects from the database using a query.</summary>
		public static List<LetterMergeField> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LetterMergeField> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<LetterMergeField> TableToList(DataTable table) {
			List<LetterMergeField> retVal=new List<LetterMergeField>();
			LetterMergeField letterMergeField;
			foreach(DataRow row in table.Rows) {
				letterMergeField=new LetterMergeField();
				letterMergeField.FieldNum      = PIn.Long  (row["FieldNum"].ToString());
				letterMergeField.LetterMergeNum= PIn.Long  (row["LetterMergeNum"].ToString());
				letterMergeField.FieldName     = PIn.String(row["FieldName"].ToString());
				retVal.Add(letterMergeField);
			}
			return retVal;
		}

		///<summary>Converts a list of LetterMergeField into a DataTable.</summary>
		public static DataTable ListToTable(List<LetterMergeField> listLetterMergeFields,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="LetterMergeField";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("FieldNum");
			table.Columns.Add("LetterMergeNum");
			table.Columns.Add("FieldName");
			foreach(LetterMergeField letterMergeField in listLetterMergeFields) {
				table.Rows.Add(new object[] {
					POut.Long  (letterMergeField.FieldNum),
					POut.Long  (letterMergeField.LetterMergeNum),
					            letterMergeField.FieldName,
				});
			}
			return table;
		}

		///<summary>Inserts one LetterMergeField into the database.  Returns the new priKey.</summary>
		public static long Insert(LetterMergeField letterMergeField) {
			return Insert(letterMergeField,false);
		}

		///<summary>Inserts one LetterMergeField into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(LetterMergeField letterMergeField,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				letterMergeField.FieldNum=ReplicationServers.GetKey("lettermergefield","FieldNum");
			}
			string command="INSERT INTO lettermergefield (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="FieldNum,";
			}
			command+="LetterMergeNum,FieldName) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(letterMergeField.FieldNum)+",";
			}
			command+=
				     POut.Long  (letterMergeField.LetterMergeNum)+","
				+"'"+POut.String(letterMergeField.FieldName)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				letterMergeField.FieldNum=Db.NonQ(command,true,"FieldNum","letterMergeField");
			}
			return letterMergeField.FieldNum;
		}

		///<summary>Inserts one LetterMergeField into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(LetterMergeField letterMergeField) {
			return InsertNoCache(letterMergeField,false);
		}

		///<summary>Inserts one LetterMergeField into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(LetterMergeField letterMergeField,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO lettermergefield (";
			if(!useExistingPK && isRandomKeys) {
				letterMergeField.FieldNum=ReplicationServers.GetKeyNoCache("lettermergefield","FieldNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="FieldNum,";
			}
			command+="LetterMergeNum,FieldName) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(letterMergeField.FieldNum)+",";
			}
			command+=
				     POut.Long  (letterMergeField.LetterMergeNum)+","
				+"'"+POut.String(letterMergeField.FieldName)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				letterMergeField.FieldNum=Db.NonQ(command,true,"FieldNum","letterMergeField");
			}
			return letterMergeField.FieldNum;
		}

		///<summary>Updates one LetterMergeField in the database.</summary>
		public static void Update(LetterMergeField letterMergeField) {
			string command="UPDATE lettermergefield SET "
				+"LetterMergeNum=  "+POut.Long  (letterMergeField.LetterMergeNum)+", "
				+"FieldName     = '"+POut.String(letterMergeField.FieldName)+"' "
				+"WHERE FieldNum = "+POut.Long(letterMergeField.FieldNum);
			Db.NonQ(command);
		}

		///<summary>Updates one LetterMergeField in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(LetterMergeField letterMergeField,LetterMergeField oldLetterMergeField) {
			string command="";
			if(letterMergeField.LetterMergeNum != oldLetterMergeField.LetterMergeNum) {
				if(command!="") { command+=",";}
				command+="LetterMergeNum = "+POut.Long(letterMergeField.LetterMergeNum)+"";
			}
			if(letterMergeField.FieldName != oldLetterMergeField.FieldName) {
				if(command!="") { command+=",";}
				command+="FieldName = '"+POut.String(letterMergeField.FieldName)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE lettermergefield SET "+command
				+" WHERE FieldNum = "+POut.Long(letterMergeField.FieldNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(LetterMergeField,LetterMergeField) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(LetterMergeField letterMergeField,LetterMergeField oldLetterMergeField) {
			if(letterMergeField.LetterMergeNum != oldLetterMergeField.LetterMergeNum) {
				return true;
			}
			if(letterMergeField.FieldName != oldLetterMergeField.FieldName) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one LetterMergeField from the database.</summary>
		public static void Delete(long fieldNum) {
			string command="DELETE FROM lettermergefield "
				+"WHERE FieldNum = "+POut.Long(fieldNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many LetterMergeFields from the database.</summary>
		public static void DeleteMany(List<long> listFieldNums) {
			if(listFieldNums==null || listFieldNums.Count==0) {
				return;
			}
			string command="DELETE FROM lettermergefield "
				+"WHERE FieldNum IN("+string.Join(",",listFieldNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}