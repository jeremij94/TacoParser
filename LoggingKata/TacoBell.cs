using System;
namespace LoggingKata

    //created TacoBell class and had it inherit from ITrackable
{
    internal class TacoBell : ITrackable 
    {
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}

