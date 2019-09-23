using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Each recipe creates an item which is referred to as an id
public class Recipe
{
    private string Name;
    private Dictionary<string, int> Ingredients;
    private float CraftTime;

    public Recipe(string name, float craftTime, Dictionary<string, int>ingredients)
    {
        Name = name;
        CraftTime = craftTime;
        Ingredients = ingredients;
        
    }

    public string GetName()
    {
        return Name;
    }

    public float GetCraftTime()
    {
        return CraftTime;
    }

    public Dictionary<string, int> GetIngredients()
    {
        return Ingredients;
    }
}
