using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using OceanicAirlinesWebApp.Models;

namespace OceanicAirlinesWebApp.Algorithms
{
    public enum EdgeType
    {
        Airline = 1,
        Car = 2,
        Ship = 4
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

        public bool IsSupported { get; set; } = true;

        public double TotalPrice
        {
            get; set;
        }

        public double TotalTime
        {
            get
            {
                double time = 0;
                foreach (Edge edge in EdgePath)
                {
                    time += edge.Time;
                }
                return time;
            }
        }

        public void CalculatePriceAndTime(Parcel parcel)
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

                        var result = Endpoints.FetchResultFromEIT(new RequestDTO()
                        {
                            From = Path.Find(node => node.Id == edge.From).Name,
                            To = Path.Find(node => node.Id == edge.To).Name,
                            Height = parcel.Height,
                            Length = parcel.Length,
                            Width = parcel.Width,
                            Weight = parcel.Weight,
                        });
                        time += result.Result.Time;
                        price += result.Result.Price;
                        break;
                    case EdgeType.Car:
                        // Fetch from API
                        var result2 = Endpoints.FetchResultFromTL(new RequestDTO()
                        {
                            From = Path.Find(node => node.Id == edge.From).Name,
                            To = Path.Find(node => node.Id == edge.To).Name,
                            Height = parcel.Height,
                            Length = parcel.Length,
                            Width = parcel.Width,
                            Weight = parcel.Weight,
                        });
                        time += result2.Result.Time;
                        price += result2.Result.Price;
                        break;
                    default:
                        isAirline = true;
                        time += edge.Time;
                        break;
                }
            }
            if (isAirline)
            {
                double sizeprice = 0;
                double typeprice = 0;

                switch (parcel.Size)
                {
                    case "A":
                        if (parcel.Weight < 1)
                        {
                            sizeprice = 40;
                        }
                        else if (parcel.Weight <= 5)
                        {
                            sizeprice = 60;
                        }
                        else
                        {
                            sizeprice = 80;
                        }
                        break;
                    case "B":
                        if (parcel.Weight < 1)
                        {
                            sizeprice = 48;
                        }
                        else if (parcel.Weight <= 5)
                        {
                            sizeprice = 68;
                        }
                        else
                        {
                            sizeprice = 88;
                        }
                        break;
                    case "C":
                        if (parcel.Weight < 1)
                        {
                            sizeprice = 80;
                        }
                        else if (parcel.Weight <= 5)
                        {
                            sizeprice = 100;
                        }
                        else
                        {
                            sizeprice = 120;
                        }
                        break;
                }
                Category category = Parcel.Categories[parcel.Category];

                if (category.AddedPrice != -1)
                {
                    typeprice = category.AddedPrice;
                }
                else
                {
                    IsSupported = false;
                }
                

                double Airlineprice = sizeprice * typeprice;


                price = Airlineprice;
            }
            TotalPrice = price;
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
                    Id = 0,
                    Name = "Addis Abeba",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 0,
                            To = 11,
                            Type = EdgeType.Car,
                            Dots = 2
                        },

                        new Edge()
                        {
                            From = 0,
                            To = 29,
                            Type = EdgeType.Car,
                            Dots = 2
                        },

                        new Edge()
                        {
                            From = 0,
                            To = 22,
                            Type = EdgeType.Car,
                            Dots = 2
                        }
                    }
                },

                new Node()
                {
                    Id = 1,
                    Name = "Bahr El Ghazal",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 1,
                            To = 4,
                            Type = EdgeType.Car,
                            Dots = 1
                        },

                        new Edge()
                        {
                            From = 1,
                            To = 29,
                            Type = EdgeType.Car,
                            Dots = 1
                        }
                    }
                },

                new Node()
                {
                    Id = 2,
                    Name = "Cairo",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 2,
                            To = 23,
                            Type = EdgeType.Airline,
                            Dots = 0
                        },

                        new Edge()
                        {
                            From = 2,
                            To = 27,
                            Type = EdgeType.Ship,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 2,
                            To = 17,
                            Type = EdgeType.Car,
                            Dots = 3,
                        }
                    }
                },

                new Node()
                {
                    Id = 3,
                    Name = "Congo",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 3,
                            To = 4,
                            Type = EdgeType.Car,
                            Dots = 5
                        },

                        new Edge()
                        {
                            From = 3,
                            To = 14,
                            Type = EdgeType.Car,
                            Dots = 2
                        },

                        new Edge()
                        {
                            From = 3,
                            To = 30,
                            Type = EdgeType.Car,
                            Dots = 4
                        },

                        new Edge()
                        {
                            From = 3,
                            To = 20,
                            Type = EdgeType.Car,
                            Dots = 4
                        }
                    }
                },

                new Node()
                {
                    Id = 4,
                    Name = "Dafur",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 4,
                            To = 10,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 4,
                            To = 22,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 4,
                            To = 26,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 4,
                            To = 30,
                            Type = EdgeType.Car,
                            Dots = 3,
                        },

                        new Edge()
                        {
                            From = 4,
                            To = 17,
                            Type = EdgeType.Car,
                            Dots = 2,
                        }

                    }
                },

                new Node()
                {
                    Id = 5,
                    Name = "Dakar",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 5,
                            To = 19,
                            Type = EdgeType.Ship,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 5,
                            To = 21,
                            Type = EdgeType.Ship,
                            Dots = 9,
                        },

                        new Edge()
                        {
                            From = 5,
                            To = 6,
                            Type = EdgeType.Ship,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 5,
                            To = 15,
                            Type = EdgeType.Car,
                            Dots = 7,
                        },

                        new Edge()
                        {
                            From = 5,
                            To = 19,
                            Type = EdgeType.Car,
                            Dots = 3,
                        }
                    }
                },

                new Node()
                {
                    Id = 6,
                    Name = "De kanariske oeer",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 6,
                            To = 24,
                            Type = EdgeType.Ship,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 6,
                            To = 5,
                            Type = EdgeType.Ship,
                            Dots = 4,
                        }
                    }
                },

                new Node()
                {
                    Id = 7,
                    Name = "Dragebjerget",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 7,
                            To = 29,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 7,
                            To = 13,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        }
                    }
                },

                new Node()
                {
                    Id = 8,
                    Name = "Guldkysten",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 8,
                            To = 15,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 8,
                            To = 26,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 8,
                            To = 9,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 8,
                            To = 14,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 8,
                            To = 25,
                            Type = EdgeType.Car,
                            Dots = 3,
                        },

                        new Edge()
                        {
                            From = 8,
                            To = 20,
                            Type = EdgeType.Ship,
                            Dots = 3,
                        }

                    }
                },

                new Node()
                {
                    Id = 9,
                    Name = "Hvalbugten",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 9,
                            To = 8,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 9,
                            To = 14,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 9,
                            To = 13,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 10,
                            To = 20,
                            Type = EdgeType.Ship,
                            Dots = 8,
                        },

                        new Edge()
                        {
                            From = 10,
                            To = 28,
                            Type = EdgeType.Car,
                            Dots = 3,
                        }
                    }
                },

                new Node()
                {
                    Id = 10,
                    Name = "Kabalo",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 10,
                            To = 13,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 10,
                            To = 4,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        }
                    }
                },

                new Node()
                {
                    Id = 11,
                    Name = "Kap Guardafui",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 11,
                            To = 29,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 11,
                            To = 23,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 11,
                            To = 16,
                            Type = EdgeType.Ship,
                            Dots = 7,
                        },

                        new Edge()
                        {
                            From = 11,
                            To = 31,
                            Type = EdgeType.Car,
                            Dots = 5,
                        },

                        new Edge()
                        {
                            From = 11,
                            To = 0,
                            Type = EdgeType.Car,
                            Dots = 2,
                        }
                    }
                },

                new Node()
                {
                    Id = 12,
                    Name = "Kap St Marie",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 12,
                            To = 13,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 12,
                            To = 16,
                            Type = EdgeType.Ship,
                            Dots = 2,
                        }
                    }
                },

                new Node()
                {
                    Id = 13,
                    Name = "Kapstaden",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 13,
                            To = 12,
                            Type = EdgeType.Airline,
                            Dots = 0
                        },

                        new Edge()
                        {
                            From = 13,
                            To = 21,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 13,
                            To = 9,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 13,
                            To = 10,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 13,
                            To = 7,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        }
                    }
                },

                new Node()
                {
                    Id = 14,
                    Name = "Luanda",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 14,
                            To = 9,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 14,
                            To = 8,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 14,
                            To = 3,
                            Type = EdgeType.Car,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 14,
                            To = 16,
                            Type = EdgeType.Car,
                            Dots = 9,
                        }
                    }
                },

                new Node()
                {
                    Id = 15,
                    Name = "Marrakesh",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 15,
                            To = 24,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 15,
                            To = 19,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 15,
                            To = 8,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 15,
                            To = 18,
                            Type = EdgeType.Car,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 15,
                            To = 5,
                            Type = EdgeType.Car,
                            Dots = 7,
                        }
                    }
                },

                new Node()
                {
                    Id = 16,
                    Name = "Mocambique",
                    Edges = new List<Edge>()
                    {

                        new Edge()
                        {
                            From = 16,
                            To = 11,
                            Type = EdgeType.Ship,
                            Dots = 7,
                        },

                        new Edge()
                        {
                            From = 16,
                            To = 12,
                            Type = EdgeType.Ship,
                            Dots = 2
                        },

                        new Edge()
                        {
                            From = 16,
                            To = 31,
                            Type = EdgeType.Car,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 16,
                            To = 29,
                            Type = EdgeType.Car,
                            Dots = 5,
                        },

                        new Edge()
                        {
                            From = 16,
                            To = 7,
                            Type = EdgeType.Car,
                            Dots = 3,
                        },

                        new Edge()
                        {
                            From = 16,
                            To = 14,
                            Type = EdgeType.Car,
                            Dots = 9,
                        }
                    }
                },

                new Node()
                {
                    Id = 17,
                    Name = "Omdurman",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 17,
                            To = 2,
                            Type = EdgeType.Car,
                            Dots = 3,
                        },
                        new Edge()
                        {
                            From = 17,
                            To = 4,
                            Type = EdgeType.Car,
                            Dots = 2,
                        },
                        new Edge()
                        {
                            From = 17,
                            To = 26,
                            Type = EdgeType.Car,
                            Dots = 5,
                        }
                    }
                },

                new Node()
                {
                    Id = 18,
                    Name = "Sahara",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 18,
                            To = 24,
                            Type = EdgeType.Car,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 18,
                            To = 4,
                            Type = EdgeType.Car,
                            Dots = 7,
                        },

                        new Edge()
                        {
                            From = 18,
                            To = 15,
                            Type = EdgeType.Car,
                            Dots = 4,
                        }
                    },
                },

                new Node()
                {
                    Id = 19,
                    Name = "Sierra Leone",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 19,
                            To = 15,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 19,
                            To = 21,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 19,
                            To = 25,
                            Type = EdgeType.Car,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 19,
                            To = 5,
                            Type = EdgeType.Ship,
                            Dots = 2,
                        }
                    }
                },

                new Node()
                {
                    Id = 20,
                    Name = "Slavekysten",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 20,
                            To = 9,
                            Type = EdgeType.Ship,
                            Dots = 8,
                        },

                        new Edge()
                        {
                            From = 20,
                            To = 8,
                            Type = EdgeType.Ship,
                            Dots = 3,
                        },

                        new Edge()
                        {
                            From = 20,
                            To = 30,
                            Type = EdgeType.Car,
                            Dots = 6,
                        },

                        new Edge()
                        {
                            From = 20,
                            To = 25,
                            Type = EdgeType.Car,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 20,
                            To = 4,
                            Type = EdgeType.Car,
                            Dots = 6,
                        },

                        new Edge()
                        {
                            From = 20,
                            To = 3,
                            Type = EdgeType.Car,
                            Dots = 4,
                        }
                    }
                },

                new Node()
                {
                    Id = 21,
                    Name = "St Helena",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 21,
                            To = 13,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 21,
                            To = 19,
                            Type = EdgeType.Airline,
                            Dots = 0
                        }
                    }
                },

                new Node()
                {
                    Id = 22,
                    Name = "Suakin",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 22,
                            To = 29,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 22,
                            To = 2,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 22,
                            To = 4,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 22,
                            To = 0,
                            Type = EdgeType.Car,
                            Dots = 2,
                        }
                    }
                },

                new Node()
                {
                    Id = 23,
                    Name = "Tamatave",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 23,
                            To = 11,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 23,
                            To = 13,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        }
                    }
                },

                new Node()
                {
                    Id = 24,
                    Name = "Tanger",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 24,
                            To = 26,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 24,
                            To = 15,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 24,
                            To = 27,
                            Type = EdgeType.Ship,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 24,
                            To = 27,
                            Type = EdgeType.Car,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 24,
                            To = 6,
                            Type = EdgeType.Ship,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 24,
                            To = 18,
                            Type = EdgeType.Car,
                            Dots = 4,
                        }
                    }
                },

                new Node()
                {
                    Id = 25,
                    Name = "Timbuktu",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 25,
                            To = 8,
                            Type = EdgeType.Car,
                            Dots = 3,
                        },

                        new Edge()
                        {
                            From = 25,
                            To = 20,
                            Type = EdgeType.Car,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 25,
                            To = 19,
                            Type = EdgeType.Car,
                            Dots = 4,
                        }
                    }
                },

                new Node()
                {
                    Id = 26,
                    Name = "Tripoli",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 26,
                            To = 4,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 26,
                            To = 24,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 26,
                            To = 8,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 26,
                            To = 27,
                            Type = EdgeType.Car,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 26,
                            To = 17,
                            Type = EdgeType.Car,
                            Dots = 5,
                        }
                    }
                },

                new Node()
                {
                    Id = 27,
                    Name = "Tunis",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 27,
                            To = 24,
                            Type = EdgeType.Car,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 27,
                            To = 2,
                            Type = EdgeType.Ship,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 27,
                            To = 24,
                            Type = EdgeType.Ship,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 27,
                            To = 26,
                            Type = EdgeType.Car,
                            Dots = 2,
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
                    Id = 28,
                    Name = "Victoriafaldene",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 28,
                            To = 7,
                            Type = EdgeType.Car,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 28,
                            To = 16,
                            Type = EdgeType.Car,
                            Dots = 4,
                        },

                        new Edge()
                        {
                            From = 28,
                            To = 9,
                            Type = EdgeType.Car,
                            Dots = 3,
                        },

                        new Edge()
                        {
                            From = 28,
                            To = 14,
                            Type = EdgeType.Car,
                            Dots = 10,
                        }
                    }
                },

                new Node()
                {
                    Id = 29,
                    Name = "Victoriasoeen",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 29,
                            To = 22,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 29,
                            To = 7,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 29,
                            To = 11,
                            Type = EdgeType.Airline,
                            Dots = 0,
                        },

                        new Edge()
                        {
                            From = 29,
                            To = 31,
                            Type = EdgeType.Car,
                            Dots = 5,
                        },

                        new Edge()
                        {
                            From = 29,
                            To = 16,
                            Type = EdgeType.Car,
                            Dots = 5,
                        },

                        new Edge()
                        {
                            From = 29,
                            To = 1,
                            Type = EdgeType.Car,
                            Dots = 1,
                        },

                        new Edge()
                        {
                            From = 29,
                            To = 0,
                            Type = EdgeType.Car,
                            Dots = 2,
                        }
                    }
                },

                new Node()
                {
                    Id = 30,
                    Name = "Wadai",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 30,
                            To = 20,
                            Type = EdgeType.Car,
                            Dots = 6,
                        },

                        new Edge()
                        {
                            From = 30,
                            To = 3,
                            Type = EdgeType.Car,
                            Dots = 5,
                        },

                        new Edge()
                        {
                            From = 30,
                            To = 4,
                            Type = EdgeType.Car,
                            Dots = 3,
                        }
                    }
                },

                new Node()
                {
                    Id = 31,
                    Name = "Zanzibar",
                    Edges = new List<Edge>()
                    {
                        new Edge()
                        {
                            From = 31,
                            To = 16,
                            Type = EdgeType.Car,
                            Dots = 2,
                        },

                        new Edge()
                        {
                            From = 31,
                            To = 11,
                            Type = EdgeType.Car,
                            Dots = 5,
                        },

                        new Edge()
                        {
                            From = 31,
                            To = 29,
                            Type = EdgeType.Car,
                            Dots = 5,
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



