using System;
using Logika;
using System.Collections.Generic;
using System.IO;
using  System.Globalization;


namespace OOP_DZ2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int weatherCount = 10;
            double minTemperature = -25.00, maxTemperature = 43.00;
            double minHumidity = 0.00, maxHumidity = 100.00;
            double minWindSpeed = 0.00, maxWindSpeed = 10.00;
            Random generator = new Random();

            IRandomGenerator randomGenerator = new UniformGenerator(generator);
            WeatherGenerator weatherGenerator = new WeatherGenerator(
                minTemperature, maxTemperature,
                minHumidity, maxHumidity,
                minWindSpeed, maxWindSpeed,
                randomGenerator
            );

            Weather[] uniformWeathers = new Weather[weatherCount];
            for (int i = 0; i < uniformWeathers.Length; i++)
            {
                uniformWeathers[i] = weatherGenerator.Generate();
            }

            randomGenerator = new BiasedGenerator(generator);
            weatherGenerator.SetGenerator(randomGenerator);
            Weather[] winterWeathers = new Weather[weatherCount];
            for (int i = 0; i < winterWeathers.Length; i++)
            {
                winterWeathers[i] = weatherGenerator.Generate();
            }

            IPrinter[] uniformPrinters = new IPrinter[]
            {
                new ConsolePrinter(ConsoleColor.DarkYellow),
                new FilePrinter(@"uniformWeathers.txt"),
            };
            ForecastUtilities.PrintWeathers(uniformPrinters, uniformWeathers);

            IPrinter[] winterPrinters = new IPrinter[]
            {
                new ConsolePrinter(ConsoleColor.Green),
                new FilePrinter(@"winterWeathers.txt"),
            };
            ForecastUtilities.PrintWeathers(winterPrinters, winterWeathers);
        }

       

        /*public static void RunExercise1()
        {
            DateTime monday = new DateTime(2021, 11, 8);
            Weather mondayWeather = new Weather(6.17, 56.13, 4.9);
            DailyForecast mondayForecast = new DailyForecast(monday, mondayWeather);
            Console.WriteLine(monday.ToString());
            Console.WriteLine(mondayWeather.GetAsString());
            Console.WriteLine(mondayForecast.GetAsString());


            string fileName = "weather.forecast";


            if (File.Exists(fileName) == false)
            {
                Console.WriteLine("The required file does not exist. Please create it, or change the path.");
                return;
            }

            string[] dailyWeatherInputs = File.ReadAllLines(fileName);

            DailyForecast[] dailyForecasts = new DailyForecast[dailyWeatherInputs.Length];
            for (int i = 0; i < dailyForecasts.Length; i++)
            {
                dailyForecasts[i] = ForecastUtilities.Parse(dailyWeatherInputs[i]);

            }

            WeeklyForecast weeklyForecast = new WeeklyForecast(dailyForecasts);
            Console.WriteLine(weeklyForecast.ToString());

            Console.WriteLine("Maximal weekly temperature:");
            Console.WriteLine(weeklyForecast.GetMaxTemperature());
            Console.WriteLine(weeklyForecast[0].ToString());
        }*/
    }
}
