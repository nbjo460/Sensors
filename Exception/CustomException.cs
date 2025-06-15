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
public class RankDoesNotExist : Exception
{
    static string[] TypesOfRanks;
    string RanksSpllited;
    string Rank;
    private static string JoinsRanksToString(string[] _typesOsRanks)
    {
        string joined = "";
        for (int i = 0; i < TypesOfRanks.Length; i++)
        {
            joined = joined + " " + TypesOfRanks[i];
        }
        joined.TrimEnd();
        return joined;

    }

    public RankDoesNotExist(string[] _typesOfRanks, string _rank) : 
        base($"You wrote Rank: {_rank}.\n" +
        $"You can write only one of them:\n" +
        $"{JoinsRanksToString(_typesOfRanks)}")
    {
        TypesOfRanks = _typesOfRanks;
        Rank = _rank;
    }
}


