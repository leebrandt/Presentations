using BddDemo.Framework.Domain;
using NUnit.Framework;

namespace BddDemo.Specifications.TheOldWay
{
    [TestFixture]
    public class FloogleTestAAA
    {
        [Test]
        public void ShouldBeAbleToSetPartNumber()
        {
            // Arrange
            var floogle = new Floogle();

            // Act
            floogle.PartNumber = "PPK0120";

            //Assert
            Assert.AreEqual("PPK0120", floogle.PartNumber);
        }
    }
}