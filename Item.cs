using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem01
{
    public class Item : ICloneable
    {

        public int Profit { get; }
        public int Weight { get; }
        public int index { get; }

        public Item(int index, int Weight, int Profit)
        {
            this.Profit = Profit;
            this.Weight = Weight;
            this.index = index;
        }

        public object Clone()
        {
            return new Item(this.index, this.Weight, this.Profit);
        }
    }
}
