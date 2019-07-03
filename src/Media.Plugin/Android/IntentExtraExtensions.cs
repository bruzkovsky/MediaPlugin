﻿using Android.Content;
using Android.Hardware;

namespace Plugin.Media
{
	internal static class IntentExtraExtensions
	{
		private const string extraFrontPre25 = "android.intent.extras.CAMERA_FACING";
		private const string extraFrontPost25 = "android.intent.extras.LENS_FACING_FRONT";
		private const string extraBackPost25 = "android.intent.extras.LENS_FACING_BACK";
		private const string extraUserFront = "android.intent.extra.USE_FRONT_CAMERA";

		public static void UseFrontCamera(this Intent intent)
		{
			// Android before API 25 (7.1)
			intent.PutExtra(extraFrontPre25, (int)CameraFacing.Front);

			// Android API 25 and up
			intent.PutExtra(extraFrontPost25, 1);
			intent.PutExtra(extraUserFront, true);
		}

		public static void UseBackCamera(this Intent intent)
		{
			// Android before API 25 (7.1)
			intent.PutExtra(extraFrontPre25, (int)CameraFacing.Back);

			// Android API 25 and up
			intent.PutExtra(extraBackPost25, 1);

			//Removed PutExtra.  LG Phones crash when setting this intent and the back camera
			// is already enabled (UserFront=false)

			//TODO: Test if we can use the GetExtra to check before setting. May still fix LG
			//with less potential negative side-effects for other phones or for the front-facing camera
			
			//var val = intent.GetBooleanExtra(extraUserFront, false);
			//if (val)
			//	intent.PutExtra(extraUserFront, false);
		}
	}
}