using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace OpenDentBusiness{
	///<summary></summary>
	public class WebChatAiAssistants {
		///<summary>The object that accesses the cache in a thread-safe manner.</summary>
		private static WebChatAiAssistantCache _webChatAiAssistantCache=new WebChatAiAssistantCache();

		#region Cache Pattern
		private class WebChatAiAssistantCache : CacheListAbs<WebChatAiAssistant> {
			protected override List<WebChatAiAssistant> GetCacheFromDb() {
				List<WebChatAiAssistant> listAssistants=new List<WebChatAiAssistant>();
				WebChatMisc.DbAction(() => listAssistants=Crud.WebChatAiAssistantCrud.SelectMany("SELECT * FROM WebChatAiAssistant"));
				return listAssistants;
			}
			protected override List<WebChatAiAssistant> TableToList(DataTable table) {
				return Crud.WebChatAiAssistantCrud.TableToList(table);
			}
			protected override WebChatAiAssistant Copy(WebChatAiAssistant WebChatAiAssistant) {
				return WebChatAiAssistant.Copy();
			}
			protected override DataTable ListToTable(List<WebChatAiAssistant> listWebChatAiAssistants) {
				return Crud.WebChatAiAssistantCrud.ListToTable(listWebChatAiAssistants,"WebChatAiAssistant");
			}
			protected override void FillCacheIfNeeded() {
				WebChatAiAssistants.GetTableFromCache(false);
			}
		}

		public static DataTable RefreshCache() {
			return GetTableFromCache(true);
		}

		public static WebChatAiAssistant GetFirstOrDefault(Func<WebChatAiAssistant,bool> match,bool isShort=false) {
			return _webChatAiAssistantCache.GetFirstOrDefault(match,isShort);
		}

		///<summary>Returns the cache in the form of a DataTable. Always refreshes the ClientMT's cache.</summary>
		///<param name="doRefreshCache">If true,will refresh the cache if MiddleTierRole is ClientDirect or ServerWeb.</param> 
		public static DataTable GetTableFromCache(bool doRefreshCache) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				DataTable table=Meth.GetTable(MethodBase.GetCurrentMethod(),doRefreshCache);
				_webChatAiAssistantCache.FillCacheFromTable(table);
				return table;
			}
			return _webChatAiAssistantCache.GetTableFromCache(doRefreshCache);
		}

		public static void ClearCache() {
			_webChatAiAssistantCache.ClearCache();
		}

		///<summary>Fills the local cache with the passed in DataTable.</summary>
		public static void FillCacheFromTable(DataTable table) {
			_webChatAiAssistantCache.FillCacheFromTable(table);
		}
		#endregion Cache Pattern

		#region Methods - Modify
		///<summary></summary>
		public static long Insert(WebChatAiAssistant webChatAiAssistant) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				webChatAiAssistant.WebChatAiAssistantNum=Meth.GetLong(MethodBase.GetCurrentMethod(),webChatAiAssistant);
				return webChatAiAssistant.WebChatAiAssistantNum;
			}
			WebChatMisc.DbAction(delegate () {
				Crud.WebChatAiAssistantCrud.Insert(webChatAiAssistant);
			});
			WebChatMisc.DbAction(delegate() {
				Signalods.Insert(new Signalod {
					IType=InvalidType.WebChatAiAssistants
				});
			},false);
			return webChatAiAssistant.WebChatAiAssistantNum;
		}
		#endregion Methods - Modify


	}
}