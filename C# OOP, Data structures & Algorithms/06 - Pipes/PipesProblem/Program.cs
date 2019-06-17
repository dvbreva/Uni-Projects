using System;
using System.Collections.Generic;
using System.Linq;

namespace PipesProblem
{
    class Program
    {
        private static void ValidateDataInput(Dictionary<int, Pipe> pipesDictionary, int[] pipeData, int i)
        {
            int pipeIndex = pipeData[0] - 1;

            int leftBranchIndex = pipeData[1] - 1;

            double leftBranchPercent = pipeData[2];

            int rightBranchIndex = pipeData[3] - 1;

            double rightBranchPercent = pipeData[4]; 

            
            // if percentages or pipes are somehow now okay an exception is displayed 
            bool percentCheck = leftBranchPercent + rightBranchPercent != 100;

            bool branchesCheck = rightBranchIndex - leftBranchIndex != 1 || leftBranchIndex / 2 != pipeIndex;

            if (percentCheck || branchesCheck)
            {
                Console.WriteLine("\nYou have entered either two percentage values that summed together do not equal 100% exactly \nor you have entered your branch indexes incorrectly.");
                throw new Exception();
            }
        }

        static void Main(string[] args)
        {
            Dictionary<int, Pipe> PipesDictionary = new Dictionary<int, Pipe>();

            double EntryPipeDebit;
            int TotalPipeAmount = 0;
            int PipeRows;

            while (true)
            {
                Console.Write("Enter the debit of the first pipe: ");
                if (double.TryParse(Console.ReadLine(), out EntryPipeDebit))
                {
                    break;
                }
            }

            PipesDictionary[0] = new Pipe(0, 1);
            while (true)
            {
                Console.Write("Enter the total number of pipes: ");
                // until you enter an odd number otherwise whole logic breaks
                if (int.TryParse(Console.ReadLine(), out TotalPipeAmount) && TotalPipeAmount % 2 != 0) 
                    break;
            }

            PipeRows = (int)(TotalPipeAmount / 2);
            for (int i = 0; i < PipeRows; i++)
            {
                while (true)
                {
                    Console.WriteLine("Enter as it follows:");
                    Console.WriteLine("<number/row of the pipe> <number of left branch> <% for left branch> <number of right branch> <% for right branch>\nall separated by space for pipe {0}:", i + 1);
                    int[] PipeData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                    ValidateDataInput(PipesDictionary, PipeData, i);

                    int PipeIndex = PipeData[0] - 1;

                    int LeftBranchIndex = PipeData[1] - 1;
                    int RightBranchIndex = PipeData[3] - 1;

                    double LeftBranchPercent = PipeData[2] / 100d;
                    double RightBranchPercent = PipeData[4] / 100d;

                    PipesDictionary[LeftBranchIndex] = new Pipe(LeftBranchIndex, LeftBranchPercent);
                    PipesDictionary[RightBranchIndex] = new Pipe(RightBranchIndex, RightBranchPercent);

                    PipesDictionary[PipeIndex].Pipes.AddRange(new Pipe[] { PipesDictionary[LeftBranchIndex], PipesDictionary[RightBranchIndex] });
                    break;
                }
            }
            Console.WriteLine();
            PipesDictionary[0].ShowInfo(EntryPipeDebit);
        }   
    }
}
