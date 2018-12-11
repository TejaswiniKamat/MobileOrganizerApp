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

namespace OrganizerApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MainTheme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);
            //System.Threading.Thread.Sleep(3000);
            StartActivity(typeof(MainActivity));
            // Create your application here
            //System.Threading.ThreadPool.QueueUserWorkItem(o => LoadActivity());
        }

        private void LoadActivity()
        {
            System.Threading.Thread.Sleep(1000); // Simulate a long pause    
            RunOnUiThread(() => StartActivity(typeof(MainActivity)));
        }
    }
}