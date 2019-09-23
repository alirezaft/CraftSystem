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

    //This function creates Recipe objects based on Recipes.json to be used in game.
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
            
            
        }
    }
    
}
