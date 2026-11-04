public class Solution {
    public bool IsPerfectSquare(int num) {
        if (num < 0)
            return false;

        long left = 0, right = num;

        while (left <= right)
        {
            long mid = left + (right - left) / 2;
            long square = mid * mid;

            if (square == num)
                return true;

            if (square < num)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}