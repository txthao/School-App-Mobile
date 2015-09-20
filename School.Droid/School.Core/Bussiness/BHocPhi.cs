using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using SQLite;

namespace School.Core
{
	public class BHocPhi
	{
		
		public static List<HocPhi> list;
		public static List<HocPhi> getAll(SQLiteConnection connection)
		{
			list = new List<HocPhi>();
			DataProvider dtb = new DataProvider (connection);
			list = dtb.GetAllHP ();
			return list;
		}
		public static int AddHP(SQLiteConnection connection, HocPhi hp)
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.GetHP (hp.NamHoc,hp.HocKy) == null) {
				return dtb.AddHP (hp);
			}
			return 0;
		}
		public static List<CTHocPhi> GetCTHP(SQLiteConnection connection,int namhoc, int hocky)
		{
			DataProvider dtb = new DataProvider (connection);
			return dtb.GetCTHPs ( namhoc,  hocky);
		}
		public static int AddCTHP(SQLiteConnection connection, CTHocPhi ct)
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.GetCTHP (ct) == null) {
				return dtb.AddCTHP (ct);
			}
			return 0;
		}

		public static HocPhi GetHP(SQLiteConnection connection,int namhoc, int hocky)
		{
			DataProvider dtb = new DataProvider (connection);
			return dtb.GetHP (namhoc,hocky);
		}
		public static HocPhi MakeDataFromXml(string xml,SQLiteConnection connection)
		{
			
			XDocument doc = XDocument.Parse (xml);
			 


			XElement node = doc.Root;
			HocPhi hp = new HocPhi();
			hp.HocKy = int.Parse(node.Elements().ElementAt(1).Value[7].ToString());
			hp.NamHoc = int.Parse(node.Elements().ElementAt(1).Value.Substring(19, 4));
			hp.TienConNo = node.Elements ().ElementAt (2).Value.Trim ();
			hp.TienDaDong = node.Elements ().ElementAt (3).Value.Trim ();
			hp.TienDongTTLD = node.Elements ().ElementAt (4).Value.Trim ();
			hp.TongSoTC = node.Elements ().ElementAt (5).Value.Trim ();
			hp.TongSoTien = node.Elements ().ElementAt (6).Value.Trim ();

			foreach (XElement node1 in node.Elements ().ElementAt (0).Elements())
			{
				CTHocPhi ct = new CTHocPhi();
				ct.HocPhi = node1.Elements().ElementAt(0).Value.Trim();
				ct.MaNhom = node1.Elements().ElementAt(1).Value.Trim();
				ct.MienGiam = node1.Elements().ElementAt(2).Value.Trim();
				ct.PhaiDong = node1.Elements().ElementAt(3).Value.Trim();
				ct.HocKy = hp.HocKy;
				ct.NamHoc = hp.NamHoc;

				ct.MaMH = node1.Elements().ElementAt(4).Elements().ElementAt(0).Value.Trim();;
				AddCTHP (connection, ct);
			}
			AddHP(connection,hp);
			return hp;

		}

	}
}

