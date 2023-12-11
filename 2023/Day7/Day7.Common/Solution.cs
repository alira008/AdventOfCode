namespace Day7.Common;

public static class Solution
{
    enum CardType
    {
        Joker,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    enum HandType
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind,
    }

    class Hand
    {
        public HandType Type { get; set; }
        public IEnumerable<CardType> Cards { get; set; }
        public int Bid { get; set; }

        public Hand(HandType type, IEnumerable<CardType> cards, int bid)
        {
            Type = type;
            Cards = cards;
            Bid = bid;
        }
    }

    static int IsHandStrongerThan(Hand current, Hand other)
    {
        if (current.Type == other.Type)
        {
            for (int i = 0; i < current.Cards.Count(); i++)
            {
                int cardComparison = IsCardStrongerThan(
                    current.Cards.ElementAt(i),
                    other.Cards.ElementAt(i)
                );
                if (cardComparison != 0)
                {
                    return cardComparison;
                }
            }
            return 0;
        }
        else if (current.Type > other.Type)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    static int IsCardStrongerThan(CardType card, CardType other)
    {
        if (card == other)
        {
            return 0;
        }
        else if (card > other)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public static int PartOne(string input)
    {
        var lines = input
            .Split(Environment.NewLine)
            .Where(line => line.Length > 0)
            .Select(line =>
            {
                var tokens = line.Split(" ");
                var hand = tokens[0].Select(c =>
                {
                    switch (c)
                    {
                        case '2':
                            return CardType.Two;
                        case '3':
                            return CardType.Three;
                        case '4':
                            return CardType.Four;
                        case '5':
                            return CardType.Five;
                        case '6':
                            return CardType.Six;
                        case '7':
                            return CardType.Seven;
                        case '8':
                            return CardType.Eight;
                        case '9':
                            return CardType.Nine;
                        case 'T':
                            return CardType.Ten;
                        case 'J':
                            return CardType.Jack;
                        case 'Q':
                            return CardType.Queen;
                        case 'K':
                            return CardType.King;
                        case 'A':
                            return CardType.Ace;
                        default:
                            throw new Exception("Invalid card");
                    }
                });
                var bid = tokens[1];

                return (hand, bid);
            });

        var cardsSeen = new HashSet<CardType>();
        var cards = new List<int>();
        var handsTypes = new List<Hand>();

        for (int i = 0; i < lines.Count(); i++)
        {
            var (hand, bidStr) = lines.ElementAt(i);
            var bid = int.Parse(bidStr);
            cardsSeen = new();
            cards = new();

            for (int j = 0; j < hand.Count(); j++)
            {
                if (cardsSeen.Contains(hand.ElementAt(j)))
                {
                    continue;
                }

                cards.Add(hand.Count(c => c == hand.ElementAt(j)));

                cardsSeen.Add(hand.ElementAt(j));
            }

            if (cards.Count() == 1)
            {
                handsTypes.Add(new(HandType.FiveOfAKind, hand, bid));
            }
            else if (cards.Count() == 2)
            {
                if (cards.Any(c => c == 4))
                {
                    handsTypes.Add(new(HandType.FourOfAKind, hand, bid));
                }
                else
                {
                    handsTypes.Add(new(HandType.FullHouse, hand, bid));
                }
            }
            else if (cards.Count() == 3)
            {
                if (cards.Any(c => c == 3))
                {
                    handsTypes.Add(new(HandType.ThreeOfAKind, hand, bid));
                }
                else
                {
                    handsTypes.Add(new(HandType.TwoPair, hand, bid));
                }
            }
            else if (cards.Count() == 4)
            {
                handsTypes.Add(new(HandType.Pair, hand, bid));
            }
            else
            {
                handsTypes.Add(new(HandType.HighCard, hand, bid));
            }
        }

        handsTypes.Sort(IsHandStrongerThan);

        var winnings = 0;
        for (int i = 0; i < handsTypes.Count(); i++)
        {
            var hand = handsTypes.ElementAt(i);
            winnings += hand.Bid * (i + 1);
        }

        return winnings;
    }

    public static int PartTwo(string input)
    {
        var lines = input
            .Split(Environment.NewLine)
            .Where(line => line.Length > 0)
            .Select(line =>
            {
                var tokens = line.Split(" ");
                var hand = tokens[0].Select(c =>
                {
                    switch (c)
                    {
                        case '2':
                            return CardType.Two;
                        case '3':
                            return CardType.Three;
                        case '4':
                            return CardType.Four;
                        case '5':
                            return CardType.Five;
                        case '6':
                            return CardType.Six;
                        case '7':
                            return CardType.Seven;
                        case '8':
                            return CardType.Eight;
                        case '9':
                            return CardType.Nine;
                        case 'T':
                            return CardType.Ten;
                        case 'J':
                            return CardType.Joker;
                        case 'Q':
                            return CardType.Queen;
                        case 'K':
                            return CardType.King;
                        case 'A':
                            return CardType.Ace;
                        default:
                            throw new Exception("Invalid card");
                    }
                });
                var bid = tokens[1];

                return (hand, bid);
            });

        var cardsSeen = new HashSet<CardType>();
        var cards = new Dictionary<CardType, int>();
        var handsTypes = new List<Hand>();

        for (int i = 0; i < lines.Count(); i++)
        {
            var (hand, bidStr) = lines.ElementAt(i);
            var bid = int.Parse(bidStr);
            cardsSeen = new();
            cards = new();

            for (int j = 0; j < hand.Count(); j++)
            {
                if (cardsSeen.Contains(hand.ElementAt(j)))
                {
                    continue;
                }

                cards.Add(hand.ElementAt(j), hand.Count(c => c == hand.ElementAt(j)));

                cardsSeen.Add(hand.ElementAt(j));
            }

            var jokerCount = hand.Count(c => c == CardType.Joker);
            var cardCount = cards.Count();
            var maxValue = cardCount > 1 ? cards.Where(kvp => kvp.Key != CardType.Joker).Max(kvp => kvp.Value) : 0;

            Console.WriteLine($"Hand: {string.Join(",", hand)} Frequency: {string.Join(",", cards.Select(kvp => $"{kvp.Key}:{kvp.Value}"))} Max Value: {maxValue}");
            if (jokerCount > 0)
            {
                if(cardCount > 1){
                    cardCount -= 1;
                }

                foreach (var (card, count) in cards)
                {
                    if (card == CardType.Joker)
                    {
                        continue;
                    }
                    if (count == maxValue)
                    {
                        cards[card] += jokerCount;
                    }
                }
            }

            if (cardCount == 1)
            {
                handsTypes.Add(new(HandType.FiveOfAKind, hand, bid));
            }
            else if (cardCount == 2)
            {
                if (cards.Any(c => c.Value == 4))
                {
                    handsTypes.Add(new(HandType.FourOfAKind, hand, bid));
                }
                else
                {
                    handsTypes.Add(new(HandType.FullHouse, hand, bid));
                }
            }
            else if (cardCount == 3)
            {
                if (cards.Any(c => c.Value == 3))
                {
                    handsTypes.Add(new(HandType.ThreeOfAKind, hand, bid));
                }
                else
                {
                    handsTypes.Add(new(HandType.TwoPair, hand, bid));
                }
            }
            else if (cardCount == 4)
            {
                handsTypes.Add(new(HandType.Pair, hand, bid));
            }
            else
            {
                handsTypes.Add(new(HandType.HighCard, hand, bid));
            }
        }

        handsTypes.Sort(IsHandStrongerThan);

        var winnings = 0;
        for (int i = 0; i < handsTypes.Count(); i++)
        {
            var hand = handsTypes.ElementAt(i);
            Console.WriteLine("Hand: {0}\tType: {1}\tBid: {2}\tRank: {3}", string.Join(",", hand.Cards), hand.Type, hand.Bid, i+1);
            winnings += hand.Bid * (i + 1);
        }

        return winnings;
    }
}
