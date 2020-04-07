using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTestMVC.Models
{
    public class UnitTest
    {
        private ITestHelper ith;
        public int FiveTimes(int a)
        {
            return a * 5;
        }

        public UnitTest(ITestHelper ithPara)
        {
            ith = ithPara;
        }

        public decimal Value(decimal d)
        {
            return ith.ApplyDiscount(d);
        }

        public UnitTest()
        {

        }

    }

    public interface ITestHelper
    {
        decimal ApplyDiscount(decimal total);
    }
}