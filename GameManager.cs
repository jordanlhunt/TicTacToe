using ConsoleApp1;
using System;

namespace TicTacToe
{
    internal class GameManager
    {
        #region Members
        Player player = new Player();
        GameBoard gameBoard = new GameBoard();
        #endregion
        #region  Public Methods
        public void PlayGame()
        {
            while (IsGameOver(gameBoard) == false)
            {
                Console.WriteLine();
                string playerMove = player.MakeMove();
                while (IsBoardSpaceFree(playerMove, gameBoard) == false)
                {
                    Console.WriteLine("[ERROR] - Invalid Input - You can't place a Marker on an occupied location");
                    Console.Write("Input Movement: ");
                    playerMove = Console.ReadLine();
                }
                gameBoard.UpdateGameBoard(playerMove, player.Marker);
            }
        }
        /*
         * If the the board location is free allow the placement if not don't allow the placement
         
        */
        public bool IsBoardSpaceFree(string playerMove, GameBoard gameBoard)
        {
            int possibleRow = 0;
            int possibleColumn = 0;
            string emptySpace = "|_|";
            // Get the row and column 
            if (Char.IsDigit(playerMove[0]))
            {
                possibleRow = playerMove[0] - '0';
                possibleColumn = gameBoard.ConvertInputColumn(playerMove[0]);
            }
            else
            {
                // Convert char to int
                possibleRow = playerMove[1] - '0';
                possibleColumn = gameBoard.ConvertInputColumn(playerMove[0]);
            }
            if (gameBoard.PlayBoard[possibleRow, possibleColumn] == emptySpace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region  Private Methods
        private bool IsGameOver(GameBoard gameBoard)
        {
            string emptySpace = "|_|";
            // Loop through the playBoard and check the if there are zero empty squares. If there are no empty squares end the game.
            for (int i = 1; i < gameBoard.PlayBoard.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < gameBoard.PlayBoard.GetLength(1) - 1; j++)
                {
                    if (gameBoard.PlayBoard[i, j] == emptySpace)
                    {
                        return false;
                    }
                    else if (gameBoard.CheckForWin() == true)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}