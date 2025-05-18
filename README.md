# HTTP Chess API ♜

A lightweight **ASP.NET Core Web API** for playing chess via HTTP requests.

🚨 **Note:** This is a demo used in the [Codando Live](http://codando.live) course.  
There is **no chess rules validation**—players can move pieces freely.  
💡 A great coding exercise is to implement **proper validation** based on chess rules.

> **Hosted on Azure Free Tier** ✅

## 🏁 Start a New Game

### 🔹 Request

```http
GET https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/new
```

* Response

  Returns a **unique Game ID**.

  * Example

  ```text
  3b8ac115-9807-472e-9ddd-b9d798657e90
  ```

---

## 🔍 View the Game Board

Retrieve the **current board state** using your **Game ID**.

* Request

  ```http
  GET https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/{game_id}
  ```

  >Replace `{game_id}` with your actual Game ID.

  * Example

  ```http
  GET https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/3b8ac115-9807-472e-9ddd-b9d798657e90
  ```

* Response

  Returns a **chessboard representation** using Unicode chess pieces.

  ![Board](images/chess-board.png)

---

## ➡️ Make a Move

Move a piece by specifying the **origin** and **destination** (e.g., `A7A6`).

* Request

  ```http
  GET https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/{game_id}/{move}
  ```

  * Example

    ```http
    GET https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/3b8ac115-9807-472e-9ddd-b9d798657e90/move/A7A6
    ```

* Response

  Returns the **updated chessboard** after the move.

---

## 🗑️ Delete a Game

* Request

  ```http
  GET https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/{game_id}/delete
  ```

  * Example

  ```http
  GET https://http-chess-ckfyheevasetabez.westus-01.azurewebsites.net/api/game/3b8ac115-9807-472e-9ddd-b9d798657e90/delete
  ```

---

## 🛠️ Next Steps: Implement Chess Rule Validation

Currently, the API allows **any move**, ignoring chess rules.  
Take on the challenge of **adding logic** to enforce:

✅ **Legal move validation** (e.g., knights move in L-shape).  
✅ **Turn-based movement** (white moves first).  
✅ **Checkmate detection** (game-ending logic).  
✅ **Castling & en passant mechanics**.

---

♖ **Happy Coding!** ♜♞♛
