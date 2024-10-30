using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using CodeBase;

namespace OpenDental.UI {
	///<summary>This class is specifically designed to duplicate the functionality of the Topaz SigPlusNET control.  So even if I would have done it differenly, I didn't have a choice.  Size of box will always be 362,79 or scaled properly with scale and zoom while keeping the same proportions. Always test at different monitor scales.</summary>
	public partial class SignatureBox:Control {
		///<summary>Default 1. Typical value 1.5</summary>
		private float _scaleMS = 1;
		///<summary>Default 1. Typical value 1.2</summary>
		private float _zoomLocal=1;
		///<summary>0=not accepting input. 1=accepting input.</summary>
		private int tabletState;
		///<summary>Collection of points that will be connected to draw the signature.  0,0 represents pen up. Also see _strDigitalSig for the alternate way of storing a string as a "digital sig".</summary>
		private List<PointF> listPointFs;
		//<summary>0=none, 1=lossless.  Always use 1.</summary>
		//private int compressionMode;
		//<summary>0=clear text. 1=40 bit DES.  2=higher security.</summary>
		//private int encryptionMode;
		///<summary>The hash of the document which will be used to encrypt the signature.</summary>
		private byte[] hash;
		private bool mouseIsDown;
		///<summary>This is a string that looks something like this: Digitally Signed by Abbr - LName, FName (hidden)\r\nDate Signed: 10/29/2024 7:25 PM.  This string will get converted to bytes and then to a format that looks like a series of points. It's a bad strategy, but we are stuck with it. Every place where listPointFs is used, this might be used instead.</summary>
		private string _strDigitalSig=null;

		public SignatureBox() {
			InitializeComponent();
			DoubleBuffered=true;
			listPointFs=new List<PointF>();
		}

		///<summary>Defaults are 1,1.</summary>
		public void SetScaleAndZoom(float scaleMS,float zoomLocal){
			if(scaleMS==_scaleMS && zoomLocal==_zoomLocal){
				return;
			}
			_scaleMS = scaleMS;
			_zoomLocal=zoomLocal;
		}

		///<summary>Converts from 96dpi to current total scale.</summary>
		private float ScaleF(float val96){
			float scaleTotal=_scaleMS*_zoomLocal;//example 1.5*1.2
			return val96*scaleTotal;
		}

		///<summary>Converts from scaled back to 96dpi.</summary>
		private float Unscale(float valScreen){
			float val96=(float)(valScreen/(_scaleMS*_zoomLocal));//example 180/(1.5*1.2)=100
			return val96;
		}

		///<summary>Set to 1 to activate it to start accepting signatures.  Set to 0 to no longer accept input.</summary>
		public void SetTabletState(int state){
			tabletState=state;
		}

		///<summary>1 if the control is accepting signature input. 0 if not.</summary>
		public int GetTabletState() {
			return tabletState;
		}

		///<summary>Clears the display and the stored signature.</summary>
		public void ClearTablet(){
			listPointFs=new List<PointF>();
			_strDigitalSig=null;
			Invalidate();
		}

		public int NumberOfTabletPoints(){
			//this is only used to check for zero
			if(_strDigitalSig!=null){
				return 10;//arbitrary number bigger than zero
			}
			return listPointFs.Count;
		}

		/*
		///<summary>0=none, 1=lossless.  2-8 not used?</summary>
		public void SetSigCompressionMode(int compressMode){
			compressionMode=compressMode;
		}

		///<summary>0=clear text. 1=low DES (do not use).  2=high Rijndael.</summary>
		public void SetEncryptionMode(int encryptMode){
			encryptionMode=encryptMode;
		}*/

		///<summary>Set it to "0000000000000000" (16 zeros) to indicate no key string to be used for encryption.  Use this OR SetAutoKeyData.</summary>
		public void SetKeyString(string keyStr){
			UTF8Encoding enc=new UTF8Encoding();
			hash=enc.GetBytes(keyStr);
		}

		///<summary>The data that's being signed.  A 16 byte hash will be created off this data, and used to encrypt the signature.  Use this OR SetKeyString.  But once the choice is made for a particular data type, it may never be changed.</summary>
		public void SetAutoKeyData(string keyData){
			hash=ODCrypt.MD5.Hash(Encoding.UTF8.GetBytes(keyData));
		}

		///<summary>Encrypts signature text and returns a base 64 string so that it can go directly into the database.</summary>
		public string GetSigString(){
			string rawString="";
			if(_strDigitalSig!=null){
				//These two points indicate that this is NOT a "Normal" signature.
				rawString+=int.MinValue.ToString()+","+int.MinValue.ToString()+";";
				rawString+=int.MinValue.ToString()+","+int.MinValue.ToString()+";";
				byte[] byteArray = Encoding.UTF8.GetBytes(_strDigitalSig);
				for(int i=0;i<byteArray.Length;i=i+2) {
					rawString+=byteArray[i].ToString();//this is safe because the loop condition checks i<byteArray.Length
					rawString+=",";
					if(i>byteArray.Length-2){//there is no byte to use for "Y"
						rawString+=int.MinValue.ToString();
					}
					else{
						rawString+=byteArray[i+1].ToString();
					}
					if(i < byteArray.Length-2){//if not last iteration
						rawString+=";";
					}
				}
				return OpenDentBusiness.UI.SigBox.EncryptSigString(hash,rawString);
			}
			if(listPointFs.Count==0){
				return "";
			}
			for(int i=0;i<listPointFs.Count;i++){
				if(i>0){
					rawString+=";";
				}
				rawString+=listPointFs[i].X.ToString("0.#");//Show to one decimal place. But 5.0395757 would show as 5, for example.
				rawString+=",";
				rawString+=listPointFs[i].Y.ToString("0.#");
			}
			return OpenDentBusiness.UI.SigBox.EncryptSigString(hash,rawString);
		}

