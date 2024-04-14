namespace joseChipsConsole.Controllers
{
    public class ChipManager
    {
        public static int MinChipMoves(int[] chips, int sumMoves = 0)
        {
            int totalChips = CalculateTotalChips(chips);
            int n = chips.Length;
            int[] newChips = (int[])chips.Clone();

            if (totalChips % n != 0)
            {
                return -1;
            }

            int target = CalculateTarget(totalChips, n);

            if (newChips.All(chip => chip == target))
            {
                return sumMoves;
            }

            int moves = sumMoves;
            for (int i = 0; i < n; i++)
            {
                if (newChips[i] <= target)
                {
                    continue;
                }

                int diffLeft = CalculateDiffLeft(newChips, i, target);
                int diffRight = CalculateDiffRight(newChips, i, target);
                if (diffRight == 0 && diffLeft > 0)
                {
                    int l = (i - diffLeft) % n;
                    int diff = MoveChips(newChips, i, l, target);
                    moves += CalculateMoves(diff, diffLeft, newChips, i, l);
                    continue;
                }

                if (diffLeft == 0 && diffRight > 0)
                {
                    int l = (i + diffRight) % n;
                    int diff = MoveChips(newChips, i, l, target);
                    moves += CalculateMoves(diff, diffRight, newChips, i, l);
                    continue;
                }

                if (diffRight < diffLeft)
                {
                    int l = (i + diffRight) % n;
                    int diff = MoveChips(newChips, i, l, target);
                    moves += CalculateMoves(diff, diffRight, newChips, i, l);
                    continue;
                }

                if (diffLeft < diffRight)
                {
                    int l = (i - diffLeft) % n;
                    int diff = MoveChips(newChips, i, l, target);
                    moves += CalculateMoves(diff, diffLeft, newChips, i, l);
                    continue;
                }

                if (diffRight == diffLeft && diffRight > 0 && diffLeft > 0)
                {
                    int l = (i + diffRight) % n;
                    int diff = MoveChips(newChips, i, l, target);
                    moves += CalculateMoves(diff, diffRight, newChips, i, l);
                    continue;
                }
            }
            return MinChipMoves(newChips, moves);
        }

        private static int CalculateMoves(int diff, int diffValue, int[] chips, int startIndex, int targetIndex)
        {
            int minMoves = CalculateMinMoves(chips, startIndex, targetIndex);
            return diff * Math.Min(diffValue, minMoves);
        }

        //private static int CalculateMinMoves(int[] chips, int startIndex, int targetIndex)
        //{
        //    int n = chips.Length;
        //    int clockwiseMoves = Math.Abs(targetIndex - startIndex);
        //    int counterclockwiseMoves = n - clockwiseMoves;
        //    return Math.Min(clockwiseMoves, counterclockwiseMoves);
        //}


        private static int CalculateMinMoves(int[] chips, int startIndex, int targetIndex)
        {
            int n = chips.Length;
            int clockwiseMoves = Math.Abs(targetIndex - startIndex);
            int counterclockwiseMoves = n - clockwiseMoves;
            return Math.Min(clockwiseMoves, counterclockwiseMoves);
        }

        //private static int CalculateMoves(int diff, int diffValue)
        //{
        //    return diff * diffValue;
        //}

        private static int CalculateTotalChips(int[] chips)
        {
            return chips.Sum();
        }

        private static int CalculateTarget(int totalChips, int n)
        {
            return totalChips / n;
        }

        private static int CalculateDiffLeft(int[] chips, int currentIndex, int targetValue)
        {
            int diffLeft = 0;
            int n = chips.Length;
            int j = (currentIndex - 1 + n) % n;
            while (chips[j] < targetValue || (j != currentIndex && chips[j] <= targetValue))
            {
                diffLeft += 1;
                if (chips[j] < targetValue)
                {
                    break;
                }
                j = (j - 1 + n) % n;
            }
            return diffLeft;
        }

        private static int CalculateDiffRight(int[] chips, int currentIndex, int targetValue)
        {
            int diffRight = 0;
            int n = chips.Length;
            int k = (currentIndex + 1) % n;
            while (chips[k] < targetValue || (k != currentIndex && chips[k] <= targetValue))
            {
                diffRight += 1;
                if (chips[k] < targetValue)
                {
                    break;
                }
                k = (k + 1) % n;
            }
            return diffRight;
        }
        private static int MoveChips(int[] chips, int currentIndex, int targetIndex, int targetValue)
        {
            int n = chips.Length;
            currentIndex = (currentIndex + n) % n;
            targetIndex = (targetIndex + n) % n;

            int diff = Math.Min(Math.Abs(chips[currentIndex] - targetValue), Math.Abs(chips[targetIndex] - targetValue));
            chips[targetIndex] += diff;
            chips[currentIndex] -= diff;
            return diff;
        }

    }
}