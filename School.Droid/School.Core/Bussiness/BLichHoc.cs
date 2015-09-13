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
	public class BLichHoc
	{
		public static List<LichHoc> list;
		public static List<LichHoc> GetAll(SQLiteConnection connection)
		{
			list = new List<LichHoc>();
			DataProvider dtb = new DataProvider (connection);
			list = dtb.GetAllLH ();
			return list;
		}
		public static void AddLH(LichHoc lt,SQLiteConnection connection )
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.GetLH (lt.MaMH) == null) {
				dtb.AddLH (lt);
			}
		}
		public static int GetId(SQLiteConnection connection)
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.GetLast() == null) {
				return 1;
			}
			string k = dtb.GetLast ().Id;
			return int.Parse (k) + 1;
		}
		public static int AddCTLH(SQLiteConnection connection, chiTietLH ct)
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.GetCTLH (ct.Id).Count==0) {
				return dtb.AddCTLH (ct);
			}
			return 0;
		}
		public static List<chiTietLH> GetCTLH(SQLiteConnection connection, string id)
		{
			DataProvider dtb = new DataProvider (connection);
			return dtb.GetCTLH (id);
		}

		public static List<LichHoc> MakeDataFromXml(string xml,SQLiteConnection connection)
		{
			list = new List<LichHoc> ();
			XDocument doc = XDocument.Parse (xml);
			//get lichthi 
			IEnumerable<XElement> childList =
				from el in doc.Root.Elements ()
				select el;
			//get attri lichthi
			int k=GetId( connection);
			foreach (XElement node in childList) {
				LichHoc lh = new LichHoc();
				MonHoc mh = new MonHoc();
				lh.Id = k.ToString() ;

				lh.MaMH = node.Elements().ElementAt(0).Value.Trim();
				lh.MaLop = node.Elements().ElementAt(1).Value.Trim();
				lh.NhomMH = node.Elements().ElementAt(3).Value.Trim();
				mh.MaMH = lh.MaMH;
				mh.TenMH = node.Elements().ElementAt(7).Value.Trim();
				mh.SoTC=int.Parse(node.Elements().ElementAt(5).Value.Trim());
				mh.TiLe = "test";
				lh.ThoigianBD = node.Elements().ElementAt(10).Value.Trim().Substring(0, 10);
				lh.ThoigianKT = node.Elements().ElementAt(10).Value.Trim().Substring(12);

				// constant
				int one = 1;
				int five = 5;
				for (int i = 0; i < node.Elements().ElementAt(8).Value.Trim().Length; i++)
				{
					chiTietLH ct = new chiTietLH();
					ct.Id = k.ToString();
					ct.CBGD = node.Elements().ElementAt(0).Value.Trim().Substring(i * five, five);

					ct.Phong = node.Elements().ElementAt(4).Value.Trim().Substring(i * 6, 6);
					ct.Thu =  node.Elements().ElementAt(8).Value.Trim().Substring(i * one, one);
					ct.TietBatDau = node.Elements().ElementAt(8).Value.Trim().Substring(i * one, one);//tiet bat dau = 10

					ct.SoTiet =node.Elements().ElementAt(6).Value.Trim()[i].ToString();
					AddCTLH (connection, ct);
				}

				list.Add(lh);
				AddLH(lh,connection);
				BMonHoc.Add(connection,mh);
				k++;
			}
			return list;
		}


	}
}

