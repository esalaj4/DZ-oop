using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
     public class BiasedGenerator:IRandomGenerator
    {
        private Random generator;

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double Generate(double min, double max)
        {
            return min + (max - min) * Math.Pow(generator.NextDouble(), 2.5);
        }
    }
}
