using domain.Entities;
using domain.Enums;

namespace domain.Services;

/// <summary>
/// Represents a deck of playing cards with shuffle and deal functionality.
/// </summary>
public sealed class Deck
{
    private readonly List<Card> _cards;
    private readonly Random _random;

    /// <summary>
    /// Gets the number of cards remaining in the deck.
    /// </summary>
    public int CardsRemaining => _cards.Count;

    /// <summary>
    /// Gets a value indicating whether the deck is empty.
    /// </summary>
    public bool IsEmpty => _cards.Count == 0;

    /// <summary>
    /// Initializes a new instance of the Deck class with a standard 52-card deck.
    /// </summary>
    /// <param name="random">Optional random number generator for shuffling. If null, a new instance will be created.</param>
    public Deck(Random? random = null)
    {
        _random = random ?? new Random();
        _cards = CreateStandardDeck();
    }

    /// <summary>
    /// Shuffles the deck using the Fisher-Yates algorithm.
    /// </summary>
    public void Shuffle()
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    /// <summary>
    /// Deals a single card from the top of the deck.
    /// </summary>
    /// <returns>The card from the top of the deck.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the deck is empty.</exception>
    public Card Deal()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Cannot deal from an empty deck.");

        var card = _cards[^1];
        _cards.RemoveAt(_cards.Count - 1);
        return card;
    }

    /// <summary>
    /// Deals a specified number of cards from the deck.
    /// </summary>
    /// <param name="count">The number of cards to deal.</param>
    /// <returns>A list of cards dealt from the deck.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when count is negative or exceeds available cards.</exception>
    public List<Card> Deal(int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(count, CardsRemaining);

        var cards = new List<Card>(count);
        for (int i = 0; i < count; i++)
        {
            cards.Add(Deal());
        }
        
        return cards;
    }

    /// <summary>
    /// Resets the deck to a full 52-card deck and shuffles it.
    /// </summary>
    public void Reset()
    {
        _cards.Clear();
        _cards.AddRange(CreateStandardDeck());
        Shuffle();
    }

    /// <summary>
    /// Creates a standard 52-card deck.
    /// </summary>
    /// <returns>A list of 52 cards representing a standard deck.</returns>
    private static List<Card> CreateStandardDeck()
    {
        var cards = new List<Card>(52);
        
        foreach (Suit suit in Enum.GetValues<Suit>())
        {
            foreach (Rank rank in Enum.GetValues<Rank>())
            {
                cards.Add(new Card(suit, rank));
            }
        }
        
        return cards;
    }
}