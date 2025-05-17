using System.Text;

namespace HttpChess.Models;

public class Chess
{
  private char[,] Board { get; set; }

  public Chess()
  {
    Board = new char[,]
    {
      { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' }, // Black major pieces
      { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' }, // Black pawns
      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, // Empty row
      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, // Empty row
      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, // Empty row
      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, // Empty row
      { 'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' }, // White pawns
      { 'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' }  // White major pieces
    };

    // Board = new char[,] {
    //   { '♜', '♞', '♝', '♛', '♚', '♝', '♞', '♜' },
    //   { '♟', '♟', '♟', '♟', '♟', '♟', '♟', '♟' },
    //   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    //   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    //   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    //   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    //   { '♙', '♙', '♙', '♙', '♙', '♙', '♙', '♙' },
    //   { '♖', '♘', '♗', '♕', '♔', '♗', '♘', '♖' }
    // };
  }

  public void Move(string source, string target)
  {
    var sourceCell = Extract(source.ToUpper());
    var targetCell = Extract(target.ToUpper());
    char piece = Board[sourceCell.Row, sourceCell.Col];
    Board[sourceCell.Row, sourceCell.Col] = ' ';
    Board[targetCell.Row, targetCell.Col] = piece;
  }

  public (int Row, int Col) Extract(string position)
  {
    char file = position[0];
    int rank = int.Parse(position[1].ToString());
    int col = file - 'A';
    int row = 8 - rank;
    return (row, col);
  }

  public override string ToString()
  {
    StringBuilder result = new StringBuilder();
    // Files indicators (A-H)
    result.Append("  A B C D E F G H\n");
    for (int i = 0; i < Board.GetLength(0); i++)
    {
      // Rank indicator (1-8)
      result.Append(8 - i).Append(" ");
      for (int j = 0; j < Board.GetLength(1); j++)
      {
        result.Append(Board[i, j]).Append(" ");
      }
      result.Append(Environment.NewLine);
    }
    return result.ToString();
  }
}