using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public class Weather
    {

        private double temperature;
        private double humidity;
        private double windSpeed;

        public double GetTemperature() { return this.temperature; }
        public double GetHumidity() { return this.humidity; }
        public double GetWindSpeed() { return this.windSpeed; }

        public void SetTemperature(double temperature) { this.temperature = temperature; }
        public void SetHumidity(double humidity) { this.humidity = humidity; }
        public void SetWindSpeed(double windSpeed) { this.windSpeed = windSpeed; }

        public Weather()
        {
            this.temperature = 0;
            this.humidity = 0;
            this.windSpeed = 0;
        }

        public Weather(double temperature, double humidity, double windSpeed)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }

        public double CalculateFeelsLikeTemperature()
        {
            const double c1 = -8.78469475556;
            const double c2 = 1.61139411;
            const double c3 = 2.33854883889;
            const double c4 = -0.14611605;
            const double c5 = -0.012308094;
            const double c6 = -0.0164248277778;
            const double c7 = 0.002211732;
            const double c8 = 0.00072546;
            const double c9 = -0.000003582;

            double humidityPercentage = GetHumidity();

            double heatIndex = c1 + (c2 * GetTemperature()) + (c3 * humidityPercentage) + (c4 * GetTemperature() * humidityPercentage) + (c5 * Math.Pow(GetTemperature(), 2)) + (c6 * Math.Pow(humidityPercentage, 2)) + (c7 * Math.Pow(GetTemperature(), 2) * humidityPercentage) + (c8 * GetTemperature() * Math.Pow(humidityPercentage, 2) + (c9 * Math.Pow(GetTemperature(), 2)) * Math.Pow(humidityPercentage, 2));

            return heatIndex;
        }

        public double CalculateWindChill()
        {


            double WCI = 0;
            if (GetTemperature() <= 10 && GetWindSpeed() > 4.8)
                WCI = 13.12 + (0.6215 * GetTemperature()) - (11.37 * Math.Pow(GetWindSpeed(), 0.16)) + (0.3965 * GetTemperature() * Math.Pow(GetWindSpeed(), 0.16));
            else WCI = 0;
            return WCI;
        }

        public override string ToString()
        {
            return $"T={temperature}°C w={windSpeed} km/h h={humidity}%";
        }

    }
}
