using joseChipsConsole.Controllers;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            ChipManager chipManager = new ChipManager();

            int[] chips0 = { 1, 2, 3};
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

            var moves0 = chipManager.MinChipMoves(chips0, 0);
            var moves1 = chipManager.MinChipMoves(chips1, 0);
            var moves2 = chipManager.MinChipMoves(chips2, 0);
            var moves3 = chipManager.MinChipMoves(chips3, 0);
            var moves4 = chipManager.MinChipMoves(chips4, 0);
            var moves5 = chipManager.MinChipMoves(chips5, 0);
            var moves6 = chipManager.MinChipMoves(chips6, 0);
            var moves7 = chipManager.MinChipMoves(chips7, 0);
            var moves8 = chipManager.MinChipMoves(chips8, 0);
            var moves9 = chipManager.MinChipMoves(chips9, 0);
            var moves10 = chipManager.MinChipMoves(chips10, 0);

            Console.WriteLine($"Moves 0: {moves0}");
            Console.WriteLine($"Moves 1: {moves1}");
            Console.WriteLine($"Moves 2: {moves2}");
            Console.WriteLine($"Moves 3: {moves3}");
            Console.WriteLine($"Moves 4: {moves4}");
            Console.WriteLine($"Moves 5: {moves5}");
            Console.WriteLine($"Moves 6: {moves6}");
            Console.WriteLine($"Moves 7: {moves7}");
            Console.WriteLine($"Moves 8: {moves8}");
            Console.WriteLine($"Moves 9: {moves9}");
            Console.WriteLine($"Moves 10: {moves10}");

        }
    }
}
