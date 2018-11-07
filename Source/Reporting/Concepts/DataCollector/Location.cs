/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.DataCollector
{
    public class Location : Value<Location>
    {
        public static readonly Location NotSet;
        static Location()
        {
            NotSet = new Location(-1d, -1d);
        }
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
         }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public override string ToString() => Latitude.ToString("##.###") + ", " + Longitude.ToString("##.###");


        public bool IsValid()
        {
            return (Latitude >= -90 && Latitude <= 90) && (Longitude >= -180 && Longitude <= 180);
        }
    }
}
