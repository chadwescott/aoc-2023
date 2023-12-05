namespace AdventOfCode.Day_5
{
  public class SeedMap
  {
    public List<long> Seeds = new List<long>();
    public Dictionary<long, long> SeedToSoilMap = new Dictionary<long, long>();
    public Dictionary<long, long> SoilToFertilizerMap = new Dictionary<long, long>();
    public Dictionary<long, long> FertilizerToWaterMap = new Dictionary<long, long>();
    public Dictionary<long, long> WaterToLightMap = new Dictionary<long, long>();
    public Dictionary<long, long> LightToTemperatureMap = new Dictionary<long, long>();
    public Dictionary<long, long> TemperatureToHumidityMap = new Dictionary<long, long>();
    public Dictionary<long, long> HumidityToLocationMap = new Dictionary<long, long>();
  }

  public class MapData
  {
    public long Source { get; set; }
    public long Destination { get; set; }
    public long Range { get; set; }
  }
}
