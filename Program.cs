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
            double minTemperature = -25.00, maxTemperature = 43.00;
            double minHumidity = 0.0, maxHumidity = 100.00;
            double minWindSpeed = 0.00, maxWindSpeed = 10.00;
            IRandomGenerator randomGenerator = new UniformGenerator(new Random());
            WeatherGenerator weatherGenerator = new WeatherGenerator(
                   minTemperature, maxTemperature,
                   minHumidity, maxHumidity,
                   minWindSpeed, maxWindSpeed,
                   randomGenerator
             );

            DailyForecastRepository repository = new DailyForecastRepository();
            repository.Add(new DailyForecast(DateTime.Now, weatherGenerator.Generate()));
            repository.Add(new DailyForecast(DateTime.Now.AddDays(1), weatherGenerator.Generate()));
            repository.Add(new DailyForecast(DateTime.Now.AddDays(2), weatherGenerator.Generate()));
            Console.WriteLine($"Current state of repository:{Environment.NewLine}{repository}");

            repository.Add(new DailyForecast(DateTime.Now.AddHours(2), weatherGenerator.Generate()));
            Console.WriteLine($"Current state of repository:{Environment.NewLine}{repository}");

            List<DailyForecast> forecasts = new List<DailyForecast>() {
                new DailyForecast(DateTime.Now.AddDays(2), weatherGenerator.Generate()),
                new DailyForecast(DateTime.Now.AddDays(3), weatherGenerator.Generate()),
                new DailyForecast(DateTime.Now.AddDays(4), weatherGenerator.Generate()),
                };
            repository.Add(forecasts);
            Console.WriteLine($"Current state of repository:{Environment.NewLine}{repository}");

            try
            {
                repository.Remove(DateTime.Now);
                repository.Remove(DateTime.Now.AddDays(100));
            }
            catch (NoSuchDailyWeatherException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine($"Current state of repository:{Environment.NewLine}{repository}");

            Console.WriteLine("Temperatures:");
            foreach (DailyForecast dailyForecast in repository)
            {
                Console.WriteLine($"-> {dailyForecast.Weather.GetTemperature()}");
            }

            DailyForecastRepository copy = new DailyForecastRepository(repository);
            Console.WriteLine($"Original repository:{Environment.NewLine}{repository}");
            Console.WriteLine($"Cloned repository:{Environment.NewLine}{copy}");

            DailyForecast forecastToAdd = new DailyForecast(DateTime.Now, new Weather(-2.0, 47.12, 2.1));
            copy.Add(forecastToAdd);

            Console.WriteLine($"Original repository:{Environment.NewLine}{repository}");
            Console.WriteLine($"Cloned repository:{Environment.NewLine}{copy}");

        }



       
    }
}
