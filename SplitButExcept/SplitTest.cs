using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SplitButExcept
{
    [TestClass]
    public class SplitTest
    {
        [TestMethod]
        public void Result_Test_0()
        {
            var input = "ab,bc";
            var actual = new Split(',', '"', input).Result();
            string[] expected = { "ab", "bc" };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Result_Test_1()
        {
            var input = "ab,\"bc,cd\"";
            var actual = new Split(',', '"', input).Result();
            string[] expected = { "ab", "bc,cd" };
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}