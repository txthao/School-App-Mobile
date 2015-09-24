
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
		ListView listView;
		ProgressBar progress;
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

		

		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
		
  
			var rootView = inflater.Inflate(Resource.Layout.LichThi, container, false);
		


            

             listView = rootView.FindViewById<ListView>(Resource.Id.listLT);
			progress= rootView.FindViewById<ProgressBar>(Resource.Id.progressLT);
			LoadData ();


			return rootView;
		}
		async void LoadData()
		{
			progress.Visibility = ViewStates.Visible;
			progress.Indeterminate = true;
			List<LichThi> list = new List<LichThi>();
			var t=await BLichThi.MakeDataFromXml( SQLite_Android.GetConnection());

			list = BLichThi.getAll (SQLite_Android.GetConnection ());
			List<User> l = new List<User> ();
			System.Diagnostics.Debug.WriteLine("size: " + list.Count);
			l.Add(BUser.GetUser (SQLite_Android.GetConnection (),"1111"));

			LichThiAdapter adapter = new LichThiAdapter(Activity, list);
			listView.Adapter = adapter;
			progress.Indeterminate = false;
			progress.Visibility = ViewStates.Gone;
		}


	}
}

