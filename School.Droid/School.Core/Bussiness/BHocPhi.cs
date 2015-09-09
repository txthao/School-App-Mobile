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

	}
}

