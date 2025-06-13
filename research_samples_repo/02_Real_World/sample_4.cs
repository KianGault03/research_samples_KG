// ============================================================================
// Date Retrieved:      2025-06-10
// Source:              Stack Overflow question “Compiler Error CS-1939” (ID 37611241)
// URL:                 https://stackoverflow.com/questions/37611241/compiler-error-cs-1939
// Author:              Sameer Ahmed S and contributors 
// Description:         Demonstrates CS1939 when calling a ref-parameter method within a LINQ query in Main.
// ============================================================================
using System;
using System.Linq;

namespace research_samples_repo.Real_World
{
    class sample_CS1939
    {
        public static string F(ref int i)
        {
            string[] names = { "test", "test2", "test3" };
            return names[i];
        }

        public static void Main(string[] args)
        {
            var list = new int[] { 0, 1, 2, 3, 4, 5 };
            // This causes CS1939: cannot use 'ref' parameter inside query expression
            var q = from x in list
                    let k = x
                    select new TempData
                    {
                        temp = sample_CS1939.F(ref x)
                    };

            foreach (var item in q)
            {
                Console.WriteLine(item.temp);
            }
        }
    }

    public class TempData
    {
        public string temp;
    }
}
