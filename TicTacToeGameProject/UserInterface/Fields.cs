using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameProject.GameLogic;

namespace TicTacToeGameProject.UserInterface
{
    /// <summary>
    /// Класс предназначенный для создания доски
    /// </summary>
    internal class Fields
    {
        protected static string[] field = { "*", "*", "*", "*", "*", "*", "*", "*", "*" };

        /// <summary>
        ///  Моделирует внешний вид доски для игры
        /// </summary>
        public void PrintField()
        {
            Console.WriteLine($"\n{field[0]} {field[1]} {field[2]}");
            Console.WriteLine($"{field[3]} {field[4]} {field[5]}");
            Console.WriteLine($"{field[6]} {field[7]} {field[8]}\n");
        }
        protected bool OpenSpace(int index)
        {
            if (field[index] == "X" || field[index] == "O")
            {
                Console.WriteLine("\nThat space is taken. Choose a free space!\n");
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        ///  После завершенной игры, предлагает сыграть заново и выводит чистую доску
        /// </summary>
        protected void ResetField()
        {
            try
            {
                Console.WriteLine("\nThe position on the table is as follows:");
                field[0] = "*";
                field[1] = "*";
                field[2] = "*";
                field[3] = "*";
                field[4] = "*";
                field[5] = "*";
                field[6] = "*";
                field[7] = "*";
                field[8] = "*";
                PrintField();

                Game game = new Game();
                game.PlayAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void AskForPlayAgain()
        {
            try
            {
                Console.WriteLine("\nShall we play again? Type in (y/n)\n");
                string answer = Console.ReadLine().ToLower().Trim();
                if (answer == "y")
                {
                    ResetField();
                    Game game = new Game();
                    game.PlayAsync();
                }
                else if (answer == "n")
                {
                    Menu menu = new Menu();
                    menu.PrintMenu();
                    menu.MenuLogic();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
