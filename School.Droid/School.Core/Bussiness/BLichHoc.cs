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
	}
}

