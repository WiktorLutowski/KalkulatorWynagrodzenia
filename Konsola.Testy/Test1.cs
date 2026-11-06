namespace Konsola.Testy
{
    [TestClass]
    public sealed class KalkulatorTest
    {
        [TestMethod]
        public void TestZaliczkiPit()
        {
            Kalkulator k1 = new(500, true, true);

            Assert.AreEqual(0, k1.ZaliczkaPit());
        }
    }
}
