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

        public void Delete(Node toDel)
        {
            //no children - just delete
            //1 child - reference previous node to child
            //2 children

            //recursive Delete but also non recursive :)
            Node previousNode = null;
            Node currentNode = root;

            if (root == null) //empty
            {
                return;
            }
            else
            {
                while (true)
                {
                    if (toDel.value < currentNode.value) //go left please
                    {
                        if (currentNode.left == null) //no other pointer
                        {
                            return; //didnt find a node, so success???
                        }
                        else
                        {
                            previousNode = currentNode;
                            currentNode = currentNode.left; //lets see what the pointers have to offer
                        }
                    }
                    else if (toDel.value > currentNode.value) //go right please
                    {
                        if (currentNode.right == null)
                        {
                            return; //didnt find a node, so success???
                        }
                        else
                        {
                            previousNode = currentNode;
                            currentNode = currentNode.right; //lets see what the pointers have to offer
                        }
                    }
                    else //found the node
                    {
                        if (currentNode.left == null && currentNode.right == null) //if 0 children
                        {
                            if (toDel.value >= previousNode.value)
                            {
                                previousNode.right = null;  //remove right ref
                            }
                            else
                            {
                                previousNode.left = null; //remove left ref
                            }
                        }
                        else if (currentNode.left == null && currentNode.right != null) //if only right child
                        {
                            previousNode.right = currentNode.right;
                        }
                        else if (currentNode.left != null && currentNode.right == null) //if only left child
                        {
                            previousNode.right = currentNode.left;
                        }
                        else // 2 children
                        {
                            Node successor = min(currentNode.right);
                            currentNode.value = successor.value;
                            Delete(successor);
                        }
                        return;
                    }
                }
            }
        }

        public void Delete(int toDel)
        {
            //no children - just delete
            //1 child - reference previous node to child
            //2 children

            //non-recursive Delete
            Node previousNode = null;
            Node currentNode = root;

            if (root == null) //empty
            {
                return;
            }
            else
            {
                while (true)
                {
                    if (toDel < currentNode.value) //go left please
                    {
                        if (currentNode.left == null) //no other pointer
                        {
                            return; //didnt find a node, so success???
                        }
                        else
                        {
                            previousNode = currentNode;
                            currentNode = currentNode.left; //lets see what the pointers have to offer
                        }
                    }
                    else if (toDel > currentNode.value) //go right please
                    {
                        if (currentNode.right == null)
                        {
                            return; //didnt find a node, so success???
                        }
                        else
                        {
                            previousNode = currentNode;
                            currentNode = currentNode.right; //lets see what the pointers have to offer
                        }
                    }
                    else //found the node
                    {
                        if (currentNode.left == null && currentNode.right == null) //if 0 children
                        {
                            if (toDel >= previousNode.value)
                            {
                                previousNode.right = null;  //remove right ref
                            }
                            else
                            {
                                previousNode.left = null; //remove left ref
                            }
                        }
                        else if (currentNode.left == null && currentNode.right != null) //if only right child
                        {
                            previousNode.right = currentNode.right;
                        }
                        else if (currentNode.left != null && currentNode.right == null) //if only left child
                        {
                            previousNode.right = currentNode.left;
                        }
                        else // 2 children
                        {
                            //not brainstormed yet
                        }
                        return;
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
            return Find(value) != null;
        }

        public Node Find(int value)
        {
            //non-recursive check
            Node currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.value == value)
                {
                    return currentNode;
                }
                else if (value < currentNode.value) //go left please
                {
                    if (currentNode.left != null)
                    {
                        currentNode = currentNode.left;
                    }
                    else
                        return null;
                }
                else //go right please
                {
                    if (currentNode.right != null)
                    {
                        currentNode = currentNode.right;
                    }
                    else
                        return null;
                }
            }

            return null;
            
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

        public int Sum(Node cur = null)
        {
            // sum
            // recursive

            if (cur == null)
            {
                cur = root;
            }
            int sum = cur.value;
            if (cur.left != null)
            {
                sum += Sum(cur.left);
            }
            if (cur.right != null)
            {
                sum += Sum(cur.right);
            }

            return sum;
        }

        Node min (Node cur)
        {
            if (cur.left != null)
            {
                return min(cur.left);
            }
            else
            {
                return cur;
            }
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

        public Node Find(int value)
        {
            if(this.value == value)
            {
                return this;
            }
            else if(value < this.value && left != null)
            {
                return left.Find(value);
            }
            else if (value > this.value && right != null)
            {
                return right.Find(value);
            }
            return null;
        }
    }
}
