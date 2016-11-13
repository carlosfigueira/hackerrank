using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesCS
{
    // https://www.hackerrank.com/challenges/swap-nodes-algo
    class SwapNodes
    {
        public static void Run()
        {
            Node input = ReadInput();
            int swapCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < swapCount; i++)
            {
                int k = int.Parse(Console.ReadLine());
                input.SwapLevel(k);
                input.InOrder();
            }
        }

        static Node ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            Node[] allNodes = new Node[n];
            for (var i = 0; i < n; i++)
            {
                allNodes[i] = new Node { data = i + 1 };
            }
            for (var i = 0; i < n; i++)
            {
                int[] children = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (children[0] >= 1)
                {
                    allNodes[i].left = allNodes[children[0] - 1];
                }
                if (children[1] >= 1)
                {
                    allNodes[i].right = allNodes[children[1] - 1];
                }
            }

            return allNodes[0];
        }

        class Node
        {
            public Node left;
            public Node right;
            public int data;

            public void InOrder()
            {
                this.InOrderInternal();
                Console.WriteLine();
            }

            private void InOrderInternal()
            {
                if (left != null) left.InOrderInternal();
                Console.Write("{0} ", this.data);
                if (right != null) right.InOrderInternal();
            }

            public void SwapLevel(int level)
            {
                SwapLevelInternal(level, 1);
            }

            private void SwapLevelInternal(int level, int currentLevel)
            {
                if ((currentLevel % level) == 0)
                {
                    Node temp = this.left;
                    this.left = this.right;
                    this.right = temp;
                }

                if (this.left != null) this.left.SwapLevelInternal(level, currentLevel + 1);
                if (this.right != null) this.right.SwapLevelInternal(level, currentLevel + 1);
            }
        }
    }
}
