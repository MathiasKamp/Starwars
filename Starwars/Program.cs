using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text.RegularExpressions;


namespace Starwars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Planet> planets = LoadData();
            // Opgave 1 start
            var planetsOpgave1 = from planet1 in planets where planet1.Name.StartsWith("M") select planet1.Name;
            Console.WriteLine("Opgave 1.");
            foreach (var planetName in planetsOpgave1)
            {
                Console.WriteLine(planetName);
            }
            // opgave 1 done

            // opgave 2 start
            Console.WriteLine("Opgave 2.");
            var planetsOpgave2 = from planet2 in planets where planet2.Name.ToLower().Contains("y") select planet2.Name;
            foreach (var planetName in planetsOpgave2)
            {
                Console.WriteLine(planetName);
            }
            // opgave 2 done

            // opgave 3 start
            var planetsOpgave3 = from planet3 in planets
                where planet3.Name.Length > 9 && planet3.Name.Length < 15
                select planet3.Name;
            Console.WriteLine("Opgave 3.");
            foreach (var planetName in planetsOpgave3)
            {
                Console.WriteLine(planetName);
            }

            // opgave 3 done

            // opgave 4 start
            Console.WriteLine("Opgave 4.");
            var planetsOpgave4 = from planet4 in planets
                where planet4.Name[1].Equals('a') && planet4.Name.EndsWith("e")
                select planet4.Name;
            foreach (var planetName in planetsOpgave4)
            {
                Console.WriteLine(planetName);
            }
            // opgave 4 done


            //opgave 5 start
            Console.WriteLine("Opgave 5.");
            var planetsOpgave5 = from planet5 in planets
                orderby planet5.RotationPeriod
                where planet5.RotationPeriod > 40
                select planet5.Name;
            foreach (var planetName in planetsOpgave5)
            {
                Console.WriteLine(planetName);
            }
            // opave 5 done

            // opgave 6 start
            Console.WriteLine("Opgave 6.");
            var planetsOpgave6 = from planet6 in planets
                where planet6.RotationPeriod > 10 && planet6.RotationPeriod < 20
                orderby planet6.Name
                select planet6.Name;

            foreach (var planetName in planetsOpgave6)
            {
                Console.WriteLine(planetName);
            }
            // opgave 6 done

            // opgave 7 start
            Console.WriteLine("Opgave 7.");
            var planetsOpgave7 = from planet7 in planets
                where planet7.RotationPeriod > 30
                orderby planet7.Name, planet7.RotationPeriod
                select planet7.Name;

            foreach (var planetName in planetsOpgave7)
            {
                Console.WriteLine(planetName);
            }
            // opgave 7 done

            // opgave 8 start

            Console.WriteLine("Opave 8");

            var planetsOpgave8 = from planet8 in planets
                where (planet8.RotationPeriod < 30 || planet8.SurfaceWater > 50) && planet8.Name.Contains("ba")
                orderby planet8.Name, planet8.SurfaceWater, planet8.RotationPeriod
                select planet8.Name;
            foreach (var planetName in planetsOpgave8)
            {
                Console.WriteLine(planetName);
            }

            // opgave 9 start
            Console.WriteLine("opgave 9.");

            var planetsOpgave9 = from planet9 in planets
                where planet9.SurfaceWater > 0
                orderby planet9.SurfaceWater descending
                select planet9.Name;

            foreach (var planetName in planetsOpgave9)
            {
                Console.WriteLine(planetName);
            }

            // opgave 9 done

            // opgave 10 start
            Console.WriteLine("opgave 10.");


            var planetsOpgave10 = from planet10 in planets
                where planet10.Diameter > 0 && planet10.Population > 0
                orderby 4 * Math.PI * planet10.Diameter / planet10.Population
                select planet10.Name;

            foreach (var planetName in planetsOpgave10)
            {
                Console.WriteLine(planetName);
            }

            // opgave 10 done

            // Opgave 11 start
            Console.WriteLine("Opgave 11.");

            var planetsOpgave11 = from planet in planets where planet.RotationPeriod > 0 select planet;

            var planetsCompared = planets.Except(planetsOpgave11, new NameComparer());

            foreach (var planet in planetsCompared)
            {
                Console.WriteLine(planet.Name);
            }

            // opgave 11 done

            // opgave 12 start
            Console.WriteLine("Opgave 12");
            var planetsWithNameStartA = from planet in planets
                where planet.Name.StartsWith("A") || planet.Name.EndsWith("s")
                select planet;


            var planetsWithRainForrest = from planet in planets
                where planet.Terrain != null && planet.Terrain.Contains("rainforests")
                select planet;


            var planetsAddedTogether = planetsWithNameStartA.Union(planetsWithRainForrest, new NameComparer());

            foreach (var planet in planetsAddedTogether)
            {
                Console.WriteLine(planet.Name);
            }

            // opgave 12 done


            // opgave 13 start

            Console.WriteLine("Opgave 13.");

            var planetsWithClimateDessert = from planet in planets
                where planet.Terrain != null && (planet.Terrain.Contains("deserts") ||
                                                 planet.Terrain.Contains("desert") ||
                                                 planet.Terrain.Contains("rocky deserts"))
                select planet;

            foreach (var planet in planetsWithClimateDessert)
            {
                Console.WriteLine(planet.Name);
            }
            // opgave 13 done

            // opgave 14 start
            Console.WriteLine("Opgave 14");
            var planetsWithClimateSwamp = from planet in planets
                where planet.Terrain != null && (planet.Terrain.Contains("swamps") || planet.Terrain.Contains("swamp"))
                orderby planet.RotationPeriod, planet.Name
                select planet;

            foreach (var planet in planetsWithClimateSwamp)
            {
                Console.WriteLine(planet.Name);
            }

            // opgave 14 done
            
            // opgave 15 start
            Console.WriteLine("opgave 15.");

            var doubleVokals = from planet in planets
                where Regex.IsMatch(planet.Name, @"([aeiuoy])\1")
                select planet;

            foreach (var planet in doubleVokals)
            {
                Console.WriteLine(planet.Name);
            }
            // opgave 15 done
            
            
            
            // opgave 16 start

            Console.WriteLine("Opgave 16.");
            var planetsOpave16 = from planet in planets
                where Regex.IsMatch(planet.Name, @"([kk ll rr nn])\1")
                orderby planet.Name descending
                select planet;

            foreach (var planet in planetsOpave16)
            {
                Console.WriteLine(planet.Name);
            }

            Console.ReadKey();
        }


        static List<Planet> LoadData()
        {
            List<Planet> planets = new List<Planet>()
            {
                new Planet
                {
                    Name = "Corellia", Terrain = new List<string> {"plains", "urban", "hills", "forests"},
                    RotationPeriod = 25, SurfaceWater = 70, Diameter = 11000, Population = 3000000000
                },
                new Planet
                {
                    Name = "Rodia", Terrain = new List<string> {"jungles", "oceans", "urban", "swamps"},
                    RotationPeriod = 29, SurfaceWater = 60, Diameter = 7549, Population = 1300000000
                },
                new Planet
                {
                    Name = "Nal Hutta", Terrain = new List<string> {"urban", "oceans", "bogs", "swamps"},
                    RotationPeriod = 87, Diameter = 12150, Population = 7000000000
                },
                new Planet
                {
                    Name = "Dantooine", Terrain = new List<string> {"savannas", "oceans", "mountains", "grasslands"},
                    RotationPeriod = 25, Diameter = 9830, Population = 1000
                },
                new Planet
                {
                    Name = "Bestine IV", Terrain = new List<string> {"rocky islands", "oceans"}, RotationPeriod = 26,
                    SurfaceWater = 98, Diameter = 6400, Population = 62000000
                },
                new Planet
                {
                    Name = "Ord Mantell", Terrain = new List<string> {"plains", "seas", "mesas"}, RotationPeriod = 26,
                    SurfaceWater = 10, Diameter = 14050, Population = 4000000000
                },
                new Planet
                {
                    Name = "Trandosha", Terrain = new List<string> {"mountains", "seas", "grasslands", "deserts"},
                    RotationPeriod = 25, Diameter = 0, Population = 42000000
                },
                new Planet
                {
                    Name = "Socorro", Terrain = new List<string> {"mountains", "deserts"}, RotationPeriod = 20,
                    Population = 300000000
                },
                new Planet
                {
                    Name = "Mon Cala", Terrain = new List<string> {"oceans", "reefs", "islands"}, RotationPeriod = 21,
                    SurfaceWater = 100, Diameter = 11030, Population = 27000000000
                },
                new Planet
                {
                    Name = "Chandrila", Terrain = new List<string> {"plains", "forests"}, RotationPeriod = 20,
                    SurfaceWater = 40, Diameter = 13500, Population = 1200000000
                },
                new Planet
                {
                    Name = "Sullust", Terrain = new List<string> {"mountains", "volcanoes", "rocky deserts"},
                    RotationPeriod = 20, SurfaceWater = 5, Diameter = 12780, Population = 18500000000
                },
                new Planet
                {
                    Name = "Toydaria", Terrain = new List<string> {"swamps", "lakes"}, RotationPeriod = 21,
                    Diameter = 7900, Population = 11000000
                },
                new Planet
                {
                    Name = "Malastare", Terrain = new List<string> {"swamps", "deserts", "jungles", "mountains"},
                    RotationPeriod = 26, Diameter = 18880, Population = 2000000000
                },
                new Planet
                {
                    Name = "Dathomir", Terrain = new List<string> {"forests", "deserts", "savannas"},
                    RotationPeriod = 24, Diameter = 10480, Population = 5200
                },
                new Planet
                {
                    Name = "Ryloth", Terrain = new List<string> {"mountains", "valleys", "deserts", "tundra"},
                    RotationPeriod = 30, SurfaceWater = 5, Diameter = 10600, Population = 1500000000
                },
                new Planet {Name = "Aleen Minor"},
                new Planet
                {
                    Name = "Vulpter", Terrain = new List<string> {"urban", "barren"}, RotationPeriod = 22,
                    Diameter = 14900, Population = 421000000
                },
                new Planet
                {
                    Name = "Troiken", Terrain = new List<string> {"desert", "tundra", "rainforests", "mountains"}
                },
                new Planet
                {
                    Name = "Tund", Terrain = new List<string> {"barren", "ash"}, RotationPeriod = 48, Diameter = 12190
                },
                new Planet
                {
                    Name = "Haruun Kal", Terrain = new List<string> {"toxic cloudsea", "plateaus", "volcanoes"},
                    RotationPeriod = 25, Diameter = 10120, Population = 705300
                },
                new Planet
                {
                    Name = "Cerea", Terrain = new List<string> {"verdant"}, RotationPeriod = 27, SurfaceWater = 20,
                    Population = 450000000
                },
                new Planet
                {
                    Name = "Glee Anselm", Terrain = new List<string> {"islands", "lakes", "swamps", "seas"},
                    RotationPeriod = 33, SurfaceWater = 80, Diameter = 15600, Population = 500000000
                },
                new Planet
                {
                    Name = "Iridonia", Terrain = new List<string> {"rocky canyons", "acid pools"}, RotationPeriod = 29
                },
                new Planet {Name = "Tholoth"},
                new Planet {Name = "Iktotch", Terrain = new List<string> {"rocky"}, RotationPeriod = 22},
                new Planet {Name = "Quermia",},
                new Planet {Name = "Dorin", RotationPeriod = 22, Diameter = 13400},
                new Planet
                {
                    Name = "Champala", Terrain = new List<string> {"oceans", "rainforests", "plateaus"},
                    RotationPeriod = 27, Population = 3500000000
                },
                new Planet {Name = "Mirial", Terrain = new List<string> {"deserts"}},
                new Planet {Name = "Serenno", Terrain = new List<string> {"rivers", "rainforests", "mountains"}},
                new Planet {Name = "Concord Dawn", Terrain = new List<string> {"jungles", "forests", "deserts"}},
                new Planet {Name = "Zolan"},
                new Planet
                {
                    Name = "Ojom", Terrain = new List<string> {"oceans", "glaciers"}, SurfaceWater = 100,
                    Population = 500000000
                },
                new Planet
                {
                    Name = "Skako", Terrain = new List<string> {"urban", "vines"}, RotationPeriod = 27,
                    Population = 500000000000
                },
                new Planet
                {
                    Name = "Muunilinst", Terrain = new List<string> {"plains", "forests", "hills", "mountains"},
                    RotationPeriod = 28, SurfaceWater = 25, Diameter = 13800, Population = 5000000000
                },
                new Planet {Name = "Shili", Terrain = new List<string> {"cities", "savannahs", "seas", "plains"}},
                new Planet
                {
                    Name = "Kalee", Terrain = new List<string> {"rainforests", "cliffs", "seas", "canyons"},
                    RotationPeriod = 23, Diameter = 13850, Population = 4000000000
                },
                new Planet {Name = "Umbara"},
                new Planet
                {
                    Name = "Tatooine", Terrain = new List<string> {"deserts"}, RotationPeriod = 23, SurfaceWater = 1,
                    Diameter = 10465, Population = 200000
                },
                new Planet {Name = "Jakku", Terrain = new List<string> {"deserts"}},
                new Planet
                {
                    Name = "Alderaan", Terrain = new List<string> {"grasslands", "mountains"}, RotationPeriod = 24,
                    SurfaceWater = 40, Diameter = 12500, Population = 2000000000
                },
                new Planet
                {
                    Name = "Yavin IV", Terrain = new List<string> {"rainforests", "jungle"}, RotationPeriod = 24,
                    SurfaceWater = 8, Diameter = 10200, Population = 1000
                },
                new Planet
                {
                    Name = "Hoth", Terrain = new List<string> {"tundra", "ice caves", "mountain ranges"},
                    RotationPeriod = 23, SurfaceWater = 100
                },
                new Planet
                {
                    Name = "Dagobah", Terrain = new List<string> {"swamp", "jungles"}, RotationPeriod = 23,
                    SurfaceWater = 8
                },
                new Planet
                {
                    Name = "Bespin", Terrain = new List<string> {"gas giant"}, RotationPeriod = 12, Diameter = 118000,
                    Population = 6000000
                },
                new Planet
                {
                    Name = "Endor", Terrain = new List<string> {"forests", "mountains", "lakes"}, RotationPeriod = 18,
                    SurfaceWater = 8, Diameter = 4900, Population = 30000000
                },
                new Planet
                {
                    Name = "Naboo", Terrain = new List<string> {"grassy hills", "swamps", "forests", "mountains"},
                    RotationPeriod = 26, SurfaceWater = 12, Diameter = 12120, Population = 4500000000
                },
                new Planet
                {
                    Name = "Coruscant", Terrain = new List<string> {"cityscape", "mountains"}, RotationPeriod = 24,
                    Diameter = 12240, Population = 1000000000000
                },
                new Planet
                {
                    Name = "Kamino", Terrain = new List<string> {"ocean"}, RotationPeriod = 27, SurfaceWater = 100,
                    Diameter = 19720, Population = 1000000000
                },
                new Planet
                {
                    Name = "Geonosis", Terrain = new List<string> {"rock", "desert", "mountain", "barren"},
                    RotationPeriod = 30, SurfaceWater = 5, Diameter = 11370, Population = 100000000000
                },
                new Planet
                {
                    Name = "Utapau", Terrain = new List<string> {"scrublands", "savanna", "canyons", "sinkholes"},
                    RotationPeriod = 27, SurfaceWater = 0.9f, Diameter = 12900, Population = 95000000
                },
                new Planet
                {
                    Name = "Mustafar", Terrain = new List<string> {"volcanoes", "lava rivers", "mountains", "caves"},
                    RotationPeriod = 36, Diameter = 4200, Population = 20000
                },
                new Planet
                {
                    Name = "Kashyyyk", Terrain = new List<string> {"jungle", "forests", "lakes", "rivers"},
                    RotationPeriod = 26, SurfaceWater = 60, Diameter = 12765, Population = 45000000
                },
                new Planet
                {
                    Name = "Polis Massa", Terrain = new List<string> {"airless", "asteroid"}, RotationPeriod = 24,
                    Diameter = 0, Population = 1000000
                },
                new Planet
                {
                    Name = "Mygeeto", Terrain = new List<string> {"glaciers", "mountains", "ice canyons"},
                    RotationPeriod = 12, Diameter = 10088, Population = 19000000
                },
                new Planet
                {
                    Name = "Felucia", Terrain = new List<string> {"fungus", "forests"}, RotationPeriod = 34,
                    Diameter = 9100, Population = 8500000
                },
                new Planet
                {
                    Name = "Cato Neimoidia",
                    Terrain = new List<string> {"mountains", "fields", "forests", "rock arches"}, RotationPeriod = 25,
                    Population = 10000000
                },
                new Planet
                {
                    Name = "Saleucami", Terrain = new List<string> {"caves", "deserts", "mountains", "volcanoes"},
                    RotationPeriod = 26, Population = 1400000000, Diameter = 14920
                },
                new Planet {Name = "Stewjon", Terrain = new List<string> {"grass"}},
                new Planet
                {
                    Name = "Eriadu", Terrain = new List<string> {"cityscape"}, RotationPeriod = 24, Diameter = 13490,
                    Population = 22000000000
                },
            };
            return planets;
        }
    }
}