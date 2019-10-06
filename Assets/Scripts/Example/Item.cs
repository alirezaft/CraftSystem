using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An example class to represent items
//You can replace this class with your own class
//Or you can personalize it.
public class Item
{
    private string Name;
    
    public Item(string name)
    {
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }
}
