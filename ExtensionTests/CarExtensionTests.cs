using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cars;
using static Cars.CarExtension;
using System.Collections.Generic;

namespace ExtensionTests
{

    [TestClass]
    public class CarExtensionTests
    {
        static IEnumerable<object[]> RateFixture()
        {
            return new List<object[]>() {
                new object[]
                {
                    new Car()
                    {
                        Price = 1000,
                        Year = 2004,
                        EngineVolume = 2.5
                    },
                    0.1,
                    0.1,
                    1100.0
                },
                new object[]
                {
                    new Car()
                    {
                        Price = 12000,
                        Year = 2007,
                        EngineVolume = 3.5
                    },
                    0.2,
                    0.2,
                    14400.0
                }
            };
        }

        [TestMethod]
        [DynamicData(nameof(RateFixture), DynamicDataSourceType.Method)]
        public void ShouldCalculateTaxRate(Car car, double tax, double taxEx, double totalPrice)
        {
            Assert.AreEqual(tax, car.Tax, 0.001);
            Assert.AreEqual(taxEx, car.TaxEx(), 0.001);
            Assert.AreEqual(totalPrice, car.TotalPrice(), 0.001);
        }
    }
}
