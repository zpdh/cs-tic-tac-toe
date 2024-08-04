using tictactoe.Entities;

namespace tictactoe.Game;

public class PlayerManager
{
    private Player _player1;
    private Player _player2;

    private bool _turn;

    public PlayerManager()
    {
        _player1 = new Player
        {
            IsPlaying = true,
            Name = "Player1",
            PlayerSymbol = 'X'
        };
        _player2 = new Player
        {
            IsPlaying = false,
            Name = "Player2",
            PlayerSymbol = 'O'
        };
    }

    public Player GetPlayer()
    {
        _turn = !_turn;
        return _turn
            ? _player1
            : _player2;
    }
}