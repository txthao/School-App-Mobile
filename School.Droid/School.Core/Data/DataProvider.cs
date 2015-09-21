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
			_connection = connection;
		
			_connection.CreateTable<MonHoc> ();
			_connection.CreateTable<LichThi> ();
			_connection.CreateTable<User> ();
			_connection.CreateTable<LichHoc> ();
			_connection.CreateTable<HocPhi> ();
			_connection.CreateTable<DiemThi> ();
			_connection.CreateTable<DiemMon> ();
			_connection.CreateTable<CTHocPhi> ();
			_connection.CreateTable<chiTietLH> ();
		}
			public void AddLT(LichThi T)
		{
			_connection.Insert(T);
			_connection.Commit();

		}
		public List<LichThi> GetAllLT()
		{
			var query = from c in _connection.Table<LichThi>()
				select c;
			return query.ToList();
		}
		public LichThi GetLT(string mamh)
		{
			var query = from c in _connection.Table<LichThi>()
					where c.MaMH.Equals(mamh)
				select c;

			return query.FirstOrDefault ();
		}
		public void AddLH(LichHoc lh)
		{
			_connection.Insert(lh);
			_connection.Commit();
		}
		public List<LichHoc> GetAllLH()
		{
			var query = from c in _connection.Table<LichHoc>()
				select c;
			return query.ToList();
		}
//		public List<LichHoc> GetLH(int namhoc, int hocky)
//		{
//			if (hocky == 1) {
//				var query = from c in _connection.Table<LichHoc> ()
//				           where (c.ThoigianBD.Substring (5).Equals (namhoc)) && (int.Parse (c.ThoigianBD.Substring (3, 1)) < 12)
//				           select c;
//				return query.ToList();
//			}
//
//		}
		public LichHoc GetLast()
		{
			var query = from c in _connection.Table<LichHoc>()
					orderby c.Id descending 
				select c;

			return query.FirstOrDefault ();
		}

		public LichHoc GetLH_Id(string id)
		{
			var query = from c in _connection.Table<LichHoc>()
					where c.Id.Equals(id)
				select c;

			return query.FirstOrDefault ();
		}
		public LichHoc GetLH_Ma(string mamh)
		{
			var query = from c in _connection.Table<LichHoc>()
					where c.MaMH.Equals(mamh)
				select c;

			return query.FirstOrDefault ();
		}
		public List<DiemThi> GetDT(int namhoc,int  hocky)
		{
			var query = from c in _connection.Table<DiemThi>()
					where (c.Hocky==hocky)
					where (c.NamHoc==namhoc)
				select c;
			return query.ToList();
		}
		public HocPhi GetHP(int namhoc,int  hocky)
		{
			var query = from c in _connection.Table<HocPhi>()
					where (c.HocKy==hocky)&&(c.NamHoc==namhoc)
				select c;
			return query.FirstOrDefault ();
		}
		public CTHocPhi GetCTHP(CTHocPhi hp)
		{
			var query = from c in _connection.Table<CTHocPhi>()
					where (c.HocKy==hp.HocKy)&&(c.NamHoc==hp.NamHoc)&&(c.MaMH.Equals(hp.MaMH))
				select c;
			return query.FirstOrDefault ();
		}
		public List<DiemThi> GetAllDT()
		{
			var query = from c in _connection.Table<DiemThi>()
				select c;
			return query.ToList();
		}

		public List<HocPhi> GetAllHP()
		{
			var query = from c in _connection.Table<HocPhi>()
				select c;
			return query.ToList();
		}
		public List<chiTietLH> GetCTLH(string id)
		{
			var query = from c in _connection.Table<chiTietLH>()
					where c.Id.Equals(id)
				select c;
			return query.ToList();
		}

		public chiTietLH checkCTLH(chiTietLH ct)
		{
			var query = from c in _connection.Table<chiTietLH>()
					where c.Id.Equals(ct.Id) && c.Thu.Equals(ct.Thu) && c.Phong.Equals(ct.Phong)
				select c;
			return query.FirstOrDefault();
		}

		public List<CTHocPhi> GetCTHPs(int namhoc,int hocky)
		{
			var query = from c in _connection.Table<CTHocPhi>()
					where (c.HocKy==hocky)&&(c.NamHoc==namhoc)
				select c;
			return query.ToList();
		}

		public List<DiemMon> GetDMs(int hocky,int namhoc)
		{
			var query = from c in _connection.Table<DiemMon>()
					where (c.Hocky==hocky)&&(c.NamHoc==namhoc)
				select c;
			return query.ToList();
		}

		public DiemMon GetDM(DiemMon dm)
		{
			var query = from c in _connection.Table<DiemMon>()
					where (c.Hocky==dm.Hocky)&&(c.NamHoc==dm.NamHoc)&&(c.MaMH.Equals(dm.MaMH))
				select c;
			return query.FirstOrDefault ();
		}
		public MonHoc GetMonHoc(string mamh)
		{
			var query = from c in _connection.Table<MonHoc>()
					where c.MaMH.Equals(mamh)
				select c;

			return query.FirstOrDefault ();
		}
		public User GetUser(string id)
		{
			var query = from c in _connection.Table<User>()
					where c.Id.Equals(id)
				select c;

			return query.FirstOrDefault ();
		}
		public CTHocPhi GetCTHP(int namhoc, int hocky)
		{
			var query = from c in _connection.Table<CTHocPhi>()
					where (c.HocKy==hocky)&&(c.NamHoc==namhoc)
				select c;
			return query.FirstOrDefault ();
		}
		public int AddDM(DiemMon T)
		{
			int i= _connection.Insert(T);
			_connection.Commit();
			return i;
		}
		public int AddDT(DiemThi T)
		{
			int i=_connection.Insert(T);
			_connection.Commit();
			return i;
		}
		public int AddHP(HocPhi T)
		{
			int i=_connection.Insert(T);
			_connection.Commit();
			return i;
		}
		public int AddUser(User T)
		{
			int i=_connection.Insert(T);
			_connection.Commit();
			return i;
		}
		public int AddMH(MonHoc T)
		{
			int i=_connection.Insert(T);
			_connection.Commit();
			return i;
		}
		public int AddCTLH(chiTietLH T)
		{
			int i=_connection.Insert(T);
			_connection.Commit();
			return i;
		}
		public int AddCTHP(CTHocPhi T)
		{
			int i=_connection.Insert(T);
			_connection.Commit();
			return i;
		}
		public int UpdateMH(MonHoc mh)
		{
			int i = _connection.Update (mh);
			_connection.Commit();
			return i;
		}

		public int DeleteAll()
		{
			int i=_connection.DeleteAll<LichHoc>();
			i+=_connection.DeleteAll<User>();
			i+=_connection.DeleteAll<LichThi>();

			i+=_connection.DeleteAll<DiemThi>();
			i+=_connection.DeleteAll<HocPhi>();
			i+=_connection.DeleteAll<CTHocPhi>();
			i+=_connection.DeleteAll<chiTietLH>();
			i+=_connection.DeleteAll<DiemMon>();
			i+=_connection.DeleteAll<MonHoc>();
			_connection.Commit ();
			return i;
		}


	}
}

