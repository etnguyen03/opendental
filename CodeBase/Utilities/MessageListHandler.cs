using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Utilities.DcvExtension {
	public class MessageListHandler {
		private readonly List<string> _listResponses=new List<string>();
		private readonly object _listLock=new object();
		private const int _bufferSize=1048576;

		public void AddMessage(string response) {
			lock (_listLock) {
				_listResponses.Add(response);
			}
		}

		public string GetFirstMessage() {
			lock(_listLock) {
				if (_listResponses.Count==0) {
					return null;
				}
				string request=_listResponses[0];
				_listResponses.RemoveAt(0);
				return request;
			}
		}

		public string GetMessage(string requestId) {
			lock(_listLock) {
				string response=null;
				if(_listResponses.Count > 0) {
					int removeIdx=-1;
					for(int i = 0;i<_listResponses.Count;i++) {
						if(_listResponses[i].Contains(requestId)) {
							int delimiterIndex=_listResponses[i].IndexOf("<FileIdentifier:");
							response=_listResponses[i].Substring(0,delimiterIndex);
							removeIdx=i;
							break;
						}
					}
					if(removeIdx>=0) {
						_listResponses.RemoveAt(removeIdx);
					}
				}
				return response;
			}
		}

		public async Task ProcessMessages(NamedPipeClientStream namedPipeClientStream) {
			while (true) {
				try {
					string request=GetFirstMessage();
					if(request!=null) {
						byte[] messageByteArray=Encoding.UTF8.GetBytes(request);
						await SendMessage(namedPipeClientStream,messageByteArray);
					}
					else {
						await Task.Delay(250);
					}
				}
				catch(Exception ex) {
					throw (new Exception(ex.Message));
				}
			}
		}

		async Task SendMessage(NamedPipeClientStream namedPipeClientStream,byte[] messageByteArray) {
			try {
				if (namedPipeClientStream!=null) {
						int numBytes=messageByteArray.Length;
						int numBytesSent=0;
						while(numBytesSent<numBytes) {
							int numBytesSending=Math.Min(_bufferSize,numBytes-numBytesSent);
							await namedPipeClientStream.WriteAsync(messageByteArray,numBytesSent,numBytesSending);
							await namedPipeClientStream.FlushAsync();
							numBytesSent+=numBytesSending;
						}
					}
				}
			catch (Exception ex) {
				ex.DoNothing();
			}
		}
	}
}