using System;
using System.Collections.Generic;
using System.Text;

namespace Beehive
{
    class Bee
    {
        const double HONEY_UNITS_CONSUMED_PER_MG = .25;

        public double WeightMg { get; private set; }

        public Bee(double weightMg)
        {
            WeightMg = weightMg;
        }

        public virtual double HoneyConsumptionRate()
        {
            return WeightMg * HONEY_UNITS_CONSUMED_PER_MG;
        }
    }
}
