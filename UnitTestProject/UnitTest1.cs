using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using WpfApp;
using WpfApp.Utility;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VideoApp vidApp = new VideoApp();
            var res = vidApp.GetpicFromvideo(@"H:\csharpProjects\WpfApp\WpfApp\123.mkv", "160*100", "1", false);
            Assert.IsTrue(!string.IsNullOrEmpty(res), "Get Frame OK");
        }
    }
}
