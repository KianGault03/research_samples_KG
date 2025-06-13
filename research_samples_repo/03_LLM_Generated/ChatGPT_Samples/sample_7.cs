// ============================================================================
// Date Generated:      2025-06-10
// Model Used:          ChatGPT (GPT-4o)
// Prompt:              "You are an expert C# developer and static-analysis specialist.
//                      Generate exactly one C# source file named `sample_n.cs`..."            
// ============================================================================


using System;
using System.Collections.Generic;
using System.Threading;
using System.Net; 
using System.IO; 

namespace research_samples_repo.LLM_Generated.ChatGPT_Samples
{

    class sample_7
    {
        // Shared list accessed concurrently without synchronization
        static List<int> sharedBuffer = new List<int>();

        static void Main(string[] args)
        {
            // Static-analysis issue: using uninitialized variable
            int totalItems;
            Console.WriteLine("Total items to process: " + totalItems);

            Thread producerThread = new Thread(() => ProduceItems(1, 50));
            Thread consumerThread = new Thread(() => ConsumeItems());

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();

            Console.WriteLine("Final buffer count: " + sharedBuffer.Count);

            return;

            // Unreachable code - static-analysis-detectable issue
            Console.WriteLine("This line is never reached.");
        }

        static void ProduceItems(int start, int count)
        {
            for (int i = start; i < start + count; i++)
            {
                // Potential race condition here
                sharedBuffer.Add(i);
            }
        }

        static void ConsumeItems()
        {
            // Another concurrency issue
            for (int i = 0; i < 50; i++)
            {
                if (sharedBuffer.Count > 0)
                {
                    // Potential race condition here: 
                    int item = sharedBuffer[0];
                    sharedBuffer.RemoveAt(0);
                    Console.WriteLine("Consumed: " + item);
                }
                Thread.Sleep(10);
            }
        }

        static void AdjustValue(ref int x)
        {
            x += 100;
        }

        static void TestRefMisuse()
        {
            int localValue = 42;
            // Incorrect ref usage - static-analysis-detectable issue (passing without 'ref')
            AdjustValue(localValue);
        }

        static void TypeMismatchExample()
        {
            // Static-analysis-detectable issue: type mismatch assignment
            string text = 12345;
        }

        static void UnusedMethod()
        {
            // Method never used - static-analysis may warn
            Console.WriteLine("I am never called");
        }
    }
}

