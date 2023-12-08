using AdventOfCode.Utils;

namespace AdventOfCode.Day_8
{
  public class Navigator
  {
    public const string StartingLocation = "AAA";
    public const string TerminalLocation = "ZZZ";

    public long NormalSteps(Map map)
    {
      var currentMapEntry = map.MapEntries.Single(x => x.Location == StartingLocation);
      var steps = 0;
      while(currentMapEntry.Location != TerminalLocation) {
        var direction = map.Directions[steps % map.Directions.Length];
        currentMapEntry = map.MapEntries.Where(x => x.Location == (direction == Directions.Left ? currentMapEntry.LeftDestination : currentMapEntry.RightDestination)).Single();
        steps++;
      }

      return steps;
    }

    public long GhostSteps(Map map)
    {
      var currentMapEntries = map.MapEntries.Where(x => x.Location.EndsWith('A')).ToArray();
      var minimumSteps = new int[currentMapEntries.Length];
      Parallel.For(0, currentMapEntries.Length, i => {
        var currentMapEntry = currentMapEntries[i];
        var steps = 0;

        while(!currentMapEntry.Location.EndsWith('Z')) {
          var direction = map.Directions[steps % map.Directions.Length];
          currentMapEntry = map.MapEntries.Where(x => x.Location == (direction == Directions.Left ? currentMapEntry.LeftDestination : currentMapEntry.RightDestination)).Single();
          steps++;
        }

        minimumSteps[i] = steps;
      });

      return minimumSteps.LeastCommonMultiple();
    }

    public Map GetMap(string data)
    {
      var lines = data.Split("\n");
      var directions = lines[0].Trim('\r').ToCharArray().Select(c => c == 'L' ? Directions.Left : Directions.Right).ToArray();
      var mapEntries = lines.Skip(2).Select(line =>
      {
        var tokens = line.Split(" = ");
        var destinations = tokens[1].Trim(new char[]{ '(', ')', '\r' }).Split(", ");
        return new MapEntry
        {
          Location = tokens[0],
          LeftDestination = destinations[0],
          RightDestination = destinations[1]
        };
      }).ToArray();

      return new Map { Directions = directions, MapEntries = mapEntries };
    }
  }
}
