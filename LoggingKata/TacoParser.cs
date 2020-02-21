﻿namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            if (line == null)
            {
                return null;
            }

            var cells = line.Split(',');


            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogError("Something went wrong! Array length is less than 3");
                return null;
            }

            Point cords = new Point();
            TacoBell restaurant = new TacoBell();
            // grab the latitude from your array at index 0
            cords.Latitude = double.Parse(cells[0]);

            // grab the longitude from your array at index 1
            cords.Longitude = double.Parse(cells[1]);

            // grab the name from your array at index 2
            restaurant.Name = cells[2];
            restaurant.Location = cords;

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
            return restaurant;

            // Do not fail if one record parsing fails, return null
            // TODO Implement
        }
    }
}