using domain.ValueObjects;

namespace domain.Entities;

/// <summary>
/// Represents a player in the Pisti card game.
/// </summary>
public sealed class Player
{
    /// <summary>
    /// Gets the unique identifier of the player.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the name of the player.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the player's current hand.
    /// </summary>
    public Hand Hand { get; }

    /// <summary>
    /// Gets the cards captured by the player.
    /// </summary>
    public Hand CapturedCards { get; }

    /// <summary>
    /// Gets the current score of the player.
    /// </summary>
    public int Score => CapturedCards.Cards.Sum(card => card.Points);

    /// <summary>
    /// Gets the number of cards captured by the player.
    /// </summary>
    public int CardsWon => CapturedCards.Count;

    /// <summary>
    /// Initializes a new instance of the Player class.
    /// </summary>
    /// <param name="name">The name of the player.</param>
    /// <exception cref="ArgumentException">Thrown when name is null, empty, or whitespace.</exception>
    public Player(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        
        Id = Guid.NewGuid();
        Name = name.Trim();
        Hand = new Hand();
        CapturedCards = new Hand();
    }

    /// <summary>
    /// Initializes a new instance of the Player class with a specific ID.
    /// </summary>
    /// <param name="id">The unique identifier for the player.</param>
    /// <param name="name">The name of the player.</param>
    /// <exception cref="ArgumentException">Thrown when name is null, empty, or whitespace.</exception>
    public Player(Guid id, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        
        Id = id;
        Name = name.Trim();
        Hand = new Hand();
        CapturedCards = new Hand();
    }

    /// <summary>
    /// Adds captured cards to the player's collection.
    /// </summary>
    /// <param name="cards">The cards to add to captured cards.</param>
    /// <exception cref="ArgumentNullException">Thrown when cards collection is null.</exception>
    public void AddCapturedCards(IEnumerable<Card> cards)
    {
        ArgumentNullException.ThrowIfNull(cards);
        CapturedCards.AddCards(cards);
    }

    /// <summary>
    /// Plays a card from the player's hand.
    /// </summary>
    /// <param name="cardIndex">The index of the card to play.</param>
    /// <returns>The card that was played.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when cardIndex is out of range.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the player has no cards to play.</exception>
    public Card PlayCard(int cardIndex)
    {
        if (Hand.IsEmpty)
            throw new InvalidOperationException($"Player {Name} has no cards to play.");
            
        return Hand.RemoveCard(cardIndex);
    }

    /// <summary>
    /// Determines whether the player can play (has cards in hand).
    /// </summary>
    /// <returns>True if the player has cards to play, false otherwise.</returns>
    public bool CanPlay() => !Hand.IsEmpty;

    /// <summary>
    /// Returns a string representation of the player.
    /// </summary>
    /// <returns>A string containing the player's name and current status.</returns>
    public override string ToString()
    {
        return $"{Name} (Cards in hand: {Hand.Count}, Score: {Score}, Cards won: {CardsWon})";
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current player.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>True if the objects are equal, false otherwise.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Player other && Id == other.Id;
    }

    /// <summary>
    /// Returns a hash code for the current player.
    /// </summary>
    /// <returns>A hash code based on the player's ID.</returns>
    public override int GetHashCode() => Id.GetHashCode();
}