namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ',' - done
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong - done
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                logger.LogError("Sorry! Something went wrong.");

                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

            double lat = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`


            // You'll need to create a TacoBell class   -done
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            Point newCoordinates = new Point();
            newCoordinates.Longitude = longitude;
            newCoordinates.Latitude = lat;

            var newLocation = new TacoBell()
            {
                Location = newCoordinates,
                Name = name
            };

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return newLocation;
        }
    }
}