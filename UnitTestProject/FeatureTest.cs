using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp;
using WpfApp.Utility;

namespace UnitTestProject
{
    [TestClass]
    public class FeatureTest
    {
        [TestMethod]
        public void GetFrameTestMethod()
        {
            VideoApp vidApp = new VideoApp();
            var res = vidApp.GetpicFromvideo(@"H:\csharpProjects\WpfApp\WpfApp\123.mkv", "160*100", "1", false);
            Assert.IsTrue(!string.IsNullOrEmpty(res), "Get Frame OK");
        }

        [TestMethod]
        public void DebugLambdaTestMethod()
        {
            List<string> strList = new List<string>() { "aa", "bbb", "ccc", "dddd" };
            var longerThan2List = strList.Where(t => t.Length > 2);
        }
    }
}
