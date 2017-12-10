using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "76,1,88,148,166,217,130,0,128,254,16,2,130,71,255,229";
            //input = "3, 4, 1, 5";

            var size = 256;
            //size = 5;

            var skipsize = 0;

            // our 255 list with 0,1,2,3,4,5,6.. written to it
            var hashList = new List<int>() { };

            for (int i = 0; i < size; i++)
            {
                hashList.Add(i);
            }


            List<int> lenghts = input.Split(',').Select(int.Parse).ToList();

            var index = 0;
            
            foreach (var len in lenghts)
            {
                var subList = new List<int>();

                // Are we trying to do stuff out of bounds? Then we need to wrap around
                if (index + len > hashList.Count())
                {
                    // first get all on this side
                    subList = hashList.GetRange(index, hashList.Count() - index);

                    // then add the missing ones from the start
                    subList.AddRange(hashList.GetRange(0, len - (hashList.Count() - index)));

                } else
                {
                    subList = hashList.GetRange(index, len);
                }

                subList.Reverse();

                for (int i = 0; i < subList.Count(); i++)
                {
                    var hashI = (index + i) % hashList.Count();
                    hashList[hashI] = subList[i];
                }

                Console.WriteLine(len);

                PrintList(hashList);

                index += (len + skipsize);
                index %= hashList.Count();
                skipsize++;
            }

            Console.WriteLine("-- derp --");
            Console.WriteLine(hashList[0] * hashList[1]); // 161 is too low, 3288 is too low, 29240 is right

        }

        private static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
