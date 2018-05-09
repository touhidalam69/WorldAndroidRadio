using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Net;
using System.Collections.Generic;

namespace WorldAndroidRadio
{
    [Activity(Label = "Radio List", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]

    public class RadioChannelActivity : Activity
    {
        List<RadioChannel> RadioChannelLst;
        public const string Category = "Bangladesh";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ListRadio aListRadio = new ListRadio(Intent.GetStringExtra(Category));

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DefaultListViewer);
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().PermitAll().Build();
            StrictMode.SetThreadPolicy(policy);

            ListView myListView = FindViewById<ListView>(Resource.Id.DefaultListView);

            RadioChannelLst = aListRadio.GetCountryWiseRadio();

            myListView.Adapter = GetAdapter();
            myListView.ItemClick += MyListView_ItemClick;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ListPageMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Home:
                    Finish();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (isOnline())
            {
                try
                {
                    MediaPlayerManager.Play(RadioChannelLst[e.Position].Url, this);
                }
                catch (IOException ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Check your Internet Connection", ToastLength.Long).Show();
            }
        }
        public ListViewMenuAdapter GetAdapter()
        {
            ListViewMenuAdapter adapter = new ListViewMenuAdapter(this, RadioChannelLst, "Channel");
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
        public bool isOnline()
        {
            try
            {
                int timeoutMs = 1500;
                Socket sock = new Socket();
                Java.Net.SocketAddress sockaddr = new InetSocketAddress("8.8.8.8", 53);
                sock.Connect(sockaddr, timeoutMs);
                sock.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}