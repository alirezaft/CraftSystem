using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InventorySlot[] Slots = new InventorySlot[20];    
    private CraftManager craftManager;
    [SerializeField] private GameObject ManagerObject;

    private void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            Slots[i] = new InventorySlot();
        }
        craftManager = ManagerObject.GetComponent<CraftManager>();
    }
    
    //This method is supposed to checks if resources are available and there is enough space
    //if all the conditions are satisfied, then it creates the item and uses necessary resources
    //TODO: Make a refactor to use a limited list instead of array for inventory.
    //You can change the logic if you want
    //if there is not enough space in the inventory, it won't craft the item
    public void CraftItem(string name)
    {
        var recipe = craftManager.FindRecipe(name);
        var destSlot = GetFirstEmptySlot();
        var AnotherExists = false;
        
        for (int k = 0; k < Slots.Length; k++)
        {
            if (Slots[k].item.GetName().Equals(name))
            {
                destSlot = k;
                AnotherExists = true;
                break;
            }
        }
        
        if (destSlot != -1)
        {
            if (isAvailable(recipe.GetIngredients()))
            {
                List<string> materials = new List<string>(recipe.GetIngredients().Keys);
                List<int> Quantity = recipe.GetIngredients().Values.ToList();
                
                //Here The system "uses" needed resources.
                for (int i = 0; i < materials.Count; i++)
                {
                    for (int j = 0; j < Slots.Length; j++)
                    {
                        if (Slots[j].item.GetName().Equals(materials[i]))
                        {
                            Slots[j].Quantity -= Quantity[i];
                            if (Slots[j].Quantity == 0)
                            {
                                Slots[j].item = null;
                            }
                        }
                    }
                }
                craftManager.CraftItem(name);

                if (AnotherExists)
                {
                    Slots[destSlot].Quantity++;
                }
                else
                {
                    Slots[destSlot] = new InventorySlot(name);
                }

            }
        }
    }

    //This method checks if there are enough resources in inventory
    private bool isAvailable(Dictionary<string, int> ing)
    {
        bool[] state = new bool[ing.Count];
        bool exists = false;
        var stateindex = 0;

        for (int i = 0; i < Slots.Length; i++)
        {
            for (int j = 0; j < ing.Count; j++)
            {
                if (ing.ContainsKey(Slots[i].item.GetName()))
                {
                    if (ing[Slots[i].item.GetName()] != Slots[j].Quantity)
                    {
                        return false;
                    }

                    state[stateindex] = true;
                    stateindex++;
                    if (stateindex == ing.Count - 1)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
    
    //Returns first available slot in the inventory to put the created item in.
    //If it returns -1, It means there's no empty space left in the inventory.
    private int GetFirstEmptySlot()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].Quantity == 0)
            {
                return i;
            }
        }

        return -1;
    }
}

class InventorySlot
{
    public Item item;
    public int Quantity;

    public InventorySlot()
    {/*Just for initializing inventory*/}

    public InventorySlot(string name)
    {
        item = new Item(name);
        Quantity = 1;
    }
}