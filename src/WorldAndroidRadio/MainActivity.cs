using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.IO;
using System.Collections.Generic;

namespace WorldAndroidRadio
{
    [Activity(Label = "World Radio", MainLauncher = true)]
    public class MainActivity : Activity
    {
        List<RadioChannel> MenuLst = new List<RadioChannel>();
        ListView myListView;
        
        // This Function will call when application will loaded
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ListRadio aListRadio = new ListRadio();

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().PermitAll().Build();
            StrictMode.SetThreadPolicy(policy);

            // Get Country category to load on landing page
            MenuLst = aListRadio.GetAllCountry();

            myListView = FindViewById<ListView>(Resource.Id.DefaultMenuListView);

            // Fill listview throw Adapter
            myListView.Adapter = GetAdapter();
            // Added Event on Country click
            myListView.ItemClick += MyListView_ItemClick;
        }
        // Top Raght Menu will be created by this event
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MainMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //Menu item click event when select a menu item
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.About:
                    AlertDialog.Builder Alertbuilder = new AlertDialog.Builder(this);
                    Alertbuilder.SetTitle("About World Radio");
                    Alertbuilder.SetMessage("World Radio Version 1.0.1. Designed and Developed by Touhid Alam");
                    Alertbuilder.SetPositiveButton("OK", (s, ss) => { });
                    Alertbuilder.SetNegativeButton("Cancel", (s, ss) => { }).Create();
                    Alertbuilder.Show();
                    return true;
                case Resource.Id.Exit:
                    Finish();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        // Country category select event Channenl list will apear
        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
            {
                Intent intent = new Intent(this, typeof(RadioChannelActivity));
                intent.PutExtra(RadioChannelActivity.Category, MenuLst[e.Position].Country);
                this.StartActivity(intent);
            }
            catch (IOException ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
        public ListViewMenuAdapter GetAdapter()
        {
            ListViewMenuAdapter adapter = new ListViewMenuAdapter(this, MenuLst, "Country");
            return adapter;
        }
        protected override void OnPause()
        {
            base.OnPause();
        }
        protected override void OnResume()
        {
            base.OnResume();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }

    // Making Adapter for list view
    public class ListViewMenuAdapter : BaseAdapter<RadioChannel>
    {
        private List<RadioChannel> MenuList;
        private Context LstContext;
        private string flag;
        public ListViewMenuAdapter(Context cntext, List<RadioChannel> items, string flag)
        {
            MenuList = items;
            LstContext = cntext;
            this.flag = flag;
        }
        public override int Count
        {
            get
            {
                return MenuList.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override RadioChannel this[int position]
        {
            get
            {
                return MenuList[position];
            }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(LstContext).Inflate(Resource.Layout.MenuAdapter, null, false);
            }

            TextView btnMenuItem = row.FindViewById<TextView>(Resource.Id.btnMenuItem);
            btnMenuItem.Text = flag == "Country" ? MenuList[position].Country : MenuList[position].Name;
            return row;
        }
    }
}

