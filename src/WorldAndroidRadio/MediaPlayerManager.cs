using Android.App;
using Android.Content;
using Android.Media;
using Android.Views;
using Android.Widget;

namespace WorldAndroidRadio
{
    public class MediaPlayerManager
    {
        // Declaring Mediaplayer
        public static MediaPlayer player;

        // Declaring ProgressDialog
        public static ProgressDialog mDialog;
        public static async void Play(string Url, Context context)
        {
            if (player == null)
            {
                // Creating new instance of Mediaplayer
                player = new MediaPlayer();
                player.SetAudioStreamType(Stream.Music);
            }
            else {
                player.Reset();
                // IF Stoped Stop button will be hide
                MainActivity.btnPlay.Visibility = ViewStates.Invisible;
            }
            try
            {
                // ProgressDialog will be apeared before playing
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
            // IF Stoped Stop button will be showen
            MainActivity.btnPlay.Visibility = ViewStates.Visible;
        }

        // This function will check the player mode (Playing/Stopped)
        public static bool CheckPlayer()
        {
            if (player != null)
            {
                if (player.IsPlaying)
                {
                    // IF Stoped Stop button will be showen
                    MainActivity.btnPlay.Visibility = ViewStates.Visible;
                    return true;
                }
                else
                {
                    // IF Stoped Stop button will be hide
                    MainActivity.btnPlay.Visibility = ViewStates.Invisible;
                    return false;
                }
            }
            else
            {
                // IF Stoped Stop button will be hide
                MainActivity.btnPlay.Visibility = ViewStates.Invisible;
                return false;
            }
        }
        public static bool StopePlayer()
        {
            if (CheckPlayer())
            {
                player.Stop();
                player.Reset();
                // IF Stoped Stop button will be hide
                MainActivity.btnPlay.Visibility = ViewStates.Invisible;
            }

            return true;
        }
    }
}