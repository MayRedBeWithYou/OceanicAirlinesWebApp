using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanicAirlinesWebApp.Algorithms
{
    public enum EdgeType
    {
        Airline,
        Car,
        Ship
    }

    public class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public EdgeType Type { get; set; }
        public int Dots { get; set; }
        public int Price { get
            {
                switch(Type)
                {
                    case EdgeType.Airline: return 0;
                    case EdgeType.Ship: return 300 * Dots;
                    case EdgeType.Car: return 300 * Dots;
                    default: return 0;
                }
            } 
        }
        public int Time { get;
            {
                switch(Type)
                {
                    case EdgeType.Airline: return 8;
                    case EdgeType.Ship: return 10 * Dots;
                    case EdgeType.Car: return 10 * Dots;
                    default: return 0;
                }
            }
        }
    }

    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Edge> Edges { get; set; }

       

    }

    public class Route
    {
        public List<Node> route { get; set; }

        public int TotalPrice { get; set; }

        public int TotalTime { get; set; }
    }

    public class Graph
    {
        public List<Edge> Edges = new List<Edge>();
        public List<Node> Nodes = new List<Node>();

        static void Main(String[] args)
        {

            Graph graph = new Graph()
            {
                Nodes = new List<Node>()
                {
                    new Node()
                    {
                        Id = 1,
                        Name = "Tanger",
                        Edges = new List<Edge>()
                        {
                            new Edge()
                            {
                                From = 1,
                                To = 2,
                                Type = EdgeType.Airline,
                                Dots = 0,
                            }

                            new Edge()
                            {
                                From = 1,
                                To = 12,
                                Type = EdgeType.Airline,
                                Dots = 0,
                            }

                        }
                    },

                    new Node()
                    {
                        Id = 2,
                        Name = "Marrakesh",
                        Edges= new List<Edge>()
                        {
                            new Edge()
                            {
                                From = 2,
                                To = 11,
                                Type = EdgeType.Airline,
                                Dots = 0,
                            }
                            
                            new Edge()
                            {
                                From = 2,
                                To = 3,
                                Type = EdgeType.Airline,
                                Dots = 0,
                            }
                        }
                    }

                    new Node()
                    {
                        Id = 3,
                        Name = "Sierra",
                        Edges = new List<Edge>()
                        {

                        }
                    }

                    new Node()
                    {
                        Id=4,
                        Name = "St.Helena",
                        Edges = 
                    }

                    new Node()
                    {
                        Id = 11,
                        Name = "Guldkysten"
                        Edges = new List<Edge>()
                        {
                            new Edge()
                            {
                                From = 11,
                                To = 2,

                            }
                        }
                    }

                    new Node()
                    {
                        Id = 12,
                        Name = "Tripoli"
                        Edges = new List<Edge>()
                        {
                            new Edge()
                            {
                                From = 12,
                                To = 11,
                                Type = EdgeType.Airline,
                                Dots = 0,
                            }
                        }
                    }
                }
            }
           

          

            Node Helma = new Node();
            Helma.Name = "St. Helma";
            Helma.Id = 4;
            Helma.Edges = new List<Edge>();

            Node Kapstaden = new Node();
            Kapstaden.Name = "Kapstaden";
            Kapstaden.Id = 5;
            Kapstaden.Edges = new List<Edge>();

            Node Marie = new Node();
            Marie.Name = "Kap St. Marie";
            Marie.Id = 6;
            Marie.Edges = new List<Edge>();

            Node Amatave = new Node();
            Amatave.Name = "Amatave";
            Amatave.Id = 7;
            Amatave.Edges = new List<Edge>();

            Node Dragebjerget = new Node();
            Dragebjerget.Name = "Dragebjerget";
            Dragebjerget.Id = 8;
            Dragebjerget.Edges = new List<Edge>();

            Node Hvalbugten = new Node();
            Hvalbugten.Name = "Hvalbugten";
            Hvalbugten.Id = 9;
            Hvalbugten.Edges = new List<Edge>();

            Node Luanda = new Node();
            Luanda.Name = "Luanda";
            Luanda.Id = 10;
            Luanda.Edges = new List<Edge>();

          

            //Node Tripoli = new Node();
            //Tripoli.Name =  
            
        }

        public Route Dijkstra(int from, int to, Func<Edge, int> edgeWeight)
        {
            foreach(Edge e in Edges)
            {
                sum += edgeWeight(e);
            }
            return null;

        }
    }



    ///Dijkstra copied, need to be reajusted to our case.

    class GFG
    {
        // A utility function to find the
        // vertex with minimum distance
        // value, from the set of vertices
        // not yet included in shortest
        // path tree
        static int V = 9;
        int minDistance(int[] dist,
                        bool[] sptSet)
        {
            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }
        


        // A utility function to print
        // the constructed distance array
        void printSolution(int[] dist, int n)
        {
            Console.Write("Vertex     Distance "
                          + "from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

        // Function that implements Dijkstra's
        // single source shortest path algorithm
        // for a graph represented using adjacency
        // matrix representation
        void dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; // The output array. dist[i]
                                     // will hold the shortest
                                     // distance from src to i

            // sptSet[i] will true if vertex
            // i is included in shortest path
            // tree or shortest distance from
            // src to i is finalized
            bool[] sptSet = new bool[V];

            // Initialize all distances as
            // INFINITE and stpSet[] as false
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex
            // from itself is always 0
            dist[src] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex
                // from the set of vertices not yet
                // processed. u is always equal to
                // src in first iteration.
                int u = minDistance(dist, sptSet);

                // Mark the picked vertex as processed
                sptSet[u] = true;

                // Update dist value of the adjacent
                // vertices of the picked vertex.
                for (int v = 0; v < V; v++)

                    // Update dist[v] only if is not in
                    // sptSet, there is an edge from u
                    // to v, and total weight of path
                    // from src to v through u is smaller
                    // than current value of dist[v]
                    if (!sptSet[v] && graph[u, v] != 0 &&
                         dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            // print the constructed distance array
            printSolution(dist, V);
        }

        // Driver Code
        public static void Main()
        {
            /* Let us create the example 
    graph discussed above */
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            GFG t = new GFG();
            t.dijkstra(graph, 0);
        }
    }




}
