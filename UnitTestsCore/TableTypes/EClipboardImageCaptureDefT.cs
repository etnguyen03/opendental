using System;
using OpenDentBusiness;

namespace UnitTestsCore {
	public class EClipboardImageCaptureDefT {
		public static EClipboardImageCaptureDef CreateEClipboardImageCaptureDef(long defNum,bool isSelfPortrait,EnumEClipFreq frequency,TimeSpan resubmitInterval,long clinicNum) {
			EClipboardImageCaptureDef eClipboardImageCaptureDef=new EClipboardImageCaptureDef();
			eClipboardImageCaptureDef.DefNum=defNum;
			eClipboardImageCaptureDef.IsSelfPortrait=isSelfPortrait;
			eClipboardImageCaptureDef.Frequency=frequency;
			eClipboardImageCaptureDef.ResubmitInterval=resubmitInterval;
			eClipboardImageCaptureDef.ClinicNum=clinicNum;
			long eClipboardImageCaptureDefNum=EClipboardImageCaptureDefs.Insert(eClipboardImageCaptureDef);
			eClipboardImageCaptureDef.EClipboardImageCaptureDefNum=eClipboardImageCaptureDefNum;
			return eClipboardImageCaptureDef;
		}

		public static void ClearEClipboardImageCaptureDefTable() {
			string command="DELETE FROM eclipboardimagecapturedef WHERE EClipboardImageCaptureDefNum > 0";
			DataCore.NonQ(command);
		}
	}
}
