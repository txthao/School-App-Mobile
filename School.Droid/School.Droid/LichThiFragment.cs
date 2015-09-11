
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
			BLichThi.MakeDataFromXml(GetXmlFromSV(),SQLite_Android.GetConnection ());


			var rootView = inflater.Inflate(Resource.Layout.LichThi, container, false);
		

			List<User> l = new List<User> ();

			l.Add(BUser.GetUser (SQLite_Android.GetConnection (),"1111"));



			return rootView;
		}


		private string GetXmlFromSV()
		{
			XmlDocument doc = new XmlDocument ();
			doc.Load ("http://www.schoolapi.somee.com/api/lichthi/3112410012");
			return doc.InnerXml;
		}
	}
}

