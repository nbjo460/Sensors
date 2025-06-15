using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


public class LocationNotInRange : Exception
{
    int Location;
    int MaxLocation;
    public LocationNotInRange(int _location, int _max_location) : base($"The Location: {_location}, is not within 1 and {_max_location}")
    {
        Location = _location;
        MaxLocation = _max_location;
    }

    
}


