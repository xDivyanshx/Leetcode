public class Solution {
    public bool IsPerfectSquare(int num) {
        if (num < 0)
            return false;

        for (int i = 1; i <= num / i; i++)
        {
            if (i * i == num)
                return true;
        }

        return num == 0;
    }
}