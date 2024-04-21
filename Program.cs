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
            int[] chips3 = { 13, 8, 28, 21, 30, 6, 13, 27, 23, 1 };
            int[] chips4 = { 0, 10, 0, 8, 3, 10, 7, 0, 9, 3 };
     

            var moves0 = chipManager.CalculateChips(chips0);
            var moves1 = chipManager.CalculateChips(chips1);
            var moves2 = chipManager.CalculateChips(chips2);
            var moves3 = chipManager.CalculateChips(chips3);
            var moves4 = chipManager.CalculateChips(chips4);


            Console.WriteLine($"Moves 0: {moves0}");
            Console.WriteLine($"Moves 1: {moves1}");
            Console.WriteLine($"Moves 2: {moves2}");
            Console.WriteLine($"Moves 3: {moves3}");
            Console.WriteLine($"Moves 4: {moves4}");

        }
    }
}
