using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Shared;
using System;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IWeatherView  {
        //vkládáme prvky:
        ImageView imageViewWeather;
        TextView textViewCity;
        TextView textViewWeather;
        TextView textViewTemperature;
        TextView textViewHuminidy;
        TextView textViewWind;
        TextView textViewLocalTime;
        Button buttonChangeCity;
        WeatherService weatherService;  
        TextView textViewPressure;
        TextView textViewCloudcover;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);          
            SetContentView(Resource.Layout.activity_main);//!!!!!!!tady vložíme cities_layout!!!!!!
                                                          
            weatherService = new WeatherService(this);    //důležité - inicicalizace datové složky
            SetupReferences();
            SubscribeEventHandlers();
   }

        //POZOR TATO METODA SE MUSÍ SMAZAT !!!!!!!! , ale my to chceme kvůli poloze
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults){
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }



        private void SetupReferences() {
            imageViewWeather = FindViewById<ImageView>(Resource.Id.imageViewPicture);
            textViewCity = FindViewById<TextView>(Resource.Id.textViewCity);
            textViewHuminidy = FindViewById<TextView>(Resource.Id.textViewHuminidy);
            textViewLocalTime = FindViewById<TextView>(Resource.Id.textViewLocalTime);
            textViewTemperature = FindViewById<TextView>(Resource.Id.textViewTemperature);
            textViewWeather = FindViewById<TextView>(Resource.Id.textViewWeather);
            textViewWind = FindViewById<TextView>(Resource.Id.textViewWind);
            buttonChangeCity = FindViewById<Button>(Resource.Id.buttonChangeCity);
            textViewPressure = FindViewById<TextView>(Resource.Id.textViewPressure);
            textViewCloudcover = FindViewById<TextView>(Resource.Id.textViewCloudcover);
        }

        private void SubscribeEventHandlers() {
            buttonChangeCity.Click += ButtonChangeCity_Click;
        }
         private void ButtonChangeCity_Click(object sender, EventArgs e) {
            Intent intent = new Intent(this, typeof(CitiesActivity));  //po zmáčknutí tlačítka se spustí třída CitiesActivity pro výběr města
           // StartActivity(intent);        //otevření třídy                      
            StartActivityForResult(intent, 1);              //chce odpověď z handlerů pro zvolení města v třídě CitiesActivity (1=request kód - díky němu vracíme jednotlivé položky) 
        }

        //metoda pro přijetí intentu s městem
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data) {
           // base.OnActivityResult(requestCode, resultCode, data);            //toto můžeme smazat
                if (requestCode==1 && resultCode == Result.Ok) {    //otestujeme zda intent přišel OK a zda je jeho request code stejný jako poslaný kod
                    string city = data.GetStringExtra("City");  //přijetí klíče
                    textViewCity.Text = city;     //zadáváme v mobilu výpis do úvodního řádku pro město     // (vypsání názvu města bez použití pole)        
                
                  //  string nameCity = data.GetStringExtra("City");                                         
                  //  textViewCity.Text = nameCity;
                    weatherService.GetWeatherForCityAsync(city);  //zde by metoda GetWeatherForCityAsync s Task dělala potíže
            }
        }

        public void SetWeatherData(WeatherModel weatherModel) {
            textViewCity.Text = weatherModel.Location.Name;
            textViewHuminidy.Text = $"{ weatherModel.Current.Humidity.ToString()} %";
            textViewLocalTime.Text = weatherModel.Location.Localtime;
            textViewTemperature.Text = $"{weatherModel.Current.Temperature.ToString()} °C";
            textViewWind.Text = $"{weatherModel.Current.Wind_dir}  {weatherModel.Current.Wind_speed} km/h";//wind-dir je azimut větru
            textViewCloudcover.Text = $"{weatherModel.Current.Cloudcover.ToString()} %";
            textViewPressure.Text = $"{weatherModel.Current.Pressure.ToString()} MB";
            textViewWeather.Text = weatherModel.Current.Weather_descriptions[0];
            imageViewWeather.SetImageBitmap(GetImageBitmapFromUrl(weatherModel.Current.Weather_icons[0]));
        }

        private Bitmap GetImageBitmapFromUrl(string url) {
            Bitmap imageBitmap = null;
            using (var webClient = new System.Net.WebClient()) {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0) {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }
    }

    }
