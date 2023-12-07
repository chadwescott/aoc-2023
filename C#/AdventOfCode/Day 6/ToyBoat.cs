namespace AdventOfCode.Day_6
{
  public class ToyBoat
  {
    private readonly object _lock = new object();

    public int WaysToWin(RaceData raceData)
    {
      var waysToWin = 0;
      Parallel.For(0, raceData.Time, i =>
      {
        if (i * (raceData.Time - i) > raceData.Distance)
        {
          lock (_lock) { waysToWin++; }
        }
      });
      return waysToWin;
    }

    public int MultiplyWaysToWin(RaceData[] raceData)
    {
      var total = 1;
      foreach (var data in raceData)
      {
        total *= WaysToWin(data);
      }

      return total;
    }
  }
}