		///<summary>Unencrypts the signature coming in from the database.  The key data etc needs to be set first before calling this function.</summary>
		public void SetSigString(string sigString){
			listPointFs=new List<PointF>();
			_strDigitalSig=null;
			if(sigString==""){
				return;
			}
			try{
				//convert base64 string to bytes
				byte[] byteArrayEncrypted=Convert.FromBase64String(sigString);
				//create the streams
				MemoryStream memoryStream=new MemoryStream();
				//ms.Write(encryptedBytes,0,(int)encryptedBytes.Length);
				//create a crypto stream
				Rijndael rijndael=Rijndael.Create();
				rijndael.KeySize=128;//16 bytes;
				rijndael.Key=hash;
				rijndael.IV=new byte[16];
				CryptoStream cryptoStream=new CryptoStream(memoryStream,rijndael.CreateDecryptor(),CryptoStreamMode.Write);
				cryptoStream.Write(byteArrayEncrypted,0,byteArrayEncrypted.Length);
				cryptoStream.FlushFinalBlock();
				byte[] byteArray=new byte[memoryStream.Length];
				memoryStream.Position=0;
				memoryStream.Read(byteArray,0,(int)memoryStream.Length);
				cryptoStream.Dispose();
				memoryStream.Dispose();
				//now convert the bytes into a string.
				string rawString=Encoding.UTF8.GetString(byteArray);
				string strDigitalSigPrefix="";
				strDigitalSigPrefix+=int.MinValue.ToString()+","+int.MinValue.ToString()+";";
				strDigitalSigPrefix+=int.MinValue.ToString()+","+int.MinValue.ToString()+";";
				if(rawString.StartsWith(strDigitalSigPrefix)){
					List<byte> listBytes=new List<byte>();
					List<string> listStrPoints=rawString.Split(';').ToList();
					for(int i=0;i<listStrPoints.Count;i++){
						string[] coords=listStrPoints[i].Split(new char[] {','});
						//We can't use floats here
						Point point=new Point(Convert.ToInt32(coords[0]),Convert.ToInt32(coords[1]));
						if(point.X>int.MinValue){
							listBytes.Add((byte)point.X);
						}
						if(point.Y>int.MinValue){
							listBytes.Add((byte)point.Y);
						}
					}
					_strDigitalSig=Encoding.UTF8.GetString(listBytes.ToArray());
				}
				else{
					//convert the raw string into a series of points
					List<string> listStrPoints=rawString.Split(new char[] {';'}).ToList();
					for(int i=0;i<listStrPoints.Count;i++){
						string[] coords=listStrPoints[i].Split(new char[] {','});
						PointF pointF=new PointF(Convert.ToSingle(coords[0]),Convert.ToSingle(coords[1]));
						listPointFs.Add(pointF);
					}
				}
				Invalidate();
			}
			catch(Exception e) {
				e.DoNothing();
				//this will leave the list with zero points
			}
		}

		///<Summary>Also includes a surrounding box.</Summary>
		public Image GetSigImage(bool includeBorder){
			Image image=new Bitmap(Width,Height);
			Graphics g=Graphics.FromImage(image);
			g.FillRectangle(Brushes.White,0,0,this.Width,this.Height);
			using Pen pen=new Pen(Color.Black,2f);
			g.SmoothingMode=SmoothingMode.HighQuality;
			if(IsDigitalSignature()) {
				StringFormat stringFormat = StringFormat.GenericDefault;
				stringFormat.Alignment=StringAlignment.Center;
				g.DrawString(_strDigitalSig,Font,Brushes.Black,Width/2,Height/2,stringFormat);
				stringFormat?.Dispose();
			}
			else {
				for(int i=1;i<listPointFs.Count;i++) {//skip the first point
					if(listPointFs[i-1].X==0 && listPointFs[i-1].Y==0) {
						continue;
					}
					if(listPointFs[i].X==0 && listPointFs[i].Y==0) {
						continue;
					}
					g.DrawLine(pen,listPointFs[i-1],listPointFs[i]);
				}
			}
			if(includeBorder){
				g.DrawRectangle(Pens.Black,0,0,Width-1,Height-1);
			}
			g.Dispose();
			return image;
		}

		public void SetPointList(List<PointF> listPointFs) {
			this.listPointFs=new List<PointF>(listPointFs);
			Invalidate();
		}

