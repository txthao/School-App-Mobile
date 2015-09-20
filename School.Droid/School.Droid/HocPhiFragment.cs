
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
	public class HocPhiFragment : Fragment
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

			var rootView = inflater.Inflate(Resource.Layout.HocPhi, container, false);


			HocPhi hp = BHocPhi.MakeDataFromXml(GetXmlFromSV(),SQLite_Android.GetConnection ());
			List<CTHocPhi> listCT = BHocPhi.GetCTHP (SQLite_Android.GetConnection (), hp.NamHoc, hp.HocKy);
			ListView listView = rootView.FindViewById<ListView>(Resource.Id.listHP);
			HocPhiAdapter adapter = new HocPhiAdapter(Activity, listCT);

			listView.Adapter = adapter;
			rootView.FindViewById<TextView> (Resource.Id.txtTSTC).Text += hp.TongSoTC;
			rootView.FindViewById<TextView> (Resource.Id.txtTSTHP).Text += hp.TongSoTien;
			rootView.FindViewById<TextView> (Resource.Id.txtTTLD).Text += hp.TienDongTTLD;
			rootView.FindViewById<TextView> (Resource.Id.txtTDD).Text += hp.TienDaDong;
			rootView.FindViewById<TextView> (Resource.Id.txtTCN).Text += hp.TienConNo;

			return rootView;
		}
		private string GetXmlFromSV()
		{
			XmlDocument doc = new XmlDocument ();
			doc.Load ("http://www.schoolapi.somee.com/api/hocphi/3111410089/secret01");
			return doc.InnerXml;
		}
	}
}

