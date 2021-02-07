using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areascript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Item on the ground")]
    public string itemName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            
            other.gameObject.GetComponent<Inventory>().AddItemToInventory(itemName);
        }
    }
}
