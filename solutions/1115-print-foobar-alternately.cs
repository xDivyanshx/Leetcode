// 1115. Print FooBar Alternately
// Difficulty: Medium
// https://leetcode.com/problems/print-foobar-alternately/
// Runtime: 47 ms | Memory: 34.2 MB | Submitted: 2025-10-11

using System;
using System.Threading;

public class FooBar
{
	private int n;
	private static SemaphoreSlim foo = new SemaphoreSlim(1);
	private static SemaphoreSlim bar = new SemaphoreSlim(0);
	public FooBar(int n)
	{
		this.n = n;
	}

	public void Foo(Action printFoo)
	{

		for (int i = 0; i < n; i++)
		{
			foo.Wait();
			// printFoo() outputs "foo". Do not change or remove this line.
			printFoo();
			bar.Release();
		}
	}

	public void Bar(Action printBar)
	{

		for (int i = 0; i < n; i++)
		{
			bar.Wait();
			// printBar() outputs "bar". Do not change or remove this line.
			printBar();
			foo.Release();
		}
	}
}