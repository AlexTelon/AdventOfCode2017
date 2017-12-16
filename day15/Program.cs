using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattis
{
    class Program
    {
        public class Generator
        {
            public long Previous { get; set; }
            public long Factor { get; set; }
            public long Divider { get; set; } = 2147483647;

            public long Next()
            {
                long tmp = (Previous * Factor);
                Previous = (tmp % Divider); // overwrite old prev with the next one
                return Previous;
            }
        }


        static void Main(string[] args)
        {

            var initA = 277;
            var factorA = 16807;

            var initB = 349;
            var factorB = 48271;

            Generator A = new Generator() { Previous = initA, Factor = factorA };
            Generator B = new Generator() { Previous = initB, Factor = factorB };

            var sum = 0;
            for (int i = 0; i < 40000000; i++)
            {
                var a = ToBinary(A.Next());
                var b = ToBinary(B.Next());

                //Console.WriteLine("A: " + a + " B: " + b);
                if (Hit(a, b)) sum++;
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }

        private static bool Hit(string a, string b)
        {
            // strings are at least 16 long!
            var shortA = a.Substring(a.Length - 16);
            var shortB = b.Substring(b.Length - 16);
            return shortA == shortB;
        }

        private static string ToBinary(long num)
        {
            string binary = Convert.ToString(num, 2);

            // check if string is shorter than 16 bits
            var missing = 16 - binary.Length;
            if (missing > 0)
            {
                binary = binary.Insert(0, new string('0', missing));
            }
            Debug.Assert(binary.Length >= 16);
            return binary;
        }
    }

}
