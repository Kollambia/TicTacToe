using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameProject.GameLogic;

namespace TicTacToeGameProject.UserInterface
{
    /// <summary>
    /// Класс меню отвечает за Вывод основного меню для приложения
    /// </summary>
    internal class Menu : Fields
    {
        /// <summary>
        /// Моделирует поведение класс вызовом меню
        /// </summary>
        public void PrintMenu()
        {
            Console.WriteLine("Welcome to the tic-tac-toe game. Available commands:" +
                "\n1. ’start’ (or ‘s’) - start the game." +
                "\n2. ‘help’ (or ‘h’) - show game rules." +
                "\n3. ‘quit’ (or ‘q’) -quit the game.\n");
        }
        public string MenuLogic()
        {
            while (true)
            {
                Console.Write(">");
                string messageToMenu = Console.ReadLine();
                messageToMenu = messageToMenu.Trim().ToLower();
                
                switch (messageToMenu)
                {
                    case "start":
                    case "s":
                        Game game = new Game();
                        ResetField();
                        game.PlayAsync();
                        break;

                    case "help":
                    case "h":
                        Console.Clear();
                        Console.WriteLine("The first move is human, then computer." +
                            "\nThe game is played until one of the players draws three symbols in one row or until there is a tie.");
                        break;

                    case "quit":
                    case "q":
                        Console.Clear();
                        Console.WriteLine("It's too bad you're leaving us.");
                        Environment.Exit(0);
                        break;

                    default: Console.WriteLine("\nUnknown command"); break;
                }
            }
        }
        public void Help()
        {
            Console.Clear();
            Console.WriteLine("The first move is human, then computer." +
                            "\nThe game is played until one of the players draws three symbols in one row or until there is a tie.\n");
        }
        public void Quit()
        {
            Console.Clear();
            Console.WriteLine("It's too bad you're leaving us.");
            Environment.Exit(0);
        }

    }
}
