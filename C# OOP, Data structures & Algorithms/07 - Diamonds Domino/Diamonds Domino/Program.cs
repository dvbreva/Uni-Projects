using System;

namespace Diamonds_Domino
{
    class Program
    {
        static void Main(string[] args)
        {
            long diamonds = 0;
            long block = 0;

            Console.Write("Please enter n=");
            int n = int.Parse(Console.ReadLine());

            if (n < 1 || n > 1000)
            {
                Console.WriteLine("Wrong input. You need to enter n in the range of: 1<n<1000");
            }
            else
            {
                Console.WriteLine("Correct input");

                block = (n + 1) * (n + 2) / 2;
                diamonds = n * block;

                Console.WriteLine("Diamonds={0}", diamonds);
            }

            // output when entered n=1 diamonds=3 
            // n =2 diamonds=18
            // n=3 diamonds=30
            // n=4 diamonds=60 
        }
    }
}
