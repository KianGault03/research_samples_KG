// ============================================================================
// Date Generated:      2025-06-10
// Model Used:          ChatGPT (GPT-4o)
// Prompt:              "You are an expert C# developer and static-analysis specialist.
//                      Generate exactly one C# source file named `sample_n.cs`..."            
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Net; 

namespace research_samples_repo.LLM_Generated.ChatGPT_Samples
{
    class sample_8
    {
        private List<string> filePaths = new List<string>();
        private volatile bool stopFlag = false;

        public void StartProcessing()
        {
            Thread scanner1 = new Thread(() => ScanDirectory("/path/dirA"));
            Thread scanner2 = new Thread(() => ScanDirectory("/path/dirB"));
            scanner1.Start();
            scanner2.Start();
            Thread.Sleep(500);
            stopFlag = true;
            scanner1.Join();
            scanner2.Join();
            TransformFiles();
        }

        private void ScanDirectory(string path)
        {
            int dummyCounter = 0; // unused local variable -> warning
            while (!stopFlag)
            {
                string fileName = $"file_{DateTime.Now.Ticks}.txt";
                filePaths.Add(fileName); // Potential race condition: unsynchronized access to shared list
                Thread.Sleep(50);
                return; // unreachable code below -> warning
                Console.WriteLine("This will never execute"); // unreachable code
            }
        }

        private void TransformFiles()
        {
            if (filePaths == null)
            {
                Console.WriteLine("No files to transform"); // dead code: filePaths never null
            }
            int processedCount; // declared but never used -> warning
            foreach (var file in filePaths)
            {
                // Simulate transformation
                Console.WriteLine($"Transforming {file}");
            }
        }

        static void Main(string[] args)
        {
            var transformer = new sample_8();
            transformer.StartProcessing();

            // Demonstrate a static-analysis-detectable issue: out parameter not assigned on all code paths
            string config;
            bool ok = transformer.TryLoadConfig(out config);
            Console.WriteLine($"Config loaded: {ok}, config: {config}");
        }

        // Potential static-analysis error: out parameter 'configPath' not assigned on all paths -> compile-time error
        private bool TryLoadConfig(out string configPath)
        {
            if (DateTime.Now.Ticks % 2 == 0)
            {
                // Forgot to assign configPath here
                return true;
            }
            configPath = "default.cfg";
            return false;
        }
    }
}

