using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationTestMVC.Models;
using Moq;

namespace WebApplicationTestMVC.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UnitTest ut = new UnitTest();
            int b = ut.FiveTimes(10);
            Assert.AreEqual(b, 50);
        }

        [TestMethod]
        public void TestMock()
        {
            Mock<ITestHelper> mock = new Mock<ITestHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(t => t*3);

            var target = new UnitTest(mock.Object);

            var result = target.Value(100m);

            Assert.AreEqual(300m, result);

        }
    }
}
