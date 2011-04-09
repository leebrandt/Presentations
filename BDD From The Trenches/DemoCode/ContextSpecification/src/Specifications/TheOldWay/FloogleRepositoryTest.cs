using System.Linq;
using BddDemo.Framework.Data;
using NUnit.Framework;

namespace BddDemo.Specifications.TheOldWay
{
    [TestFixture]
    public class FloogleRepositoryTest
    {
        FloogleRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new FloogleRepository();
        }

        [Test]
        public void CanSearchFloogles()
        {
            var results = _repository.Search("A");
            Assert.AreEqual(0, results.Count(p=>!(p.PartNumber.Contains("A"))));
        }
    }
}