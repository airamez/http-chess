using System.Text;

namespace HttpChess.Models;

public class Chess
{
  private char[,] Board { get; set; }

  public Chess()
  {
    // Board = new char[,]
    // {
    //   { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' }, // Black major pieces
    //   { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' }, // Black pawns
    //   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, // Empty row
    //   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, // Empty row
    //   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, // Empty row
    //   { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, // Empty row
    //   { 'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' }, // White pawns
    //   { 'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' }  // White major pieces
    // };

    Board = new char[,] {
      { '♜', '♞', '♝', '♛', '♚', '♝', '♞', '♜' },
      { '♟', '♟', '♟', '♟', '♟', '♟', '♟', '♟' },
      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
      { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
      { '♙', '♙', '♙', '♙', '♙', '♙', '♙', '♙' },
      { '♖', '♘', '♗', '♕', '♔', '♗', '♘', '♖' }
    };
  }

  public void Move(string origin, string destiny)
  {
    var sourceCell = Extract(origin.ToUpper());
    if (Board[sourceCell.Row, sourceCell.Col] == ' ')
    {
      return;
    }
    var targetCell = Extract(destiny.ToUpper());
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

  public string ToHtml()
  {
    string htmlTemplate = @"
    <html>
    <head>
        <style>
            body { background-color: black; color: white; text-align: center; }
            table { border-collapse: collapse; margin: auto; }
            td { width: 50px; height: 50px; text-align: center; font-size: 24px; font-weight: bold; }
            .light { background-color: #EEEED2; }  /* Light squares */
            .dark { background-color: #769656; }  /* Dark squares */
            .white-piece { color: white; }  /* White pieces */
            .black-piece { color: black; }  /* Black pieces */
        </style>
    </head>
    <body>
        <table border='1'>
    ";
    StringBuilder result = new StringBuilder(htmlTemplate);
    // File indicators (A-H)
    result.Append("<tr><td></td>");
    for (char file = 'A'; file <= 'H'; file++)
    {
      result.Append($"<td style='font-weight: bold;'>{file}</td>");
    }
    result.Append("</tr>");
    for (int i = 0; i < Board.GetLength(0); i++)
    {
      result.Append("<tr>");
      // Rank indicators (1-8)
      result.Append($"<td style='font-weight: bold;'>{8 - i}</td>");
      for (int j = 0; j < Board.GetLength(1); j++)
      {
        string cellClass = (i + j) % 2 == 0 ? "light" : "dark";
        string pieceClass = char.IsUpper(Board[i, j]) ? "white-piece" : "black-piece"; // Capital letters → White, Lowercase → Black
        result.Append($"<td class='{cellClass} {pieceClass}'>{Board[i, j]}</td>");
      }
      result.Append("</tr>");
    }
    result.Append("</table></body></html>");
    return result.ToString();
  }
}