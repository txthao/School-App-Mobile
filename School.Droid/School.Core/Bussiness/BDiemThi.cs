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
	public class BDiemThi
	{
		
			public static List<DiemThi> list;
			public static List<DiemThi> getAll(SQLiteConnection connection)
			{
				list = new List<DiemThi>();
				DataProvider dtb = new DataProvider (connection);
				list = dtb.GetAllDT ();
				return list;
			}
			public static int Add(DiemThi lt,SQLiteConnection connection )
			{
				DataProvider dtb = new DataProvider (connection);
			if (dtb.GetDT (lt.NamHoc,lt.Hocky).Count==0) {
					return dtb.AddDT (lt);
				}
				return 0;
			}
			public static int AddDM(DiemMon dm,SQLiteConnection connection)
			{
				DataProvider dtb = new DataProvider (connection);
				if (dtb.GetDM (dm) == null) {
					return dtb.AddDM(dm);
					}
				return 0;
			}
			public static List<DiemMon> GetDiemMons(SQLiteConnection connection,int namhoc, int hocky)
			{
				DataProvider dtb = new DataProvider (connection);
				return dtb.GetDMs (hocky, namhoc);
			}
	}
}

