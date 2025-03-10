﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace OpenDentBusiness{
	///<summary></summary>
	public class MobileBrandingProfiles{
		#region Methods - Get
		public static MobileBrandingProfile GetByClinicNum(long clinicNum) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT){
				return Meth.GetObject<MobileBrandingProfile>(MethodBase.GetCurrentMethod(),clinicNum);
			}
			string command="SELECT * FROM mobilebrandingprofile WHERE ClinicNum="+clinicNum;
			return Crud.MobileBrandingProfileCrud.SelectOne(command);
		}
		#endregion
		#region Methods - Modify
		///<summary></summary>
		public static long Insert(MobileBrandingProfile mobileBrandingProfile){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT){
				mobileBrandingProfile.MobileBrandingProfileNum=Meth.GetLong(MethodBase.GetCurrentMethod(),mobileBrandingProfile);
				return mobileBrandingProfile.MobileBrandingProfileNum;
			}
			return Crud.MobileBrandingProfileCrud.Insert(mobileBrandingProfile);
		}
		///<summary></summary>
		public static void Update(MobileBrandingProfile mobileBrandingProfile){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT){
				Meth.GetVoid(MethodBase.GetCurrentMethod(),mobileBrandingProfile);
				return;
			}
			Crud.MobileBrandingProfileCrud.Update(mobileBrandingProfile);
		}

		///<summary></summary>
		public static void Delete(long mobileBrandingProfileNum) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),mobileBrandingProfileNum);
				return;
			}
			Crud.MobileBrandingProfileCrud.Delete(mobileBrandingProfileNum);
		}

		/// <summary>Deletes clinics MBP if they are using default. creates a duplicate of default MBP if they are not using default, the MBP is null and the clinic has changes.</summary>
		public static void SynchMobileBrandingProfileClinicDefaults(List<long> listClinicNumsChanged) {
			Meth.NoCheckMiddleTierRole();
			MobileBrandingProfile mobileBrandingProfileDefault=MobileBrandingProfiles.GetByClinicNum(0);
			for(int i = 0; i<listClinicNumsChanged.Count; i++) {
				MobileBrandingProfile mobileBrandingProfile=MobileBrandingProfiles.GetByClinicNum(listClinicNumsChanged[i]);
				//try fetching the updated version
				bool doUseEClipbardDefaultsforClinic=ClinicPrefs.GetBool(PrefName.EClipboardUseDefaults, listClinicNumsChanged[i]);
				if(doUseEClipbardDefaultsforClinic && mobileBrandingProfile!=null) {
					//Was changed, and pref does not exist, or is true.
					//Defaults are in use.
					//Delete MBP if it exists.
					MobileBrandingProfiles.Delete(mobileBrandingProfile.MobileBrandingProfileNum);
					continue;
				}
				//Was changed, pref exists, and is false
				//Defaults are not in use.
				//Create a copy of the default MBP if no MBP exists, otherwise update existing to match default.
				if(mobileBrandingProfile==null && mobileBrandingProfileDefault!=null) {
					mobileBrandingProfile=new MobileBrandingProfile();
					mobileBrandingProfile.ClinicNum=listClinicNumsChanged[i];
					mobileBrandingProfile.OfficeDescription=mobileBrandingProfileDefault.OfficeDescription;
					mobileBrandingProfile.LogoFilePath=mobileBrandingProfileDefault.LogoFilePath;
					mobileBrandingProfile.DateTStamp=DateTime.Now;
					mobileBrandingProfile.MobileBrandingProfileNum=MobileBrandingProfiles.Insert(mobileBrandingProfile);
				}
				//No else. In the case that MBP exists, the user created it after unchecking use defaults, so retain their changes.
			}
		}
		#endregion
		
	}
}