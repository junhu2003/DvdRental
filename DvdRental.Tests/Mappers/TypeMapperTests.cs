using DvdRental.Library.Mappers;

namespace DvdRental.Tests
{

    [TestClass]
    public class TypeMapperTests
    {
        public TypeMapperTests()
        {
            TypeMapper.Initialize("DvdRental.Library.Models");
        }

        /*
        [TestMethod]
        public void TypeMapperTest()
        {
            
            var map = SqlMapper.GetTypeMap(typeof(Employer));
            Assert.IsNotNull(map);
            var propName = map?.GetMember("d_ser_assoc")?.Property?.Name;
            Assert.IsTrue(propName?.Equals("Assoc"));

        }
        */
    }
}
