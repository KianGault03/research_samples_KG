// ============================================================================
// Date Generated:      2025-06-12
// Model Used:          GitHub Copilot (GPT-4.1)
// Prompt:              "You are an expert C# developer and static-analysis specialist.
//                      Generate exactly one C# source file named `sample_n.cs`..."            
// ============================================================================

using System;
using System.Collections.Generic;
using System.Threading;

namespace research_samples_repo.LLM_Generated.GitHub_Copilot_Samples
{
    internal class sample_14
    {
        

        // Static-analysis-detectable issue: Unassigned variable 'result' used
        public int CalculateSum(int[] numbers)
        {
            int result;
            if (numbers == null)
                return -1;
            if (numbers.Length > 0)
                result = numbers[0];
            // 'result' might be unassigned here if numbers.Length == 0
            return result;
        }

        // Concurrency issue: Unsynchronized access to shared dictionary
        private static Dictionary<int, string> sharedData = new();

        // Potential race condition here: Multiple threads may mutate sharedData without synchronization
        public static void AddOrUpdate(int key, string value)
        {
            if (sharedData.ContainsKey(key))
            {
                sharedData[key] = value;
            }
            else
            {
                sharedData.Add(key, value);
            }
        }

        public static void SimulateConcurrentAccess()
        {
            var threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                int localKey = i;
                threads.Add(new Thread(() => AddOrUpdate(localKey, $"Value_{localKey}")));
            }
            foreach (var t in threads)
                t.Start();
            foreach (var t in threads)
                t.Join();
        }

        // Unreachable code (static-analysis-detectable)
        public void DoNothing()
        {
            return;
            Console.WriteLine("This will never be printed.");
        }
    }
}