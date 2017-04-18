using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SplitButExcept
{
    [TestClass]
    public class SplitTest
    {
        [TestMethod]
        public void Result_Test_1()
        {
            var input = "ab,bc";
            var actual = new Split(',', '"', input).Result();
            string[] expected = { "ab", "bc" };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Result_Test_2()
        {
            var input = "ab,\"bc,cd\"";
            var actual = new Split(',', '"', input).Result();
            string[] expected = { "ab", "bc,cd" };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Result_Test_3()
        {
            var input = "ab,\"bc,cd\",\"de\"";
            var actual = new Split(',', '"', input).Result();
            string[] expected = { "ab", "bc,cd","de" };
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}