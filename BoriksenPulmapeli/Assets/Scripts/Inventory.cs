using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<string> items;

    // Start is called before the first frame update
    void Start()
    {

        items = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItemToInventory(string item)
    {
        items.Add(item.ToLower());      //string is made to lower case just in case

        PrintInventory();
    }

    public bool CheckInventory(string item)
    {
        PrintInventory();

        foreach (string i in items)
        {
            if (i == item.ToLower())     //checks if inventory has item in it and returns true if it does
            {
                return true;
            }
        }
        return false;
    }
    public void PrintInventory()          //for debugging
    {
        int j = 0;
        foreach (string i in items)
        {
            
            Debug.Log( "Item " + j + " is " + i);
            j++;
        }
    }
}
