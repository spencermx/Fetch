
namespace Fetch
{
    public class Item
    {
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }

        public int GetPoints()
        {
            int points = 0;

            if (!string.IsNullOrWhiteSpace(ShortDescription) && ShortDescription.Trim().Length % 3 == 0)
            {
                points = (int)Math.Ceiling(Price * 0.2m);
            }

            return points;
        }
    }
}
