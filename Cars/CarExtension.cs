using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public static class CarExtension
    {
        public static double TaxEx(this Car car)
        {
            if (car.Year < 2006 && car.EngineVolume > 4)
            {
                return 0.3;
            }

            if (car.Year >= 2006 && car.Year < 2010 && car.EngineVolume > 3)
            {
                return 0.2;
            }
            return 0.1;
        }

        public static double TotalPrice(this Car car)
        {
            return (1 + car.TaxEx()) * car.Price;
        }
    }
}