		public string GetPointStringForWebTest() {
			if(_strDigitalSig!=null){
				return _strDigitalSig;
			}
			//return string.Join(";",listPoints);
			//The above probably won't work with floats.
			//We want format like this:
			//"{X=1,Y=1};{X=15,Y=15};{X=0,Y=0};{X=1,Y=15};{X=15,Y=1}"
			string retVal="";
			for(int i=0;i<listPointFs.Count;i++){
				if(i>0){
					retVal+=";";
				}
				retVal+="{";
				retVal+="X="+listPointFs[i].X.ToString("f0");
				retVal+=",";
				retVal+="Y="+listPointFs[i].Y.ToString("f0");
				retVal+="}";
			}
			return retVal;
		}

		///<summary></summary>
		protected override void OnPaintBackground(PaintEventArgs pea) {
			//base.OnPaintBackground (pea);
			//don't paint background.  This reduces flickering when using double buffering.
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g=e.Graphics;
			using Pen pen = new Pen(Color.Black,2f);
			g.FillRectangle(Brushes.White,0,0,this.Width,this.Height);
			g.SmoothingMode=SmoothingMode.HighQuality;
			if(IsDigitalSignature()) {
				StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
				stringFormat.Alignment=StringAlignment.Center;
				stringFormat.LineAlignment=StringAlignment.Center;
				g.DrawString(_strDigitalSig,Font,Brushes.Black,Width/2,Height/2,stringFormat);
				stringFormat?.Dispose();
				return;
			}
			for(int i = 1;i<listPointFs.Count;i++) {//skip the first point
				if(listPointFs[i-1].X==0 && listPointFs[i-1].Y==0) {
					continue;
				}
				if(listPointFs[i].X==0 && listPointFs[i].Y==0) {
					continue;
				}
				g.DrawLine(pen,ScaleF(listPointFs[i-1].X),ScaleF(listPointFs[i-1].Y),ScaleF(listPointFs[i].X),ScaleF(listPointFs[i].Y));
			}
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			//mouse events won't get hit when _strDigitalSig is filled with text because control is disabled.
			base.OnMouseDown(e);
			if(tabletState==0){
				return;
			}
			mouseIsDown=true;
			PointF pointF=new PointF(Unscale(e.X),Unscale(e.Y));
			listPointFs.Add(pointF);
			//Invalidate();
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			//mouse events won't get hit when _strDigitalSig is filled with text because control is disabled.
			base.OnMouseMove(e);
			if(tabletState==0) {
				return;
			}
			if(!mouseIsDown){
				return;
			}
			PointF pointF=new PointF(Unscale(e.X),Unscale(e.Y));
			listPointFs.Add(pointF);
			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			//mouse events won't get hit when _strDigitalSig is filled with text because control is disabled.
			base.OnMouseUp(e);
			if(tabletState==0) {
				return;
			}
			mouseIsDown=false;
			listPointFs.Add(new PointF(0,0));
		}

		public bool IsDigitalSignature(){
			return _strDigitalSig!=null;
		}

		///<summary>This is used for when "digitally signing". A string is created describing who signed, and the string is passed in here. This method converts the bytes of the text into a format that looks like a series of points. This was not a good strategy, but we are stuck with it. It also prepends two points (4 numbers) that are all int.MinValue.</summary>
		public void SetDigitalSig(string str){
			_strDigitalSig=str;
		}

		/*
		public string GetEncryptedString() {
			if(!IsDigitalSignature()) {
				return "";
			}
			try {
				return Encoding.UTF8.GetString(listPointFs.SelectMany(x => new[] { x.X,x.Y }).Where(x=>x>int.MinValue).Select(x=>(byte)x).ToArray());
			}
			catch(Exception ex) { ex.DoNothing(); }
			return "";
		}

		///<summary>This is used for when "digitally signing". A string is created describing who signed, and the string is passed in here. This method converts the bytes of the text into a format that looks like a series of points. This was not a good strategy, but we are stuck with it. It also prepends two points (4 numbers) that are all int.MinValue.</summary>
		public List<PointF> EncryptString(string input) {
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			List<Point> retVal = new List<Point>() {
				//These two points indicate that this is NOT a "Normal" signature.
				new Point(int.MinValue,int.MinValue),
				new Point(int.MinValue,int.MinValue)
			};
			for(int i = 0;i<bytes.Length;i=i+2) {
				retVal.Add(new Point(bytes[i],(i+2)>bytes.Length?int.MinValue:bytes[i+1]));
			}
			return retVal;
		}

		/// <summary>A "digital" signature has the first two dummy points of int.min, followed by a user readable string.</summary>
		public bool IsDigitalSignature() {
			if(listPointFs==null || listPointFs.Count<2 || listPointFs[0]!=listPointFs[1] || listPointFs[0].X!=int.MinValue || listPointFs[0].Y!=int.MinValue) {
				//The first two points MUST be Point(Int.MinValue,Int.MinValue), otherwise this is a "Normal" signature.
				return false;
			}
			return true;
		}
		*/


	}
}
