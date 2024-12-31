using System;
using System.IO;
using System.IO.Pipes;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeBase.Utilities.DcvExtension;
using Newtonsoft.Json;

namespace CodeBase.Utilities {
	public class ODCloudDcvExtension {
		private static DateTime LastRequest;
		private const int _bufferSize=1048576;// 1MB
		private const string _delimiter="<END>";
		private static readonly ODCloudDcvExtension _instance=new ODCloudDcvExtension();
    private NamedPipeClientStream _namedPipeClientStream;
		private MessageListHandler _responseListHandler;
		private MessageListHandler _sendingListHandler;

		private ODCloudDcvExtension() { }

		public static ODCloudDcvExtension Instance { 
			get {
				return _instance; 
			} 
		}

		public static async Task Start() {
			while(true) {
				if(!Instance.IsConnected()) {
					LastRequest=DateTime.MinValue;
					// Create the client side stream to connect to the server namedpipe.
					NamedPipeClientStream pipeClientStream=null;
					string userName=Environment.UserName;
					try {
						if(Instance._namedPipeClientStream==null || !Instance._namedPipeClientStream.IsConnected) {
							Task.Delay(200).Wait();
							pipeClientStream=new NamedPipeClientStream(".","ServerPipe"+userName,PipeDirection.InOut,PipeOptions.Asynchronous | PipeOptions.WriteThrough);
							Instance._namedPipeClientStream=pipeClientStream;
						}
						if(pipeClientStream!=null && !pipeClientStream.IsConnected) {
							await Instance._namedPipeClientStream.ConnectAsync();
						}
						if(Instance._responseListHandler==null && Instance._sendingListHandler==null) {
							Instance._responseListHandler=new MessageListHandler();
							Instance._sendingListHandler=new MessageListHandler();
							Task readTask = Task.Run(async () => await Instance.RunClient(Instance._responseListHandler));
							Task writeTask = Task.Run(async () => await Instance._sendingListHandler.ProcessMessages(Instance._namedPipeClientStream));
						}
					}
					catch(Exception ex) {
						ex.DoNothing();
					}
					finally {
						if(Instance._namedPipeClientStream!=null && !Instance._namedPipeClientStream.IsConnected) {
							Instance._namedPipeClientStream.Close();
							Instance._namedPipeClientStream.Dispose();
							Instance._namedPipeClientStream=null;
						}
					}
				}
				Task.Delay(500).Wait();
			}
		}

		public bool IsConnected() {
			try {
				return (Instance._namedPipeClientStream!=null && Instance._namedPipeClientStream.IsConnected);
			}
			catch (Exception ex) {
				ex.DoNothing();
				return false;
			}
		}

		public DateTime GetLastRequest() {
			return LastRequest;
		}

		public void SendRequest(string request) {
			if(request==null || request.Length==0) {
				return;
			}
			Instance._sendingListHandler.AddMessage(request+_delimiter);
			return;
		}

		public string GetResponse(string requestId) {
			if(Instance._responseListHandler==null) {
				return null;
			}
			return Instance._responseListHandler.GetMessage(requestId);
		}

		private async Task RunClient(MessageListHandler responseListHandler) {
			byte[] readBufferArray=new byte[_bufferSize];
			StringBuilder stringBuilder=new StringBuilder();
			while(true) {
				if (_namedPipeClientStream==null || !_namedPipeClientStream.IsConnected ) {
          Thread.Sleep(250);
					break;
        }
				try {
					int numBytes=await Instance._namedPipeClientStream.ReadAsync(readBufferArray,0,readBufferArray.Length);
					if(numBytes==0) {
						continue;
					}
          if(!IsValidUtf8(readBufferArray,numBytes)) {
						continue;
					}
					stringBuilder.Append(Encoding.UTF8.GetString(readBufferArray,0,numBytes));
          string completeResponse=stringBuilder.ToString();
          if(completeResponse.Contains(_delimiter)) {
            int delimiterIndex=completeResponse.IndexOf(_delimiter);
            string response=completeResponse.Substring(0,delimiterIndex);

            ProcessResponse(response, responseListHandler);

            completeResponse=completeResponse.Substring(delimiterIndex+_delimiter.Length);
          }
          stringBuilder.Clear();
          stringBuilder.Append(completeResponse);
				}
				catch(Exception ex) {
					ex.DoNothing();
				}
			}
		}

		private static bool IsValidUtf8(byte[] byteArray,int length) {
      try {
        Encoding.UTF8.GetString(byteArray,0,length);
        return true;
      }
      catch (DecoderFallbackException) {
        return false;
      }
    }

		private static void ProcessResponse(string response,MessageListHandler responseListHandler) {
			if(response==null || response.Length==0) {
				return;
			}
			LastRequest=DateTime.Now;
			responseListHandler.AddMessage(response);
		}
	}
}