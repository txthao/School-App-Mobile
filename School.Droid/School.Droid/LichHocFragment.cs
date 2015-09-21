
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
using System.Xml;
using School.Core;

namespace School.Droid
{
	public class LichHocFragment : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
		
//  Lich hoc theo HK
			var rootView = inflater.Inflate(Resource.Layout.LichHoc, container, false);
			ListView listView = rootView.FindViewById<ListView>(Resource.Id.listLH);

			var t= BLichHoc.MakeDataFromXml(SQLite_Android.GetConnection ());
			List<LichHoc> listLH = BLichHoc.GetAll (SQLite_Android.GetConnection ());
			List<chiTietLH> listCT = new List<chiTietLH> ();
			foreach (var item in listLH) {
				listCT.AddRange(BLichHoc.GetCTLH (SQLite_Android.GetConnection (), item.Id));

			}
	

			LichHocHKAdapter adapter = new LichHocHKAdapter (Activity, listCT);
			listView.Adapter  = adapter;

//
//			var rootView = inflater.Inflate(Resource.Layout.LichHocHeader, container, false);
//			List<LichHoc> listLH = BLichHoc.GetAll(SQLite_Android.GetConnection ());
//			List<chiTietLH> listCT = new List<chiTietLH> ();
//			foreach (var item in listLH) {
//				listCT.Add(BLichHoc.GetCTLH (SQLite_Android.GetConnection (), item.Id).First());
//			}

			return rootView;
		}

	}
}

