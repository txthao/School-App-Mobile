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
       public static List<LichThi> list;
		public static List<LichThi> getAll(SQLiteConnection connection)
        {
            list = new List<LichThi>();
            
			DataProvider dtb = new DataProvider (connection);
			list = dtb.GetAll ();
            
            return list;
        }
		public static void AddLT(LichThi lt,SQLiteConnection connection )
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.Get (lt.MaMH) == null) {
				dtb.Add (lt);
			}
		}


    }
}
