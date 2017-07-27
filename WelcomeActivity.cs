
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Timers;
using Newtonsoft.Json;

namespace QR_Only
{
	[Activity(Label = "WelcomeActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
	public class WelcomeActivity : Activity
	{
		public class Answer
		{
			public string accept { get; set; }
			public string answers { get; set; }
		}

		//String url = "http://zespolowka.co.nf/vote.html";
		String url = "http://158.75.112.74/www/php/script/appGetAnswers.php?nrVoter=";

		Timer _timer = new Timer();
		string name;
		string surname;
		string numer;
		string date;
		Answer answer;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			name = Intent.GetStringExtra("name");
			surname = Intent.GetStringExtra("surname");
			numer = Intent.GetStringExtra("numer");
			date = Intent.GetStringExtra("date");

			double NrOfDays = 0;
			if (date != "")
			{
				DateTime dateNow1 = DateTime.Now;
				TimeSpan t = dateNow1 - DateTime.Parse(date);
				NrOfDays = t.TotalDays;
			}

			if (NrOfDays > 1.0)
			{
				base.OnStop();
				Finish();
			}

            SetContentView(Resource.Layout.Welcome);

			TextView txtUser = FindViewById<TextView>(Resource.Id.txtUser);
			txtUser.Text = txtUser.Text + " " + name + " " + surname;

			LinearLayout bWyloguj = FindViewById<LinearLayout>(Resource.Id.bWyloguj);
			bWyloguj.Click += delegate
			{
				AlertDialog.Builder alert = new AlertDialog.Builder(this);
				alert.SetTitle ("Czy na pewno chcesz się wylogować?");
				alert.SetIcon(Resource.Drawable.warning);
				alert.SetPositiveButton ("TAK", (senderAlert, args) => {

					ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
					ISharedPreferencesEditor edit = pref.Edit();
					edit.PutString("name", "");
					edit.PutString("surname", "");
					edit.PutString("numer", "");
					edit.PutString("date", "");
					edit.Apply();

					String url2 = "http://158.75.112.74/www/php/script/appLogout.php?nrVoter=";
					var json = new WebClient().DownloadString(url2+numer);

					base.OnStop();
					Finish();
					_timer.Stop();
				});

				alert.SetNegativeButton ("NIE", (senderAlert, args) => { });

				Dialog dialog = alert.Create();
				dialog.Show();
			};

			_timer.Interval = 1000;
			_timer.Elapsed += OnTimedEvent;
			_timer.Enabled = true;
		}

		public override void OnBackPressed(){ }

		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
				this.RunOnUiThread(() =>
					{
						var json = new WebClient().DownloadString(url+numer);
						//var json = new WebClient().DownloadString(url);

						if (json.Substring(0, 1) == "{")
						{
							answer = JsonConvert.DeserializeObject<Answer>(json);
							
							if (String.Equals(answer.accept, "yes"))
							{
								var voteActivity = new Intent(this, typeof(VoteActivity));
								voteActivity.PutExtra("answers", answer.answers);
								voteActivity.PutExtra("numer", numer);
								voteActivity.PutExtra("name", name);
								voteActivity.PutExtra("surname", surname);
								voteActivity.PutExtra("date", date);
								StartActivity(voteActivity);
								base.OnStop();
								Finish();
								_timer.Stop();
							}
						}
					});
		}
	}
}
