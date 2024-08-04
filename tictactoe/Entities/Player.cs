namespace tictactoe.Entities;

public class Player
{
    public bool IsPlaying;
    public string Name { get; set; } = string.Empty;
    public char PlayerSymbol { get; set; }
}