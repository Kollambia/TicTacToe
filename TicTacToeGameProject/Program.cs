using System;
using System.Text.RegularExpressions;
using TicTacToeGameProject.UserInterface;

namespace TicTacToeGameProject
{
    class Program
    {
        static void Main(String[] args)
        {
            Menu menu = new Menu();
            menu.PrintMenu();
            menu.MenuLogic();
        }
    }
}