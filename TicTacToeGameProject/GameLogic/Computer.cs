using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameProject.UserInterface;

namespace TicTacToeGameProject.GameLogic
{
    /// <summary>
    /// Класс для реализации действий компьютера
    /// </summary>
    internal class Computer : Fields
    {
        /// <summary>
        /// Моделирование действий компьютера
        /// </summary>
        public async Task ComputerMoveAsync(CancellationToken token = default)
        {
            try
            {
                GameResults gameResults = new GameResults();

                int[] openSpots = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                int count = 0;

                for (int i = 0; i <= 8; i++)
                {
                    if (field[i] == "*")
                    {
                        openSpots[count] = i;
                        count++;
                    }
                }

                Console.WriteLine("\nArtificial intelligence finds the best move...");

                Random rnd = new Random();
                int rndForDelay = rnd.Next(500, 2001);
                int rndInt = rnd.Next(0, count);

                Task.Delay(rndForDelay).Wait();

                field[openSpots[rndInt]] = "O";

                if (gameResults.CheckForWin())
                {
                    PrintField();
                    Console.WriteLine("\nYou lose!");
                    AskForPlayAgain();

                    Game game = new Game();
                    game.PlayAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
