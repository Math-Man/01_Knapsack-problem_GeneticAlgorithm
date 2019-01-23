using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem01
{

    /*!RULES!*/ 
    /* 1.First generation is created randomly with a algorithm which maximizes diversity by not picking the same item twice.                        */
    /* 2.Selection is done with weighted random algorithm, if a bag has a higher totalProfit, higher the chance for it to be picked.                */
    /* 3.CrossOver uses a que system. shuffles the items of both parents and start picking items for the child starting from the first index.       */
    /* 4.CrossOver prevents the same child from having multiple of the same items.                                                                  */
    /* 5.Mutation is done in two ways: randomly removing an item and adding it to the pool of available items and randomly adding an item from pool */
    /* 6.After Mutation new children replaces the current generation and this process repeats.                                                      */
    /* 7.Algorithm has no real stop parameter as it can be manipulated through UI, algorithm iterates for the given amount of times                 */




    /// <summary>
    /// Genetic algorithm built around optimizing the maximum total profit of a bag
    /// Uses Fitness-Propotional random selection for selecting breeding pairs
    /// Uses all-random for cross over 
    /// Uses pooling for mutation if not applicable uses random removing
    /// </summary>
    public class GeneticAlgorithm
    {
        List<Item> ItemsDictionary = new List<Item>();
        List<Bag> currentGeneration = new List<Bag>();
        List<Bag> nextGeneration = new List<Bag>();

        List<Bag> bestBags = new List<Bag>();

        public int CurrentIterationNumber { get; set; }
        public string GenerationalLog { get; set; } //Record this generations data and puts it in a readable string (record mutations, crossovers avarage etc...)
        private int GlobalBagCapacity { get; set; }


        //Parameters
        public int PopulationSize { get; set; }
        /// <summary>
        /// Numerical value between 0 and 1, depicts the chance of mutation for an individual bag
        /// </summary>
        public double MutationRate { get; set; }
        /// <summary>
        /// Numerical value between 0 and 1, describes how many times a single bag can mutate, mutation chance is multiplied by this number after every succesful mutation
        /// </summary>
        public double MutationStrength { get; set; }
        /// <summary>
        /// Used for initial generation, determines how many tries each initial bag gets at selecting items randomly
        /// </summary>
        public int[] InitialSelectionChances = new int[2];


        
        //Calculates a semi-optimal population size automaticly
        public GeneticAlgorithm(string fileName, double MutationRate, double MutationStrength, int initRangeLow, int initRangeHigh)
        {
            this.MutationRate = MutationRate;
            this.MutationStrength = MutationStrength;
            this.InitialSelectionChances[0] = initRangeLow;
            this.InitialSelectionChances[1] = initRangeHigh;

            setupInstance(fileName);

            //Pop size is calculated by totalweight/bag capacity
            double totalWeight = 0;
            foreach (Item i in ItemsDictionary)
            {
                totalWeight += i.Weight;
            }
            this.PopulationSize = ((int)Math.Ceiling(totalWeight / (2*GlobalBagCapacity)));


            setupInitialPopulation(InitialSelectionChances[0], InitialSelectionChances[1]); //Create the first generation
        }


        public GeneticAlgorithm(string fileName, int PopulationSize_Override, double MutationRate, double MutationStrength, int initRangeLow, int initRangeHigh)
        {
            this.MutationRate = MutationRate;
            this.MutationStrength = MutationStrength;
            this.InitialSelectionChances[0] = initRangeLow;
            this.InitialSelectionChances[1] = initRangeHigh;

            setupInstance(fileName);

            PopulationSize = PopulationSize_Override; //Override the population size instead of computing it

            setupInitialPopulation(InitialSelectionChances[0], InitialSelectionChances[1]); //Create the first generation

            
        }

        public Bag getBestInCurrentGeneration()
        {
            int bestProfit = int.MinValue;
            Bag bestBag = null;
            foreach (Bag b in currentGeneration)
            {
                if (b.TotalProfit > bestProfit) { bestProfit = b.TotalProfit; bestBag = b; }
            }

            return bestBag; 
        }

        public Bag getBestBagEver()
        {
            int bestProfit = int.MinValue;
            Bag bestBag = null;
            foreach (Bag b in bestBags)
            {
                if (b.TotalProfit > bestProfit) { bestProfit = b.TotalProfit; bestBag = b; }
            }

            return bestBag;
        }

        public double getAvarageProfitForCurrentGeneration()
        {
            double sum = 0;
            foreach (Bag b in currentGeneration) { sum += b.TotalProfit; }
            return sum / currentGeneration.Count;
        }

        public string bagItemsToString(Bag bag)
        {
            string outs = "";
            foreach (Item item in bag.ItemsList)
            {
                outs += "("+item.Profit +","+ item.Weight+") , ";
            }
            return outs;
        }

        /// <summary>
        /// Reads the data from the comma seperated instance files, writes data to ItemsDictionary
        /// </summary>
        /// <param name="fileName"></param>
        private void setupInstance(string fileName)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(fileName);

            int indexCounter = 0;
            string line = reader.ReadLine();
            GlobalBagCapacity = int.Parse(line);

            line = reader.ReadLine();
            while (line != null)
            {
                string[] words = line.Split(',');   //Split words by the coma
                Item item = new Item(indexCounter, int.Parse(words[1]), int.Parse(words[0])); // Weight first then profit in the constructor for item object
                ItemsDictionary.Add(item);

                line = reader.ReadLine();
                indexCounter++;
            }   
        }


        //Randomly creates a population of bags with random properties
        private void setupInitialPopulation(int minTries, int maxTries)
        {
            GenerationalLog += "Initial Population is being setup...";
            Random rnd = new Random();
            List<Item> availableItems = new List<Item>();   //Items are removed from this temporary list once they are added to a bag
            ItemsDictionary.ForEach((item) => { availableItems.Add((Item)item.Clone()); }); //Copies the ItemsDictionary to the aviable items list
            
            for (int i = 0; i < PopulationSize; i++)
            {
                //Give this bag a random number of tries before item search is stopped
                int tryCount = rnd.Next(minTries, maxTries);
                Bag b = new Bag(GlobalBagCapacity);
                //start adding items
                while (tryCount > 0 && availableItems.Count > 0)
                {
                    int randomItemIndex = rnd.Next(0, availableItems.Count);
                    if (b.addItem(availableItems[randomItemIndex]))//If item is added succsefully, remove the same item from availbles list
                    {
                        availableItems.RemoveAt(randomItemIndex);
                    }
                    else { tryCount--; }
                }

                if (availableItems.Count == 0)//No more items left, override the pop count
                {
                    PopulationSize = i;
                }

                //Add the bag to the list
                //Console.WriteLine(b.CurrentWeight + " " + b.ItemsList.Count);
                currentGeneration.Add(b);
            }

            bestBags.Add(getBestInCurrentGeneration());//Add the best initial bag to the list
            GenerationalLog += "\nInitial Population avarage profit per bag: " + getAvarageProfitForCurrentGeneration();
        }

    
        /// <summary>
        /// Builds the next generation and sets it to the global variable: nextGeneration
        /// Calls crossOver and Mutation functions 
        /// </summary>
        public void buildNextGeneration()
        {
            GenerationalLog = "\n\nITERATION #"+CurrentIterationNumber;

            GenerationalLog += "\nNext generation Pairing start:\n";
            Random rnd = new Random();
            Console.WriteLine("Begin pairing...");
            

            //Select pairs for crossover
            List<Tuple<Bag, Bag>> PairsList = new List<Tuple<Bag, Bag>>(); //Cross Over pairs stored in tuple list

            //printLikelyHoodOfSelection();
            GenerationalLog += "\nLikely hood of each bag being picked for selection: " + printLikelyHoodOfSelection() + "\n";

            
            for (int i = 0; i < PopulationSize; i++)
            {
                List<Bag> tempSelectionsList = new List<Bag>(currentGeneration);
                Bag parent1 = WeightedRandomSelect(tempSelectionsList, rnd);
                tempSelectionsList.Remove(parent1); //Make sure same parent is not picked twice
                Bag parent2 = WeightedRandomSelect(tempSelectionsList, rnd);

                PairsList.Add(new Tuple<Bag, Bag>(parent1, parent2));
                //Console.WriteLine("Pair: " + parent1.TotalProfit + " AND " + parent2.TotalProfit);
                GenerationalLog += "\nPair#"+(i+1)+": 1st parent (profit,weight): (" + parent1.TotalProfit+" , " + parent1.CurrentWeight + ")\t 2nd parent (profit,weight): (" + parent2.TotalProfit + " , "+ parent2.CurrentWeight+")";
            }
            Console.WriteLine("Pairing Completed...\n Starting CrossOver...");
            GenerationalLog += "\nPairing Completed...\n";
            

            //Cross Over begins here
            foreach (Tuple<Bag, Bag> pair in PairsList)
            {
                Bag child = crossOver(pair.Item1, pair.Item2, rnd);
                nextGeneration.Add(child);  //TODO: Problem with crossover, child bags picking multiple of the same item?
            }

            Console.WriteLine("CrossOver completed...\nMutating...");
            GenerationalLog += "\nCrossOver Completed...\n";
            
            
            //Make a list of available items which are not used by any member of the nextGeneration
            List<Item> availableItems = new List<Item>();

            //Merge all used items into one list 
            List<Item> allUsedItems = new List<Item>();
            foreach (Bag nbag in nextGeneration) { allUsedItems.AddRange(nbag.ItemsList); }
            allUsedItems = allUsedItems.GroupBy(x => x.index).Select(g => g.First()).ToList();  //Due to cloning objects cant be measured by using "equals" therefore index distinction is used
            foreach (Item item in ItemsDictionary)
            {
                //Scans through allusedItems and itemsdictionary
                bool found = false;
                foreach (Item usedItem in allUsedItems)
                {
                    if (item.Weight.Equals(usedItem.Weight) && item.Profit.Equals(usedItem.Profit)) { found = true;  break; }
                }
                if (!found)
                {
                    availableItems.Add(item);
                }
            }

            Console.WriteLine("Used items: " + allUsedItems.Count + " Availble items: " + availableItems.Count);
            GenerationalLog += "\nStarting mutations...\n";

            //Finally do the mutation on the availbable items list
            foreach (Bag child in nextGeneration)
            {
                Console.WriteLine("\nBefore Mutation: WEIGHT: " + child.CurrentWeight + " GROFIT: " + child.TotalProfit);
                Mutation(child, availableItems, rnd);
                Console.WriteLine("After Mutation: WEIGHT: " + child.CurrentWeight + " GROFIT: " + child.TotalProfit);
            }
            Console.WriteLine("\nMutation complete! New generation is ready!");
        }


        /// <summary>
        /// Replace current generation with the next generation
        /// </summary>
        public void proceedToNextGeneration()
        {
            Console.WriteLine("Replacing current generation...");
            
            bestBags.Add(getBestInCurrentGeneration());
            var best = getBestInCurrentGeneration();

            GenerationalLog += "\n\nGeneration processed succesfully! Best bag of this generation " + best.TotalProfit + "\nAvarage profit per bag in this generation: " + getAvarageProfitForCurrentGeneration();
            GenerationalLog += "\nBest Bag items are: " + bagItemsToString(best);
            GenerationalLog += "\nBest bag ever items: " + bagItemsToString(getBestBagEver());

            currentGeneration = nextGeneration;
            nextGeneration = new List<Bag>();
            CurrentIterationNumber++;
        }

        

        /// <summary>
        /// Debug function, prints all likely hoods of selection to console, used for reporting
        /// </summary>
        public string printLikelyHoodOfSelection()
        {
            string outs = "";
            int sumOfWTotalProfits = 0; 
            foreach (Bag b in currentGeneration)
            {
                sumOfWTotalProfits += b.TotalProfit;
            }
            foreach (Bag b in currentGeneration)
            {
                double chance = (( ((double)(b.TotalProfit)) / ((double)(sumOfWTotalProfits)))) * 100;
                Console.WriteLine("Bag with profit of: " + b.TotalProfit + " CHANCE OF SELECTION:\t %" + chance);
                outs += "\nChance of selection" + " :\t %" + chance + "\tfor a bag with profit of: \t" + b.TotalProfit;
            }

            return outs;
        }


        private Bag WeightedRandomSelect(List<Bag> selectionList, Random rnd)
        {
            //Select pairs depending on their totalProfit value, higher totalProfit higher chance to be picked.
            //This uses weighted random selection instead of being normalized around 1

            //https://medium.com/@peterkellyonline/weighted-random-selection-3ff222917eb6
            /*  Pseudocode for weighted selection
             randomWeight = rand(1, sumOfWeights)
             for each item in array
                  randomWeight = randomWeight - item.Weight 
                  if randomWeight <= 0
                    break // done, we select this item
             */

            int sumOfWTotalProfits = 0; //Represents the sum of weights
            foreach (Bag b in selectionList)
            {
                sumOfWTotalProfits += b.TotalProfit;
            }
            //Console.WriteLine("Median of the profit for this generation: " + sumOfWTotalProfits/selectionList.Count);
            int randomWeight = rnd.Next(0, sumOfWTotalProfits);
            foreach (Bag b in selectionList)
            {
                randomWeight = randomWeight - b.TotalProfit;
                if (randomWeight <= 0)
                {
                    return b;
                }
            }

            //Something went wrong if this method returns null
            //TODO: Add error statements
            return null;
        }
        

        /// <summary>
        /// Cross Over between 2 individual Bags
        /// <br>Uses uniform corssover instead of "crossover point" algorithm</br>
        /// </summary>
        /// <returns>Child bag</returns>
        public Bag crossOver(Bag parent1, Bag parent2, Random rnd)
        {
            Bag child = new Bag(GlobalBagCapacity);

            //Shuffle items within both parents then use a "que-like" structure to select from parents, priority to the ques given randomly when pairing so there is no need for further randomization
            List<Item> ItemsParent1 = new List<Item>(parent1.ItemsList).OrderBy(x => Guid.NewGuid()).ToList();  //Collect parent1's items in a new list and shuffle it
            List<Item> ItemsParent2 = new List<Item>(parent2.ItemsList).OrderBy(x => Guid.NewGuid()).ToList();  //Collect parent2's items in a new list and shuffle it

            //Searches shuffled parent items list, adds item if there is space, if not skips to the next items within the list, this keeps going until all items are scanned on both lists 
            int index1 = 0;
            int index2 = 0;
            for (int i = 0; i < (ItemsParent1.Count+ItemsParent2.Count); i++)
            {
                //First check in the following ifs are there to prevent multiple of the same item from being picked.
                if ( (!child.ItemsList.Any(n => n.index == ItemsParent1[index1].index)) && (child.CurrentWeight + ItemsParent1[index1].Weight) < child.WeightCapacity) { Console.WriteLine("Grabbing item with profit from parent1: " + ItemsParent1[index1].Profit); child.addItem((Item)ItemsParent1[index1].Clone()); }
                if ( (!child.ItemsList.Any(n => n.index == ItemsParent2[index2].index)) && (child.CurrentWeight + ItemsParent2[index2].Weight) < child.WeightCapacity) { Console.WriteLine("Grabbing item with profit from parent2: " + ItemsParent2[index2].Profit); child.addItem((Item)ItemsParent2[index2].Clone()); }

                if (index1+1 < ItemsParent1.Count) { index1++; }
                if (index2+1 < ItemsParent2.Count) { index2++; }
            }

            GenerationalLog += "\nNew child with a (profit,weight): (" + child.TotalProfit + "," + child.CurrentWeight + ") From parents with profit of: Parent1: " + parent1.TotalProfit + " Parent2: " + parent2.TotalProfit;
            Console.WriteLine("New child bag with: " + child.TotalProfit + " Weight: " + child.CurrentWeight + " \tPARENTS: "+ parent1.TotalProfit + " "+ parent2.TotalProfit);
            return child;
        }

        /// <summary>
        /// Mutates a bag, if the mutation check is passed, mutation is depending on the mutation strength, very low strength might not provide any mutation even though check is passed
        /// random amount of random items are swapped with items in the available pool if no items are in the ppol swapped with a completly random item
        /// </summary>
        public void Mutation(Bag bag, List<Item> availableItems, Random rnd)
        {
           
            double currentMutationRate = MutationRate;
            GenerationalLog += "\nAttempting to mutate child with (Profit,Weight) of (" + bag.TotalProfit + "," + bag.CurrentWeight + ")";
            while (currentMutationRate > rnd.NextDouble())  //While mutation chance is passing
            {
               
                //Roll a (mutationRate + MutationStrength) to remove a random item (This allows for high mutation strength to force an item removal)
                if (MutationRate / MutationStrength > rnd.NextDouble())
                {
                    //Remove random item
                    int randomIndex = rnd.Next(0, bag.ItemsList.Count);
                    availableItems.Add(bag.ItemsList[randomIndex]);
                    bag.ItemsList.RemoveAt(randomIndex);
                    bag.calculateParams(); //recalculate the parameters of the bag for new item selection
                }

                //if there are suitable items available in the pool, remove and replace an item randomly
                if (availableItems.Count > 0)
                {
                    //Find items which fit in the empty space of the bag
                    List <Item> fittingItems = new List<Item>();
                    fittingItems = availableItems.Where(x => (bag.CurrentWeight + x.Weight <= bag.WeightCapacity)).ToList();

                    if (fittingItems.Count <= 0) { break;  }

                    //Randomly pick a fitting item and add it to the bag
                    int randomIndex = rnd.Next(0, fittingItems.Count);
                    bag.addItem(fittingItems[randomIndex]);

                    //remove added item from available items list
                    availableItems.Remove(fittingItems[randomIndex]);

                }
                currentMutationRate = currentMutationRate * (MutationStrength); // set the new mutation rate, higher mutation rate will cause mutation chance to decay slower 
            }

            GenerationalLog += "\n↳After Attempted Mutation (Profit,Weight) (" + bag.TotalProfit + "," + bag.CurrentWeight + ")";
        }

    }
}
