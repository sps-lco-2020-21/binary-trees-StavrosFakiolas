using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.App
{
    class Tree
    {
        Node root;

        public Tree()
        {
            root = null;
        }
        
        public Tree(int num)
        {
            root = new Node(num);
        }

        
        public void Add(int toAdd)
        {
            //non-recursive Add
            Node currentNode = root;
            bool addSuccesful = false;

            if (root == null) //empty
            {
                root = new Node(toAdd);
            }
            else
            {
                while (addSuccesful == false)
                {
                    if (toAdd < currentNode.value) //go left please
                    {
                        if (currentNode.left == null) //add here please
                        {
                            Node toAddNode = new Node(toAdd);
                            currentNode.left = toAddNode;
                            addSuccesful = true;

                        }
                        else
                        {
                            currentNode = currentNode.left; //lets see what the pointers have to offer
                        }
                    }
                    else //go right please
                    {
                        if (currentNode.right == null)
                        {
                            Node toAddNode = new Node(toAdd);
                            currentNode.right = toAddNode;
                            addSuccesful = true;
                        }
                        else
                        {
                            currentNode = currentNode.right;
                        }
                    }
                }


            }
        }
        
        public void Print(ref string s, ref bool first, Node cur = null)
        {
            // write out the tree in a string sorted
            //recursive
            

            if (cur == null)
            {
                cur = root;
            }
            if (cur.left != null)
            {
                Print(ref s, ref first, cur.left);
            }
            
            if (!first)
            {
                s += "  ";
            }
            first = false;

            s = s + cur.value.ToString();

            if (cur.right != null)
            {
                Print(ref s, ref first, cur.right);
            }

        }

        public bool Contains(int value)
        {
            //non-recursive check
            Node currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.value == value)
                {
                    return true;
                }
                else if (value < currentNode.value) //go left please
                {
                    if (currentNode.left != null)
                    {
                        currentNode = currentNode.left;
                    }
                    else
                        return false;
                }
                else //go right please
                {
                    if (currentNode.right != null)
                    {
                        currentNode = currentNode.right;
                    }
                    else
                        return false;
                }
            }

            return false;
            
        }


        public int Depth(Node cur = null)
        {
            //gets depth of tree
            //recursive

            if (cur == null)
            {
                cur = root;
            }
            
            int leftDepth = 0;

            if (cur.left != null)
            {
                leftDepth = Depth(cur.left) + 1;
            }
            
            int rightDepth = 0;

            if (cur.right != null)
            {
                rightDepth = Depth(cur.right) + 1;
            }

            return Math.Max(leftDepth, rightDepth);
        }

        public int Sum(ref int sum, Node cur = null)
        {
            // sum
            // recursive

            if (cur == null)
            {
                cur = root;
            }
            sum = sum + cur.value;
            if (cur.left != null)
            {
                Sum(ref sum, cur.left);
            }
            if (cur.right != null)
            {
                Sum(ref sum, cur.right);
            }

            return sum;
        }

    }
    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int num)
        {
            value = num;
            left = null;
            right = null;
        }
    }
}
