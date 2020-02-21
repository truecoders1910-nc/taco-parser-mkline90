using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";


        static void Main(string[] args)
        {

            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            //logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
            logger.LogInfo("Begin parsing");
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable locA = null;
            ITrackable locB = null;
            double distance = 0;


            for (int i = 0; i < locations.Length; i++)
            {
                var corA = new GeoCoordinate();
                corA.Latitude = locations[i].Location.Latitude;
                corA.Longitude = locations[i].Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    GeoCoordinate corB = new GeoCoordinate();
                    corB.Latitude = locations[j].Location.Latitude;
                    corB.Longitude = locations[j].Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        locA = locations[i];
                        locB = locations[j];
                    }
                }

            }
            Console.WriteLine($"The two TacoBell restaurants located the furthest apart are: \n" +
                $"{locA.Name} and {locB.Name}");




            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops
        }

        

    }
}