using AdventOfCode.Day_6;

namespace AdventOfCodeTests.Day_6
{
  [TestClass]
  public class CamelCardsTests
  {
    private readonly ToyBoat _target = new ToyBoat();

    private readonly RaceData[] _sample = new[] {
      new RaceData {
        Time = 7,
        Distance = 9
      },
      new RaceData {
        Time = 15,
        Distance = 40
      },
      new RaceData {
        Time = 30,
        Distance = 200
      }
    };

    private readonly RaceData[] _input = new[] {
      new RaceData {
        Time = 35,
        Distance = 213
      },
      new RaceData {
        Time = 69,
        Distance = 1168
      },
      new RaceData {
        Time = 68,
        Distance = 1086
      },
      new RaceData {
        Time = 87,
        Distance = 1248
      }
    };

    [TestMethod]
    public void MultiplyWaysToWinTests()
    {
      var actual = _target.MultiplyWaysToWin(_sample);
      Assert.AreEqual(288, actual);

      actual = _target.MultiplyWaysToWin(_input);
      Assert.AreEqual(170000, actual);

      actual = _target.WaysToWin(new RaceData
      {
        Time = 71530,
        Distance = 940200
      });
      Assert.AreEqual(71503, actual);
    }

    [TestMethod]
    public void WaysToWinTests()
    {
      var actual = _target.WaysToWin(new RaceData
      {
        Time = 71530,
        Distance = 940200
      });
      Assert.AreEqual(71503, actual);

      actual = _target.WaysToWin(new RaceData
      {
        Time = 35696887,
        Distance = 213116810861248
      });
      Assert.AreEqual(20537782, actual);
    }
  }
}
