using System.ComponentModel.DataAnnotations;

namespace AdventOfCode.Day_5
{
  public class SeedMap
  {
    public List<long> Seeds = new List<long>();
    public List<MapData> SeedToSoilMap = new List<MapData>();
    public List<MapData> SoilToFertilizerMap = new List<MapData>();
    public List<MapData> FertilizerToWaterMap = new List<MapData>();
    public List<MapData> WaterToLightMap = new List<MapData>();
    public List<MapData> LightToTemperatureMap = new List<MapData>();
    public List<MapData> TemperatureToHumidityMap = new List<MapData>();
    public List<MapData> HumidityToLocationMap = new List<MapData>();
  }
  public class SeedMapList
  {
    public List<long> Seeds = new List<long>();
    public List<MapData> MapData = new List<MapData>();
  }


  public class MapData
  {
    public DataType Type { get; set; } = DataType.None;
    public long? Source { get; set; }
    public long? Destination { get; set; }
    public long Range { get; set; }
    public MapData? Parent { get; set; }
  }
}
