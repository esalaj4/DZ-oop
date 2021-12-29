using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public class WeatherGenerator
    {
        private double minTemp, maxTemp, minHumidity, maxHumidity, minWindSpeed, maxWindSpeed;
        private IRandomGenerator generator;

        public void SetGenerator(IRandomGenerator generator)
        {
            this.generator = generator;
        }

        public WeatherGenerator(double minTemp, double maxTemp, double minHumidity, double maxHumidity, double minWindSpeed, double maxWindSpeed, IRandomGenerator generator)
        {
            this.minTemp = minTemp;
            this.maxTemp = maxTemp;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.generator = generator;
        }

        public Weather Generate()
        {
            return new Weather(generator.Generate(minTemp, maxTemp), generator.Generate(minHumidity, maxHumidity), generator.Generate(minWindSpeed, maxWindSpeed));
        }
    }
}
