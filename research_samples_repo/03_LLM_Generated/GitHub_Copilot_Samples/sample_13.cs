// ============================================================================
// Date Generated:      2025-06-12
// Model Used:          GitHub Copilot (GPT-4.1)
// Prompt:              "You are an expert C# developer and static-analysis specialist.
//                      Generate exactly one C# source file named `sample_n.cs`..."            
// ============================================================================

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace research_samples_repo.LLM_Generated.GitHub_Copilot_Samples
{
    class sample_13
    {
        

        private static int sharedCounter = 0;
        private static object syncObj = new object();

        public static void Main()
        {
            // Static-analysis-detectable issue: Unassigned variable usage
            string uninitializedString;
            if (DateTime.Now.Ticks % 2 == 0)
            {
                uninitializedString = "Hello";
            }
            // Warning: 'uninitializedString' is used before it has been assigned a value
            Console.WriteLine(uninitializedString);

            // Start multiple tasks that increment a shared counter without proper synchronization
            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    // Potential race condition here: unsynchronized increment
                    for (int j = 0; j < 1000; j++)
                    {
                        sharedCounter++;
                    }
                });
            }

            Task.WaitAll(tasks);

            Console.WriteLine($"Final counter value (should be 10000): {sharedCounter}");

            // Static-analysis-detectable issue: Unreachable code
            return;
            Console.WriteLine("This line is unreachable.");
        }
    }
}