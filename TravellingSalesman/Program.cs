using System;
using System.Linq;

namespace TravellingSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *        Rome  Madrid Athens Paris Warsar
             * Rome    0,     10     20     5     50
             * Madrid
             * Athens
             * Paris
             * Warsaw
             * Valletta
             * */

            //var distance = new int[][] {
            //    new [] { 0, 29, 82, 46, 68, 52, 72, 42, 51, 55, 29, 74, 23, 72, 46 },
            //    new [] { 29, 0, 55, 46, 42, 43, 43, 23, 23, 31, 41, 51, 11, 52, 21 },
            //    new [] { 82, 55, 0, 68, 46, 55, 23, 43, 41, 29, 79, 21, 64, 31, 51 },
            //    new [] { 46, 46, 68, 0, 82, 15, 72, 31, 62, 42, 21, 51, 51, 43, 64 },
            //    new [] { 68, 42, 46, 82, 0, 74, 23, 52, 21, 46, 82, 58, 46, 65, 23 },
            //    new [] { 52, 43, 55, 15, 74, 0, 61, 23, 55, 31, 33, 37, 51, 29, 59 },
            //    new [] { 72, 43, 23, 72, 23, 61, 0, 42, 23, 31, 77, 37, 51, 46, 33 },
            //    new [] { 42, 23, 43, 31, 52, 23, 42, 0, 33, 15, 37, 33, 33, 31, 37 },
            //    new [] { 51, 23, 41, 62, 21, 55, 23, 33, 0, 29, 62, 46, 29, 51, 11 },
            //    new [] { 55, 31, 29, 42, 46, 31, 31, 15, 29, 0, 51, 21, 41, 23, 37 },
            //    new [] { 29, 41, 79, 21, 82, 33, 77, 37, 62, 51, 0, 65, 42, 59, 61 },
            //    new [] { 74, 51, 21, 51, 58, 37, 37, 33, 46, 21, 65, 0, 61, 11, 55 },
            //    new [] { 23, 11, 64, 51, 46, 51, 51, 33, 29, 41, 42, 61, 0, 62, 23 },
            //    new [] { 72, 52, 31, 43, 65, 29, 46, 31, 51, 23, 59, 11, 62, 0, 59 },
            //    new [] { 46, 21, 51, 64, 23, 59, 33, 37, 11, 37, 61, 55, 23, 59, 0 }};

            // Rome -> Madrid -> Athens -> Paris -> Warsaw = 29 + 55 + 68 + 82 + 74
            // Rome -> Madrid -> Athens -> Warsaw -> Paris = 29 + 55 + 68 + 15 + 23

            var distance = new int[][] {
                new [] { 0, 29, 82, 46, 68, 52},
                new [] { 29, 0, 55, 46, 42, 43},
                new [] { 82, 55, 0, 68, 46, 55},
                new [] { 46, 46, 68, 0, 82, 15},
                new [] { 68, 42, 46, 82, 0, 74},
                new [] { 52, 43, 55, 15, 74, 0}
            };

            //Initial configuration of a basic path, the counter and some temp variables 
            var vals = new int[] { 0, 1, 2, 3, 4, 5 };
            var counter = 1;
            var shortest = int.MaxValue; //keep track of the cheapest path
            int[] best = new int[1]; //keep track of the best path

            //loop until we finish the combinations
            while (true)
            {
                var total = 0;
                //For each city in my path
                for (int currentStep = 0; currentStep < vals.Length; currentStep++)
                {
                    //Get the cost of the first step
                    var costOfTravelling = distance[currentStep][vals[currentStep]];
                    if (costOfTravelling == 0) { //if step is 0, the path is invalid (going from Rome to Rome)
                        total = int.MaxValue;
                        break;
                    }

                    total += costOfTravelling; //adding it to the total cost of the path
                }

                if (total < shortest) //if the cost of the path is lower than the previous minumum, save the path and the cost
                {
                    shortest = total; //cost of shortest path
                    best = vals; //actual combination of cities (path)
                    Console.WriteLine("New Shortest path = " + shortest);
                }

                #region PermutationsOfArray

                //ABCDEFG
                //-----<>
                //ABCDEGF

                var largestI = -1;
                for (var i = 0; i < vals.Length - 1; i++)
                    if (vals[i] < vals[i + 1])
                        largestI = i;

                if (largestI == -1) //we completed the reverse
                    break;

                var largestJ = -1;
                for (var j = 0; j < vals.Length; j++)
                    if (vals[largestI] < vals[j])
                        largestJ = j;

                counter++;

                //swapped the two items in the array
                var temp = vals[largestI];
                vals[largestI] = vals[largestJ];
                vals[largestJ] = temp;

                //we are getting the part of the array that should be reverted
                var endArray = vals.Skip(largestI + 1).ToArray();
                endArray = endArray.Reverse().ToArray();

                //we are actually pasting that part at the end of the array
                var list = vals.Take(largestI + 1).ToList();
                list.AddRange(endArray);
                vals = list.ToArray();
                #endregion
            }

            Console.WriteLine("Lower cost: " + shortest);
            Console.WriteLine("Best Path: ");
            foreach (var value in best)
                Console.WriteLine(value);
            Console.WriteLine("Iteration needed: " + counter);
        }
    }
}
