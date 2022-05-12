using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherApp {
    [Activity(Label = "CitiesActivity")]
    public class CitiesActivity : Activity {
        TextView textViewKarvina;
        TextView textViewMadrid;
        TextView textViewOstrava;
        TextView textViewHelsinki;
        TextView textViewSydney;
        TextView textViewHavirov;
        TextView textViewBohumin;
        TextView textViewCeskyTesin;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.cities_layout);//!!!!!!!tady vložíme cities_layout!!!!!!

            SetupReferences();
            SubscribeEventHandlers();
        }

        private void SetupReferences() {
            textViewKarvina = FindViewById<TextView>(Resource.Id.textViewKarvina);
            textViewHelsinki = FindViewById<TextView>(Resource.Id.textViewHelsinki);
            textViewMadrid = FindViewById<TextView>(Resource.Id.textViewMadrid);
            textViewOstrava = FindViewById<TextView>(Resource.Id.textViewOstrava);
            textViewSydney = FindViewById<TextView>(Resource.Id.textViewSydney);
            textViewHavirov = FindViewById<TextView>(Resource.Id.textViewHavirov);
            textViewBohumin = FindViewById<TextView>(Resource.Id.textViewBohumin);
            textViewCeskyTesin = FindViewById<TextView>(Resource.Id.textViewCeskyTesin);
        }

        private void SubscribeEventHandlers() {
            textViewSydney.Click += TextViewSydney_Click;
            textViewOstrava.Click += TextViewOstrava_Click;
            textViewMadrid.Click += TextViewMadrid_Click;
            textViewHelsinki.Click += TextViewHelsinki_Click;
            textViewKarvina.Click += TextViewKarvina_Click;
            textViewHavirov.Click += TextViewHavirov_Click;
            textViewBohumin.Click += TextViewBohumin_Click;
            textViewCeskyTesin.Click += TextViewCeskyTesin_Click;

        }
        private void TextViewSydney_Click(object sender, EventArgs e) {
            //odseparuji do metody
            /*         Intent intent = new Intent();            //vytvoříme nový intent
                     intent.PutExtra("City", "Sydney");       //vracíme intentu ze třídy MainActivity  jméno hledaného města(klíč)  - Sydney(odpověď)
                     SetResult(Result.Ok, intent);          //zadáváme výsledek - OK
                     Finish();      //zavření aktivity
                     */
           // GoBackWithCity("Sydney", "Sydney");
             GoBackWithCity("Sydney");
        }
       // private void GoBackWithCity(string city,string nameCity) {
        private void GoBackWithCity(string city) {
         //  string [] cities = new string[] { city, nameCity };
            Intent intent = new Intent();
                 intent.PutExtra("City", city);   //(poslání města bez použití pole)
        //    intent.PutExtra("City", cities);       
            SetResult(Result.Ok, intent);
            Finish();
        }

        private void TextViewCeskyTesin_Click(object sender, EventArgs e) {
            // GoBackWithCity("Cesky%20Tesin", "Český Těšín");//pozor tento název města se už bude hledat ve weatherstacku takže bez diakritiky
           GoBackWithCity("Cesky%20Tesin");//pozor tento název města se už bude hledat ve weatherstacku takže bez diakritiky

        }
        private void TextViewBohumin_Click(object sender, EventArgs e) {
            //   GoBackWithCity("Bohumin","Bohumín");
            GoBackWithCity("Bohumin");
        }
        private void TextViewHavirov_Click(object sender, EventArgs e) {
            // GoBackWithCity("Havirov","Havířov");
            GoBackWithCity("Havirov");
        }
        private void TextViewOstrava_Click(object sender, EventArgs e) {
            //GoBackWithCity("Ostrava", "Ostrava");
            GoBackWithCity("Ostrava");
        }
        private void TextViewKarvina_Click(object sender, EventArgs e) {
            //GoBackWithCity("Karvina","Karviná");
GoBackWithCity("Karvina");
        }
        private void TextViewHelsinki_Click(object sender, EventArgs e) {
            // GoBackWithCity("Helsinki","Helsinky");
            GoBackWithCity("Helsinki");
        }
        private void TextViewMadrid_Click(object sender, EventArgs e) {
            // GoBackWithCity("Madrid","Madrid");
           GoBackWithCity("Madrid");
        }
    }
}