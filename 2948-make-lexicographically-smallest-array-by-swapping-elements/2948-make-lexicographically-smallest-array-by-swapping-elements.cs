public class Solution
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        Dictionary<int, List<int>> indexListMap = new Dictionary<int, List<int>>();
        List<List<int>> bucketList = new List<List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!indexListMap.ContainsKey(nums[i]))
            {
                indexListMap[nums[i]] = [];
            }
            indexListMap[nums[i]].Add(i);
        }
        nums.Sort();
        List<int> currentBucket = new List<int>();
        currentBucket.Add(nums[0]);
        for (int i = 1; i < nums.Length; i++)
        {

            int range = nums[i] - nums[i - 1];
            if (range > limit)
            {
                List<int> tempBucket = new List<int>();
                foreach (int x in currentBucket)
                    tempBucket.Add(x);
                bucketList.Add(tempBucket);
                currentBucket = new List<int>();
                currentBucket.Add(nums[i]);
            }
            else
            {
                currentBucket.Add(nums[i]);
            }

        }

        if (currentBucket.Count > 0)
            bucketList.Add(currentBucket);

        List<List<int>> bucketIndex = new List<List<int>>();
        for (int i = 0; i < bucketList.Count; i++)
        {
            List<int> bucketNow = bucketList[i];
            List<int> bucketindexList = new List<int>();
            for (int y = 0; y < bucketNow.Count; y++)
            {
                if (y == 0)
                {
                    bucketindexList.AddRange(indexListMap[bucketNow[y]]);
                }
                else if (y > 0 && bucketNow[y] != bucketNow[y - 1])
                {
                    bucketindexList.AddRange(indexListMap[bucketNow[y]]);
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
