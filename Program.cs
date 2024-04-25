using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.PlayGame();
            Console.ReadLine();

        }
    }
}
