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
            bool first = true;
            Random rng = new Random();
            for (int i = 0; i <= 10; ++i)
            {
                tree.Add(rng.Next(0,100));
                //tree.Add(i);
                //tree.Add(i);
            }
            tree.Print(ref result, ref first);
            Console.WriteLine(result);
            Console.WriteLine(tree.Depth());
            Console.WriteLine(tree.Sum());

            /*for (int i = 0; i <= 100; ++i)
            {
                Console.WriteLine(tree.Contains(i).ToString());
            }*/
            Console.ReadLine();
        }
    }
}
