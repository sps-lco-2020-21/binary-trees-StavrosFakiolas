using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.App
{
    class Program
    {
        static void Main()
        {
            Tree tree = new Tree(7);
            string result = "";
            int summing = 0;
            bool first = true;

            tree.Add(3);
            tree.Add(8);
            tree.Add(8);
            tree.Add(15);
            tree.Add(5);
            tree.Add(2);
            tree.Add(12);
            /*Random rng = new Random();
            for (int i = 0; i <= 10; ++i)
            {
                tree.Add(rng.Next(0,100));
                //tree.Add(i);
                //tree.Add(i);
            }*/
            tree.Print(ref result, ref first);
            Console.WriteLine(result);
            Console.WriteLine(tree.Depth()); //should be 4
            Console.WriteLine(tree.Sum(ref summing)); //should be 60

            /*for (int i = 0; i <= 100; ++i)
            {
                Console.WriteLine(tree.Contains(i).ToString());
            }*/
            Console.ReadLine();
        }
    }
}
