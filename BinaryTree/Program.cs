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
                frameworkAlternative.Add(i, "whatever string " + randomGenerator.Next(1000000));
                //binaryTree.Insert(root, randomGenerator.Next(1000000));
            }

            var sw = Stopwatch.StartNew();
            var res = frameworkAlternative[12409];
            Console.WriteLine(sw.ElapsedMilliseconds);
            //binaryTree.Insert(root, 10);
            //binaryTree.Insert(root, 12);
            //binaryTree.Insert(root, 8);
            //binaryTree.Insert(root, 5);
            //binaryTree.Insert(root, 6);
            //binaryTree.Insert(root, 4);
            //binaryTree.Insert(root, 7);
            //binaryTree.Insert(root, 10);
            //binaryTree.Insert(root, 10);
            //binaryTree.Insert(i, 11);
            //binaryTree.Insert(i, 100);
            //binaryTree.Insert(i, 1100);
        }
    }



}

