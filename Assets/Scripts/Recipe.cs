using System;
using UnityEngine;

//Ingredients, required time and all of the necessary data for crafting an item.
[CreateAssetMenu(fileName = "New Recipe", menuName = "Craft recipe", order = 20)]
public class Recipe : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private int craftTime;
    //Should fill this part in order of the resources enum
    //TODO: Find an approach to make it more friendly. Show text or something. 
    [SerializeField] private int[] ingredients;
    [SerializeField] private Category category;

    public Recipe()
    {
        ingredients = new int[Enum.GetNames(typeof(Resources)).Length];
//        var res = Enum.GetNames(typeof(Resources));
    }
}
