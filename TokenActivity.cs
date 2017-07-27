
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Newtonsoft.Json;

namespace QR_Only
{
	[Activity(Label = "TokenActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
	public class TokenActivity : Activity
	{
		public class Answer
		{
			public string accept { get; set; }
			public string name { get; set; }
			public string surname { get; set; }
			public string numer { get; set; }
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Token);

			LinearLayout layoutButton = FindViewById<LinearLayout>(Resource.Id.myButton);

			EditText editToken = FindViewById<EditText>(Resource.Id.editToken);

			layoutButton.Click += delegate
			{
				try
				{
					String token = editToken.Text; 
					String url = "http://158.75.112.74/www/php/script/appAddController.php?token="+token;
					//String url = "http://zespolowka.co.nf/qr.html";

					var json = new WebClient().DownloadString(url);
					if (json.Substring(0, 1) == "{")
					{
						Answer answer = JsonConvert.DeserializeObject<Answer>(json);

						if (String.Equals(answer.accept, "yes"))
						{
							ISharedPreferences prefPut = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
							ISharedPreferencesEditor edit = prefPut.Edit();
							edit.PutString("name", answer.name);
							edit.PutString("surname", answer.surname);
							edit.PutString("numer", answer.numer);
							edit.Apply();

							DateTime dateNow2 = DateTime.Now;

							var welcomeActivity = new Intent(this, typeof(WelcomeActivity));
							welcomeActivity.PutExtra("name", answer.name);
							welcomeActivity.PutExtra("surname", answer.surname);
							welcomeActivity.PutExtra("numer", answer.numer);
							welcomeActivity.PutExtra("date", dateNow2.ToString());
							StartActivity(welcomeActivity);
							base.OnStop();
							Finish();
						}else
						{
							Toast toast = Toast.MakeText(this, answer.accept, ToastLength.Short);
							toast.Show();
						}
					}
				}
				catch (InvalidOperationException)
				{
				}
			};
		}
	}
}