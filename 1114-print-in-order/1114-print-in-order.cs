// 1114. Print in Order
// Difficulty: Easy
// https://leetcode.com/problems/print-in-order/
// Runtime: 96 ms | Memory: 43.9 MB | Submitted: 2025-10-11

using System;
using System.Threading;

public class Foo
{
	private SemaphoreSlim first = new SemaphoreSlim(0, 1);
	private SemaphoreSlim second = new SemaphoreSlim(0, 1);

	public Foo()
	{

	}

	public void First(Action printFirst)
	{

		// printFirst() outputs "first". Do not change or remove this line.
		printFirst();
		first.Release();
	}

	public void Second(Action printSecond)
	{
		first.Wait();
		// printSecond() outputs "second". Do not change or remove this line.
		printSecond();
		second.Release();
	}

	public void Third(Action printThird)
	{
		second.Wait();
		// printThird() outputs "third". Do not change or remove this line.
		printThird();
	}
}