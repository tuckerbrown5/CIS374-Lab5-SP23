using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/BeReal.txt");

            Console.WriteLine(undirectedGraph);

            //var startingNode = undirectedGraph.GetNodeByName("i");
            //undirectedGraph.DFS(startingNode);

            Console.WriteLine(undirectedGraph.IsReachable("gb", "mw"));

        }
    }
}
