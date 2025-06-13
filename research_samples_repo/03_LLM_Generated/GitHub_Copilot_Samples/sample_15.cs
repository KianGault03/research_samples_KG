// ============================================================================
// Date Generated:      2025-06-12
// Model Used:          GitHub Copilot (GPT-4.1)
// Prompt:              "You are an expert C# developer and static-analysis specialist.
//                      Generate exactly one C# source file named `sample_n.cs`..."            
// ============================================================================
using System;
using System.Threading;
using System.Collections.Generic;

namespace research_samples_repo.LLM_Generated.GitHub_Copilot_Samples
{
    class sample_15
    {
        
        private Dictionary<string, int> _sensorCounts = new Dictionary<string, int>();

        // Static-analysis-detectable issue: Unassigned variable 'average'
        public double CalculateAverage(string sensor)
        {
            double sum = 0;
            int count = 0;
            double average;
            if (_sensorCounts.TryGetValue(sensor, out count))
            {
                sum = count * 10.0;
            }
            // 'average' is used before being definitely assigned
            return average;
        }

        // Potential race condition here: unsynchronized access to _sensorCounts
        public void IncrementSensor(string sensor)
        {
            if (!_sensorCounts.ContainsKey(sensor))
            {
                _sensorCounts[sensor] = 0;
            }
            _sensorCounts[sensor]++;
        }

        public void SimulateConcurrentUpdates()
        {
            var threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        IncrementSensor("TempSensor");
                    }
                });
                threads[i].Start();
            }
            foreach (var t in threads)
            {
                t.Join();
            }
        }
    }
}
