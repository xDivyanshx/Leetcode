public class Solution
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        Dictionary<int, List<int>> indexMap = new Dictionary<int, List<int>>();
        List<List<int>> bucketList = new List<List<int>>();
        int lastInteger = -1;
        List<int> bucket = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!indexMap.ContainsKey(nums[i]))
            {
                indexMap[nums[i]] = [];
            }
            indexMap[nums[i]].Add(i);
        }
        nums.Sort();
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                bucket.Add(nums[i]);
            }
            else
            {
                int range = nums[i] - nums[i - 1];
                if (range > limit)
                {
                    List<int> tempBucket = new List<int>();
                    foreach (int x in bucket)
                        tempBucket.Add(x);
                    bucketList.Add(tempBucket);
                    bucket = new List<int>();
                    bucket.Add(nums[i]);
                }
                else
                {
                    bucket.Add(nums[i]);
                }
            }
        }

        if (bucket.Count > 0)
            bucketList.Add(bucket);

        List<List<int>> bucketIndex = new List<List<int>>();
        for (int i = 0; i < bucketList.Count; i++)
        {
            List<int> bucketNow = bucketList[i];
            List<int> bucketindexList = new List<int>();
            for (int y = 0; y < bucketNow.Count; y++)
            {
                if (y == 0)
                {
                    bucketindexList.AddRange(indexMap[bucketNow[y]]);
                }
                else if (y > 0 && bucketNow[y] != bucketNow[y - 1])
                {
                    bucketindexList.AddRange(indexMap[bucketNow[y]]);
                }
            }
            bucketindexList.Sort();
            bucketIndex.Add(bucketindexList);
        }

        int[] result = new int[nums.Length];

        for (int i = 0; i < bucketList.Count; i++)
        {
            List<int> bucketNow = bucketList[i];
            List<int> indexNow = bucketIndex[i];
            for (int j = 0; j < bucketNow.Count; j++)
            {
                result[indexNow[j]] = bucketNow[j];
            }
        }
        return result;
    }
}
