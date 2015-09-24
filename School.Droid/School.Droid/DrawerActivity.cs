
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics.Drawables;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Content.Res;
using School.Core;

namespace School.Droid
{
	[Activity (Label = "School App")]			
	public class DrawerActivity : Activity
	{
		private DrawerLayout _drawer;
		private MyActionBarDrawerToggle _drawerToggle;
		private ListView _drawerList;

		private string _drawerTitle;
		private string _title;
		private string[] _menuTitles;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Menu);

			_title = _drawerTitle = Title;
			_menuTitles = Resources.GetStringArray(Resource.Array.MenuArray);
			_drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			_drawerList = FindViewById<ListView>(Resource.Id.left_drawer);

			_drawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);

			_drawerList.Adapter = new ArrayAdapter<string>(this,
				Resource.Layout.drawer_item, _menuTitles);
			_drawerList.ItemClick += (sender, args) => SelectItem(args.Position);


			ActionBar.SetDisplayHomeAsUpEnabled(true);
			ActionBar.SetHomeButtonEnabled(true);
			ActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));

			//DrawerToggle is the animation that happens with the indicator next to the
			//ActionBar icon. You can choose not to use this.
			_drawerToggle = new MyActionBarDrawerToggle(this, _drawer,
				Resource.Drawable.ic_drawer_light,
				Resource.String.DrawerOpen,
				Resource.String.DrawerClose);

			//You can alternatively use _drawer.DrawerClosed here
			_drawerToggle.DrawerClosed += delegate
			{
				ActionBar.Title = _title;
				ActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));
				InvalidateOptionsMenu();
			};

			//You can alternatively use _drawer.DrawerOpened here
			_drawerToggle.DrawerOpened += delegate
			{
				ActionBar.Title = _drawerTitle;
				InvalidateOptionsMenu();
			};

			_drawer.SetDrawerListener(_drawerToggle);

			if (null == savedInstanceState)
				SelectItem(0);


		}

		private void SelectItem(int position)
		{
			var fragment=new Fragment();
            switch (position) {
            case 0:
                fragment = new LichHocFragment ();
                break;
            case 1:
                fragment = new LichThiFragment ();
                break;
            case 2:
                fragment = new DiemThiFragment ();
                break;
            case 3:
                fragment = new HocPhiFragment ();
                break;
            default:
                fragment = new LichThiFragment ();
                break;
            }

			FragmentManager.BeginTransaction()
				.Replace(Resource.Id.content_frame, fragment)
				.Commit();

			_drawerList.SetItemChecked(position, true);
			ActionBar.Title = _title = _menuTitles[position];
			_drawer.CloseDrawer(_drawerList);
		}

		protected override void OnPostCreate(Bundle savedInstanceState)
		{
			base.OnPostCreate(savedInstanceState);
			_drawerToggle.SyncState();
		}

		public override void OnConfigurationChanged(Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			_drawerToggle.OnConfigurationChanged(newConfig);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{

			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnPrepareOptionsMenu(IMenu menu)
		{
			
		
			return base.OnPrepareOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			

			if (_drawerToggle.OnOptionsItemSelected(item))
				return true;
			return base.OnOptionsItemSelected(item);
	}
}
}
