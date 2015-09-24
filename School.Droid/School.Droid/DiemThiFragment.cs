
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
	public class DiemThiFragment : Fragment
	{
		ExpandableListView listView;
		ProgressBar progress;
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);


			var rootView = inflater.Inflate(Resource.Layout.DiemThi, container, false);
			listView = rootView.FindViewById<ExpandableListView>(Resource.Id.listDT);
			progress=rootView.FindViewById<ProgressBar>(Resource.Id.progressDT);
			//			List<User> l = new List<User> ();
			//			System.Diagnostics.Debug.WriteLine("size: " + list.Count);
			//			l.Add(BUser.GetUser (SQLite_Android.GetConnection (),"1111"));

			LoadData ();

			return rootView;
		}
		async void LoadData()
		{
			progress.Visibility = ViewStates.Visible;
			progress.Indeterminate = true;
			List<DiemThi> list = new List<DiemThi>();
			var t=await BDiemThi.MakeDataFromXml(SQLite_Android.GetConnection ());

			list = BDiemThi.getAll(SQLite_Android.GetConnection ());
			listView.SetAdapter (new DiemThiApdater(Activity, list)); 
			progress.Indeterminate = false;
			progress.Visibility = ViewStates.Gone;
		}

	}
}

