namespace AdventOfCode.Day_5
{
  public class SeedMapListParser
  {
    private Dictionary<string, DataType> InputKeyTypeMap = new Dictionary<string, DataType>()
    {
      { "seed-to-soil map:", DataType.SeedToSoil },
      { "soil-to-fertilizer map:", DataType.SoilToFertilizer },
      { "fertilizer-to-water map:", DataType.FertilizerToWater },
      { "water-to-light map:", DataType.WaterToLight },
      { "light-to-temperature map:", DataType.LightToTemperature },
      { "temperature-to-humidity map:", DataType.TemperatureToHumidity },
      { "humidity-to-location map:", DataType.HumidityToLocation }
    };

    public SeedMapList ParseSeedMapList(string input, bool useRange = false)
    {
      var map = new SeedMapList();
      var dataType = DataType.None;
      var previousType = DataType.None;

      foreach (var line in input.Split("\n"))
      {
        var parsedLine = line.Replace("\r", "");
        if (parsedLine.StartsWith("seeds: "))
        {
          map.Seeds = useRange ? GetSeedsWithRange(parsedLine) : GetSeeds(parsedLine);
          continue;
        }

        if (InputKeyTypeMap.ContainsKey(parsedLine))
        {
          previousType = dataType;
          dataType = InputKeyTypeMap[parsedLine];
          continue;
        }

        if (parsedLine == "") { continue; }

        ProcessLine(parsedLine, map, previousType, dataType);
      }

      return map;
    }

    private List<long> GetSeeds(string line)
    {
      line = line.Replace("seeds: ", "");
      return line.Split(" ").Select(x => long.Parse(x)).ToList();
    }

    private List<long> GetSeedsWithRange(string line)
    {
      line = line.Replace("seeds: ", "");
      var seeds = new List<long>();

      var data = line.Split(" ").Select(x => long.Parse(x)).ToArray();
      for (var i = 0; i < data.Length; i += 2)
      {
        for (var j = 0; j < data[i + 1]; j++)
        {
          seeds.Add(data[i] + j);
        }
      }

      return seeds;
    }

    private void ProcessLine(string line, SeedMapList map, DataType previousType, DataType dataType)
    {
      var data = line.Split(" ");
      if (data.Length != 3) { return; }

      var destination = long.Parse(data[0]);
      var source = long.Parse(data[1]);
      var range = long.Parse(data[2]);

      var mapData = new MapData { Source = source, Destination = destination, Range = range, Type = dataType };
      if (previousType != DataType.None)
      {
        mapData.Parent = map.MapData.Where(x => x.Type == previousType && x.Destination >= source && x.Destination < source + x.Range).FirstOrDefault();
      }

      map.MapData.Add(mapData);
    }

    public long MinimumLocationWithSeed(SeedMapList map)
    {
      foreach (var locationMap in map.MapData.Where(x => x.Type == DataType.HumidityToLocation).OrderBy(x => x.Destination))
      {
      }
      return -1;
    }
  }
}
