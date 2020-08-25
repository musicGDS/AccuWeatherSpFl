using AccuWeatherSpFl.Models;

namespace AccuWeatherSpFl.Actions
{
    class CityActions
    {
        public string GetName(CityModel city)
        {
            return city.LocalizedName;
        }
    }
}
