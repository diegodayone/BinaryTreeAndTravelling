using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree();
            var root = binaryTree.Insert(null, 1);

            var randomGenerator = new Random();
           
            var frameworkAlternative = new SortedDictionary<int, string>();
            for(var i = 0; i < 1024*1024*10; i++)
            {
                //frameworkAlternative.Add(i, "whatever string " + randomGenerator.Next(1000000));
                binaryTree.Insert(root, randomGenerator.Next(1000000));
            }

            var sw = Stopwatch.StartNew();
            var res = frameworkAlternative[12409];
            Console.WriteLine(sw.ElapsedMilliseconds);
         
        }
    }



}

