// 1550. Three Consecutive Odds
// Difficulty: Easy
// https://leetcode.com/problems/three-consecutive-odds/
// Runtime: 0 ms | Memory: 44.3 MB | Submitted: 2025-05-11

public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int countConsecutiveOdd = 0;
        foreach(int i in arr)
        {
            if (i%2==1)
            {
                if (countConsecutiveOdd != 0)
                    countConsecutiveOdd++;
                else 
                    countConsecutiveOdd = 1;
                if (countConsecutiveOdd == 3)
                    return true;
            }
            else
                countConsecutiveOdd = 0;
        }
        return false;        
    }
}