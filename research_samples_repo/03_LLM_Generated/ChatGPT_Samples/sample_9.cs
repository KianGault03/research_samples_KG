// ============================================================================
// Date Generated:      2025-06-10
// Model Used:          ChatGPT (GPT-4o)
// Prompt:              "You are an expert C# developer and static-analysis specialist.
//                      Generate exactly one C# source file named `sample_n.cs`..."            
// ============================================================================

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml; 

namespace research_samples_repo.LLM_Generated.ChatGPT_Samples
{
    class sample_9
    {
        private static Dictionary<string, int> sensorCounts = new Dictionary<string, int>();

        public static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            // Start multiple tasks to simulate sensor input
            for (int i = 0; i < 5; i++)
            {
                int sensorId = i;
                tasks.Add(Task.Run(() => ProcessSensor($"Sensor_{sensorId}")));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Processing complete.");
        }

        // Potential race condition here: unsynchronized access to shared dictionary
        private static void ProcessSensor(string sensorName)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (!sensorCounts.ContainsKey(sensorName))
                {
                    sensorCounts[sensorName] = 0; // Write without lock
                }

                sensorCounts[sensorName]++; // Increment without thread safety
            }
        }

        // Static-analysis-detectable issue: unreachable code after return
        public static int FaultyComputation(int x)
        {
            return x * 2;
            Console.WriteLine("This will never be reached."); // Unreachable code
        }
    }
}
