using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Inventura{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity{
        int sum = 0;
        int count = 0;
        List<int> counts=new List<int>();
        Button buttonIncrement;
        Button buttonDecrement;
        TextView textCount;
        Button buttonIncrementMore;
        Button buttonDecrementLast;
        Button buttonReset;
        Button buttonAddObject;
        Button buttonNextObject;
        Button buttonViewChanges;
        Button buttonViewObjectsSum;

        protected override void OnCreate(Bundle savedInstanceState){
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            buttonIncrement = FindViewById<Button>(Resource.Id.buttonIncrement);
            buttonDecrement = FindViewById<Button>(Resource.Id.buttonDecrement);
            textCount = FindViewById<TextView>(Resource.Id.textViewCount);
            buttonReset = FindViewById<Button>(Resource.Id.buttonReset);

            buttonIncrementMore = FindViewById<Button>(Resource.Id.buttonIncrementMore);
            buttonDecrementLast = FindViewById<Button>(Resource.Id.buttonDecrementLast);
            
            buttonAddObject = FindViewById<Button>(Resource.Id.buttonAddObject);
           buttonNextObject = FindViewById<Button>(Resource.Id.buttonNextObject);
            buttonViewChanges = FindViewById<Button>(Resource.Id.buttonViewChanges);
            buttonViewObjectsSum = FindViewById<Button>(Resource.Id.buttonViewObjectsSum);


            buttonIncrement.Click += ButtonIncrement_Click;
            buttonDecrement.Click += ButtonDecrement_Click;
            buttonReset.Click += ButtonReset_Click;
            buttonViewChanges.Click += ButtonViewChanges_Click;
            buttonIncrementMore.Click += ButtonIncrementMore_Click;
        }

        private void ButtonIncrementMore_Click(object sender, EventArgs e) {
            sum = sum + count;
            ShowTheSum();
        }

        private void ButtonViewChanges_Click(object sender, EventArgs e) {
            foreach(int sum in counts) {
                Console.WriteLine(sum);
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e) {
            sum=0;
            ShowTheSum();
        }

        private void ButtonDecrement_Click(object sender, EventArgs e) {
            sum--;
            ShowTheSum();
        }

        private void ShowTheSum() {
            counts.Add(sum);
            textCount.Text = sum.ToString();
        }

        private void ButtonIncrement_Click(object sender, EventArgs e) {
            sum++;
            ShowTheSum();
        }


    }
}