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
    class Sample_11
    {
        public class PlayerSession
        {
            public string PlayerId { get; set; }
            public DateTime LastActivity { get; set; }
            public int Score { get; set; }
        }

        public class GameSessionManager
        {
            private static Dictionary<string, PlayerSession> activeSessions = new Dictionary<string, PlayerSession>();
            private static readonly object lockObject = new object();

            public static void AddPlayer(string playerId)
            {
                var session = new PlayerSession
                {
                    PlayerId = playerId,
                    LastActivity = DateTime.Now,
                    Score = 0
                };

                // Race condition: Dictionary is not thread-safe for concurrent modifications
                activeSessions[playerId] = session;
            }

            public static void UpdatePlayerScore(string playerId, int newScore)
            {
                lock (lockObject)
                {
                    if (activeSessions.ContainsKey(playerId))
                    {
                        activeSessions[playerId].Score = newScore;
                        activeSessions[playerId].LastActivity = DateTime.Now;
                    }
                }
            }

            public static int GetActivePlayerCount()
            {
                // Potential race condition: Reading collection without synchronization
                return activeSessions.Count;
            }

            public static void CleanupInactiveSessions()
            {
                var cutoffTime = DateTime.Now.AddMinutes(-30);
                var keysToRemove = new List<string>();

                foreach (var kvp in activeSessions)
                {
                    if (kvp.Value.LastActivity < cutoffTime)
                    {
                        keysToRemove.Add(kvp.Key);
                    }
                }

                foreach (var key in keysToRemove)
                {
                    // Race condition: Unsynchronized removal while other threads may be accessing
                    activeSessions.Remove(key);
                }
            }
        }

        public class Program
        {
            public static async Task Main(string[] args)
            {
                // Static analysis issue: unassigned variable
                string serverConfig;
                Console.WriteLine($"Starting server with config: {serverConfig}");

                var tasks = new List<Task>();

                // Simulate concurrent player connections
                for (int i = 0; i < 10; i++)
                {
                    int playerId = i; // Capture variable correctly
                    tasks.Add(Task.Run(() =>
                    {
                        GameSessionManager.AddPlayer($"Player_{playerId}");
                        Thread.Sleep(100);
                        GameSessionManager.UpdatePlayerScore($"Player_{playerId}", playerId * 10);
                    }));
                }

                // Cleanup task running concurrently
                tasks.Add(Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        GameSessionManager.CleanupInactiveSessions();
                        Console.WriteLine($"Active players: {GameSessionManager.GetActivePlayerCount()}");
                    }
                }));

                await Task.WhenAll(tasks.Take(10)); // Only wait for the first 10 tasks, not the infinite cleanup

                Console.WriteLine("Game server simulation completed.");

                // Unreachable code - static analysis issue
                return;
                Console.WriteLine("This will never execute");
            }
        }
    }
}
