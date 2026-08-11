// 146. LRU Cache
// Difficulty: Medium
// https://leetcode.com/problems/lru-cache/
// Runtime: 32 ms | Memory: 177.9 MB | Submitted: 2026-06-27


using System.Collections.Generic;



public class LRUCache
{
    private Dictionary<int, LinkedListNode<CacheItem>> cache;
    int capacity;
    int lRU;

    class CacheItem
    {
        public int Key;
        public int Value;
        public CacheItem(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }

    private LinkedList<CacheItem> lruList;



    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        this.lruList = new LinkedList<CacheItem>();
        this.cache = new Dictionary<int, LinkedListNode<CacheItem>>();
    }

    public int Get(int key)
    {
        if (cache.TryGetValue(key, out LinkedListNode<CacheItem> value))
        {
            lruList.Remove(value);
            lruList.AddFirst(value);
            return value.Value.Value;
        }
        else
            return -1;
    }

    public void Put(int key, int value)
    {
        if (cache.TryGetValue(key, out LinkedListNode<CacheItem> valueNode))
        {
            valueNode.Value.Value = value;

            // They were just used, so pull them out of line and move to the front
            lruList.Remove(valueNode);
            lruList.AddFirst(valueNode);
        }
        else
        {
            // Are we at capacity? Someone has to get kicked out!
            if (cache.Count == capacity)
            {
                // Find the person at the very back of the line (Least Recently Used)
                LinkedListNode<CacheItem> oldestNode = lruList.Last;

                // Kick them out of the Dictionary using their Key
                cache.Remove(oldestNode.Value.Key);

                // Kick them out of the line
                lruList.RemoveLast();
            }
            CacheItem newItem = new CacheItem(key, value);
            LinkedListNode<CacheItem> newNode = new LinkedListNode<CacheItem>(newItem);

            // Put them at the front of the line (Newest)
            lruList.AddFirst(newNode);

            // Add them to the Dictionary so we can find them instantly next time
            cache[key] = newNode;
        }
    }
}