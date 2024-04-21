using joseChipsConsole.Models;

namespace joseChipsConsole.Controllers
{
    public class ChipManager
    {
        public int CalculateChips(int[] chips)
        {
            List<int> indexes = new List<int>();
            List<int> moves = new List<int>();

            double average = chips.Average();

            for (int i = 0; i < chips.Length; i++)
            {
                if (chips[i] > average)
                {
                    indexes.Add(i);
                }
            }

            if (indexes.Count > 0)
            {
                foreach (int index in indexes)
                {
                    var currentMoves = MinChipMoves(chips, index, 0);
                    moves.Add(currentMoves);
                }
            }

            return moves.Min();
        }
        public int MinChipMoves(int[] chips, int index, int sumMoves)
        {
            var totalChips = CalculateTotalChips(chips);
            var n = chips.Length;
            int[] newChips = (int[])chips.Clone();

            if (totalChips % n != 0) return -1;

            var target = CalculateTarget(totalChips, n);
    
            if (newChips.All(chip => chip == target)) return sumMoves;

            var moves = sumMoves;
            for (int i = index; i < index + n; i++)
            {
                if (newChips[i] <= target) continue;

                var diffLeft = CalculateDiff(newChips, i, target, true);
                var diffRight = CalculateDiff(newChips, i, target, false);

                    bool moveLeft = IsLeftBetterMove(newChips, i);
                    if (moveLeft)
                    {
                        moves += CalculateMovesForCondition(newChips, i, diffLeft, target, n, true);
                    break;
                    }
                    else
                    {
                        moves += CalculateMovesForCondition(newChips, i, diffRight, target, n, false);
                    break;
                }
            }
            return MinChipMoves(newChips,0, moves);
        }
        private bool IsLeftBetterMove(int[] chips, int currentIndex)
        {
            int n = chips.Length;
            int leftSum = 0, rightSum = 0;

            for (int i = 1; i <= n / 2; i++)
            {
                leftSum += chips[(currentIndex - i + n) % n];
                rightSum += chips[(currentIndex + i) % n];
            }

            return leftSum < rightSum;
        }

        private int CalculateTotalChips(int[] chips)
        {
            return chips.Sum();
        }

        private int CalculateTarget(int totalChips, int n)
        {
            return totalChips / n;
        }

        private int CalculateDiff(int[] chips, int currentIndex, int targetValue, bool isLeft)
        {
            var diff = 0;
            var n = chips.Length;
            var index = isLeft ? (currentIndex - 1 + n) % n : (currentIndex + 1) % n;

            while (index != currentIndex)
            {
                diff += 1;
                if (chips[index] < targetValue) break;
                index = isLeft ? (index - 1 + n) % n : (index + 1) % n;
            }
            return diff;
        }

        private int CalculateMovesForCondition(int[] newChips, int currentIndex, int diff, int target, int n, bool isSide)
        {
            int l = 0;

            if (isSide)
            {
                l = (currentIndex - diff) % n;
            }
            else
            {
                l = (currentIndex + diff) % n;
            }

            var diffValue = MoveChips(newChips, currentIndex, l, target);
            var moveCalculator = new MoveCalculatorModel(diffValue, diff, newChips, currentIndex, l);
            return moveCalculator.CalculateMoves(newChips);
        }

        private int MoveChips(int[] chips, int currentIndex, int targetIndex, int targetValue)
        {
            var n = chips.Length;
            currentIndex = (currentIndex + n) % n;
            targetIndex = (targetIndex + n) % n;
            var diff = 0;
            int diff1 = Math.Abs(chips[currentIndex] - targetValue);
            int diff2 = Math.Abs(targetValue - chips[targetIndex]);
            if (diff1 != 0 && diff2 != 0)
            {
                diff = Math.Min(diff1, diff2);
                chips[targetIndex] += diff;
                chips[currentIndex] -= diff;
            }
            else
            {
                if (diff1 == 0)
                {
                    diff = diff2;
                }
                else
                {
                    diff = diff1;
                }
                chips[targetIndex] += diff;
                chips[currentIndex] -= diff;
            }

            return diff;
        }

    }
}