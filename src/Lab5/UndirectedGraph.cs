using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Lab5
{
    public class UndirectedGraph
    {
        public List<Node> Nodes { get; set; }

        public UndirectedGraph()
        {
            Nodes = new List<Node>();
        }

        public UndirectedGraph(string path)
        {
            Nodes = new List<Node>();

            List<string> lines = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while( (line = sr.ReadLine()) != null )
                    {
                        line = line.Trim();
                        if (line == "")
                        {
                            continue;
                        }
                        if(line[0] == '#')
                        {
                            continue;
                        }

                        lines.Add(line);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // process the lines
            if( lines.Count < 1 )
            {
                // empty file
                Console.WriteLine("Graph file was empty");
                return;
            }

            // Add nodes
            string[] nodeNames = Regex.Split(lines[0], @"\W+");

            foreach(var name in nodeNames)
            {
                Nodes.Add(new Node(name));
            }

            // Add edges
            for( int i = 1; i < lines.Count; i++)
            {
                // extract node names
                nodeNames = Regex.Split(lines[i], @"\W+");
                if( nodeNames.Length < 2)
                {
                    throw new Exception("Two nodes are required for each edge.");
                }


                // add edge between those nodes
                AddEdge(nodeNames[0], nodeNames[1]);
            }

        }

        public void AddEdge(string nodename1, string nodename2)
        {
            // find the nodes in the List.
            Node node1 = GetNodeByName(nodename1);
            Node node2 = GetNodeByName(nodename2);

            if( node1 == null || node2 == null)
            {
                throw new Exception("Invalid node name");
            }

            // add node1 to node2's list of neighbors
            node2.Neighbors.Add(node1);

            // add node2 to node1's list of neighbors
            node1.Neighbors.Add(node2);

        }

        /// <summary>
        /// Returns the Node object for the given node name.
        /// </summary>
        /// <param name="name">The name of the node</param>
        /// <returns>The Node for the given name </returns>
        public Node GetNodeByName(string name)
        {
            var node = Nodes.Find(node => node.Name == name);

            return node;
        }

        // TODO
         /**
         * <summary> Returns the number of connected components in the graph .</summary>
         */
        
        public int ConnectedComponents
        {
            get
            {
                int connectedComponents = 0;

                // for all the nodes
                //     if node is white
                //        connectedComponents++
                //        explore the neighbors
                //        

                return connectedComponents;
            }
        }

        // TODO

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodename1"></param>
        /// <param name="nodename2"></param>
        /// <returns> true if node1 is reachable through any path from node2.</returns>
        public bool IsReachable(string nodename1, string nodename2)
        {
            ResetNodeColor();

            return false;
        }

        // TODO
        /// <summary>
        /// Searches the graph in a depth-first manner, creating a
        /// dictionary of the Node to Predessor Node links discovered by starting at the given node.
        /// Neighbors are visited in alphabetical order. 
        /// </summary>
        /// <param name="startingNode">The starting node of the depth first search</param>
        /// <returns>A dictionary of the Node to Predecessor Node 
        /// for each node in the graph reachable from the starting node
        /// as discovered by a DFS.</returns>
        public Dictionary<Node, Node> DFS(Node startingNode)
        {
            Dictionary<Node, Node> pred = new Dictionary<Node, Node>();

            // intialize nodes and the pred dictionary
            foreach( var node in Nodes)
            {
                pred[node] = null;
                node.Color = Color.White;
            }

            DFSVisit(startingNode, pred);

            return pred;
        }

        // TODO
        private void DFSVisit(Node node, Dictionary<Node,Node> pred)
        {
            Console.WriteLine(node);
            node.Color = Color.Gray;

            // sort the neighbors so that we will visit in alphabetical order
            node.Neighbors.Sort();

            foreach ( var neighbor in node.Neighbors )
            {
                if (neighbor.Color == Color.White)
                {
                    pred[neighbor] = node;
                    DFSVisit(neighbor, pred);
                }
            }
            node.Color = Color.Black;
        }

        // TODO
        /// <summary>
        /// Searches the graph in a breadth-first manner, creating a
        /// dictionary of the Node to Predecessor and Distance discovered by starting at the given node.
        /// Neighbors are visited in alphabetical order. 
        /// </summary>
        /// <param name="startingNode"></param>
        /// <returns>A dictionary of the Node to Predecessor Node and Distance 
        /// for each node in the graph reachable from the starting node
        /// as discovered by a BFS.</returns>
        public Dictionary<Node, (Node pred, int dist)> BFS(Node startingNode)
        {
            var resultDictionary = new Dictionary<Node, (Node pred, int dist)>();

            // initialize the dictionary
            foreach(var node in Nodes)
            {
                node.Color = Color.White;
                resultDictionary[node] = (null, int.MaxValue);
            }

            //setup starting node
            startingNode.Color = Color.Gray;
            resultDictionary[startingNode] = (null, 0);

            // Q = empty Queue
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(startingNode);

            // iteratively traverse the graph

            while( queue.Count > 0 )
            {
                // u = head(Q)
                var node = queue.Peek();

                // We should sort Neighbors first

                foreach( var neighbor in node.Neighbors )
                {
                    if( neighbor.Color == Color.White)
                    {
                        int distance = resultDictionary[node].ToTuple().Item2;
                        resultDictionary[neighbor] = (node, distance+1);
                        neighbor.Color = Color.Gray;
                        queue.Enqueue(neighbor);
                    }
                }

                queue.Dequeue();
                node.Color = Color.Black;
               
            }

            
            return resultDictionary;
        }

        // TODO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="endingNode"></param>
        /// <returns></returns>
        private bool DFSVisit(Node currentNode, Node endingNode)
        {
            // return true if endingNode is found

            // return false if endingNode is NOT found after visiting ALL connected nodes

            return false;
        }

        private void ResetNodeColor()
        {
            foreach(var node in Nodes)
            {
                node.Color = Color.White;
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var n in Nodes)
            {
                str += n.Name;
                str += " has the neighbors: ";

                foreach (var neighbor in n.Neighbors)
                {
                    str += neighbor.Name;
                    str += ", ";
                }

                
                str += Environment.NewLine;
            }
            return str;
        }

    }

}