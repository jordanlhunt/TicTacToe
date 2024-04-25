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
        string[,] playBoard;
        #endregion
        #region Properties
        public string[,] PlayBoard
        {
            get => playBoard;
        }
        #endregion
        #region Constructor
        public GameBoard()
        {
            playBoard = new string[,] {
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
            Console.WriteLine();
            for (int row = 0; row < playBoard.GetLength(0); row++)
            {
                for (int column = 0; column < playBoard.GetLength(1); column++)
                {
                    Console.Write(playBoard[row, column]);
                }
                Console.WriteLine();
            }
        }
        public void UpdateGameBoard(string move, char marker)
        {
            char[] moveCharacters = move.ToCharArray();
            int columnToUpdate = 0;
            int rowToUpdate = 0;
            if (char.IsDigit(moveCharacters[0]))
            {
                // Convert char to int
                rowToUpdate = moveCharacters[0] - '0';
                columnToUpdate = ConvertInputColumn(moveCharacters[1]);
            }
            else
            {
                // Convert char to int
                rowToUpdate = moveCharacters[1] - '0';
                columnToUpdate = ConvertInputColumn(moveCharacters[0]);
            }
            playBoard[rowToUpdate, columnToUpdate] = "|" + marker + "|";
            PrintGameBoard();
        }
        public int ConvertInputColumn(char someChar)
        {
            if (someChar == 'A')
            {
                return (int)GameBoardColumns.A;
            }
            else if (someChar == 'B')
            {
                return (int)GameBoardColumns.B;
            }
            else
            {
                return (int)GameBoardColumns.C;
            }
        }
        public bool CheckForWin()
        {
            string markerX = "|X|";
            string markerO = "|O|";
            // Straight line
            if (StraightLineHorizontalWin(markerO) || StraightLineHorizontalWin(markerX))
            {
                Console.Write("[CheckForWin() // HorizontalWin] - Winner");
                return true;
            }
            else if (StraightLineHorizontalWin(markerO) || StraightLineVerticalWin(markerX))
            {
                Console.Write("[CheckForWin() // VerticalWin] - Winner");
                return true;
            }
            return false;
        }
        #endregion
        #region Private Methods
        private bool StraightLineHorizontalWin(string marker)
        {
            if (playBoard[1, 1] == marker && playBoard[1, 2] == marker && playBoard[1, 3] == marker)
            {
                return true;
            }
            if (playBoard[2, 1] == marker && playBoard[2, 2] == marker && playBoard[2, 3] == marker)
            {
                return true;
            }
            if (playBoard[3, 1] == marker && playBoard[3, 2] == marker && playBoard[3, 3] == marker)
            {
                return true;
            }
            return false;
        }
        private bool StraightLineVerticalWin(string marker)
        {
            if (playBoard[1, 1] == marker && playBoard[2, 1] == marker && playBoard[3, 1] == marker)
            {
                return true;
            }
            if (playBoard[1, 2] == marker && playBoard[2, 2] == marker && playBoard[3, 2] == marker)
            {
                return true;
            }
            if (playBoard[1, 3] == marker && playBoard[2, 3] == marker && playBoard[3, 3] == marker)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}