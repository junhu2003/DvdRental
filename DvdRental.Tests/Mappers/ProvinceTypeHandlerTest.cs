using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdRental.Library.Mappers;
using DvdRental.Library.CustomTypes;

namespace DvdRental.Tests.Mappers
{
    [TestClass]
    public class ProvinceTypeHandlerTest
    {

        [TestMethod]
        public void TestProvinceHandler()
        {

            var typeHandler = new ProvinceTypeHandler();

            var parsed = typeHandler.Parse("ON");

            Assert.IsTrue(parsed.Value == ProvinceEnum.ON);


            var param = new Mock<IDbDataParameter>();

            param.SetupAllProperties();

            typeHandler.SetValue(param.Object, new Province() { Value = ProvinceEnum.ON });

            Assert.IsTrue(param.Object.Value as string == ProvinceEnum.ON.ToString());
        }
    }

}
