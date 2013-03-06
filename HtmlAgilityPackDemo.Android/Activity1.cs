using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HtmlAgilityPack;

namespace HtmlAgilityPackDemo.Android
{
    [Activity(Label = "HtmlAgilityPackDemo.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;
        EditText txtZip;
        TextView txtTemp;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            txtZip= FindViewById<EditText>(Resource.Id.txtZip);
            txtTemp= FindViewById<TextView>(Resource.Id.txtTemp);





            button.Click +=button_Click;
        }

        void button_Click(object sender, EventArgs e)
        {
 	        var webGet = new HtmlWeb();
            var document = webGet.Load("http://thefuckingweather.com/?where=" + txtZip.Text);
            var teamTags = document.DocumentNode.SelectNodes("//span[@class='temperature']");

            txtTemp.Text = teamTags[0].InnerText + "°?!";

        }


        
    }
}

