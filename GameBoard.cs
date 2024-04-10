using System;

namespace ConsoleApp1
{
    enum GameBoardColumns
    {
        A = 1,
        B,
        C
    };
    class GameBoard
    {
        #region Attributes
        string[,] gameBoard;
        #endregion
        #region Constructor
        public GameBoard()
        {
            gameBoard = new string[,] {
                {"","   A "," B "," C"},
                {"1 ","|_|","|_|","|_|" },
                {"2 ","|_|","|_|","|_|" },
                {"3 ","|_|","|_|","|_|" }
            };
        }
        #endregion

        #region Public Methods
        public void PrintGameBoard()
        {
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int column = 0; column < gameBoard.GetLength(1); column++)
                {
                    Console.Write(gameBoard[row, column]);
                }
                Console.WriteLine();
            }
        }

        public void UpdateGameBoard(string playerMove)
        {
            char[] playerMoveCharacters = playerMove.ToCharArray();
            int columnToUpdate = 0;
            int rowToUpdate = 0;
            if (Char.IsDigit(playerMoveCharacters[0]))
            {
                // Convert char to int
                rowToUpdate = playerMoveCharacters[0] - '0';
                columnToUpdate = playerMoveCharacters[1];
                if (columnToUpdate == 'C')
                {
                    columnToUpdate = (int)GameBoardColumns.C;
                }
            }
            else
            {
                // Convert char to int
                rowToUpdate = playerMoveCharacters[1] - '0';
                columnToUpdate = playerMoveCharacters[0];
                if (columnToUpdate == 'A')
                {
                    columnToUpdate = (int)GameBoardColumns.A;
                }
                else if (columnToUpdate == 'B')
                {
                    columnToUpdate = (int)GameBoardColumns.B;
                }
                else
                {
                    columnToUpdate = (int)GameBoardColumns.C;
                }
            }
            gameBoard[rowToUpdate, columnToUpdate] = "|X|";
            PrintGameBoard();
        }
        #endregion
    }
}