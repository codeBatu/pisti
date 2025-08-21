using domain.Entities;

namespace domain.ValueObjects;

/// <summary>
/// Represents a player's hand in the Pisti card game.
/// Implements value object pattern with proper encapsulation.
/// </summary>
public sealed class Hand
{
    private readonly List<Card> _cards;

    /// <summary>
    /// Gets the cards in the hand as a read-only collection.
    /// </summary>
    public IReadOnlyList<Card> Cards => _cards.AsReadOnly();

    /// <summary>
    /// Gets the number of cards in the hand.
    /// </summary>
    public int Count => _cards.Count;

    /// <summary>
    /// Gets a value indicating whether the hand is empty.
    /// </summary>
    public bool IsEmpty => _cards.Count == 0;

    /// <summary>
    /// Initializes a new instance of the Hand class.
    /// </summary>
    public Hand()
    {
        _cards = new List<Card>();
    }

    /// <summary>
    /// Initializes a new instance of the Hand class with the specified cards.
    /// </summary>
    /// <param name="cards">The initial cards to add to the hand.</param>
    public Hand(IEnumerable<Card> cards)
    {
        ArgumentNullException.ThrowIfNull(cards);
        _cards = new List<Card>(cards);
    }

    /// <summary>
    /// Adds a card to the hand.
    /// </summary>
    /// <param name="card">The card to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when card is null.</exception>
    public void AddCard(Card card)
    {
        ArgumentNullException.ThrowIfNull(card);
        _cards.Add(card);
    }

    /// <summary>
    /// Adds multiple cards to the hand.
    /// </summary>
    /// <param name="cards">The cards to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when cards collection is null.</exception>
    public void AddCards(IEnumerable<Card> cards)
    {
        ArgumentNullException.ThrowIfNull(cards);
        _cards.AddRange(cards);
    }

    /// <summary>
    /// Removes and returns a card from the hand at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the card to remove.</param>
    /// <returns>The card that was removed.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when index is out of range.</exception>
    public Card RemoveCard(int index)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, _cards.Count);

        var card = _cards[index];
        _cards.RemoveAt(index);
        return card;
    }

    /// <summary>
    /// Removes a specific card from the hand.
    /// </summary>
    /// <param name="card">The card to remove.</param>
    /// <returns>True if the card was found and removed, false otherwise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when card is null.</exception>
    public bool RemoveCard(Card card)
    {
        ArgumentNullException.ThrowIfNull(card);
        return _cards.Remove(card);
    }

    /// <summary>
    /// Determines whether the hand contains the specified card.
    /// </summary>
    /// <param name="card">The card to locate.</param>
    /// <returns>True if the hand contains the card, false otherwise.</returns>
    public bool Contains(Card card) => _cards.Contains(card);

    /// <summary>
    /// Removes all cards from the hand.
    /// </summary>
    public void Clear() => _cards.Clear();

    /// <summary>
    /// Gets a card at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the card.</param>
    /// <returns>The card at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when index is out of range.</exception>
    public Card GetCard(int index)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, _cards.Count);
        return _cards[index];
    }

    /// <summary>
    /// Returns a string representation of the hand.
    /// </summary>
    /// <returns>A string showing all cards in the hand.</returns>
    public override string ToString()
    {
        return _cards.Count == 0 ? "Empty hand" : string.Join(", ", _cards);
    }
}