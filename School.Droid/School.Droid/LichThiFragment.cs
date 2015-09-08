
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
			LichThi lt = new LichThi ();
			lt.GhepThi = "01";
			lt.PhongThi = "001";
			lt.MaMH = "8410";
			BLichThi.AddLT (lt,SQLite_Android.GetConnection());


			var rootView = inflater.Inflate(Resource.Layout.LichThi, container, false);
		
			ListView lv = rootView.FindViewById<ListView> (Resource.Id.listLT);
			List<LichThi> l = new List<LichThi> ();

			l = BLichThi.getAll (SQLite_Android.GetConnection ());





			return rootView;
		}
	}
}

