// 3304. Find the K-th Character in String Game I
// Difficulty: Easy
// https://leetcode.com/problems/find-the-k-th-character-in-string-game-i/
// Runtime: 1 ms | Memory: 43.5 MB | Submitted: 2025-07-03

using System.Text;

public class Solution
{
public char KthCharacter(int k)
{
   StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append('a');
    StringBuilder stringBuilder2 = new StringBuilder();
    int i = 0;
    while (stringBuilder.Length < k)
    {
        int len = stringBuilder.Length;
        for (;i<len;i++)
        {
            char c = stringBuilder[i];
            stringBuilder2.Append((char)(((c + 1 - 97) % 26) + 97));
        }
        stringBuilder.Append(stringBuilder2);
    }
    return stringBuilder[k-1];

}
}