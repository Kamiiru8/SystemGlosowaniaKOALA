using Android.App;
using Android.Widget;
using Android.OS;
using Android;
using Android.Media;
using Android.Net;
using Android.Content;
using ZXing.Mobile;
using System.Net;
using Newtonsoft.Json;
using Java.Lang;
using System;

namespace QR_Only
{
	[Activity(Label = "SG Koala", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
	public class MainActivity : Activity
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

			ISharedPreferences prefGet = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
			string name = prefGet.GetString("name", "");
			string surname = prefGet.GetString("surname", "");
			string numer = prefGet.GetString("numer", "");
			string date = prefGet.GetString("date", "");

			double NrOfDays = 0;
			if (date != "")
			{
				DateTime dateNow1 = DateTime.Now;
				TimeSpan t = dateNow1 - DateTime.Parse(date);
				NrOfDays = t.TotalDays;
				//Toast tost = Toast.MakeText(this, NrOfDays.ToString(), ToastLength.Long);
				//tost.Show();
			}

			if (name != "" && surname != "" && numer != "" && NrOfDays < 1.0)
			{
				var welcomeActivity = new Intent(this, typeof(WelcomeActivity));
				welcomeActivity.PutExtra("name", name);
				welcomeActivity.PutExtra("surname", surname);
				welcomeActivity.PutExtra("numer", numer);
				welcomeActivity.PutExtra("date", date);
				StartActivity(welcomeActivity);
			}

			SetContentView(Resource.Layout.Main);

			if (CheckInternetConnection())
			{
				MobileBarcodeScanner.Initialize(Application);
				LinearLayout bQR = FindViewById<LinearLayout>(Resource.Id.bQR);

				bQR.Click += async (sender, e) =>
				{
					var scanner = new ZXing.Mobile.MobileBarcodeScanner();
					var result = await scanner.Scan();

					if (result != null)
					{
						//Toast.MakeText(this, result.Text, ToastLength.Long).Show();
						var json = new WebClient().DownloadString(result.Text);
						if (json.Substring(0, 1) == "{")
						{
							Answer answer = JsonConvert.DeserializeObject<Answer>(json);
							if (Android.Resource.String.Equals(answer.accept, "yes"))
							{
								DateTime dateNow2 = DateTime.Now;

								ISharedPreferences prefPut = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
								ISharedPreferencesEditor edit = prefPut.Edit();
								edit.PutString("name", answer.name);
								edit.PutString("surname", answer.surname);
								edit.PutString("numer", answer.numer);
								edit.PutString("date", dateNow2.ToString());
								edit.Apply();

								var welcomeActivity = new Intent(this, typeof(WelcomeActivity));
								welcomeActivity.PutExtra("name", answer.name);
								welcomeActivity.PutExtra("surname", answer.surname);
								welcomeActivity.PutExtra("numer", answer.numer);
								welcomeActivity.PutExtra("date", dateNow2.ToString());
								StartActivity(welcomeActivity);
							}
							else
							{
								Toast toast = Toast.MakeText(this, "Błąd serwera", ToastLength.Short);
								toast.Show();
							}
						}
						else
						{
							Toast toast = Toast.MakeText(this, "Odczytano niepoprawny QR", ToastLength.Short);
							toast.Show();
						}
					}
				};

				LinearLayout bToken = FindViewById<LinearLayout>(Resource.Id.bToken);
				bToken.Click += delegate { StartActivity(typeof(TokenActivity)); };
			}
			else
			{
				AlertDialog.Builder alert = new AlertDialog.Builder(this);
				alert.SetTitle ("Brak sieci Połącz się z siecią i spróbuj ponownie.");
				alert.SetIcon(Resource.Drawable.warning);
				alert.SetPositiveButton("OK", (senderAlert, args) =>
				{
						base.OnStop();
                        this.FinishAffinity();
						//Finish();
				});

				Dialog dialog = alert.Create();
				dialog.Show();
			}
		}

		public bool CheckInternetConnection()
		{
			string CheckUrl = "http://158.75.112.74/www/";
			try
			{
				HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
				iNetRequest.Timeout = 5000;
				WebResponse iNetResponse = iNetRequest.GetResponse();
				iNetResponse.Close();
				return true;
			}
			catch (WebException ex)
			{
				return false;
			}
		}
	}
}