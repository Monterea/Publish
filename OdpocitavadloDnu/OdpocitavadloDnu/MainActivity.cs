using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace OdpocitavadloDnu
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity{
        TextView textViewDays;
        RadioButton rbHalloween;
        RadioButton rbKidsDay;
        RadioButton rbChristmas;
        TextInputEditText textInputCustomDate;
        Button buttonCountDays;
//datové složky pro výpočet:
DateTime today = DateTime.Today;
            DateTime endDate;
            TimeSpan daysToEvent;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //udělaná metoda pro inicializaci prvků uživatelského rozhraní:
            SetupReferences();
            //udělaná metoda pro vložení událostí
            SubscribeEvenHandlers();

        }
        private void SetupReferences() {
            textViewDays = FindViewById<TextView>(Resource.Id.textViewDays);
            rbHalloween = FindViewById<RadioButton>(Resource.Id.radioButtonHalloween);
            rbKidsDay = FindViewById<RadioButton>(Resource.Id.radioButtonKidsDay);
            rbChristmas = FindViewById<RadioButton>(Resource.Id.radioButtonChristmas);
            textInputCustomDate = FindViewById<TextInputEditText>(Resource.Id.textInputCustomDate);
            buttonCountDays=FindViewById<Button>(Resource.Id.buttonCountDays)
        }
        private void SubscribeEvenHandlers() {
            rbHalloween.CheckedChange += RbHalloween_CheckedChange;
            rbKidsDay.CheckedChange += rbKidsDay_CheckedChange;
            rbChristmas.CheckedChange += RbChristmas_CheckedChange;
            buttonCountDays.Click += ButtonCountDays_Click;
        }
        private void RbHalloween_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (rbHalloween.Checked) {
                /*   
                    DateTime today = DateTime.Today;
                    DateTime endDate = new DateTime(today.Year, 10, 31);
                    //pozor!!  když se dělá výpočet s daty je výsledek typu TimeSpan
                    TimeSpan daysToEvent = endDate - today;
                    textViewDays.Text = daysToEvent.ToString();

                předěláme na metodu:
                */
                CountEndDate(31, 10, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Halloween");
            }
        }
        private void RbKidsDay_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (rbKidsDay.Checked) {
                CountEndDate(1, 6, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Summer");
            }
        }

        private void RbChristmas_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (rbChristmas.Checked) {
                CountEndDate(24, 12, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Christmas");
            }
        }


        //předělání společných příkazů na metody
        private void CountEndDate(int day, int month, int year) {
            endDate = new DateTime(year, month, day);
            //zjišťujeme jestli není dnešní aktuální den vyšší než den, který hledáme
            if (today.DayOfYear > endDate.DayOfYear) { //pokud ano tak se bude odpočítávat hledaný den z dalšího roku                                                   
                endDate = endDate.AddYears(1);
            }

            private void CountTimeSpan() {
                TimeSpan daysToEvent = endDate - today;
            }
            private void ViewTheCountOfDays(string event) {
                textViewDays.Text = event;
        }




    }
}