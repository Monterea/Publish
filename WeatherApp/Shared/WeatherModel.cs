using System;
using System.Collections.Generic;
using System.Text;

namespace Shared {
    

        //z www api si stáhneme odpověď
        
	public class WeatherModel {
		public Request Request { get; set; }
		public Location Location { get; set; }
		public Current Current { get; set; }
	}

	public class Request {
		public string Type { get; set; }
		public string Query { get; set; }
		public string Language { get; set; }
		public string Unit { get; set; }
	}

	public class Location {
		public string Name { get; set; }
		public string Country { get; set; }
		public string Region { get; set; }
		public string Lat { get; set; }
		public string Lon { get; set; }
		public string Timezone_id { get; set; }
		public string Localtime { get; set; }
		public int Localtime_epoch { get; set; }
		public string Utc_offset { get; set; }
	}
	public class Current {
		public string Observation_time { get; set; }
		public int Temperature { get; set; }
		public int Weather_code { get; set; }
		public string[] Weather_icons { get; set; }
		public string[] Weather_descriptions { get; set; }
		public int Wind_speed { get; set; }
		public int Wind_degree { get; set; }
		public string Wind_dir { get; set; }
		public int Pressure { get; set; }
		public float Precip { get; set; }
		public int Humidity { get; set; }
		public int Cloudcover { get; set; }
		public int Feelslike { get; set; }
		public int Uv_index { get; set; }
		public int Visibility { get; set; }
		public string Is_day { get; set; }
	}

}
