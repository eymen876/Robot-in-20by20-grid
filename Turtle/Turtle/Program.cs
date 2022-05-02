namespace Turtle
{
    class Program
    {
        static void Main(string[]args)
        {
            //test
            Robot r = new Robot();
            r.printGrid();
            r.turnRight_action();
            r.penDown_action();
            r.moveForward(10);
            r.printGrid();
            r.turnLeft_action();
            r.moveForward(5);
            r.printGrid();
            r.turnLeft_action();
            r.penUp_action();
            r.moveForward(5);
            r.printGrid();
        }
    }
    class Robot
    {
        bool faceRight;
        bool faceLeft;
        bool faceUp;
        bool faceDown;
        bool penUp;
        bool penDown;
        int x;
        int y;
        int[,] grid;
        public Robot()
        {
            grid = new int[20, 20];
            Array.Clear(grid, 0, grid.Length);
            faceRight = true;
            faceLeft = false;
            faceUp = false;
            faceDown = false;
            penUp = true;
            penDown = false;
            x = 0;
            y = 0;
        }
        public void printGrid()
        {
            for(int i=0; i<grid.GetLength(0);i++)
            {
                for (int k = 0; k < grid.GetLength(1); k++)
                {
                    if(i==y&&k==x)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write(grid[i, k] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void penUp_action()
        {
            penDown = false;
            penUp = true;
            Console.WriteLine("Pen is up");
        }
        public void penDown_action()
        {
            penUp = false;
            penDown = true;
            Console.WriteLine("Pen is down");
        }
        public void turnRight_action()
        {
            if(faceRight)
            {
                faceRight = false;
                faceDown = true;
                Console.WriteLine("Face is down");
            }
            else if(faceDown)
            {
                faceDown = false;
                faceLeft = true;
                Console.WriteLine("Face is left");
            }
            else if(faceLeft)
            {
                faceLeft = false;
                faceUp = true;
                Console.WriteLine("Face is up");
            }
            else if (faceUp)
            {
                faceUp = false;
                faceRight = true;
                Console.WriteLine("Face is right");
            }
        }
        public void turnLeft_action()
        {
            if (faceRight)
            {
                faceRight = false;
                faceUp = true;
                Console.WriteLine("Face is up");
            }
            else if (faceUp)
            {
                faceUp = false;
                faceLeft = true;
                Console.WriteLine("Face is left");
            }
            else if (faceLeft)
            {
                faceLeft = false;
                faceDown = true;
                Console.WriteLine("Face is down");
            }
            else if (faceDown)
            {
                faceDown = false;
                faceRight = true;
                Console.WriteLine("Face is right");
            }
        }
        public void moveForward(int steps)
        {
            int xnext;
            int ynext;
            if(faceDown)
            {
                ynext = steps + y;
                if(ynext>19)
                {
                    Console.WriteLine("Out of grid , moved to point 19 on Y coordinate");
                    ynext = 19;
                }
                if(penDown)
                {
                    for(int i = y; i <= ynext; i++)
                    {
                        grid[i,x]=1;
                    }
                }
                y = ynext;
            }
            else if(faceUp)
            {
                ynext = y-steps;
                if(ynext<0)
                {
                    Console.WriteLine("Out of grid, moved to point 0 on Y coordinate");
                    ynext = 0;
                }
                if (penDown)
                {
                    for(int i = y; i >= ynext; i--)
                    {
                        grid[i, x] = 1;
                    }
                }
                y = ynext;
            }
            else if (faceRight)
            {
                xnext = x + steps;
                if(xnext>19)
                {
                    Console.WriteLine("Out of grid, moved to point 19 on X coordinate");
                    xnext = 19;
                }
                if (penDown)
                {
                    for(int i = x; i <= xnext; i++)
                    {
                        grid[y, i] = 1;
                    }
                }
                x = xnext;
            }
            else if(faceLeft)
            {
                xnext = x - steps;
                if(xnext<0)
                {
                    Console.WriteLine("Out of grid, moved to point 0 on X coordinate");
                    xnext = 0;
                }
                if (penDown)
                {
                    for(int i=x;i>=xnext;i--)
                    {
                        grid[y, i] = 1;
                    }
                }
                x = xnext;
            }
        }
    }













}