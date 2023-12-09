namespace AdventOfCode.Day_9
{
  public class OasisReport
  {
    public long CalculateReportValue(string input, bool normal)
    {
      long total = 0;

      foreach (var line in input.Split("\n"))
      {
        var data = GetDataFromLine(line);
        total += normal ? GetNormalValue(data) : GetBackwardsValue(data);
      }

      return total;
    }

    private List<List<long>> GetDataFromLine(string line)
    {
      var numbers = line.Trim('\r').Split(" ").Select(x => long.Parse(x)).ToList();
      List<long> differences = numbers;
      var data = new List<List<long>>();

      do
      {
        data.Add(differences);
        differences = GetNumberDifferences(differences);
      }
      while (differences.Any(x => x != 0));

      return data;
    }

    public long GetNormalValue(List<List<long>> data)
    {
      for (int i = data.Count() - 1; i > 0; i--)
      {
        var difference = data[i].Last() + data[i - 1].Last();
        data[i - 1].Add(difference);
      }
      return data.First().Last();
    }

    public long GetBackwardsValue(List<List<long>> data)
    {
      for (int i = data.Count() - 2; i >= 0; i--)
      {
        var difference = data[i].First() - data[i + 1].First();
        data[i].Insert(0, difference);
      }
      return data.First().First(); 
    }

    private List<long> GetNumberDifferences(List<long> numbers)
    {
        return numbers.Select((n, i) => i == 0 ? -1 : numbers[i] - numbers[i - 1])
          .Skip(1)
          .ToList();
    }
  }
}
