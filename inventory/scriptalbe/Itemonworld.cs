using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Itemonworld : MonoBehaviour
{
    public Items thisItem;
    public Inventory playerInventory;
    public Camera mainCamera; // The camera used for raycasting

    void Update()
    {
        // Check if the screen is touched
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Check if the touch phase began this frame
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Perform the raycast
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the hit object is this object
                    if (hit.collider.gameObject == gameObject)
                    {
                        AddNewItem();
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
        //   playerInventory.itemList.Add(thisItem);
        //   InventoryManager.CreatNewItem(thisItem);
        for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InventoryManager.RefreshItem();
    }
}