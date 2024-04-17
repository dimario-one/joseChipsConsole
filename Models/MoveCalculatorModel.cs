using System;

namespace joseChipsConsole.Models
{
    internal class MoveCalculatorModel
    {
        public int Diff { get; set; }
        public int DiffValue { get; set; }
        public int[] Chips { get; set; }
        public int StartIndex { get; set; }
        public int TargetIndex { get; set; }

        public MoveCalculatorModel(int diff, int diffValue, int[] chips, int startIndex, int targetIndex)
        {
            Diff = diff;
            DiffValue = diffValue;
            Chips = chips;
            StartIndex = startIndex;
            TargetIndex = targetIndex;
        }
        public int CalculateMoves(int[] chips)
        {
            int minMoves = CalculateMinMoves(chips);
            return Diff * Math.Min(DiffValue, minMoves);
        }
        private int CalculateMinMoves(int[] chips)
        {
            int n = Chips.Length;
            int clockwiseMoves = Math.Abs(TargetIndex - StartIndex);
            int counterclockwiseMoves = n - clockwiseMoves;
            return Math.Min(clockwiseMoves, counterclockwiseMoves);
        }
    }
}
