using System;
using System.Linq;
namespace TicTacToe
{
    class Player
    {
        char marker;
        #region Constructor
        public Player()
        {
            SelectMarker();
        }
        #endregion
        #region Properties
        public char Marker
        {
            get => marker;
            set => marker = value;
        }
        #endregion
        #region Public Methods
        public string MakeMove()
        {
            Console.Write("Input Movement: ");
            string playerMove = Console.ReadLine();
            // Validate the Move
            while (IsMoveValid(playerMove) == false)
            {
                Console.WriteLine("[ERROR] - Invalid Input - Length must be 2 and Digits must between 1-3 and Characters must be 'A', 'B', or 'C'");
                Console.Write("Input Movement: ");
                playerMove = Console.ReadLine();
            }
            return playerMove;
        }
        public void SelectMarker()
        {
            Console.WriteLine("Would you like marker to be? X or O?");
            Marker = Console.ReadKey().KeyChar;
            // Only allow 'X' or 'O'
            while (Marker != 'X' && Marker != 'O')
            {
                Console.WriteLine("[ERROR] - Invalid Input - Please input X or O");
                Console.WriteLine("Would you like marker to be? X or O?");
                Marker = Console.ReadKey().KeyChar;
            }
        }
        #endregion
        #region Private Methods

        private bool IsMoveValid(string playerMove)
        {
            // Validate the input
            if (playerMove.Length != 2)
            {
                return false;
            }
            char[] validCharacters = { 'A', 'B', 'C' };
            if (Char.IsDigit(playerMove[0]))
            {
                if (Char.GetNumericValue(playerMove[0]) > 3)
                {
                    return false;
                }
                if (validCharacters.Contains(playerMove[1]) == false)
                {
                    return false;
                }
            }
            else
            {
                if (Char.GetNumericValue(playerMove[1]) > 3)
                {
                    return false;
                }
                if (validCharacters.Contains(playerMove[0]) == false)
                {
                    return false;
                }
            }
            // Validate the choice
            return true;
        }
        #endregion
    }
}