namespace Galactic_GPS
{
    using System;

    struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }

            private set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Latitude must be greather than -90 and smaller than 90.");
                }
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }

            private set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be greather than -180 and smaller than 180.");
                }
                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get
            {
                return this.planet;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}",
                this.Latitude, this.Longitude, this.Planet);
        }
    }
}
