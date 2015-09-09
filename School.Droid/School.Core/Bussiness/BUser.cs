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
	public class BUser
	{
		public static User GetUser(SQLiteConnection connection,string id )
		{
			DataProvider dtb = new DataProvider (connection);
			return dtb.GetUser (id);
		}
		public static int AddUser(SQLiteConnection connection,User user)
		{
			DataProvider dtb = new DataProvider (connection);
			if (dtb.GetUser (user.Id) == null) {
				return dtb.AddUser (user);
			}
			return 0;
		}
	}
}

