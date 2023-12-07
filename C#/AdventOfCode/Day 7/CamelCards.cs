namespace AdventOfCode.Day_7
{
  public class CamelCards
  {
    public List<Hand> GetHands(string data)
    {
      return data.Split("\n").Select(line =>
      {
        var cardValues = line.Split(" ");
        var cards = cardValues[0].ToCharArray();
        var value = int.Parse(cardValues[1]);

        return new Hand(cards, value);
      }).ToList();
    }

    public long GetHandValues(List<Hand> hands, bool jokers)
    {
      var comparer = new HandComparer(jokers);
      return hands.OrderBy(hand => hand, comparer).Select((x, index) => x.Value * (index + 1)).Sum(x => x);
    }
  }
}
