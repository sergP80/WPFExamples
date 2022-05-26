using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Car
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public double EngineVolume { get; set; }
        public double Price { get; set; }

        public double Tax
        {
            get
            {
                if (Year < 2010 && EngineVolume > 3)
                {
                    return 0.2;
                }
                return 0.1;
            }
        }
    }
}
