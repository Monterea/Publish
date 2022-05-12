using System;
using System.Collections.Generic;
using System.Text;

namespace Shared {
    public interface IWeatherView {
        void SetWeatherData(WeatherModel weatherModel);  //nastaví poslání, ale vracet nic nebude
    }
}
