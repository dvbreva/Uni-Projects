using System;

namespace PrisonBreak
{
    class Program
    {
        public static int[,] board;
        public static int BOARD_SIZE;
        public static int newX, newY;
        public static int[] exitX = new int[] { 1, -1, 0, 0 };
        public static int[] exitY = new int[] { 0, 0, 1, -1 }; 
         // down = row+1,column 0
         // right = row 0,column+1
         // up = row-1,column 0
         // left = row 0,column-1
  
        // a method that looks for exit from the labirinth
        public static bool FindExit(int x,int y)
        {

            if (x < 0 || y < 0 || x > BOARD_SIZE -1 || y> BOARD_SIZE-1)
            {
                return true;
            }

            if (board[x, y] == TileTypes.EMPTY)
            {
                board[x, y] = TileTypes.AlreadyVISITED;
            }

            for(int i = 0; i < exitX.Length; i++)
            {
                newX = x + exitX[i];
                newY = y + exitY[i];

                if(newX<0 || newY <0||newX>BOARD_SIZE-1|| newY>BOARD_SIZE-1|| board[newX, newY] == TileTypes.EMPTY || board[newX, newY] == TileTypes.DOOR)
                {
                    bool flag = FindExit(newX, newY);
                    if (flag)
                    {
                        return true;
                    }
                }

                board[x, y] = 0;
                return false;
            }
            return false;
        }

        
        public static void AlreadySolvedBoard()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j] == TileTypes.AlreadyVISITED)
                    {
                        board[i, j] = TileTypes.EMPTY;
                    }
                }
            }
        }


        public static int BlockingDoors(int x, int y)
        {
            int doors = 0;

            for(int i=0; i < BOARD_SIZE; i++)
            {
                for(int j=0;j<BOARD_SIZE;j++)
                {
                    AlreadySolvedBoard();

                    if(board[i,j]==TileTypes.DOOR)
                    {
                        board[i, j] = TileTypes.WALL;

                        if(!FindExit(x,y))
                        {
                            doors++;
                        }
                        board[i, j] = TileTypes.DOOR;
                    }
                }
            }
            return doors;
        }


        // method to print the already solved labirinth
        public static void PrintSolvedBoard()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            // Get random board
            Console.WriteLine("Unsolved labirinth: ");
            do
            {
                Random rnd = new Random();
                BOARD_SIZE = rnd.Next(5, 21);
            }
            while (BOARD_SIZE < 5 && BOARD_SIZE > 20);
            board = PrisonBreakTools.getNewMaze(BOARD_SIZE);
            PrintSolvedBoard();

            // Get random staring point
            Random rand = new Random();
            int startX, startY;
            do
            {
                 startX = rand.Next(0, BOARD_SIZE);
                 startY = rand.Next(0, BOARD_SIZE);
            }
            while (board[startX, startY] != TileTypes.EMPTY || startX == 0 || startY == 0 || startX == BOARD_SIZE-1 || startY == BOARD_SIZE-1);

            Console.WriteLine("Start: {0} {1}", startX, startY);
            Console.Write("\n");

            //print results
            if (FindExit(startX, startY))
            { 
                Console.WriteLine("This is the solved labirinth. Path found: ");
                PrintSolvedBoard();
                Console.WriteLine("Exit: {0} {1}", newX, newY);
                if (BlockingDoors(startX, startY) == 0)
                {
                    Console.WriteLine("No blocking doors!");
                }
            }
            else
            {
                Console.WriteLine("No path found!");
            }
            Console.ReadKey();
        }
    }
}
