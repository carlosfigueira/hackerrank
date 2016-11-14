using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCS
{
    // https://www.hackerrank.com/challenges/bfsshortreach
    class BFS_ShortestReach
    {
        public static void Run()
        {
            int q = int.Parse(Console.ReadLine());
            for (var i = 0; i < q; i++)
            {
                SolveQuery();
            }
        }

        private static void SolveQuery()
        {
            var edges = ReadGraph();
            var s = int.Parse(Console.ReadLine());
            Queue<QueueItem> toProcess = new Queue<QueueItem>();
            toProcess.Enqueue(new QueueItem { NodeNumber = s, Distance = 0 });
            bool[] visited = new bool[edges.Count];
            int[] distance = new int[edges.Count];
            visited[s] = true;
            while (toProcess.Count > 0)
            {
                var next = toProcess.Dequeue();
                int node = next.NodeNumber;
                int nodeDistance = next.Distance;
                distance[next.NodeNumber] = nodeDistance;
                for (var i = 0; i < edges[node].Count; i++)
                {
                    int otherNode = edges[node][i];
                    if (!visited[otherNode])
                    {
                        visited[otherNode] = true;
                        toProcess.Enqueue(new QueueItem { NodeNumber = otherNode, Distance = nodeDistance + 6 });
                    }
                }
            }

            for (var i = 1; i < edges.Count; i++)
            {
                if (i != s)
                {
                    var dist = visited[i] ? distance[i] : -1;
                    Console.Write("{0} ", dist);
                }
            }

            Console.WriteLine();
        }

        class QueueItem
        {
            public int NodeNumber { get; set; }
            public int Distance { get; set; }
        }

        private static List<List<int>> ReadGraph()
        {
            var nm = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = nm[0];
            var m = nm[1];
            List<List<int>> edges = new List<List<int>>();
            edges.Add(null); // 0-index
            for (var i = 0; i < n; i++)
            {
                edges.Add(new List<int>());
            }

            for (var i = 0; i < m; i++)
            {
                var uv = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var u = uv[0];
                var v = uv[1];
                if (!edges[u].Contains(v))
                {
                    edges[u].Add(v);
                    edges[v].Add(u);
                }
            }

            return edges;
        }
    }
}
