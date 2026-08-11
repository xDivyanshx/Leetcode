// 1912. Design Movie Rental System
// Difficulty: Hard
// https://leetcode.com/problems/design-movie-rental-system/
// Runtime: 221 ms | Memory: 228 MB | Submitted: 2025-09-22

using System;
using System.Collections.Generic;

/// <summary>
/// Structure for movie
/// </summary>
public struct MovieStruct : IComparable<MovieStruct>
{
	private int shop;
	private int movie;
	private int price;

	/// <summary>
	/// Getter for shop
	/// </summary>
	public int Shop
	{
		get { return shop; }
	}

	/// <summary>
	/// Getter for movie
	/// </summary>
	public int Movie
	{
		get { return movie; }
	}

	/// <summary>
	/// Getter for price
	/// </summary>
	public int Price
	{
		get { return price; }
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="shop"></param>
	/// <param name="movie"></param>
	/// <param name="price"></param>
	public MovieStruct(int shop, int movie, int price)
	{
		this.shop = shop;
		this.movie = movie;
		this.price = price;
	}

	/// <summary>
	/// overrding compare to function for sorting
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public int CompareTo(MovieStruct other)
	{
		int rValue = price.CompareTo(other.price);
		if (rValue == 0)
		{
			rValue = shop.CompareTo(other.shop);
			if (rValue == 0)
			{
				rValue = movie.CompareTo(other.movie);
			}
		}
		return rValue;
	}
}

/// <summary>
/// Movie Renting System
/// </summary>
public class MovieRentingSystem
{
	Dictionary<int, Dictionary<int, int>> movieMap;
	Dictionary<int, List<MovieStruct>> sortedMovieList;
	SortedSet<MovieStruct> rentedMovies;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="_"></param>
	/// <param name="entries"></param>
	public MovieRentingSystem(int _, int[][] entries)
	{
		movieMap = new Dictionary<int, Dictionary<int, int>>();
		sortedMovieList = new Dictionary<int, List<MovieStruct>>();
		rentedMovies = new SortedSet<MovieStruct>();

		// Filling the movie map dictionary
		for (int i = 0; i < entries.Length; i++)
		{
			int movie = entries[i][1];
			if (!movieMap.ContainsKey(movie))
				movieMap[movie] = new Dictionary<int, int>();
			movieMap[movie].Add(entries[i][0], entries[i][2]);
		}

		// Filling the sorted list
		foreach (KeyValuePair<int, Dictionary<int, int>> kvp in movieMap)
		{
			int movie = kvp.Key;
			List<MovieStruct> sortedList = new List<MovieStruct>();
			foreach (KeyValuePair<int, int> sp in kvp.Value)
			{
				sortedList.Add(new MovieStruct(sp.Key, movie, sp.Value));
			}
			sortedList.Sort();
			sortedMovieList[movie] = sortedList;
		}
	}

	/// <summary>
	/// Search function
	/// </summary>
	/// <param name="movie"></param>
	/// <returns></returns>
	public IList<int> Search(int movie)
	{
		List<int> result = new List<int>();
		if (sortedMovieList.TryGetValue(movie, out List<MovieStruct> movieList))
		{
			foreach (MovieStruct movieStruct in movieList)
			{
				MovieStruct rentedMovie = new MovieStruct(movieStruct.Shop, movie, movieStruct.Price);
				if (!rentedMovies.Contains(rentedMovie))
				{
					result.Add(movieStruct.Shop);
				}
				if (result.Count == 5)
				{
					break;
				}
			}
		}
		return result;
	}

	/// <summary>
	/// Rent Function
	/// </summary>
	/// <param name="shop"></param>
	/// <param name="movie"></param>
	public void Rent(int shop, int movie)
	{
		rentedMovies.Add(new MovieStruct(shop, movie, movieMap[movie][shop]));
	}

	/// <summary>
	/// Drop Function
	/// </summary>
	/// <param name="shop"></param>
	/// <param name="movie"></param>
	public void Drop(int shop, int movie)
	{
		rentedMovies.Remove(new MovieStruct(shop, movie, movieMap[movie][shop]));
	}

	/// <summary>
	/// Report Function
	/// </summary>
	/// <returns></returns>
	public IList<IList<int>> Report()
	{
		IList<IList<int>> result = new List<IList<int>>();
		foreach (MovieStruct rented in rentedMovies)
		{
			result.Add(new List<int>() { rented.Shop, rented.Movie });
			if (result.Count == 5)
				break;
		}
		return result;
	}
}

/**
 * Your MovieRentingSystem object will be instantiated and called as such:
 * MovieRentingSystem obj = new MovieRentingSystem(n, entries);
 * IList<int> param_1 = obj.Search(movie);
 * obj.Rent(shop,movie);
 * obj.Drop(shop,movie);
 * IList<IList<int>> param_4 = obj.Report();
 */