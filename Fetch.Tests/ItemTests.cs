namespace Fetch.Tests
{
    [TestClass]
    public sealed class ItemTests
    {
        [TestMethod]
        public void RetailerNameEmpty()
        {
            Receipt receipt = new Receipt
            {
                Retailer = ""
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 0);
        }

        [TestMethod]
        public void RetailerNameAlphanumeric()
        {
            Receipt receipt = new Receipt
            {
                Retailer = "Tar - ge*lt"
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 7);
        }

        [TestMethod]
        public void ItemsTotalPriceIsRoundDollarAmount()
        {
            Receipt receipt = new Receipt
            {
                Total = 9.00m
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 50 + 25);
        }

        [TestMethod]
        public void ItemsTotalPriceIsQuarterDollarAmount()
        {
            Receipt receipt = new Receipt
            {
                Total = 3.50m
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 25);
        }

        [TestMethod]
        public void Items0MultiplesOf2With0Items()
        {
            Receipt receipt = new Receipt
            {
                Items = new List<Item>
                {

                }
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 0);
        }

        [TestMethod]
        public void Items0MultiplesOf2With1Item()
        {
            Receipt receipt = new Receipt
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Price = 3.10m
                    }
                }
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 0);
        }

        [TestMethod]
        public void Items1MultipleOf2With2Items()
        {
            Receipt receipt = new Receipt
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Price = 3.10m
                    },
                    new Item
                    {
                        Price = 3.10m
                    }
                }
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 5);
        }

        [TestMethod]
        public void Items1MultipleOf2With3Items()
        {
            Receipt receipt = new Receipt
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Price = 3.10m
                    },
                    new Item
                    {
                        Price = 3.10m
                    },
                    new Item
                    {
                        Price = 3.10m
                    }
                }
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 5);
        }

        [TestMethod]
        public void Items2MultiplesOf2With4Items()
        {
            Receipt receipt = new Receipt
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Price = 3.10m
                    },
                    new Item
                    {
                        Price = 3.10m
                    },
                    new Item
                    {
                        Price = 3.10m
                    },
                    new Item
                    {
                        Price = 3.10m
                    }
                }
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 10);
        }

        [TestMethod]
        public void GetPointsPurchaseDateIsOdd()
        {
            Receipt receipt = new Receipt
            {
                PurchaseDate = "2022-05-07"
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 6);
        }

        [TestMethod]
        public void PointsPurchaseTimeBetween2And4_1()
        {
            Receipt receipt = new Receipt
            {
                PurchaseTime = "14:59"
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 10);
        }

        [TestMethod]
        public void PointsPurchaseTimeBetween2And4_2()
        {
            Receipt receipt = new Receipt
            {
                PurchaseTime = "15:00"
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 10);
        }

        [TestMethod]
        public void FullReceipt_1()
        {
            Receipt receipt = new Receipt
            {
                Retailer = "M&M Corner Market",
                PurchaseDate = "2022-03-20",
                PurchaseTime = "14:33",
                Items = new List<Item>
                {
                    new Item
                    {
                        ShortDescription = "Gatorade",
                        Price = 2.25m
                    },
                    new Item
                    {
                        ShortDescription = "Gatorade",
                        Price = 2.25m
                    },
                    new Item
                    {
                        ShortDescription = "Gatorade",
                        Price = 2.25m
                    },
                    new Item
                    {
                        ShortDescription = "Gatorade",
                        Price = 2.25m
                    },
                },
                Total = 9.00m
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 109);
        }

        [TestMethod]
        public void FullReceipt_2()
        {
            Receipt receipt = new Receipt
            {
                Retailer = "Target",
                PurchaseDate = "2022-01-01",
                PurchaseTime = "13:01",
                Items = new List<Item>
                {
                    new Item
                    {
                        ShortDescription = "Mountain Dew 12PK",
                        Price = 6.49m
                    },
                    new Item
                    {
                        ShortDescription = "Emils Cheese Pizza",
                        Price = 12.25m
                    },
                    new Item
                    {
                        ShortDescription = "Knorr Creamy Chicken",
                        Price = 1.26m
                    },
                    new Item
                    {
                        ShortDescription = "Doritos Nacho Cheese",
                        Price = 3.35m
                    },
                    new Item
                    {
                        ShortDescription = "   Klarbrunn 12-PK 12 FL OZ  ",
                        Price = 12.00m
                    },
                },
                Total = 35.35m
            };

            int points = receipt.GetPoints();

            Assert.IsTrue(points == 28);
        }
    }
}
