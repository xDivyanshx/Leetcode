// 3508. Implement Router
// Difficulty: Medium
// https://leetcode.com/problems/implement-router/
// Runtime: 136 ms | Memory: 197 MB | Submitted: 2025-09-20

// ///////////////////////////////////////////////////////////////////////////////////////////////////////
//
//
// All rights reserved by OneBanc
//
//
// (c) Copyright 2025 OneBanc Technologies Pvt. Ltd.
//
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections.Generic;
using System.Diagnostics;

[DebuggerDisplay("Source = {source}, Destination = {destonation}, Timestamp = {timestamp}")]
public struct Packet
{
	int source;
	int destonation;
	int timestamp;

	public int Source
	{
		get { return source; }
	}

	public int Destonation
	{
		get { return destonation; }
	}

	public int Timestamp
	{
		get { return timestamp; }
	}

	public Packet(int source, int destination, int timestamp)
	{
		this.source = source;
		this.destonation = destination;
		this.timestamp = timestamp;
	}
}
public class Router
{
	Queue<Packet> packets;
	private int capacity;

	private HashSet<Packet> packetHash;
	private Dictionary<int, List<int>> destinationTimestampMap;
	public Router(int memoryLimit)
	{
		packets = new Queue<Packet>();
		capacity = memoryLimit;
		packetHash = new HashSet<Packet>();
		destinationTimestampMap = new Dictionary<int, List<int>>();
	}

	public bool AddPacket(int source, int destination, int timestamp)
	{
		Packet packet = new Packet(source, destination, timestamp);
		if (packetHash.Add(packet))
		{
			packets.Enqueue(packet);
			if (!destinationTimestampMap.ContainsKey(destination))
			{
				destinationTimestampMap[destination] = new List<int>();
			}
			destinationTimestampMap[destination].Add(timestamp);
			if (packets.Count > capacity)
			{
				Packet oldpacket = packets.Dequeue();
				packetHash.Remove(oldpacket);
				destinationTimestampMap[oldpacket.Destonation].RemoveAt(0);

			}
			return true;
		}
		else
		{
			return false;
		}
	}

	public int[] ForwardPacket()
	{
		if (packets.Count == 0)
			return new int[] { };
		Packet oldPacket = packets.Dequeue();
		destinationTimestampMap[oldPacket.Destonation].RemoveAt(0);
		packetHash.Remove(oldPacket);
		return new int[] { oldPacket.Source, oldPacket.Destonation, oldPacket.Timestamp };
	}

	public int GetCount(int destination, int startTime, int endTime)
	{
		if (!destinationTimestampMap.ContainsKey(destination))
		{
			return 0;
		}
		int c = 0;
		List<int> doablepackets = destinationTimestampMap[destination];
		// 1. Find the index of the first timestamp that is >= startTime.
		int startIndex = FindLowerBound(doablepackets, startTime);

		// 2. Find the index of the first timestamp that is > endTime.
		int endIndex = FindUpperBound(doablepackets, endTime);

		// 3. The difference between these indices is the count of items in the range.
		return endIndex - startIndex;
	}

	private int FindLowerBound(List<int> sortedList, int target)
	{
		int left = 0;
		int right = sortedList.Count; // Note: Not Count - 1
		while (left < right)
		{
			int mid = left + (right - left) / 2;
			if (sortedList[mid] >= target)
			{
				right = mid;
			}
			else
			{
				left = mid + 1;
			}
		}
		return left;
	}

	/// <summary>
	/// Modified binary search to find the index of the first element that is
	/// strictly greater than the target value (the "upper bound").
	/// </summary>
	private int FindUpperBound(List<int> sortedList, int target)
	{
		int left = 0;
		int right = sortedList.Count; // Note: Not Count - 1
		while (left < right)
		{
			int mid = left + (right - left) / 2;
			if (sortedList[mid] > target)
			{
				right = mid;
			}
			else
			{
				left = mid + 1;
			}
		}
		return left;
	}
}

/**
 * Your Router object will be instantiated and called as such:
 * Router obj = new Router(memoryLimit);
 * bool param_1 = obj.AddPacket(source,destination,timestamp);
 * int[] param_2 = obj.ForwardPacket();
 * int param_3 = obj.GetCount(destination,startTime,endTime);
 */