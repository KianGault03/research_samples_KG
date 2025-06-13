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

namespace research_samples_repo.LLM_Generated.Claude_Sample
{
    class Sample_10
    {

        public class Account
        {
            public string AccountNumber { get; set; }
            public decimal Balance { get; set; }
            public DateTime LastActivity { get; set; }
        }

        public class TransactionProcessor
        {
            private static List<Account> accounts = new List<Account>();
            private static int transactionCounter = 0;

            public static void Main(string[] args)
            {
                // Initialize some test accounts
                accounts.Add(new Account { AccountNumber = "ACC001", Balance = 1000m, LastActivity = DateTime.Now });
                accounts.Add(new Account { AccountNumber = "ACC002", Balance = 500m, LastActivity = DateTime.Now });

                // Simulate concurrent transactions
                var tasks = new List<Task>();

                for (int i = 0; i < 10; i++)
                {
                    int taskId = i;
                    tasks.Add(Task.Run(() => ProcessTransactions(taskId)));
                }

                Task.WaitAll(tasks.ToArray());

                Console.WriteLine($"Final account balances:");
                foreach (var account in accounts)
                {
                    Console.WriteLine($"{account.AccountNumber}: ${account.Balance}");
                }
            }

            private static void ProcessTransactions(int taskId)
            {
                for (int i = 0; i < 5; i++)
                {
                    // Race condition - multiple threads accessing shared collection without synchronization
                    var sourceAccount = accounts[0];
                    var targetAccount = accounts[1];

                    decimal transferAmount = 10m;

                    if (sourceAccount.Balance >= transferAmount)
                    {
                        // Unsafe mutation across threads - no synchronization
                        sourceAccount.Balance -= transferAmount;
                        targetAccount.Balance += transferAmount;

                        // Race condition on shared counter
                        transactionCounter++;

                        sourceAccount.LastActivity = DateTime.Now;
                        targetAccount.LastActivity = DateTime.Now;

                        Console.WriteLine($"Task {taskId}: Transfer ${transferAmount} completed. Transaction #{transactionCounter}");
                    }

                    Thread.Sleep(50);
                }
            }

            private static bool ValidateTransaction(string accountNumber, decimal amount)
            {
                string result; // Unassigned variable - static analysis issue

                if (amount <= 0)
                {
                    result = "Invalid amount";
                    return false;
                }

                if (string.IsNullOrEmpty(accountNumber))
                {
                    result = "Invalid account";
                    return false;
                }

                // result variable used without being assigned in all code paths
                Console.WriteLine($"Validation result: {result}");
                return true;
            }

            private static void DeadCodeExample()
            {
                return;
                // Unreachable code - static analysis issue
                Console.WriteLine("This code will never execute");
            }
        }
    }
}
