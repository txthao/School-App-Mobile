
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace School.Droid
{
	[Activity (Label = "SGU",MainLauncher = true, 
		Theme = "@android:style/Theme.Holo.NoActionBar")]			
	public class Main : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			if (School.Core.BUser.IsLogined (SQLite_Android.GetConnection ()) == false) {

				Intent myintent = new Intent (this, typeof(LoginActivity));
				StartActivity (myintent);

				this.Finish ();

			} else {

				Intent myintent = new Intent (this, typeof(DrawerActivity));
				StartActivity (myintent);

				this.Finish ();
			}
			// Create your application here
		}
	}
}

