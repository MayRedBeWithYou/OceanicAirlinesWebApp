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
            get;
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
                        },
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
                        },
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
                            },
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
                        },
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
                            },

                        }
                    },

                    new Node()
                    {
                        Id = 5,
                        Name = "Dakar",
                        Edges= new List<Edge>()
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
                            },

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
                            },
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
                                },
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
                                },
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
                               },
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
                               },
                           }
                    },

                    new Node()
                    {
                        Id = 17,
                        Name = "Omdurman",
                        Edges= new List<Edge>()
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
                            },
                        },
                    },
                    
                    new Node()
                    {
                        Id = 18,
                        Name = "Sahara",
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                            },
                        }
                    },

                    new Node()
                    {
                        Id = 24,
                        Name = "Tanger",
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                            },
                        }
                    },

                    new Node()
                    {
                        Id = 26,
                        Name = "Tripoli",
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                            }

                        }
                    },

                    new Node()
                    {
                        Id = 28,
                        Name = "Victoriafaldene",
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                        Edges= new List<Edge>()
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
                            },

                        }
                },


                }
            }

        public Route Dijkstra(int from, int to, Func<Edge, int> edgeWeight)
        {
            int[] dist = new int[33];
            List<Edge>[] routes = new List<Edge>[33];
            foreach (List<Edge> route in routes) route = new List<Edge>();
            foreach (Node node in Nodes)
            {

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
