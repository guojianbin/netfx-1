using System;

namespace LianZhao
{
    public static class RandomExtensions
    {
        public static double NextDouble(this Random random, double min, double max)
        {
            if (random == null)
            {
                throw new ArgumentNullException("random");
            }

            var rv = random.Next((int)min, (int)max) + random.NextDouble();
            if (rv > max)
            {
                rv = max;
            }

            return rv;
        }
    }
}