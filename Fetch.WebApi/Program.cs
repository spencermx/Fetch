using Fetch;

namespace Fetch.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            Dictionary<Guid, Receipt> receipts = new Dictionary<Guid, Receipt>();

            app.MapGet("/", () =>
            {
                return "index";
            });

            app.MapPost("/receipts/process", (Receipt receipt, HttpContext httpContext) =>
            {
                // Only doing minimal input validation, no validation for time, date, character set, etc

                Guid id = Guid.NewGuid();

                receipts[id] = receipt;

                return new { Id = id };
            });

            app.MapGet("/receipts/{id}/points", (Guid id) =>
            {
                Receipt receipt = receipts[id];

                int points = receipt.GetPoints();

                return new { Points = points };
            });

            app.Run();
        }
    }
}
