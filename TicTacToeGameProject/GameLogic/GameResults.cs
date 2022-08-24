using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameProject.UserInterface;

namespace TicTacToeGameProject.GameLogic
{
    internal class GameResults : Fields
    {
        /// <summary>
        /// Метод для проверки победителя
        /// </summary>
        public bool CheckForWin()
        {
            if (
                field[0] == field[1] && field[1] == field[2] && field[2] != "*" ||
                field[3] == field[4] && field[4] == field[5] && field[5] != "*" ||
                field[6] == field[7] && field[7] == field[8] && field[8] != "*" ||
                field[0] == field[4] && field[4] == field[8] && field[8] != "*" ||
                field[2] == field[4] && field[4] == field[6] && field[6] != "*" ||
                field[0] == field[3] && field[3] == field[6] && field[6] != "*" ||
                field[1] == field[4] && field[4] == field[7] && field[7] != "*" ||
                field[2] == field[5] && field[5] == field[8] && field[8] != "*"
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Метод для проверки ничьей
        /// </summary>
        public bool CheckDraw()
        {
            if (field[0] != "*" && CheckForWin() == false &&
                field[1] != "*" && CheckForWin() == false &&
                field[2] != "*" && CheckForWin() == false &&
                field[3] != "*" && CheckForWin() == false &&
                field[4] != "*" && CheckForWin() == false &&
                field[5] != "*" && CheckForWin() == false &&
                field[6] != "*" && CheckForWin() == false &&
                field[7] != "*" && CheckForWin() == false &&
                field[8] != "*" && CheckForWin() == false)
            {
                Console.WriteLine("\nIt's a draw, babe.");
                AskForPlayAgain();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
