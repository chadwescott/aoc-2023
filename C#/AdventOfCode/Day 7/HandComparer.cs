namespace AdventOfCode.Day_7
{
  public class HandComparer : IComparer<Hand>
  {
    public char[] Cards = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

    private readonly bool _jokers = false;

    public HandComparer(bool jokers)
    {
      _jokers = jokers;
    }

    public int Compare(Hand? x, Hand? y)
    {
      var xStrength = HandStrength(x);
      var yStrength = HandStrength(y);

      return xStrength > yStrength ? 1
        : xStrength < yStrength ? -1
        : GetTieStrength(x, y);
    }

    public int HandStrength(Hand hand)
    {
      return OfKind(hand, 5) ? 7
        : OfKind(hand, 4) ? 6
        : FullHouse(hand) ? 5
        : OfKind(hand, 3) ? 4
        : TwoPair(hand) ? 3
        : OfKind(hand, 2) ? 2 : 1;
    }

    public int GetTieStrength(Hand x, Hand y)
    {
      for (int i = 0; i < x.Cards.Length && i < y.Cards.Length; i++)
      {
        if (x.Cards[i] == y.Cards[i]) { continue; }
        return _jokers
          ? x.Cards[i] == 'J' ? -1 : y.Cards[i] == 'J' ? 1 : Array.IndexOf(Cards, x.Cards[i]) > Array.IndexOf(Cards, y.Cards[i]) ? 1 : -1
          : Array.IndexOf(Cards, x.Cards[i]) > Array.IndexOf(Cards, y.Cards[i]) ? 1 : -1;
      }
      return 0;
    }

    private bool OfKind(Hand hand, int number)
    {
      return _jokers
        ? hand.Cards.Any(card => hand.Cards.Count(c => c == card || c == 'J') == number)
        : hand.Cards.Any(card => hand.Cards.Count(c => c == card) == number);
    }

    private bool FullHouse(Hand hand)
    {
      return _jokers && hand.Cards.Any(c => c == 'J')
        ? hand.Cards.Where(c => c != 'J').Any(c1 => hand.Cards.Count(c => c == c1) == 2
          && hand.Cards.Any(c2 => hand.Cards.Count(c => c == c2 && c1 != c2) == 2))

        : hand.Cards.Any(card => hand.Cards.Count(c => c == card) == 3)
          && hand.Cards.Any(card => hand.Cards.Count(c => c == card) == 2);
    }

    private bool TwoPair(Hand hand)
    {
      return _jokers
        ? hand.Cards.Any(c1 => hand.Cards.Count(c => c == c1 && c != 'J') == 2
          && hand.Cards.Any(c2 => hand.Cards.Count(c => (c == c2 || c == 'J') && c1 != c2) == 2))
        : hand.Cards.Any(c1 => hand.Cards.Count(c => c == c1) == 2
          && hand.Cards.Any(c2 => hand.Cards.Count(c => c == c2 && c1 != c2) == 2));
    }
  }
}
