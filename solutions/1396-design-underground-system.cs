// 1396. Design Underground System
// Difficulty: Medium
// https://leetcode.com/problems/design-underground-system/
// Runtime: 28 ms | Memory: 88.3 MB | Submitted: 2026-06-29

using System.Collections.Generic;

public class UndergroundSystem
{
    Dictionary<(string startStation, string endStation), (double totalDuration, int totalCount)> timeMap;
    Dictionary<int, (string startStation, int startTime)> customerMap = [];
    public UndergroundSystem()
    {
        timeMap = [];
        customerMap = [];
    }

    public void CheckIn(int id, string stationName, int t)
    {
        customerMap.Add(id, (stationName, t));
    }

    public void CheckOut(int id, string stationName, int t)
    {
        (string startStation, int startTime) existingTripInfo = customerMap[id];
        customerMap.Remove(id);
        (string s1, string s2) stationPair = (existingTripInfo.startStation, stationName);
        double duration = t - existingTripInfo.startTime;
        if (!timeMap.ContainsKey(stationPair))
        {
            timeMap[stationPair] = (duration, 1);
        }
        else
        {
            (double totalDuration, int count) exisitingAnalytics = timeMap[stationPair];
            timeMap[stationPair] = (exisitingAnalytics.totalDuration + duration, exisitingAnalytics.count + 1);
        }
    }

    public double GetAverageTime(string startStation, string endStation)
    {
        return (timeMap[(startStation, endStation)].totalDuration / timeMap[(startStation, endStation)].totalCount);
    }
}