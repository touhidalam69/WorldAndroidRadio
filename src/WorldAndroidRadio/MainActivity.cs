using Android;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace WorldAndroidRadio
{
    [Activity(Label = "World Radio", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static Button fabPlay;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            fabPlay = FindViewById<Button>(Resource.Id.fabPlay);
            fabPlay.Click += (o, e) =>
            {
                MediaPlayerManager.StopePlayer();
            };
            MediaPlayerManager.CheckPlayer();
        }
    }
    public class MediaPlayerManager
    {
        public static MediaPlayer player;
        public static ProgressDialog mDialog;
        public static async void Play(string Url, Context context)
        {
            if (player == null)
            {
                player = new MediaPlayer();
                player.SetAudioStreamType(Stream.Music);
            }
            else {
                player.Reset();
                MainActivity.fabPlay.Visibility = ViewStates.Invisible;
            }
            try
            {
                await player.SetDataSourceAsync(Url);
                player.PrepareAsync();
                mDialog = new ProgressDialog(context);
                mDialog.Window.SetType(WindowManagerTypes.SystemAlert);
                mDialog.SetMessage("Please wait...");
                mDialog.Show();
            }
            catch
            {
                Toast.MakeText(context, "Radio Station not Responding", ToastLength.Long).Show();
            }
            player.Prepared += Player_Prepared;
            player.Error += (sender, args) =>
            {
                Toast.MakeText(context, "Radio Station not Responding", ToastLength.Long).Show();
                mDialog.Dismiss();
                StopePlayer();
            };
        }

        private static void Player_Prepared(object sender, System.EventArgs e)
        {
            player.Start();
            mDialog.Dismiss();
            MainActivity.fabPlay.Visibility = ViewStates.Visible;
        }

        public static bool CheckPlayer()
        {
            if (player != null)
            {
                if (player.IsPlaying)
                {
                    MainActivity.fabPlay.Visibility = ViewStates.Visible;
                    return true;
                }
                else
                {
                    MainActivity.fabPlay.Visibility = ViewStates.Invisible;
                    return false;
                }
            }
            else
            {
                MainActivity.fabPlay.Visibility = ViewStates.Invisible;
                return false;
            }
        }
        public static bool StopePlayer()
        {
            if (CheckPlayer())
            {
                player.Stop();
                player.Reset();
                MainActivity.fabPlay.Visibility = ViewStates.Invisible;
            }

            return true;
        }
    }
}

