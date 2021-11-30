using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Logika
{
    public class ForecastUtilities
    {
        public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            Weather max = weathers[0];
            double x = 0, Max = weathers[0].CalculateWindChill();
            for (int i = 0; i < weathers.Length; i++)
            {
                x = weathers[i].CalculateWindChill();
                if (x > Max)
                {
                    Max = x;
                    max = weathers[i];

                }
            }

            return max;

        }

        public static DailyForecast Parse(string s)
        {

            string[] part = s.Split(",");
            DateTime date = DateTime.ParseExact(part[0], "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture);
            Weather weather = new Weather();
            weather.SetTemperature(double.Parse(part[1], CultureInfo.InvariantCulture));
            weather.SetWindSpeed(double.Parse(part[2], CultureInfo.InvariantCulture));
            weather.SetHumidity(double.Parse(part[3], CultureInfo.InvariantCulture));

            return new DailyForecast(date, weather);
        }

    }
}
