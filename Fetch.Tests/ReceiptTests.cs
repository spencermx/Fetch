namespace Fetch.Tests
{
    [TestClass]
    public sealed class ReceiptTests
    {
        [TestMethod]
        public void GetPointsFromDescription()
        {
            Item item = new Item
            {
                ShortDescription = "   Klarbrunn 12-PK 12 FL OZ",
                Price = 12.00m
            };

            int points = item.GetPoints();

            Assert.IsTrue(points == 3);
        }
    }
}
