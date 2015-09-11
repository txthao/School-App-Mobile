using System;
using System.Collections.Generic;

using SQLite;
using System.Xml;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace School.Core
{
   public class BLichThi
    {
       public static List<LichThi> list;
		public static List<LichThi> getAll(SQLiteConnection connection)
        {
			list = new List<LichThi>();
			DataProvider dtb = new DataProvider (connection);
			list = dtb.GetAllLT ();
            return list;
        }
		public static void AddLT(LichThi lt,SQLiteConnection connection )
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.GetLT (lt.MaMH) == null) {
				dtb.AddLT (lt);
			}
		}
		public static List<LichThi> MakeDataFromXml(string xml,SQLiteConnection connection)
		{
			list = new List<LichThi> ();
			XDocument doc = XDocument.Parse (xml);
			//get lichthi 
			IEnumerable<XElement> childList =
				from el in doc.Root.Elements()
				select el;
			//get attri lichthi
			foreach (XElement node in childList)
			{
				
				LichThi lt = new LichThi();
				lt.GhepThi = node.Elements().ElementAt(0).Value.Trim();
				lt.GioBD = node.Elements().ElementAt(1).Value.Trim();
				MonHoc mh = new MonHoc();
				lt.MaMH = node.Elements().ElementAt(3).Value.Trim();
				mh.MaMH = lt.MaMH;
				mh.TenMH=node.Elements().ElementAt(8).Value.Trim();
				lt.NgayThi = node.Elements().ElementAt(4).Value.Trim();
				lt.PhongThi = node.Elements().ElementAt(5).Value.Trim();
				lt.SoLuong = int.Parse(node.Elements().ElementAt(6).Value.Trim());
				lt.SoPhut = int.Parse(node.Elements().ElementAt(7).Value.Trim());
				lt.ToThi = node.Elements().ElementAt(9).Value.Trim();
				list.Add(lt);
				BMonHoc.Add(connection,mh);
				AddLT(lt,connection);
			}
			return list;
		}

    }
}
