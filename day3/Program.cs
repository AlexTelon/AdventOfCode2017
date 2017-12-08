using System;

namespace Kattis
{
    class Program
    {
        class Position
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void MoveRight() { X++; }
            public void MoveUp() { Y++; }
            public void MoveLeft() { X--; }
            public void MoveDown() { Y--; }

            public string ToString()
            {
                return "(" + X + ", " + Y + ")";
            }
        }


        class Square
        {
            public Square(int side, int stepsLeft, int maxStepsInSquare)
            {
                this.Side = side;
                this.Steps = stepsLeft;
                this.MaxStepsInSquare = maxStepsInSquare;
            }

            public Square()
            {
                Side = 1;
                Steps = 1;
                MaxStepsInSquare = 0;
            }

            public int Side { get; set; }
            public int Steps { get; set; }
            public int MaxStepsInSquare { get; set; }


            public void Step(Position position)
            {
                //if (StepsLeft == 0) position.MoveRight();

                // we are along the last side 
                //if (Steps <= Side + 1) position.MoveRight(); //last side (bottom one)
                //else if (Steps <= 2 * Side) position.MoveDown(); // left side
                //else if (Steps < 3 * Side) position.MoveLeft(); // top side
                //else position.MoveUp(); // right side

                // move right if we are anywhere along the bottom side
                //if (Steps == 0) position.MoveRight();

                int BOTTOM_SIDE = MaxStepsInSquare - Side;
                int LEFT_SIDE = BOTTOM_SIDE - (Side - 1);
                int TOP_SIDE = LEFT_SIDE - (Side - 1);

                if (Steps >= BOTTOM_SIDE) position.MoveRight();
                else if (Steps >= LEFT_SIDE) position.MoveDown();
                else if (Steps >= TOP_SIDE) position.MoveLeft();
                else position.MoveUp(); // right side

                Steps++;

                if (Steps >= MaxStepsInSquare)
                {
                    Side += 2;
                    Steps = 0;
                    MaxStepsInSquare = Side * Side - (Side - 2) * (Side - 2);
                }

            }

        }

        static void Main(string[] args)
        {
            int side = 1;

            // how many steps there is left in this square
            // When steping out of a square (when its 0, always move one to the right)
            // and increase side by 2
            int stepsLeftInSquare = 1;

            Square square = new Square();

            int counter = 1;

            Position position = new Position(0, 0);

            var finalValue = 277678;
            //finalValue = 24;

            while (counter <= finalValue)
            {
                counter++;
                square.Step(position);
                //Console.Clear();
                //Console.WriteLine(counter);
                //Console.WriteLine(position.ToString());
                //Console.ReadKey();
            }
            Console.WriteLine(position.ToString());
            Console.WriteLine(Math.Abs(position.X) + Math.Abs(position.Y) - 1);
        }
    }
}
