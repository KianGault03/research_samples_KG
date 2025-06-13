// ============================================================================
// Date Retrieved:      2025-06-10
// Source:              Stack Overflow question "Roslyn failed to compile code"
// URL:                 https://stackoverflow.com/questions/31961411/roslyn-failed-to-compile-code
// Author:              ramil89, with key insights from Ian Boyd (CC BY-SA 4.0)
// Description:         A C# snippet using LINQ and dynamic types causes Roslyn to incorrectly report a CS0165
//                      error, claiming variable 'b' is unassigned. The issue lies in how the compiler reasons
//                      about short-circuiting and variable assignment. Workarounds are suggested, including
//                      changing the type, adding parentheses, or explicitly assigning 'b'.
// ============================================================================

using System;
using System.Threading;
using System.Threading.Tasks;

namespace research_samples_repo.Real_World
{
    public class sample_6
    {
        static void Main(string[] args)
        {
            decimal a, b;
            IEnumerable<dynamic> array = new string[] { "10", "20", "30" };
            var result = (from v in array
                          where decimal.TryParse(v, out a) && decimal.TryParse("15", out b) && a <= b // Error here
                          orderby decimal.Parse(v)
                          select v).ToArray();
        }

    }
}
