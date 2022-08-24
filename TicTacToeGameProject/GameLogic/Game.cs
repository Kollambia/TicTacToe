using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameProject.UserInterface;

namespace TicTacToeGameProject.GameLogic
{
    /// <summary>
    /// Касс реализующий основную логику игры 
    /// </summary>
    internal class Game : Fields
    {
        /// <summary>
        /// Моделирование игры
        /// </summary>
        public async Task PlayAsync(CancellationToken token = default)
        {
            try
            {
                GameResults results = new GameResults();
                Menu menu = new Menu();

                Console.WriteLine("Please enter index of the cell you’d like to put the cross in: X, Y\n(Exaple: 1 2)\n" +
                    "If more than two numbers are entered, they will not be counted\n");

                Console.Write(">");

                string message = Console.ReadLine().ToLower();
                message = message.Replace(" ", "");

                if (message == "help" || message == "h")
                {
                    menu.Help();
                }
                else if (message == "quit" || message == "q")
                {
                    menu.Quit();
                }
                else
                {
                    IEnumerable<int> intList = message.Select(digit => int.Parse(digit.ToString()));
                    int[] positions = intList.ToArray();

                    int x = positions[0];
                    int y = positions[1];

                    int index = FormulaForPosition(x, y);

                    // Провека, что если хотя бы один из вводимых данных неверен
                    if (!(ValidateInput(x) && ValidateInput(y)))
                    {
                        PlayAsync();
                    }

                    if (OpenSpace(index))
                    {
                        field[index] = "X";

                        Console.WriteLine("\nThe position on the table is as follows:\n");
                        PrintField();
                    }
                    else
                    {
                        PlayAsync();
                    }

                    if (results.CheckForWin())
                    {
                        PrintField();
                        Console.WriteLine("You are the champion!!!");
                        AskForPlayAgain();
                    }

                    else if (results.CheckDraw())
                    {
                        PrintField();
                        AskForPlayAgain();
                    }

                    Computer computer = new Computer();
                    await computer.ComputerMoveAsync();

                    PrintField();
                    PlayAsync();
                }
                
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                PlayAsync();
            }  
        }
        /// <summary>
        /// Метод на проверку правльного ввода, так как catch не ловит некоторые ошибки ввода к примеру: 2,5 или 5,1
        /// </summary>
        private bool ValidateInput(int input)
        {
            if (input <= 3 && input > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("\nThe entry was incorrect!\n");
                return false;
            }
        }
        /// <summary>
        /// Получаем индекс x, y и создаем формулу для устнановки x, y
        /// </summary>
        public int FormulaForPosition(int x, int y)
        {
            return (y - 1) + (x - 1) * 3;
        }
    }
}
