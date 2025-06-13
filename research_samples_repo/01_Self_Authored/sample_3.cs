// Author:              Kian Gault
// Source:              Dissertation Evaluation Sample
// Description:         A program created that contains no compiler errors or 
//                      warnings, but has a potential thread safety issues. 
// ============================================================================
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace research_samples_repo.Self_Authored
{
    public class sample_3
    {
        static List<int> sharedList = new List<int>();

        public static void Main(string[] args)
        {
           
            Task t1 = Task.Run(() => AddItems());
            Task t2 = Task.Run(() => AddItems());

            Task.WaitAll(t1, t2);

            Console.WriteLine("Done adding items. Total count: " + sharedList.Count);
            
        }
        static void AddItems()
        {
            for (int i = 0; i < 1000; i++)
            {
                sharedList.Add(i);
            }
        }
    }
}
