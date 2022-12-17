using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class GrammaTest
    {
        [TestMethod]
        public void DebugLambdaTestMethod()
        {
            List<string> strList = new List<string>() { "aa", "bbb", "ccc", "dddd" };
            var longerThan2List = strList.Where(t => t.Length > 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExpectedExceptionAttrTestMethod()
        {
            SampleClass sp = new SampleClass(null);
        }
    }
}
