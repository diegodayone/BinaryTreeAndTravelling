using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
    }

    class BinaryTree //Not B Tree
    {
        //startingNode is NOT the root of the Tree
        public TreeNode Insert(TreeNode startingNode, int value)
        {
            if (startingNode == null)
            {
                startingNode = new TreeNode();
                startingNode.value = value;
                //Console.WriteLine("Creating a leaf for " + value);
            }
            else
            {
                if (value < startingNode.value)
                {
                  //  Console.WriteLine(value + " < " + startingNode.value + " => going to the left");
                    startingNode.left = Insert(startingNode.left, value);
                }
                else
                {
                    //Console.WriteLine(value + " >= " + startingNode.value + " => going to the right");
                    startingNode.right = Insert(startingNode.right, value);
                }
            }

            return startingNode;
        }
    }
}
