namespace AdventOfCode.Day_5
{
  public class SeedMapParser
  {
    private enum DataType
    {
      None,
      SeedToSoil,
      SoilToFertilizer,
      FertilizerToWater,
      WaterToLight,
      LightToTemperature,
      TemperatureToHumidity,
      HumidityToLocation
    }

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

    public SeedMap ParseSeedMap(string input)
    {
      var map = new SeedMap();
      var dataType = DataType.None;
      foreach (var line in input.Split("\n"))
      {
        var parsedLine = line.Replace("\r", "");
        if (parsedLine.StartsWith("seeds: "))
        {
          map.Seeds = GetSeeds(parsedLine);
          continue;
        }

        if (InputKeyTypeMap.ContainsKey(parsedLine))
        {
          dataType = InputKeyTypeMap[parsedLine];
          continue;
        }

        if (parsedLine == "") {  dataType = DataType.None; continue; }

        ProcessLine(parsedLine, map, dataType);
      }

      return map;
    }

    private List<long> GetSeeds(string line)
    {
      line = line.Replace("seeds: ", "");
      return line.Split(" ").Select(x => long.Parse(x)).ToList();
    }

    private void ProcessLine(string line, SeedMap map, DataType dataType)
    {
      var data = line.Split(" ");
      if (data.Length != 3) { return; }

      var destination = long.Parse(data[0]);
      var source = long.Parse(data[1]);
      var range = long.Parse(data[2]);

      for (var i = 0; i < range; i++)
      {
        switch(dataType)
        {
          case DataType.SeedToSoil:
            map.SeedToSoilMap[source + i] = destination + i;
            break;
          case DataType.SoilToFertilizer:
            map.SoilToFertilizerMap[source + i] = destination + i;
            break;
          case DataType.FertilizerToWater:
            map.FertilizerToWaterMap[source + i] = destination + i;
            break;
          case DataType.WaterToLight:
            map.WaterToLightMap[source + i] = destination + i;
            break;
          case DataType.LightToTemperature:
            map.LightToTemperatureMap[source + i] = destination + i;
            break;
          case DataType.TemperatureToHumidity:
            map.TemperatureToHumidityMap[source + i] = destination + i;
            break;
          case DataType.HumidityToLocation:
            map.HumidityToLocationMap[source + i] = destination + i;
            break;
        }
      }
    }

    public SeedData GetSeedData(long seed, SeedMap seedMap)
    {
      var data = new SeedData { Seed = seed };
      data.Soil = seedMap.SeedToSoilMap.ContainsKey(seed) ? seedMap.SeedToSoilMap[seed] : seed;
      data.Fertilizer = seedMap.SoilToFertilizerMap.ContainsKey(data.Soil) ? seedMap.SoilToFertilizerMap[data.Soil] : data.Soil;
      data.Water = seedMap.FertilizerToWaterMap.ContainsKey(data.Fertilizer) ? seedMap.FertilizerToWaterMap[data.Fertilizer] : data.Fertilizer;
      data.Light = seedMap.WaterToLightMap.ContainsKey(data.Water) ? seedMap.WaterToLightMap[data.Water] : data.Water;
      data.Temperature = seedMap.LightToTemperatureMap.ContainsKey(data.Light) ? seedMap.LightToTemperatureMap[data.Light] : data.Light;
      data.Humidity = seedMap.TemperatureToHumidityMap.ContainsKey(data.Temperature) ? seedMap.TemperatureToHumidityMap[data.Temperature] : data.Temperature;
      data.Location = seedMap.HumidityToLocationMap.ContainsKey(data.Humidity) ? seedMap.HumidityToLocationMap[data.Humidity] : data.Humidity;
      return data;
    }
  }
}
