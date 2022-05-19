using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
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
        public int Price
        {
            get
            {
                switch (Type)
                {
                    case EdgeType.Airline: return 0;
                    case EdgeType.Ship: return 300 * Dots;
                    case EdgeType.Car: return 300 * Dots;
                    default: return 0;
                }
            }
        }
        public int Time
        {
            get
            {
                switch (Type)
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
        public int Distance { get; set; }
    }

    public class Route
    {
        public List<Node> Path { get; set; } = new List<Node>();
        public List<Edge> EdgePath { get; set; } = new List<Edge>();

        public double TotalPrice
        {
            get { return 0; }
        }

        public double TotalTime
        {
            get
            {
                double time = 0;
                foreach (Edge edge in EdgePath)
                {

                }
                return time;
            }
        }

        public void CalculatePriceAndTime()
        {
            double time = 0;
            double price = 0;
            bool isAirline = false;
            foreach (Edge edge in EdgePath)
            {
                switch (edge.Type)
                {
                    case (EdgeType.Ship):
                        // Fetch from API
                        break;
                    case EdgeType.Car:
                        // Fetch from API
                        break;
                    default:
                        isAirline = true;
                        time += edge.Time;
                        break;
                }
            }

        }
    }

    public class Graph
    {
        public List<Edge> Edges = new List<Edge>();
        public List<Node> Nodes = new List<Node>();

        public Graph()
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
                        },

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
                        },

                        new Edge()
                        {
                            From = 2,
                            To = 3,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        }
                    }
                },

                new Node()
                {
                    Id = 3,
                    Name = "Sierra Leona",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 3,
                            To = 4,
                            Type = EdgeType.Airline,
                            Dots= 0,
                        }
                    }
                },

                new Node()
                {
                    Id=4,
                    Name = "St.Helena",
                    Edges = new List<Edge>()
                    {
                    }
                },

                new Node()
                {
                    Id = 11,
                    Name = "Guldkysten",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 11,
                            To = 2,

                        }
                    }
                },

                new Node()
                {
                    Id = 12,
                    Name = "Tripoli",
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
            };
            Edges = new List<Edge>();
            foreach (Node node in Nodes) Edges.AddRange(node.Edges);
        }

        public Route Dijkstra(int from, int to, Func<Edge, int> edgeWeight)
        {
            int[] dist = new int[33];
            int[] previous = new int[33];
            foreach (Node node in Nodes)
            {
                dist[node.Id] = int.MaxValue;
                previous[node.Id] = -1;
            }
            dist[from] = 0;
            List<Node> queue = new List<Node>();
            foreach (Node node in Nodes)
            {
                node.Distance = dist[node.Id];
                queue.Add(node);
            };
            while (queue.Count > 0)
            {
                queue.Sort((val1, val2) => val1.Distance - val2.Distance);
                Node node = queue[0];
                queue.RemoveAt(0);
                foreach (Edge edge in node.Edges)
                {
                    int alt = dist[node.Id] + edgeWeight(edge);
                    if (alt < dist[edge.To])
                    {
                        dist[edge.To] = alt;
                        previous[edge.To] = node.Id;
                    }
                }
                for (int i = 0; i < queue.Count; i++)
                {
                    queue[i].Distance = dist[queue[i].Id];
                }
            }
            Route route = new Route();
            int previousId = to;
            while (previousId != from)
            {
                route.Path.Add(Nodes.Find((n) => n.Id == previousId));
                Edge e = Edges.Find(edge => edge.To == previousId && edge.From == previous[previousId]);
                route.EdgePath.Add(e);
                previousId = previous[previousId];
            }
            route.Path.Add(Nodes.Find((n) => n.Id == from));
            route.Path.Reverse();
            route.EdgePath.Reverse();
            Debug.WriteLine(route.TotalTime);

            return route;
        }
    }
}



