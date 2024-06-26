using System.Linq;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB.DataAccess.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Check if data already exists
            if (context.Items.Any())
            {
                return;   // DB has been seeded
            }

            var items = new Item[]
            {
                new Item
                {
                    ItemID = 1,
                    Description = "Sample Item 1",
                    Unit = "Piece",
                    Quantity = 10,
                    UnitPrice = 25.50m,
                    PONumber = "PO-12345"
                },
                new Item
                {
                    ItemID = 2,
                    Description = "Sample Item 2",
                    Unit = "Box",
                    Quantity = 5,
                    UnitPrice = 12.75m,
                    PONumber = "PO-67890"
                },
                
                new Item
                {
                    ItemID = 3,
                    Description = "Sample Item 3",
                    Unit = "Set",
                    Quantity = 15,
                    UnitPrice = 8.00m,
                    PONumber = "PO-54321"
                },
                new Item
                {
                    ItemID = 4,
                    Description = "Sample Item 4",
                    Unit = "Pack",
                    Quantity = 20,
                    UnitPrice = 5.25m,
                    PONumber = "PO-98765"
                }
                
            };

            context.Items.AddRange(items);
            context.SaveChanges();
        }
    }
}
