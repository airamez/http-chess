# HTTP Chess API 🏁

A simple **ASP.NET Core Web API** implementation for playing chess via HTTP requests.  
**⚠️ Note:** This is an demo to be used in the (<http://codando.live>) course and there is no chess rules validation.
Players can move pieces freely. A great **coding exercise** is to add proper validation based on chess rules!

> It is hosted on Azure free tie :)

## 🚀 How to Start a New Game

To create a new chess game instance:

* Request

  ```http
  GET https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/new
  ```

* Response

  A **unique Game ID** is returned.
  Example:

  ```json
  3b8ac115-9807-472e-9ddd-b9d798657e90
  ```

## 🏆 Viewing the Game Board

Once you have the **Game ID**, you can view the **current board state**.

* Request (GET)

  ```http
  https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/{game_id}
  ```

  Replace `{game_id}` with your actual Game ID.

  * Example

    ```http
    https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/3b8ac115-9807-472e-9ddd-b9d798657e90
    ```

* Response

  A **chessboard representation**, using Unicode chess pieces, is returned.

  ![Board](images/chess-board.png)

## ♞ Moving a Chess Piece

Use a **GET request** to move a piece by specifying:

* `move`: The **Origing and Destiny** of the piece (e.g., `A7A6`)

* Request (GET)

  ```http
  https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/{game_id}/{move}
  ```

  * Example

    ```http
    https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/3b8ac115-9807-472e-9ddd-b9d798657e90/move/A7A6
    ```

* Response

  The **updated chessboard** after moving the piece.

## 🛠️ Next Steps: Add Chess Rule Validation

Currently, the API lets you move **any piece anywhere**, breaking chess rules.  
As a **programming challenge**, try implementing:

* **Legal move validation** (e.g., knights move in L-shape).
* **Turn-based movement** (white moves first).
* **Checkmate detection** (game-ending logic).
* **Castling & en passant mechanics**.

---

Enjoy ♜♞♖
