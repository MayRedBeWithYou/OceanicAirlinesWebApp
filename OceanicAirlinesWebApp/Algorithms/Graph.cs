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
        public int Price { get; set; }
        public int Priority { get
            {
                switch(Type)
                {
                    case EdgeType.Airline: return 1;
                    case EdgeType.Ship: return 10;
                    case EdgeType.Car: return 10;
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

        public Route Dijkstra(Func<Edge, int> edgeWeight)
        {
            return null;
        }
    }
}
