using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    private Recipe[] Recipes;

    private void Awake()
    {
        RecipeJSONParser.getInstance().LoadString();
        GenerateActualRecipes();
    }

    //This function creates Recipe objects based on Recipes.json to use them in game.
    //Recipes are saved in Recipes array.
    private void GenerateActualRecipes()
    {
        Debug.Log("Generating recipes");
        var json = RecipeJSONParser.getInstance().getRecipeJSON();
        Recipes = new Recipe[json.Count];
        int j = 0;
        foreach (JSONObject o in json)
        {
            
            Debug.Log(o.Print(true));    
            var ingredients = o["Ingredints"];
            var name = o.GetField("Name").str;
            var time = o.GetField("CraftTime").n;
            Dictionary<string, int> ingredient = new Dictionary<string, int>();
            var ing = o["Ingredients"];
            for (int i = 0; i < ing.Count; i++)
            {
                var key = ing.keys[i];
                var value = (int)ing[key].n;
                ingredient.Add(key, value);
            }
            Recipes[j] = new Recipe(name, time, ingredient);
            j++;

        }
    }

    //When user wants to create an item, this method should be called.
    //It should return a new instance from the class that describes your items.
    //Change the return type if you have written your own Item class.
    //You can find example Item class in Examples folder.
    public void CraftItem(string name)
    {
        var recipe = FindRecipe(name);

        //There's not a recipe with this name
        if (recipe == null)
        {
            StartCoroutine(Wait(0));
            Debug.Log("Item not found!");
        }
        StartCoroutine(Wait(recipe.GetCraftTime()));
        
    }

    //To make system work with your in-game code and keep it dynamic, instead of calling WaitForSeconds in CraftItem,
    //This function will be called.
    private IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
    }

    //Finds a specific recipe with the given name
    //You can use this method to check requirements in your inventory class.
    //I used it in my example inventory.
    //TODO: Write an example inventory
    public Recipe FindRecipe(string name)
    {
        foreach (Recipe r in Recipes)
        {
            if (r.GetName().Equals(name))
            {
                return r;
            }
        }

        return null;
    }
    
    
}
