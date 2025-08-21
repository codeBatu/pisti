using domain.Enums;

namespace domain.Entities;

/// <summary>
/// Represents a playing card in the Pisti card game.
/// Implements value object pattern for immutability and proper equality comparison.
/// </summary>
public sealed record Card
{
    /// <summary>
    /// Gets the suit of the card (Hearts, Diamonds, Clubs, Spades).
    /// </summary>
    public Suit Suit { get; }

    /// <summary>
    /// Gets the rank of the card (Ace, 2-10, Jack, Queen, King).
    /// </summary>
    public Rank Rank { get; }

    /// <summary>
    /// Gets the display name of the card (e.g., "Ace of Hearts").
    /// </summary>
    public string DisplayName => $"{Rank} of {Suit}";

    /// <summary>
    /// Gets the point value of the card in Pisti game rules.
    /// </summary>
    public int Points => Rank switch
    {
        Rank.Ace => 1,
        Rank.Jack => 1,
        Rank.Two when Suit == Suit.Clubs => 2,
        Rank.Ten when Suit == Suit.Diamonds => 3,
        _ => 0
    };

    /// <summary>
    /// Initializes a new instance of the Card class.
    /// </summary>
    /// <param name="suit">The suit of the card.</param>
    /// <param name="rank">The rank of the card.</param>
    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    /// <summary>
    /// Determines if this card can capture the given card according to Pisti rules.
    /// </summary>
    /// <param name="otherCard">The card to potentially capture.</param>
    /// <returns>True if this card can capture the other card, false otherwise.</returns>
    public bool CanCapture(Card otherCard)
    {
        ArgumentNullException.ThrowIfNull(otherCard);
        
        // Jack can capture any card
        if (Rank == Rank.Jack)
            return true;
        
        // Same rank can capture
        return Rank == otherCard.Rank;
    }

    /// <summary>
    /// Returns a string representation of the card.
    /// </summary>
    /// <returns>The display name of the card.</returns>
    public override string ToString() => DisplayName;
}