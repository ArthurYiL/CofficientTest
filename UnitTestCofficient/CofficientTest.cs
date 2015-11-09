using System;
using System.IO;
using System.Reflection;
using Cofficient.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCofficient
{
    [TestClass]
    public class CofficientTest
    {
        private CoefficientParser _parser;
        public CofficientTest()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Config\config.json";
            _parser = new CoefficientParser(path);
        }

        [TestMethod]
        public void TestCofficientOfGuangXi_LiuZhou_Summer()
        {
            Assert.AreEqual<decimal>((decimal)0.3, _parser.GetCoefficient("广西", "柳州", "夏季"));
        }

        [TestMethod]
        public void TestCofficientOfGuangXi_LiuZhou_Spring()
        {
            Assert.AreEqual<decimal>((decimal)0.35, _parser.GetCoefficient("广西", "柳州", "春季"));
        }

        [TestMethod]
        public void TestCofficientOfGuangXi_LiuZhou_Winter()
        {
            Assert.AreEqual<decimal>((decimal)0.9, _parser.GetCoefficient("广西", "柳州", "冬季"));
        }

        [TestMethod]
        public void TestCofficientOfHuNan_XiangTan_Winter()
        {
            Assert.AreEqual<decimal>((decimal)0.9, _parser.GetCoefficient("湖南", "湘潭", "冬季"));
        }

        [TestMethod]
        public void TestCofficientOfHuNan_XiangTan_Spring()
        {
            Assert.AreEqual<decimal>((decimal)0.6, _parser.GetCoefficient("湖南", "湘潭", "春季"));
        }

        [TestMethod]
        public void TestCofficientOfHuNan_XiangTan_Summer()
        {
            Assert.AreEqual<decimal>((decimal)0.55, _parser.GetCoefficient("湖南", "湘潭", "夏季"));
        }

        [TestMethod]
        public void TestCofficientOfHuNan_XiangTan_Autumn()
        {
            Assert.AreEqual<decimal>((decimal)0.6, _parser.GetCoefficient("湖南", "湘潭", "秋季"));
        }

        [TestMethod]
        public void TestCofficientOfHuBei_WuHan_Spring()
        {
            Assert.AreEqual<decimal>((decimal)0.35, _parser.GetCoefficient("湖北", "武汉", "春季"));
        }

        [TestMethod]
        public void TestCofficientOfHuBei_WuHan_Summer()
        {
            Assert.AreEqual<decimal>((decimal)0.35, _parser.GetCoefficient("湖北", "武汉", "夏季"));
        }

        [TestMethod]
        public void TestCofficientOfHuBei_WuHan_Autumn()
        {
            Assert.AreEqual<decimal>((decimal)0.48, _parser.GetCoefficient("湖北", "武汉", "秋季"));
        }

        [TestMethod]
        public void TestCofficientOfHuBei_WuHan_Winter()
        {
            Assert.AreEqual<decimal>((decimal)0.9, _parser.GetCoefficient("湖北", "武汉", "冬季"));
        }
    }
}
