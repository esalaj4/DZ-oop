using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
     public class UniformGenerator:IRandomGenerator
    {
        private Random generator;

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double Generate(double max,double min)
        {
            return generator.NextDouble() * (max - min) + min;
        }
    }
}
