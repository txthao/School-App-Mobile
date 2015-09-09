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
   public class BLichThi
    {
       public static List<DiemThi> list;
		public static List<DiemThi> getAll(SQLiteConnection connection)
        {
			list = new List<DiemThi>();
			DataProvider dtb = new DataProvider (connection);
			list = dtb.GetAllDT ();
            return list;
        }
		public static void AddLT(LichThi lt,SQLiteConnection connection )
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.GetLT (lt.MaMH) == null) {
				dtb.AddLT (lt);
			}
		}


    }
}
