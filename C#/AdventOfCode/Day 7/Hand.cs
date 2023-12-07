namespace AdventOfCode.Day_7
{
  public class Hand
  {
    public char[] Cards { get; init; }
    public int Value { get; init; }

    public Hand(char[] cards, int value)
    {
      Cards = cards;
      Value = value;
    }
  }
}
