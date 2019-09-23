using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

//This class is supposed to load the Recipes.json file and create a JSON object to populate game recipes with
//
public class RecipeJSONParser
{
    private readonly string PATH = "CraftData/";
    private readonly string RECIPES_FILE_NAME = "Recipes";
    private string JSONString;
    private TextAsset RecipeFile;
    private JSONObject RecipesObject;

    private static RecipeJSONParser _instance;
    void Start()
    {
        LoadString();
    }

    public void LoadString()
    {
        Debug.Log("Parsing");
        RecipeFile = Resources.Load<TextAsset>(PATH + RECIPES_FILE_NAME);
        JSONString = RecipeFile.text;
        Debug.Log(JSONString);
        RecipesObject = new JSONObject(JSONString);
        Debug.Log(RecipesObject.Print(true));
    }

    public JSONObject getRecipeJSON()
    {
        return RecipesObject;
    }

    public static RecipeJSONParser getInstance()
    {
        if (_instance == null)
        {
            _instance = new RecipeJSONParser();
        }
        return _instance;
    }
}
