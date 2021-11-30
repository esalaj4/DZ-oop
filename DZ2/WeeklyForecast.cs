using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Logika
{
    public class WeeklyForecast
    {
        private DailyForecast[] dailyForecasts = new DailyForecast[7];

        public WeeklyForecast(DailyForecast[] daily)
        {
            this.dailyForecasts = daily;

        }

        public string GetAsString()
        {

            string[] s = new string[7];
            s[0] = dailyForecasts[0].GetAsString();
            s[1] = dailyForecasts[1].GetAsString();
            s[2] = dailyForecasts[2].GetAsString();
            s[3] = dailyForecasts[3].GetAsString();
            s[4] = dailyForecasts[4].GetAsString();
            s[5] = dailyForecasts[5].GetAsString();
            s[6] = dailyForecasts[6].GetAsString();

            return string.Join("\n", s);
        }

        public double GetMaxTemperature()
        {
            DailyForecast maxT = dailyForecasts[0];
            DailyForecast temp;
            double max = 0;

            for (int i = 0; i < dailyForecasts.Length; i++)
            {
                temp = dailyForecasts[i];

                if (temp > maxT == true)
                {
                    maxT = temp;
                    max = maxT.GetTemperature();
                }

            }
            return max;

        }

        public DailyForecast this[int index]
        {
            get { return dailyForecasts[index]; }
        }
    }
}
