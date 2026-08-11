// 380. Insert Delete GetRandom O(1)
// Difficulty: Medium
// https://leetcode.com/problems/insert-delete-getrandom-o1/
// Runtime: 10 ms | Memory: 126.3 MB | Submitted: 2026-06-29

using System;
using System.Collections.Generic;

public class RandomizedSet
{
    private static Random random = new Random();
    Dictionary<int, int> valueIndexMap;
    List<int> valueList;

    public RandomizedSet()
    {
        valueIndexMap = new Dictionary<int, int>();
        valueList = new List<int>();
    }

    public bool Insert(int val)
    {
        if (valueIndexMap.ContainsKey(val))
        {
            return false;
        }
        else
        {
            valueList.Add(val);
            valueIndexMap[val] = valueList.Count - 1;
            return true;
        }
    }

    public bool Remove(int val)
    {
        if (valueIndexMap.TryGetValue(val, out int index))
        {

            int lastValue = valueList[valueList.Count - 1];
            valueIndexMap[lastValue] = index;
            valueList[index] = lastValue;
            valueList.RemoveAt(valueList.Count - 1);
            valueIndexMap.Remove(val);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetRandom()
    {
        int x = random.Next(0, valueList.Count);
        return valueList[x];
    }
}