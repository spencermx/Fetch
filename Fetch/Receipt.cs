
namespace Fetch
{
    public class Receipt
    {
        public string Retailer { get; set; }

        public string PurchaseDate { get; set; }

        public string PurchaseTime { get; set; }

        public decimal Total { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        public int GetPoints()
        {
            int pointsRetailer = GetPointsRetailer();

            int pointsTotalPrice = GetPointsTotalPrice();

            int pointsTwoItems = GetPointsTwoItemsGroups();

            int pointsItemDescription = GetPointsItemDescription();

            int pointsPurchaseDate = GetPointsPurchaseDate();

            int pointsPurchaseTime = GetPointsPurchaseTime();

            return pointsRetailer + pointsTotalPrice + pointsTwoItems + pointsItemDescription + pointsPurchaseDate + pointsPurchaseTime;
        }
        private int GetPointsRetailer()
        {
            if (!string.IsNullOrEmpty(Retailer))
            {
                return Retailer.Count(x => char.IsLetterOrDigit(x));
            }

            return 0;
        }

        private int GetPointsTotalPrice()
        {
            int points = 0;

            decimal totalPrice = Total;

            if (totalPrice > 0.00m)
            {
                if (IsRoundAmount(totalPrice)) // ideally probably invert these, create fancier type than decimal or add extension method to decimal
                {
                    points += 50;
                }

                if (IsQuarterAmount(totalPrice))
                {
                    points += 25;
                }
            }

            return points;
        }

        private int GetPointsTwoItemsGroups()
        {
            int points = Items.Count / 2 * 5;

            return points;
        }

        private int GetPointsItemDescription()
        {
            int points = 0;

            foreach (Item item in Items)
            {
                points += item.GetPoints();
            }

            return points;
        }

        private int GetPointsPurchaseTime()
        {
            if (string.IsNullOrWhiteSpace(PurchaseTime))
            {
                return 0;
            }

            string[] parts = PurchaseTime.Split(':');

            int hour = int.Parse(parts[0]);
            int minute = int.Parse(parts[1]);

            if (hour == 14 && minute >= 1 && minute <= 59)
            {
                return 10;
            }

            if (hour == 15 && minute >= 0 && minute <= 59)
            {
                return 10;
            }

            return 0;
        }

        private int GetPointsPurchaseDate()
        {
            if (string.IsNullOrWhiteSpace(PurchaseDate))
            {
                return 0;
            }

            string[] parts = PurchaseDate.Split('-');

            int day = int.Parse(parts[2]);

            bool dayIsOdd = day % 2 != 0;

            if (dayIsOdd)
            {
                return 6;
            }

            return 0;
        }
           
        private bool IsQuarterAmount(decimal amount)
        {
            return decimal.Remainder(amount, 0.25m) == 0m;
        }

        private bool IsRoundAmount(decimal amount)
        {
            return decimal.Remainder(amount, 1m) == 0m;
        }
    }
}
