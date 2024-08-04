using tictactoe;
using tictactoe.Game;

TableManager.InitializeBoard();

var playerManager = new PlayerManager();

var currentPlayer = playerManager.GetPlayer();

var turns = 0;

while (true)
{
    try
    {
        Console.WriteLine("Tic Tac Toe");

        TableManager.PrintBoard();

        Console.WriteLine("Player: " + currentPlayer.Name);

        Console.WriteLine("Choose a position:");
        var input = int.Parse(Console.ReadLine()!);
        if (input is < 0 or > 9) throw new IndexOutOfRangeException("Input must be between 1 and 9. Input: " + input);

        var result = TableManager.PlayTurn(input, currentPlayer);

        if (!result)
        {
            throw new ArgumentException("You cannot play on a space that's already taken");
        }

        var win = TableManager.SearchForWinCondition();

        if (win)
        {
            break;
        }

        currentPlayer = playerManager.GetPlayer();
        Console.Clear();
        turns++;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }
}

Console.Clear();
TableManager.PrintBoard();
Console.WriteLine($"Player {currentPlayer.Name} wins!");
Console.WriteLine("Turns Played: " + turns);
Console.WriteLine("\nThanks for playing!");