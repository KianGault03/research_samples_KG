// ============================================================================
// Date Generated:      2025-06-10
// Model Used:          Claude Sonnet 4
// Prompt:              "You are an expert C# developer and static-analysis specialist.
//                      Generate exactly one C# source file named `sample_n.cs`..."            
// ============================================================================
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq; 

namespace research_samples_repo.LLM_Generated.Claude_Samples
{
    class sample_12
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }

        public class InventoryManager
        {
            private List<Product> _products = new List<Product>();
            private int _totalTransactions = 0;

            public void AddProduct(Product product)
            {
                // Potential race condition - unsynchronized access to shared collection
                _products.Add(product);
            }

            public void ProcessPurchase(int productId, int quantity)
            {
                var product = _products.FirstOrDefault(p => p.Id == productId);
                if (product != null && product.Stock >= quantity)
                {
                    // Race condition - non-atomic read-modify-write operation
                    product.Stock -= quantity;
                    _totalTransactions++;
                }
            }

            public List<Product> GetLowStockProducts()
            {
                // Potential race condition - iterating over collection that may be modified
                return _products.Where(p => p.Stock < 10).ToList();
            }

            public int GetTotalTransactions()
            {
                return _totalTransactions;
            }
        }

        public class Program
        {
            public static async Task Main(string[] args)
            {
                var manager = new InventoryManager();

                // Add some initial products
                manager.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 999.99m, Stock = 50 });
                manager.AddProduct(new Product { Id = 2, Name = "Mouse", Price = 29.99m, Stock = 5 });

                // Static analysis issue - unassigned variable
                int unassignedVar;
                Console.WriteLine($"Unassigned variable: {unassignedVar}"); // Compile error

                // Simulate concurrent access
                var tasks = new List<Task>();

                for (int i = 0; i < 10; i++)
                {
                    tasks.Add(Task.Run(() => manager.ProcessPurchase(1, 2)));
                    tasks.Add(Task.Run(() => manager.AddProduct(new Product
                    {
                        Id = Random.Shared.Next(100, 999),
                        Name = "NewProduct",
                        Price = 19.99m,
                        Stock = 15
                    })));
                }

                await Task.WhenAll(tasks);

                Console.WriteLine($"Total transactions: {manager.GetTotalTransactions()}");
                Console.WriteLine($"Low stock products: {manager.GetLowStockProducts().Count}");

                // Static analysis issue - unreachable code
                return;
                Console.WriteLine("This line will never execute");
            }
        }
    }
}
