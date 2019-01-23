using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem01
{
    public class Bag
    {   
        public List<Item> ItemsList { get; set; }  // Items within this bag
        public int WeightCapacity { get; set; } //Max possible weight of the bag
        public int CurrentWeight { get; set; } //Current weight of the Bag
        public int TotalProfit { get; set; }    //Acts as the fitness of the unit

        public Bag(int weightCapacity)
        {
            ItemsList = new List<Item>();
            this.WeightCapacity = weightCapacity;
        }

        /// <summary>
        /// adds item to the bag list
        /// Sets the weight and totalprofit automaticlly
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool addItem(Item item)
        {
            if (CurrentWeight + item.Weight > WeightCapacity)
            {
                return false;
            }
            if(ItemsList.Contains(item))
            {
                return false;
            }

            ItemsList.Add(item);
            calculateParams();
            return true;
        }
        
        /// <summary>
        /// Calculates current total profit and current weight
        /// </summary>
        public void calculateParams()
        {
            this.CurrentWeight = 0;
            this.TotalProfit = 0;
            ItemsList.ForEach((item) => { this.CurrentWeight += item.Weight; this.TotalProfit += item.Profit; });
        }

        /*
        public bool addItems(List<Item> items)
        {
            foreach (Item i in items)
            {
                if (!addItem(i))
                {
                    return false;
                }
            }
            return true;
        }
        */


    }
}
