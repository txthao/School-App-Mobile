
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
//		    var rootView = inflater.Inflate(Resource.Layout.LichHoc_HK, container, false);
//			ListView listView = rootView.FindViewById<ListView>(Resource.Id.listLH);
//
//			var t= BLichHoc.MakeDataFromXml(SQLite_Android.GetConnection ());
//			List<LichHoc> listLH = BLichHoc.GetAll (SQLite_Android.GetConnection ());
//			List<chiTietLH> listCT = new List<chiTietLH> ();
//			foreach (var item in listLH) {
//				listCT.AddRange(BLichHoc.GetCTLH (SQLite_Android.GetConnection (), item.Id));
//
//			}
//	
//
//			LichHocHKAdapter adapter = new LichHocHKAdapter (Activity, listCT);
//			listView.Adapter  = adapter;


			//Theo Tuan
			var rootView = inflater.Inflate(Resource.Layout.LichHoc_Tuan, container, false);
			var t= BLichHoc.MakeDataFromXml(SQLite_Android.GetConnection ());

			List<LichHoc> listLH = BLichHoc.GetAll(SQLite_Android.GetConnection ());
			List<chiTietLH> listCT = new List<chiTietLH> ();
			foreach (var item in listLH) {
				//List<chiTietLH> list = BLichHoc.GetCTLH (SQLite_Android.GetConnection (), item.Id).ToList();
				listCT.Add(BLichHoc.GetCTLH (SQLite_Android.GetConnection (), item.Id).First());

			}
	
			var listView = rootView.FindViewById<ExpandableListView>(Resource.Id.listLH_Tuan);
			listView.SetAdapter (new LichHocTuanAdapter(Activity, listCT)); 
			return rootView;
		}

		public static bool DateInsideOneWeek(DateTime checkDate)
		{
			// get first day of week from your actual culture info, 
			DayOfWeek firstWeekDay = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
			// or you can set exactly what you want: firstWeekDay = DayOfWeek.Monday;
			// calculate first day of week from your reference date
			DateTime referenceDate = DateTime.Today;
			DateTime startDateOfWeek = referenceDate;
			while(startDateOfWeek.DayOfWeek != firstWeekDay)
			{ startDateOfWeek = startDateOfWeek.AddDays(-1d); }
			// fist day of week is find, then find last day of reference week
			DateTime endDateOfWeek = startDateOfWeek.AddDays(6d);
			// and check if checkDate is inside this period
			return checkDate >= startDateOfWeek && checkDate <= endDateOfWeek;
		}


	}
}

