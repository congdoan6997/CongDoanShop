using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CongDoan.UnitTest
{
    namespace Db
    {
        public class Order
        {
            public List<ShipOnly> Ship { get; set; }
        }

        public class ShipOnly
        {
            public string Name { get; set; }
        }
    }

    namespace Dto
    {
        public class Order
        {
            public List<ShipOnly> Ship { get; set; }
        }

        public class ShipOnly
        {
            public string Name { get; set; }
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Db.Order, Dto.Order>();
                cfg.CreateMap<Db.ShipOnly, Dto.ShipOnly>();
            });

            Db.Order source = new Db.Order
            {
                Ship = new List<Db.ShipOnly>
                     {
                                     new Db.ShipOnly { Name = "Test" }
                    }
            };

            Dto.Order result = Mapper.Map<Dto.Order>(source);
            Assert.IsNotNull(result.Ship);
            Assert.AreEqual(1,result.Ship.Count);
            Assert.AreEqual("Test",result.Ship[0].Name);

        }
    }
}