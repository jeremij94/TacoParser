﻿using System;
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
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            for (int i = 0; i < lines.Length; i++)
            {
                if(lines.Length == 0)
                {
                    logger.LogError("Insufficient information!");
                }
                else if(lines.Length == 1)
                {
                    logger.LogWarning("Limited information may cause varied results.");
                }
            }

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable restaurant1 = null;
            ITrackable restaurant2 = null;
            double distance = 0.0;
            GeoCoordinate corA = new GeoCoordinate();
            GeoCoordinate corB = new GeoCoordinate();
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];

                // Create a new corA Coordinate with your locA's lat and long 
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

             // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];

                    // Create a new Coordinate with your locB's lat and long
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        restaurant1 = locA;
                        restaurant2 = locB;
                    }
                }
            }

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            var miFromMeters = Math.Round(distance / 1609);
            Console.WriteLine();
            Console.WriteLine($"The two TacoBells farthest from each other are {restaurant1.Name} and {restaurant2.Name}");
            Console.WriteLine($"Distance: {distance} meters or {miFromMeters} miles");
            Console.ReadKey();
            
        }
    }
}
