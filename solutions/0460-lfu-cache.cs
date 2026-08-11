// 460. LFU Cache
// Difficulty: Hard
// https://leetcode.com/problems/lfu-cache/
// Runtime: 116 ms | Memory: 183.3 MB | Submitted: 2025-12-25

using System.Collections.Generic;

public class LFUCache
{
    private int capacity;
    private int minFreq;

    private Dictionary<int, int> values;               // key → value
    private Dictionary<int, int> freq;                 // key → freq count
    private Dictionary<int, LinkedList<int>> freqList; // freq → keys (LRU inside)

    public LFUCache(int capacity)
    {
        this.capacity = capacity;
        values = new Dictionary<int, int>();
        freq = new Dictionary<int, int>();
        freqList = new Dictionary<int, LinkedList<int>>();
    }

    public int Get(int key)
    {
        if (!values.ContainsKey(key)) return -1;

        int f = freq[key];
        freq[key] = f + 1;

        // remove from old freq list
        freqList[f].Remove(key);
        if (freqList[f].Count == 0 && minFreq == f)
            minFreq++;

        // add to new freq list
        if (!freqList.ContainsKey(f + 1))
            freqList[f + 1] = new LinkedList<int>();

        freqList[f + 1].AddLast(key);

        return values[key];
    }

    public void Put(int key, int value)
    {
        if (capacity == 0) return;

        // update case
        if (values.ContainsKey(key))
        {
            values[key] = value;
            Get(key); // update frequency via Get
            return;
        }

        // eviction if full
        if (values.Count == capacity)
        {
            int evictKey = freqList[minFreq].First.Value;
            freqList[minFreq].RemoveFirst();

            values.Remove(evictKey);
            freq.Remove(evictKey);
        }

        // insert new element
        values[key] = value;
        freq[key] = 1;
        minFreq = 1;

        if (!freqList.ContainsKey(1))
            freqList[1] = new LinkedList<int>();

        freqList[1].AddLast(key);
    }
}
