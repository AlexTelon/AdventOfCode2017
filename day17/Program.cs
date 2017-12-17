using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattis
{
    class Program
    {

        class Board
        {
            public List<int> Data { get; set; } = new List<int>();
            public int Step { get; set; }
            public int Pos { get; set; } = 0;
            private int counter = 0;

            public void Next()
            {
                Pos = (Pos + Step) % Data.Count();
                Data.Insert(Pos + 1, ++counter);
                //Pos = (Pos + 1) % Data.Count();
                Pos++;
            }
        }

        static void Main(string[] args)
        {

            var input = 3;
            input = 369;
            Board board = new Board() { Step = input };
            board.Data.Add(0);

            for (int i = 0; i < 2017; i++)
            {
                board.Next();
                //Console.WriteLine(string.Join(" ", board.Data));
            }

            Console.WriteLine(string.Join(" ", board.Data));
            Console.WriteLine(board.Pos);
            Console.WriteLine(board.Data[board.Pos]);
            Console.WriteLine(board.Data[board.Pos+1]);

        }
    }
}
