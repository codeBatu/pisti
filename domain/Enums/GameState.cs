namespace domain.Enums;

/// <summary>
/// Represents the current state of a Pisti game.
/// </summary>
public enum GameState
{
    /// <summary>Game has not started yet</summary>
    NotStarted,
    
    /// <summary>Game is currently in progress</summary>
    InProgress,
    
    /// <summary>Game is paused</summary>
    Paused,
    
    /// <summary>Game has ended</summary>
    Finished
}