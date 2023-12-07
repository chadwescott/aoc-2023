using AdventOfCode.Day_7;

namespace AdventOfCodeTests.Day_7
{
  [TestClass]
  public class HandComparerTests
  {
    [TestMethod]
    public void CompareHandsWithoutJokersTests()
    {
      var target = new HandComparer(false);

      var hand1 = new Hand(new[] { 'T', '5', '5', 'J', '5' }, 1);
      var hand2 = new Hand(new[] { '3', '2', 'T', '3', 'K' }, 2);

      Assert.AreEqual(1, target.Compare(hand1, hand2));

      var hands = new List<Hand> { hand1, hand2 }.OrderBy(hand => hand, target).ToArray();

      Assert.AreEqual(2, hands[0].Value);
      Assert.AreEqual(1, hands[1].Value);
    }

    [TestMethod]
    public void CompareHandsWithJokersTests()
    {
      var target = new HandComparer(true);

      var hand1 = new Hand(new[] { 'T', '4', '5', 'J', '5' }, 1);
      var hand2 = new Hand(new[] { 'Q', '2', 'T', 'Q', 'K' }, 2);

      Assert.AreEqual(1, target.Compare(hand1, hand2));

      var hands = new List<Hand> { hand1, hand2 }.OrderBy(hand => hand, target).ToArray();

      Assert.AreEqual(2, hands[0].Value);
      Assert.AreEqual(1, hands[1].Value);

      hand1 = new Hand(new[] { 'T', '4', '5', 'J', '5' }, 1);
      hand2 = new Hand(new[] { 'Q', 'J', 'T', 'Q', 'K' }, 2);

      Assert.AreEqual(-1, target.Compare(hand1, hand2));

      hand1 = new Hand(new[] { 'Q', 'J', '5', '4', 'T' }, 1);
      hand2 = new Hand(new[] { 'Q', '2', 'T', 'Q', 'K' }, 2);

      Assert.AreEqual(-1, target.Compare(hand1, hand2));
    }

    [TestMethod]
    public void HandStrengthWithJokersTests()
    {
      var target = new HandComparer(true);

      Assert.AreEqual(7, target.HandStrength(new Hand(new[] { '5', '5', '5', 'J', '5' }, 1)));
      Assert.AreEqual(6, target.HandStrength(new Hand(new[] { '2', '5', '5', 'J', '5' }, 1)));
      Assert.AreEqual(5, target.HandStrength(new Hand(new[] { '2', '5', '5', 'J', '2' }, 1)));
      Assert.AreEqual(4, target.HandStrength(new Hand(new[] { '2', '3', '5', 'J', '2' }, 1)));
      Assert.AreEqual(2, target.HandStrength(new Hand(new[] { '2', '3', '5', 'J', '4' }, 1)));
    }
  }
}
