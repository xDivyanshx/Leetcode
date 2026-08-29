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
        List<int> currentBucket = [nums[0]];
        for (int i = 1; i < nums.Length; i++)
        {
            int range = nums[i] - nums[i - 1];
            if (range > limit)
            {
                bucketList.Add(currentBucket);
                currentBucket = [nums[i]];
            }
            else
            {
                currentBucket.Add(nums[i]);
            }

        }
        if (currentBucket.Count > 0)
            bucketList.Add(currentBucket);

        List<List<int>> indexAccordingToBucketList = new List<List<int>>();
        for (int i = 0; i < bucketList.Count; i++)
        {
            List<int> bucket = bucketList[i];
            List<int> indexAccordingToBucket = new List<int>();
            for (int y = 0; y < bucket.Count; y++)
            {
                if (y == 0)
                {
                    indexAccordingToBucket.AddRange(indexListMap[bucket[y]]);
                }
                else if (y > 0 && bucket[y] != bucket[y - 1])
                {
                    indexAccordingToBucket.AddRange(indexListMap[bucket[y]]);
                }
            }
            indexAccordingToBucket.Sort();
            indexAccordingToBucketList.Add(indexAccordingToBucket);
        }

        int[] result = new int[nums.Length];

        for (int i = 0; i < bucketList.Count; i++)
        {
            List<int> bucket = bucketList[i];
            List<int> index = indexAccordingToBucketList[i];
            for (int j = 0; j < bucket.Count; j++)
            {
                result[index[j]] = bucket[j];
            }
        }
        return result;
    }
}
