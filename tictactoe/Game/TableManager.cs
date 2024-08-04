using tictactoe.Entities;

namespace tictactoe.Game;

public class TableManager
{
    private const int Rows = 3;
    private const int Columns = 3;
    private static char[,] Board = new char[Rows, Columns];

    public static void InitializeBoard()
    {
        var pos = 1;
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                // Casting to char somehow doesn't work.
                // Need to manually convert.
                // This method just populates Board array for later usage
                Board[i, j] = pos.ToString()[0];
                pos++;
            }
        }
    }

    public static void PrintBoard()
    {
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                Console.Write(Board[i, j]);
                if (j < 2)
                {
                    Console.Write(" | ");
                }
            }

            Console.WriteLine();
            if (i < 2)
            {
                Console.WriteLine("---------");
            }
        }

        Console.WriteLine();
    }

    public static bool PlayTurn(int pos, Player player)
    {
        var posAsChar = pos.ToString()[0];

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                if (Board[i, j] != posAsChar) continue;
                Board[i, j] = player.PlayerSymbol;
                return true;
            }
        }

        return false;
    }

    public static bool SearchForWinCondition()
    {
        return CheckHorizontal() || CheckVertical() || CheckDiagonal();
    }

    private static bool CheckHorizontal()
    {
        for (var i = 0; i < Rows; i++)
        {
            if (Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2])
            {
                return true;
            }
        }

        return false;
    }
    
    private static bool CheckVertical()
    {
        for (var i = 0; i < Rows; i++)
        {
            if (Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i])
            {
                return true;
            }
        }

        return false;
    }

    private static bool CheckDiagonal()
    {
        for (var i = 0; i < Rows; i++)
        {
            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            {
                return true;
            }
            if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
            {
                return true;
            }
        }

        return false;
    }
}