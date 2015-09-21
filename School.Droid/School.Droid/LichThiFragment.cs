
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using School.Core;
using System.Xml;

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
			BLichThi.MakeDataFromXml( SQLite_Android.GetConnection());
			List<LichThi> list = BLichThi.getAll (SQLite_Android.GetConnection ());
  
			var rootView = inflater.Inflate(Resource.Layout.LichThi, container, false);
		

			List<User> l = new List<User> ();
            System.Diagnostics.Debug.WriteLine("size: " + list.Count);
			l.Add(BUser.GetUser (SQLite_Android.GetConnection (),"1111"));

            ListView listView = rootView.FindViewById<ListView>(Resource.Id.listLT);
            LichThiAdapter adapter = new LichThiAdapter(Activity, list);
            listView.Adapter = adapter;
 


			return rootView;
		}



	}
}

