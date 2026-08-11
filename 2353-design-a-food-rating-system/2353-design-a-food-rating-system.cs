// 2353. Design a Food Rating System
// Difficulty: Medium
// https://leetcode.com/problems/design-a-food-rating-system/
// Runtime: 146 ms | Memory: 132.5 MB | Submitted: 2025-09-20

using System;
using System.Collections.Generic;
using System.Linq; // Required for the .First() method

// Using a class is generally safer for collections like SortedSet
// as it works with references, not copies.
public class Food : IComparable<Food>
{
	public string FoodName { get; }
	public string Cuisine { get; }
	public int Rating { get; private set; } // Can be changed internally

	public Food(string name, string cuisine, int rating)
	{
		this.FoodName = name;
		this.Cuisine = cuisine;
		this.Rating = rating;
	}

	// This comparison logic is the "brain" of the SortedSet.
	// It tells the set how to order its elements automatically.
	public int CompareTo(Food other)
	{
		// 1. Sort by Rating in descending order (higher rating is "smaller"/comes first).
		if (this.Rating != other.Rating)
		{
			return other.Rating.CompareTo(this.Rating);
		}

		// 2. If ratings are tied, sort by FoodName in ascending (lexicographical) order.
		return this.FoodName.CompareTo(other.FoodName);
	}
}

public class FoodRatings
{
	// Maps a food's name to its full Food object for O(1) lookups.
	private readonly Dictionary<string, Food> _foodDetailsMap;
	
	// Maps a cuisine to a SortedSet of all its foods.
	// This set is ALWAYS sorted by rating/name, making lookups instant.
	private readonly Dictionary<string, SortedSet<Food>> _cuisineToFoodsMap;

	public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
	{
		_foodDetailsMap = new Dictionary<string, Food>();
		_cuisineToFoodsMap = new Dictionary<string, SortedSet<Food>>();

		for (int i = 0; i < foods.Length; i++)
		{
			var food = new Food(foods[i], cuisines[i], ratings[i]);
			_foodDetailsMap.Add(food.FoodName, food);

			if (!_cuisineToFoodsMap.ContainsKey(food.Cuisine))
			{
				_cuisineToFoodsMap.Add(food.Cuisine, new SortedSet<Food>());
			}
			
			// The SortedSet automatically places the food in its correct sorted position.
			_cuisineToFoodsMap[food.Cuisine].Add(food);
		}
	}

	public void ChangeRating(string foodName, int newRating)
	{
		// 1. Get the original food object.
		Food oldFood = _foodDetailsMap[foodName];

		// 2. Find the SortedSet for its cuisine and REMOVE the old version.
		// This is an efficient O(log K) operation.
		SortedSet<Food> foodSet = _cuisineToFoodsMap[oldFood.Cuisine];
		foodSet.Remove(oldFood);

		// 3. Create a new food object with the updated rating.
		var newFood = new Food(oldFood.FoodName, oldFood.Cuisine, newRating);

		// 4. ADD the new version back to the set. It will be re-sorted automatically.
		// This is also an efficient O(log K) operation.
		foodSet.Add(newFood);

		// 5. Update our main map to point to the new food object.
		_foodDetailsMap[foodName] = newFood;
	}

	public string HighestRated(string cuisine)
	{
		// Thanks to the SortedSet, the highest-rated food is always the first element.
		// This is an extremely fast O(1) operation.
		Food highestRatedFood = _cuisineToFoodsMap[cuisine].First();
		return highestRatedFood.FoodName;
	}
}
