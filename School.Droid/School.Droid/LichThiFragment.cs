
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  static Android.Widget.Adapter;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using School.Core;

namespace School.Droid
{
	public class LichThiFragment : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

		

		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			User lt= new User ();
			lt.Id = "";
			lt.Hoten = "Teo";

			int i=BUser.AddUser (SQLite_Android.GetConnection(),lt);


			var rootView = inflater.Inflate(Resource.Layout.LichThi, container, false);
		

			List<User> l = new List<User> ();

			l.Add(BUser.GetUser (SQLite_Android.GetConnection (),"1111"));





			return rootView;
		}
	}
}

