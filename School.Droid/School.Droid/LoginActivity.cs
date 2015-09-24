﻿
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
using School.Core;

namespace School.Droid
{
	[Activity (Label = "Login")]			
	public class LoginActivity : Activity
	{
		Button btnLogin;
		EditText username;
		EditText password;
		TextView errormsg;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
				
					
			SetContentView (Resource.Layout.LogIn);

					// Create your application here
			password = FindViewById<EditText> (Resource.Id.txtmk);
			username = FindViewById<EditText> (Resource.Id.txtmsv);
			username.Click += delegate {
						username.Text = "";
						password.Text = "";
					};



					password.Click += delegate {
						password.Text = "";
					};


			btnLogin = FindViewById<Button> (Resource.Id.btDangNhap);

			btnLogin.Click += new EventHandler (LogInProcess);
				

		
		
		}
		async void  LogInProcess(object sender, EventArgs e)
		{
			
				
				errormsg = FindViewById<TextView> (Resource.Id.errorMSG);
			if (!String.IsNullOrEmpty (username.Text) && !String.IsNullOrEmpty (password.Text)) {
				ProgressDialog dialog = new ProgressDialog (this);
				dialog.SetMessage ("Login...");
				dialog.Indeterminate = false;
				dialog.SetCancelable (false);
				dialog.Show ();

				if (await BUser.CheckAuth (username.Text, password.Text, SQLite_Android.GetConnection ())) {
					Intent myintent = new Intent (this, typeof(DrawerActivity));
					StartActivity (myintent);

					this.Finish ();
				} else {
					dialog.Dismiss ();
					errormsg.Text = "Mã Sinh Viên Hoặc Mật Khẩu Không Đúng!";

				}
			}
		}



		


//				pDialog = new ProgressDialog(LoginActivity.,1);
//				pDialog.SetMessage("Login...");
//				pDialog.Indeterminate=false;
//				pDialog.SetCancelable(false);
//				pDialog.Show();
//


	}
}

