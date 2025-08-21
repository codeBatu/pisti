using domain.Entities;
using domain.Services;

namespace pisti;

/// <summary>
/// Entry point for the Pisti card game demonstration.
/// Showcases the domain model with proper code quality practices.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// Demonstrates basic functionality of the Pisti domain model.
    /// </summary>
    /// <param name="args">Command line arguments (not used).</param>
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("=== Pisti Kart Oyunu - Domain Model Demo ===");
            Console.WriteLine();

            // Create and demonstrate deck functionality
            DemonstrateDeck();
            Console.WriteLine();

            // Create and demonstrate players
            DemonstratePlayers();
            Console.WriteLine();

            // Demonstrate card capture logic
            DemonstrateCardCapture();

            Console.WriteLine();
            Console.WriteLine("Demo tamamlandı. Domain model başarıyla çalışıyor!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata oluştu: {ex.Message}");
            Console.WriteLine($"Detay: {ex}");
        }
    }

    /// <summary>
    /// Demonstrates deck creation, shuffling, and dealing functionality.
    /// </summary>
    private static void DemonstrateDeck()
    {
        Console.WriteLine("--- Deste Demonstrasyonu ---");
        
        var deck = new Deck();
        Console.WriteLine($"Yeni deste oluşturuldu. Kart sayısı: {deck.CardsRemaining}");
        
        deck.Shuffle();
        Console.WriteLine("Deste karıştırıldı.");
        
        var dealtCards = deck.Deal(5);
        Console.WriteLine($"5 kart dağıtıldı:");
        foreach (var card in dealtCards)
        {
            Console.WriteLine($"  - {card} (Puan: {card.Points})");
        }
        
        Console.WriteLine($"Destede kalan kart sayısı: {deck.CardsRemaining}");
    }

    /// <summary>
    /// Demonstrates player creation and hand management.
    /// </summary>
    private static void DemonstratePlayers()
    {
        Console.WriteLine("--- Oyuncu Demonstrasyonu ---");
        
        var player1 = new Player("Ahmet");
        var player2 = new Player("Ayşe");
        
        var deck = new Deck();
        deck.Shuffle();
        
        // Deal cards to players
        player1.Hand.AddCards(deck.Deal(4));
        player2.Hand.AddCards(deck.Deal(4));
        
        Console.WriteLine($"Oyuncular oluşturuldu:");
        Console.WriteLine($"  - {player1}");
        Console.WriteLine($"  - {player2}");
        
        Console.WriteLine($"\n{player1.Name}'in kartları:");
        for (int i = 0; i < player1.Hand.Count; i++)
        {
            var card = player1.Hand.GetCard(i);
            Console.WriteLine($"  {i + 1}. {card}");
        }
    }

    /// <summary>
    /// Demonstrates card capture logic according to Pisti rules.
    /// </summary>
    private static void DemonstrateCardCapture()
    {
        Console.WriteLine("--- Kart Yakalama Demonstrasyonu ---");
        
        var tableCard = new Card(domain.Enums.Suit.Hearts, domain.Enums.Rank.Seven);
        var playerCard1 = new Card(domain.Enums.Suit.Spades, domain.Enums.Rank.Seven);
        var playerCard2 = new Card(domain.Enums.Suit.Clubs, domain.Enums.Rank.Jack);
        var playerCard3 = new Card(domain.Enums.Suit.Diamonds, domain.Enums.Rank.King);
        
        Console.WriteLine($"Masadaki kart: {tableCard}");
        Console.WriteLine();
        
        Console.WriteLine("Oyuncu kartları test ediliyor:");
        Console.WriteLine($"  {playerCard1} yakalayabilir mi? {(playerCard1.CanCapture(tableCard) ? "EVET" : "HAYIR")} (Aynı değer)");
        Console.WriteLine($"  {playerCard2} yakalayabilir mi? {(playerCard2.CanCapture(tableCard) ? "EVET" : "HAYIR")} (Vale her kartı yakalar)");
        Console.WriteLine($"  {playerCard3} yakalayabilir mi? {(playerCard3.CanCapture(tableCard) ? "EVET" : "HAYIR")} (Farklı değer)");
    }
}
