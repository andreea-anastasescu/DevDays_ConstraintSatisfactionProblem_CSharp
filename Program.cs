using System;
using System.Text;

namespace ConstraintSatisfactionProblem_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solver solver = new Solver();
            solver.Start();

        }

        internal static void PrintList(int[] list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int t in list)
                sb.Append($"{t} ");

            Console.WriteLine(sb.ToString());
        }
    }
}
