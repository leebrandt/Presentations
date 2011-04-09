using BddDemo.Framework.Domain;
using NUnit.Framework;

namespace BddDemo.Specifications.TheOldWay
{
    [TestFixture]
    public class FloogleTest
    {
        Floogle _floogle;

        [SetUp]
        public void SetUp()
        {
            _floogle = new Floogle();
        }

        [Test]
        public void CanSetPartNumber()
        {
            _floogle.PartNumber = "1";
            Assert.AreEqual("1", _floogle.PartNumber);
        }
    }
}