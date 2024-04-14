
using joseChipsConsole.Controllers;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] chips1 = { 8, 10, 2, 5, 5 };
            int[] chips2 = { 1, 5, 9, 10, 5 };
            int[] chips3 = { 3, 3, 3, 3, 3, 3 };
            int[] chips4 = { 0, 0, 0, 0, 0, 0, 0 };
            int[] chips5 = { 4, 3, 2, 1 };
            int[] chips6 = { 9, 8, 7, 6 };
            int[] chips7 = { 5, 5, 5, 5 };
            int[] chips8 = { 0, 2, 4, 6, 8, 10 };
            int[] chips9 = { 1, 3, 5, 7, 9, 11 };
            int[] chips10 = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };

            int moves1 = ChipManager.MinChipMoves(chips1, 0);
            int moves2 = ChipManager.MinChipMoves(chips2, 0);
            int moves3 = ChipManager.MinChipMoves(chips3, 0);
            int moves4 = ChipManager.MinChipMoves(chips4, 0);
            int moves5 = ChipManager.MinChipMoves(chips5, 0);
            int moves6 = ChipManager.MinChipMoves(chips6, 0);
            int moves7 = ChipManager.MinChipMoves(chips7, 0);
            int moves8 = ChipManager.MinChipMoves(chips8, 0);
            int moves9 = ChipManager.MinChipMoves(chips9, 0);
            int moves10 = ChipManager.MinChipMoves(chips10, 0);

        }
    }
}