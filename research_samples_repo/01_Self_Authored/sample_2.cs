// Author:              Kian Gault
// Source:              Dissertation Evaluation Sample
// Description:         A simple C# program that checks the length of a string with
//                      intentional syntax errors for evaluation purposes
// ============================================================================
using System;

namespace research_samples_repo.Self_Authored
{
    class sample_2
    {
        static void Main(string[] args)
        {
            string name = null;
            if (name.Length > 0)
            {
                Console.WriteLine("Name has characters.");
            }

            int result = Add(5, 5);
            Console.WriteLine("Result: " + result);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

    }
}
