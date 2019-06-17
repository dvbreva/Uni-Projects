using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PipesProblem
{
    class Pipe
    {
        public int Index { get; private set; }

        public double Percent { get; private set; }

        public List<Pipe> Pipes { get; }

        public Pipe(int index, double Percent)
        {
            this.Index = index;
            this.Percent = Percent;
            this.Pipes = new List<Pipe>();
        }

        public void ShowInfo(double water)
        {
            double FinalWater = water * this.Percent;

            if (this.Pipes.Count == 0)
            {
                // so that if you enter 40 and 1 its goint to print out 1 40
                Console.WriteLine($"{this.Index + 1} {FinalWater}");
            }
            else
            {
                foreach (var pipe in this.Pipes)
                {
                    pipe.ShowInfo(FinalWater);
                }
            }
        }
    }
}
