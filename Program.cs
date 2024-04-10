using ConsoleApp1;
using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.PrintGameBoard();

            string playerMove;
            Console.WriteLine("Input Movement: ");
            playerMove = Console.ReadLine();
            gameBoard.UpdateGameBoard(playerMove);
        }
    }
}
