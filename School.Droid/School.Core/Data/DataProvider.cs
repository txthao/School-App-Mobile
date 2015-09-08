using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;


namespace School.Core
{
	public class DataProvider
	{
		SQLiteConnection _connection;
		public DataProvider(SQLiteConnection connection)
		{
			//_connection = DependencyService.Get<ISQLite> ().GetConnection ();
			_connection=connection;
			_connection.CreateTable<MonHoc>();
			_connection.CreateTable<LichThi>();
		}
		public void Add(LichThi T)
		{
			_connection.Insert(T);
			_connection.Commit();
		}
		public List<LichThi> GetAll()
		{
			var query = from c in _connection.Table<LichThi>()
				select c;
			return query.ToList();
		}
		public LichThi Get(string mamh)
		{
			var query = from c in _connection.Table<LichThi>()
					where c.MaMH.Equals(mamh)
				select c;

			return query.FirstOrDefault ();
		}
	}
}

