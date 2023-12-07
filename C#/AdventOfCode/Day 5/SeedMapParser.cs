namespace AdventOfCode.Day_5
{
  public class SeedMapParser
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

    public SeedMap ParseSeedMap(string input, bool useRange = false)
    {
      var map = new SeedMap();
      var dataType = DataType.None;
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
          dataType = InputKeyTypeMap[parsedLine];
          continue;
        }

        if (parsedLine == "") { dataType = DataType.None; continue; }

        ProcessLine(parsedLine, map, dataType);
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

    private void ProcessLine(string line, SeedMap map, DataType dataType)
    {
      var data = line.Split(" ");
      if (data.Length != 3) { return; }

      var destination = long.Parse(data[0]);
      var source = long.Parse(data[1]);
      var range = long.Parse(data[2]);

      switch (dataType)
      {
        case DataType.SeedToSoil:
          map.SeedToSoilMap.Add(new MapData { Source = source, Destination = destination, Range = range });
          break;
        case DataType.SoilToFertilizer:
          map.SoilToFertilizerMap.Add(new MapData { Source = source, Destination = destination, Range = range });
          break;
        case DataType.FertilizerToWater:
          map.FertilizerToWaterMap.Add(new MapData { Source = source, Destination = destination, Range = range });
          break;
        case DataType.WaterToLight:
          map.WaterToLightMap.Add(new MapData { Source = source, Destination = destination, Range = range });
          break;
        case DataType.LightToTemperature:
          map.LightToTemperatureMap.Add(new MapData { Source = source, Destination = destination, Range = range });
          break;
        case DataType.TemperatureToHumidity:
          map.TemperatureToHumidityMap.Add(new MapData { Source = source, Destination = destination, Range = range });
          break;
        case DataType.HumidityToLocation:
          map.HumidityToLocationMap.Add(new MapData { Source = source, Destination = destination, Range = range });
          break;
      }
    }

    public SeedData GetSeedData(long seed, SeedMap seedMap)
    {
      var data = new SeedData { Seed = seed };

      var soilMap = seedMap.SeedToSoilMap.SingleOrDefault(x => x.Source <= data.Seed && x.Source + x.Range > data.Seed);
      data.Soil = soilMap == null ? data.Seed : data.Seed - soilMap.Source.Value + soilMap.Destination.Value;

      var fertilizerMap = seedMap.SoilToFertilizerMap.SingleOrDefault(x => x.Source <= data.Soil && x.Source + x.Range > data.Soil);
      data.Fertilizer = fertilizerMap == null ? data.Soil : data.Soil - fertilizerMap.Source.Value + fertilizerMap.Destination.Value;

      var waterMap = seedMap.FertilizerToWaterMap.SingleOrDefault(x => x.Source <= data.Fertilizer && x.Source + x.Range > data.Fertilizer);
      data.Water = waterMap == null ? data.Fertilizer : data.Fertilizer - waterMap.Source.Value + waterMap.Destination.Value;

      var lightMap = seedMap.WaterToLightMap.SingleOrDefault(x => x.Source <= data.Water && x.Source + x.Range > data.Water);
      data.Light = lightMap == null ? data.Water : data.Water - lightMap.Source.Value + lightMap.Destination.Value;

      var temperatureMap = seedMap.LightToTemperatureMap.SingleOrDefault(x => x.Source <= data.Light && x.Source + x.Range > data.Light);
      data.Temperature = temperatureMap == null ? data.Light : data.Light - temperatureMap.Source.Value + temperatureMap.Destination.Value;

      var humidityMap = seedMap.TemperatureToHumidityMap.SingleOrDefault(x => x.Source <= data.Temperature && x.Source + x.Range > data.Temperature);
      data.Humidity = humidityMap == null ? data.Temperature : data.Temperature - humidityMap.Source.Value + humidityMap.Destination.Value;

      var locationMap = seedMap.HumidityToLocationMap.SingleOrDefault(x => x.Source <= data.Humidity && x.Source + x.Range > data.Humidity);
      data.Location = locationMap == null ? data.Humidity : data.Humidity - locationMap.Source.Value + locationMap.Destination.Value;

      return data;
    }

    public long MinimumLocationWithSeed(SeedMap map)
    {
      foreach (var locationMap in map.HumidityToLocationMap.OrderBy(x => x.Destination))
      {
        var humidityMap = map.TemperatureToHumidityMap.FirstOrDefault(x => MapDataExists(x, locationMap))
          ?? new MapData{ Source = locationMap.Destination, Destination = locationMap.Destination, Range = 1 };
        var temperatureMap = map.LightToTemperatureMap.FirstOrDefault(x => MapDataExists(x, humidityMap))
          ?? new MapData{ Source = humidityMap.Destination, Destination = humidityMap.Destination, Range = 1 };
        var lightMap = map.WaterToLightMap.FirstOrDefault(x => MapDataExists(x, temperatureMap))
          ?? new MapData{ Source = temperatureMap.Destination, Destination = temperatureMap.Destination, Range = 1 };
        var waterMap = map.FertilizerToWaterMap.FirstOrDefault(x => MapDataExists(x, lightMap))
          ?? new MapData{ Source = lightMap.Destination, Destination = lightMap.Destination, Range = 1 };
        var fertilizerMap = map.SoilToFertilizerMap.FirstOrDefault(x => MapDataExists(x, waterMap))
          ?? new MapData{ Source = waterMap.Destination, Destination = waterMap.Destination, Range = 1 };
        var soilMap = map.SeedToSoilMap.FirstOrDefault(x => MapDataExists(x, fertilizerMap))
          ?? new MapData{ Source = fertilizerMap.Destination, Destination = fertilizerMap.Destination, Range = 1 };
        if (map.Seeds.Any(x => x >= soilMap.Source && x < soilMap.Source + soilMap.Range))
        {
          return GetSeedData(map.Seeds.First(x => x >= soilMap.Source && x < soilMap.Source + soilMap.Range), map).Location;
        }
      }
      return -1;
    }

    private bool MapDataExists(MapData parent, MapData child)
    {
      return parent.Destination <= child.Source && parent.Destination + parent.Range > child.Source;
    }
  }
}
