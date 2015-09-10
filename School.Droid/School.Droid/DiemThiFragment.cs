
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
			BDiemThi.MakeDataFromXml(GetXmlFromSV(),SQLite_Android.GetConnection ());
			var rootView = inflater.Inflate(Resource.Layout.DiemThi, container, false);
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

