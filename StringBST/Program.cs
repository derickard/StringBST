using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace StringBST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            StreamReader file = new StreamReader(@"D:\Projects\WordSolver\wlist_match12.txt");

            int counter = 0;
            string line;

            while ((line = file.ReadLine()) != null)
            {
                binaryTree.Add(line);
                Console.Write(" " + line);
                counter++;
            }

            file.Close();
            Console.WriteLine();
            //int depth = binaryTree.GetTreeDepth();
            Console.WriteLine($"There were {counter} words loaded");
            //Console.WriteLine($"The tree is {depth} deep");

            string word = "";
            while(word != "quit")
            {
                Console.Write("Enter word to find: ");
                word = Console.ReadLine();
                Node result = binaryTree.Find(word.ToLower());
                if (result != null)
                {
                    Console.WriteLine($"{result.Data} found");
                }
                else
                    Console.WriteLine($"{word.ToLower()} not found");
            }


            //binaryTree.Add("cat");
            //binaryTree.Add("bad");
            //binaryTree.Add("golf");
            //binaryTree.Add("chair");
            //binaryTree.Add("jog");
            //binaryTree.Add("elephant");
            //binaryTree.Add("helium");

            //Node node = binaryTree.Find("elephant");
            //int depth = binaryTree.GetTreeDepth();

            //Console.WriteLine($"Depth {depth}");

            //Console.WriteLine("PreOrder Traversal:");
            //binaryTree.TraversePreOrder(binaryTree.Root);
            //Console.WriteLine();

            //Console.WriteLine("InOrder Traversal:");
            //binaryTree.TraverseInOrder(binaryTree.Root);
            //Console.WriteLine();

            //Console.WriteLine("PostOrder Traversal:");
            //binaryTree.TraversePostOrder(binaryTree.Root);
            //Console.WriteLine();

            //binaryTree.Remove("golf");
            //binaryTree.Remove("helium");

            //Console.WriteLine("PreOrder Traversal After Removing Operation:");
            //binaryTree.TraversePreOrder(binaryTree.Root);
            //Console.WriteLine();

            //Console.ReadLine();
        }
    }
}
