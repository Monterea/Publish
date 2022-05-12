using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
/*takhle vypadá požadavek z weatherstack.com:
 * http://api.weatherstack.com/current?access_key=e68e69dbcbe99b0fd6d6081b8fb42c5a&query=New%20York&language=cs
dotaz na město může být i se všemi malými písmeny    
mezera mezi dvěmi slovy v názvu města se vypisuje:   %20
http://api.weatherstack.com/current?access_key=e68e69dbcbe99b0fd6d6081b8fb42c5a&query=new%20york

 */
namespace Shared {
    public class WeatherService {
        IWeatherView weatherView;   // interface
        //http://api.weatherstack.com/current? access key=e68e69dbcbe99b0fd6d6081b8fb42c5a
        private readonly string ApiKey = "e68e69dbcbe99b0fd6d6081b8fb42c5a";    //udělali jsme z toho konstantu
        

        public WeatherService(IWeatherView view) {//není aktivita a proto můžeme použít konstruktor
            this.weatherView = view;
        }

        public async void GetWeatherForCityAsync(string city) {      //má být správně:   public async Task GetWeatherForCityAsync(string city) { 
            HttpClient client = new HttpClient();   //tato třída nás spojí s weatherstack
            var response = await client.GetAsync($"http://api.weatherstack.com/current?access_key={ApiKey}&query={city}");//tato www adresa nese Success kody (od 200 do 409)
            if (response.IsSuccessStatusCode) {     //testujeme Success kód
                System.Diagnostics.Debug.WriteLine("OK");
                var content = await response.Content.ReadAsStringAsync();  // content je vlastně neupravený JSON řetězec stáhnutých dat z weatherstock
                System.Diagnostics.Debug.WriteLine(content);  //vypsání contentu do konzole
                WeatherModel weatherModel = JsonConvert.DeserializeObject<WeatherModel>(content);//deserializace contentu pomocí newtonsoft
                weatherView.SetWeatherData(weatherModel);//voláme třídu přez rozhraní (pomocí reference nejde - už je reference na shared)


            }   //zde se dává breakpoint pro první zkoušku přenosu prvních dat


        }





    }
}
