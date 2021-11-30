﻿using System;
using System.Globalization;

namespace Logika
{
    public class DailyForecast
    {
        private DateTime date;
        private Weather weather;

        public double GetTemperature()
        {
            return weather.GetTemperature();
        }

        public DailyForecast(DateTime date, Weather weather)
        {
            this.date = date;
            this.weather = weather;
        }

        public string GetAsString()
        {
            string date_str = date.ToString("dd/MM/yyyy HH:mm:ss");
            DateTime date1 = DateTime.ParseExact(date_str, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture);
            return $"{date1} " + weather.GetAsString();
        }

        public static bool operator >(DailyForecast df1, DailyForecast df2)
        {
            double t1 = df1.GetTemperature();
            double t2 = df2.GetTemperature();

            return t1 > t2 ? true : false;

        }

        public static bool operator <(DailyForecast df1, DailyForecast df2)
        {
            double t1 = df1.GetTemperature();
            double t2 = df2.GetTemperature();

            return t1 < t2 ? true : false;

        }

    }
}
