using System;


public class LocationNotInRange : Exception
{
    public int Location;
    public int MaxLocation;
    public LocationNotInRange(int _location, int _max_location) : base($"The Location: {_location}, is not within 1 and {_max_location}")
    {
        Location = _location;
        MaxLocation = _max_location;
    }
}
public class RankDoesNotExist : Exception
{
    public static string[] TypesOfRanks;
    public string RanksSpllited;
    public string Rank;
    private static string JoinsRanksToString(string[] _typesOsRanks)
    {
        string joined = string.Join(", ", _typesOsRanks);
        return joined+".";
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
public class SensorDoesNotExist : Exception
{
    public static string[] TypesOfSensors;
    public string SensorsSpllited;
    public string Sensor;
    private static string JoinsSensorsToString(string[] _typesOsSensors)
    {
        string joined = string.Join(", ", _typesOsSensors);
        return joined + ".";
    }

    public SensorDoesNotExist(string[] _typesOfSensors, string _sensor) :
        base($"You wrote Sensor: {_sensor}.\n" +
        $"You can write only one of them:\n" +
        $"{JoinsSensorsToString(_typesOfSensors)}")
    {
        TypesOfSensors = _typesOfSensors;
        Sensor = _sensor;
    }
}
public class MixtureDoseNotMatch : Exception
{
    public static string[] Mixture;
    private static string JoinsSensorsToString(string[] _typesOsSensors)
    {
        string joined = string.Join(", ", _typesOsSensors);
        return joined + ".";
    }

    public MixtureDoseNotMatch(string[] _mixture) :
        base($"You wrote the Mixture: {JoinsSensorsToString(_mixture)}.\n" +
        $"Unfortunately, you got wrong.\n" +
        $"You wiil get punished." )
    {
        Mixture = _mixture;
    }
}

public class NotMixture : Exception
{
    public string sensorName;
    public NotMixture(string _sensorName) : base($"The string include only one sensor.")
    {
        sensorName = _sensorName;
    }
}


