
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

			List<DiemThi> list = new List<DiemThi>();
				list = BDiemThi.MakeDataFromXml(GetXmlFromSV(),SQLite_Android.GetConnection ());
//
//			List<User> l = new List<User> ();
//			System.Diagnostics.Debug.WriteLine("size: " + list.Count);
//			l.Add(BUser.GetUser (SQLite_Android.GetConnection (),"1111"));


			var listView = rootView.FindViewById<ExpandableListView>(Resource.Id.listDT);
			//DiemThiApdater adapter = new DiemThiApdater(Activity, list);
			listView.SetAdapter (new DiemThiApdater(Activity, list)); 

			return rootView;
		}
		private string GetXmlFromSV()
		{
			XmlDocument doc = new XmlDocument ();
			doc.Load ("http://www.schoolapi.somee.com/api/diemthi/3111410094");
			return doc.InnerXml;
		}
	}
}

