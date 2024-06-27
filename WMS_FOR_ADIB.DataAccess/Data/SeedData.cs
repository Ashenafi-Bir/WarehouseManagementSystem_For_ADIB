using System.Linq;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB.DataAccess.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Check if data already exists
            if (context.Items.Any() || context.PurchaseOrders.Any())
            {
                return;   // DB has been seeded
            }

            // Seed Purchase Orders
            var purchaseOrders = new PurchaseOrder[]
            {
                new PurchaseOrder
                {
                    POId = 1,
                    // Set other properties as necessary
                },
                new PurchaseOrder
                {
                    POId = 2,
                    // Set other properties as necessary
                },
                new PurchaseOrder
                {
                    POId = 3,
                    // Set other properties as necessary
                }
            };

            context.PurchaseOrders.AddRange(purchaseOrders);
            context.SaveChanges();

            // Seed Items
            var items = new Item[]
            {
                new Item
                {
                    Description = "Sample Item 1",
                    Unit = "Piece",
                    Quantity = 10,
                    UnitPrice = 25.50m,
                    POId = 1
                },
                new Item
                {
                    Description = "Sample Item 2",
                    Unit = "Box",
                    Quantity = 5,
                    UnitPrice = 12.75m,
                    POId = 2
                },
                new Item
                {
                    Description = "Sample Item 3",
                    Unit = "Set",
                    Quantity = 15,
                    UnitPrice = 8.00m,
                    POId = 3
                },
                new Item
                {
                    Description = "Sample Item 4",
                    Unit = "Pack",
                    Quantity = 20,
                    UnitPrice = 5.25m,
                    POId = 3
                }
            };

            context.Items.AddRange(items);
            context.SaveChanges();
        }
    }
}
