using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using School.Core;

namespace School.Droid
{
	public class DiemThiApdater: BaseExpandableListAdapter
	{


		public List<DiemThi> listDT;
		private Context context;

		public DiemThiApdater (Context context,List<DiemThi> listDT)
		{
			this.context = context;
			this.listDT = listDT;
		}



		public override View GetGroupView (int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{
			
			View header = convertView;
			if (header == null) {
				header = LayoutInflater.From(context).Inflate(Resource.Layout.DTHeader, null);
			}
			TextView title = header.FindViewById<TextView>(Resource.Id.txtHeaderDT);
			title.Text = " HỌC KỲ " + listDT[groupPosition].Hocky + " NĂM HỌC " + listDT[groupPosition].NamHoc;
//			header.FindViewById<TextView>(Resource.Id.txtTB10).Text ="aaa" +listDT [groupPosition].DiemTB10;
//			header.FindViewById<TextView>(Resource.Id.txtTB4).Text = listDT [groupPosition].DiemTB4;
//			header.FindViewById<TextView>(Resource.Id.txtTBTL10).Text = listDT [groupPosition].DiemTBTL10;
//			header.FindViewById<TextView>(Resource.Id.txtTBTL4).Text = listDT [groupPosition].DiemTBTL4;
//			header.FindViewById<TextView>(Resource.Id.txtDRL).Text = listDT [groupPosition].DiemRL;
			ExpandableListView mExpandableListView = (ExpandableListView) parent;
			mExpandableListView.ExpandGroup(groupPosition);

			return header;
		}

		public override View GetChildView (int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
		{

			View row = convertView;
			if (row == null) {
				row = LayoutInflater.From(context).Inflate(Resource.Layout.DTRow, null);
			}

			DiemMon diemMon = GetChildViewHelper (groupPosition, childPosition);

			//row.FindViewById<TextView> (Resource.Id.txtSTTDT).Text= ;
			MonHoc mh = BMonHoc.GetMH (SQLite_Android.GetConnection (), diemMon.MaMH);
			row.FindViewById<TextView> (Resource.Id.txtMonHocDT).Text = mh.TenMH;
			row.FindViewById<TextView> (Resource.Id.txtTiLe).Text = "50/50";//mh.TiLe not done yet
			row.FindViewById<TextView> (Resource.Id.txtDKT).Text = Common.checkSpaceValue(diemMon.DiemKT);
			row.FindViewById<TextView> (Resource.Id.txtDT).Text = Common.checkSpaceValue(diemMon.DiemThi);
			row.FindViewById<TextView> (Resource.Id.txtDTK).Text = diemMon.DiemTK10 + "(" + diemMon.DiemChu+")";
				

			return row;
		}

		public String setDiemTK(string diem10, string diemChu){
			if (@diem10.Equals ("&nbsp;") && @diemChu.Equals ("&nbsp;")) {
				return diem10 + "(" + diemChu + ")";		
			}
			return "";
			
		}

		public override int GetChildrenCount (int groupPosition)
		{
			
			List<DiemMon> listDM = BDiemThi.GetDiemMons(SQLite_Android.GetConnection(), listDT[groupPosition].Hocky, listDT[groupPosition].NamHoc);
			return listDM.Count;
		}

		public override int GroupCount {
			get {
				return 26;
			}
		}

		private DiemMon GetChildViewHelper (int groupPosition, int childPosition)
		{
			
			List<DiemMon> listDM = BDiemThi.GetDiemMons(SQLite_Android.GetConnection(), listDT[groupPosition].Hocky, listDT[groupPosition].NamHoc);
			return listDM [childPosition];

		}

		#region implemented abstract members of BaseExpandableListAdapter

		public override Java.Lang.Object GetChild (int groupPosition, int childPosition)
		{
			throw new NotImplementedException ();
		}

		public override long GetChildId (int groupPosition, int childPosition)
		{
			return childPosition;
		}

		public override Java.Lang.Object GetGroup (int groupPosition)
		{
			throw new NotImplementedException ();
		}

		public override long GetGroupId (int groupPosition)
		{
			return groupPosition;
		}

		public override bool IsChildSelectable (int groupPosition, int childPosition)
		{
			return false;
		}

		public override bool HasStableIds {
			get {
				return true;
			}
		}

		#endregion
	}

	//		public List<DiemMon> listDM;
	//		public DiemThi diemThi;
	//        private Context context;
	//        public int flag;
	//
	//		public DiemThiApdater(Context context,DiemThi diemThi,List<DiemMon> listDM)
	//        {
	//			this.listDM = listDM;
	//			this.diemThi = diemThi;
	//            this.context = context;
	//        }
	//
	//        public override int Count
	//        {
	//            get { return listDT.Count; }
	//        }
	//
	//        public override long GetItemId(int position)
	//        {
	//            return position;
	//        }
	//
	//		public override DiemMon this[int position]
	//        {
	//            get
	//            {
	//				return DiemMon[position];
	//            }
	//        }
	//
	//        public override View GetView(int position, View convertView, ViewGroup parent)
	//        {
	//
	//            View view = convertView;
	//            if (view == null)
	//            {
	//                view = LayoutInflater.From(context).Inflate(Resource.Layout.DTRow, null, false);
	//
	//            }
	//            //BDiemThi.GetDiemMons listDT[position]
	//			TextView txtSTT = view.FindViewById<TextView>(Resource.Id.txtSTTDT);
	//
	//			txtSTT.Text = (position+1).ToString();
	//			listDT<DiemMon> listDM = BMonHoc.GetMH(SQLite_Android.GetConnection(), listDT[position].HocKy, listDT[position].NamHoc);
	//			txtMonHocDT
	//            //TextView txtMon = view.FindViewById<TextView>(Resource.Id.txtMonHoc);
	//			txtTiLe
	//			txtDKT
	//			txtDT
	//			txtDTK
	//            //txtMon.Text = BMonHoc.GetMH(SQLite_Android.GetConnection(), listDT[position].MaMH).TenMH;
	//            //TextView txtThoiGian = view.FindViewById<TextView>(Resource.Id.txtThoiGian);
	//            //txtThoiGian.Text = listDT[position].NgayThi;
	//            //TextView txtGioBD = view.FindViewById<TextView>(Resource.Id.txtGioBD);
	//            //txtGioBD.Text = listDT[position].GioBD;
	//            //TextView txtPhong = view.FindViewById<TextView>(Resource.Id.txtPhongThi);
	//            //txtPhong.Text = listDT[position].PhongThi;
	//
	//            return view;
	//        }
	//
	//    }
}