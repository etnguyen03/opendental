using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace OpenDentBusiness{
	///<summary></summary>
	public class ImageDraws{
		#region Methods - Get
		///<summary>All drawings for a single document.</summary>
		public static List<ImageDraw> RefreshForDoc(long docNum){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				return Meth.GetObject<List<ImageDraw>>(MethodBase.GetCurrentMethod(),docNum);
			}
			string command="SELECT * FROM imagedraw WHERE DocNum = "+POut.Long(docNum);
			return Crud.ImageDrawCrud.SelectMany(command);
		}

		///<summary>All drawings for a single mount.</summary>
		public static List<ImageDraw> RefreshForMount(long mountNum){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				return Meth.GetObject<List<ImageDraw>>(MethodBase.GetCurrentMethod(),mountNum);
			}
			string command="SELECT * FROM imagedraw WHERE MountNum = "+POut.Long(mountNum);
			return Crud.ImageDrawCrud.SelectMany(command);
		}
		/*
		///<summary>Gets one ImageDraw from the db.</summary>
		public static ImageDraw GetOne(long imageDrawNum){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT){
				return Meth.GetObject<ImageDraw>(MethodBase.GetCurrentMethod(),imageDrawNum);
			}
			return Crud.ImageDrawCrud.SelectOne(imageDrawNum);
		}*/
		#endregion Methods - Get
		#region Methods - Modify
		///<summary></summary>
		public static long Insert(ImageDraw imageDraw){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT){
				imageDraw.ImageDrawNum=Meth.GetLong(MethodBase.GetCurrentMethod(),imageDraw);
				return imageDraw.ImageDrawNum;
			}
			return Crud.ImageDrawCrud.Insert(imageDraw);
		}

		///<summary></summary>
		public static void Update(ImageDraw imageDraw){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT){
				Meth.GetVoid(MethodBase.GetCurrentMethod(),imageDraw);
				return;
			}
			Crud.ImageDrawCrud.Update(imageDraw);
		}

		///<summary></summary>
		public static void Delete(long imageDrawNum) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),imageDrawNum);
				return;
			}
			Crud.ImageDrawCrud.Delete(imageDrawNum);
		}

		///<summary></summary>
		public static void DeleteByDocNum(long docNum) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),docNum);
				return;
			}
			string command="DELETE FROM imagedraw WHERE DocNum="+POut.Long(docNum);
			Db.NonQ(command);
		}

		///<summary></summary>
		public static void DeleteByDocNumAndVendor(long docNum,EnumImageAnnotVendor enumImageAnnotVendor) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),docNum,enumImageAnnotVendor);
				return;
			}
			string command="DELETE FROM imagedraw WHERE DocNum="+POut.Long(docNum)+" AND ImageAnnotVendor="+POut.Enum(enumImageAnnotVendor);
			Db.NonQ(command);
		}
		#endregion Methods - Modify
		
		#region Methods - Helper Logic
		/*
		///<summary></summary>
		public static double ImageScale(MountItem mountItem,Bitmap bitmap,Document document) {
			double zoomOrig;
			if(document.CropW==0) {
				float ratioCropWtoH=(float)mountItem.Width/(float)mountItem.Height;
				bool isWide=false;
				if((double)bitmap.Width/bitmap.Height > ratioCropWtoH) {
					isWide=true;
				}
				if(isWide) {
					zoomOrig=(double)mountItem.Width/(double)bitmap.Width;
				}
				else {
					zoomOrig=(double)mountItem.Height/(double)bitmap.Height;
				}
			}
			else {
				zoomOrig=(double)mountItem.Width/(double)document.CropW;
			}
			zoomOrig=Math.Round(zoomOrig,3);
			return zoomOrig;
		}*/

		///<summary>Calculates in pixels, which separately get converted according to scale.</summary>
		public static float CalcLengthLine(List<PointF> listPointFs){
			float lengthTotal=0;
			for(int p=1;p<listPointFs.Count;p++){
				float x1=listPointFs[p-1].X;
				float y1=listPointFs[p-1].Y;
				float x2=listPointFs[p].X;
				float y2=listPointFs[p].Y;
				float lengthLine=(float)Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2));
				lengthTotal+=lengthLine;
			}
			return lengthTotal;
		}

		///<summary>Calculates the scale required to fit the bitmap into the mount item while maintaining original aspect ratio. Used for scaling generated ImageDraws to align with the mounted bitmap.</summary>
		public static float CalcBitmapScaleToFitMountItem(int bitmapWidth,int bitmapHeight,int mountItemWidth,int mountItemHeight) {
			float scale=1f;
			if(bitmapWidth==0 || bitmapHeight==0) {
				return scale;
			}
			if(IsBitmapWiderThanMountItem(bitmapWidth,bitmapHeight,mountItemWidth,mountItemHeight)) {
				//The bitmap is wider in shape than the mount item. Scale points based on the width, as it is the limiting dimension.
				scale=(float)mountItemWidth/bitmapWidth;
			}
			else {
				//The bitmap is taller in shape than the mount item. Scale points based on the height, as it is the limiting dimension.
				scale=(float)mountItemHeight/bitmapHeight;
			}
			return scale;
		}
		
		///<summary>Calculates the padding required to fit the bitmap into the mount item while maintaining original aspect ratio. Used for translating generated ImageDraws to align with the mounted bitmap.</summary>
		public static Point CalcBitmapPaddingToFitMountItem(int bitmapWidth,int bitmapHeight,int mountItemWidth,int mountItemHeight,float scale) {
			Point point=new Point();
			if(IsBitmapWiderThanMountItem(bitmapWidth,bitmapHeight,mountItemWidth,mountItemHeight)) {
				//The bitmap is wider in shape than the mount item. Move down to be centered within mount item.
				point.Y=(int)(mountItemHeight-(bitmapHeight*scale))/2;
			}
			else {
				//The bitmap is taller in shape than the mount item. Move right to be centered within mount item..
				point.X=(int)(mountItemWidth-(bitmapWidth*scale))/2;
			}
			return point;
		}

		///<summary>Compares aspect ratio of mount item to bitmap.</summary>
		private static bool IsBitmapWiderThanMountItem(int bitmapWidth,int bitmapHeight,int mountItemWidth,int mountItemHeight) {
			//Scale points when bitmap aspect ratio doesn't match mount item's aspect ratio. 
			float ratioWtoHMountItem=(float)mountItemWidth/mountItemHeight;
			float ratioWtoHBitmap=(float)bitmapWidth/bitmapHeight;
			if(ratioWtoHBitmap>ratioWtoHMountItem) {
				//The bitmap is wider in shape than the mount item.
				return true;
			}
			//The bitmap is taller in shape than the mount item.
			return false;
		}

		///<summary>For text + line and contour boxes, Pearl uses pixels as coordinates relative to the original image. If the image was in a mount with different pixel size, we need to scale the pixels accordingly.</summary>
		public static List<PointF> ScalePointsToMountItem(List<PointF> listPointFs,float scale) {
			List<PointF> listPointFsScaled=new List<PointF>();
			for(int i=0;i<listPointFs.Count;i++) {
				PointF pointFScaled=new PointF();
				pointFScaled.X=listPointFs[i].X * scale;
				pointFScaled.Y=listPointFs[i].Y * scale;
				listPointFsScaled.Add(pointFScaled);
			}
			return listPointFsScaled;
		}

		///<summary>Translates a list of points to a position. Used to place points over the correct location in a mount.</summary>
		public static List<PointF> TranslatePointsToMountItem(List<PointF> listPointFs,PointF pointFMountItem) {
			List<PointF> listPointFsTranslated=new List<PointF>();
			for(int i=0;i<listPointFs.Count;i++) {
				PointF pointF=new PointF();
				pointF.X=listPointFs[i].X+pointFMountItem.X;
				pointF.Y=listPointFs[i].Y+pointFMountItem.Y;
				listPointFsTranslated.Add(pointF);
			}
			return listPointFsTranslated;
		}
		#endregion


	}
}