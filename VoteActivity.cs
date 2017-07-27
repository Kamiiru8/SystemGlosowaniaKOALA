
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace QR_Only
{
	[Activity(Label = "VoteActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
	public class VoteActivity : Activity
	{
		public class Answer
		{
			public string accept { get; set; }
			public string answers { get; set; }
		}
		string name;
		string surname;
		string numer;
		string date;
		Timer _timer = new Timer();
		//String url = "http://zespolowka.co.nf/vote.html";
		//String partUrl = "";
		String url = "http://158.75.112.74/www/php/script/appGetAnswers.php?nrVoter=";
		String partUrl = "http://158.75.112.74/www/php/script/appAddResult.php?nrVoter=";
		int z = 0;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			date = Intent.GetStringExtra("date");

			_timer.Interval = 600;
			_timer.Elapsed += OnTimedEvent;
			_timer.Enabled = true;
		}

		public override void OnBackPressed(){ }

		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			this.RunOnUiThread(() =>
			{
				name = Intent.GetStringExtra("name");
				surname = Intent.GetStringExtra("surname");
				numer = Intent.GetStringExtra("numer");
				var json = new WebClient().DownloadString(url+numer);
				//var json = new WebClient().DownloadString(url);
				if (json.Substring(0, 1) == "{")
				{
					Answer answer = JsonConvert.DeserializeObject<Answer>(json);
					if (String.Equals(answer.accept, "yes"))
					{
						if (answer.answers == "2")
						{
							SetContentView(Resource.Layout.Vote2);
							TextView btn1 = FindViewById<TextView>(Resource.Id.btn1);
							TextView btn2 = FindViewById<TextView>(Resource.Id.btn2);
							btn1.Click += delegate
							{
								z=1;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=1&b=0&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
								//var json2 = new WebClient().DownloadString(url);
							};
							btn2.Click += delegate
							{
								z=2;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=1&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
								//var json2 = new WebClient().DownloadString(url);
							};
							switch (z)
							{
								case 1:
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow_ok);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									break;
								case 2:
									btn2.SetBackgroundResource(Resource.Drawable.circle_red_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									break;
							}
						}
						if (answer.answers == "3")
						{
							SetContentView(Resource.Layout.Vote3);
							TextView btn1 = FindViewById<TextView>(Resource.Id.btn1);
							TextView btn2 = FindViewById<TextView>(Resource.Id.btn2);
							TextView btn3 = FindViewById<TextView>(Resource.Id.btn3);
							btn1.Click += delegate
							{
								z = 1;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=1&b=0&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
								Console.WriteLine(urlX);
							};
							btn2.Click += delegate
							{
								z = 2;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=1&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn3.Click += delegate
							{
								z = 3;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=1&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							switch (z)
							{
								case 1:
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow_ok);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									break;
								case 2:
									btn2.SetBackgroundResource(Resource.Drawable.circle_red_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									break;
								case 3:
									btn3.SetBackgroundResource(Resource.Drawable.circle_green_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									break;
							}
						}
						if (answer.answers == "4")
						{
							SetContentView(Resource.Layout.Vote4);
							TextView btn1 = FindViewById<TextView>(Resource.Id.btn1);
							TextView btn2 = FindViewById<TextView>(Resource.Id.btn2);
							TextView btn3 = FindViewById<TextView>(Resource.Id.btn3);
							TextView btn4 = FindViewById<TextView>(Resource.Id.btn4);
							btn1.Click += delegate
							{
								z = 1;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=1&b=0&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn2.Click += delegate
							{
								z = 2;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=1&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn3.Click += delegate
							{
								z = 3;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=1&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn4.Click += delegate
							{
								z = 4;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=0&d=1&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							switch (z)
							{
								case 1:
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow_ok);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									break;
								case 2:
									btn2.SetBackgroundResource(Resource.Drawable.circle_red_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									break;
								case 3:
									btn3.SetBackgroundResource(Resource.Drawable.circle_green_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									break;
								case 4:
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									break;	
							}
						}
						if (answer.answers == "5")
						{
							SetContentView(Resource.Layout.Vote5);
							TextView btn1 = FindViewById<TextView>(Resource.Id.btn1);
							TextView btn2 = FindViewById<TextView>(Resource.Id.btn2);
							TextView btn3 = FindViewById<TextView>(Resource.Id.btn3);
							TextView btn4 = FindViewById<TextView>(Resource.Id.btn4);
							TextView btn5 = FindViewById<TextView>(Resource.Id.btn5);
							btn1.Click += delegate
							{
								z = 1;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=1&b=0&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn2.Click += delegate
							{
								z = 2;
								numer = Intent.GetStringExtra("numer");
								Toast toast = Toast.MakeText(this, numer, ToastLength.Short);		
								toast.Show();
								string urlX = partUrl + numer + "&a=0&b=1&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn3.Click += delegate
							{
								z = 3;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=1&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn4.Click += delegate
							{
								z = 4;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=0&d=1&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn5.Click += delegate
							{
								z = 5;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=0&d=0&e=1&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							switch (z)
							{
								case 1:
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow_ok);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									break;
								case 2:
									btn2.SetBackgroundResource(Resource.Drawable.circle_red_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									break;
								case 3:
									btn3.SetBackgroundResource(Resource.Drawable.circle_green_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									break;
								case 4:
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									break;
								case 5:
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									break;	
							}
						}
						if (answer.answers == "6")
						{
							SetContentView(Resource.Layout.Vote6);
							TextView btn1 = FindViewById<TextView>(Resource.Id.btn1);
							TextView btn2 = FindViewById<TextView>(Resource.Id.btn2);
							TextView btn3 = FindViewById<TextView>(Resource.Id.btn3);
							TextView btn4 = FindViewById<TextView>(Resource.Id.btn4);
							TextView btn5 = FindViewById<TextView>(Resource.Id.btn5);
							TextView btn6 = FindViewById<TextView>(Resource.Id.btn6);
							btn1.Click += delegate
							{
								z = 1;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=1&b=0&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);

							};
							btn2.Click += delegate
							{
								z = 2;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=1&c=0&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn3.Click += delegate
							{
								z = 3;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=1&d=0&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn4.Click += delegate
							{
								z = 4;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=0&d=1&e=0&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn5.Click += delegate
							{
								z = 5;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=0&d=0&e=1&f=0";
								var json2 = new WebClient().DownloadString(urlX);
							};
							btn6.Click += delegate
							{
								z = 6;
								numer = Intent.GetStringExtra("numer");
								string urlX = partUrl + numer + "&a=0&b=0&c=0&d=0&e=0&f=1";
								var json2 = new WebClient().DownloadString(urlX);
							};
							switch (z)
							{
								case 1:
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow_ok);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									btn6.SetBackgroundResource(Resource.Drawable.circle_black);
									break;
								case 2:
									btn2.SetBackgroundResource(Resource.Drawable.circle_red_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									btn6.SetBackgroundResource(Resource.Drawable.circle_black);
									break;
								case 3:
									btn3.SetBackgroundResource(Resource.Drawable.circle_green_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									btn6.SetBackgroundResource(Resource.Drawable.circle_black);
									break;
								case 4:
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									btn6.SetBackgroundResource(Resource.Drawable.circle_black);
									break;
								case 5:
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									btn6.SetBackgroundResource(Resource.Drawable.circle_black);
									break;
								case 6:
									btn6.SetBackgroundResource(Resource.Drawable.circle_black_ok);
									btn1.SetBackgroundResource(Resource.Drawable.circle_yellow);
									btn2.SetBackgroundResource(Resource.Drawable.circle_red);
									btn3.SetBackgroundResource(Resource.Drawable.circle_green);
									btn4.SetBackgroundResource(Resource.Drawable.circle_blue);
									btn5.SetBackgroundResource(Resource.Drawable.circle_gray);
									break;	
							}
						}
					}

					if (String.Equals(answer.accept, "no"))
					{ 
						_timer.Stop();
						base.OnStop();
						Finish();
							var welcomeActivity = new Intent(this, typeof(WelcomeActivity));
							welcomeActivity.PutExtra("name", name);
							welcomeActivity.PutExtra("surname", surname);
							welcomeActivity.PutExtra("numer", numer);
							welcomeActivity.PutExtra("date", date);
							StartActivity(welcomeActivity);
					}
				}
			});
		}
	}
}
