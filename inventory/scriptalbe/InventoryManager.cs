using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    //public slot slotprefab;
    public GameObject emptySlot;
    public Text itemInformation;
   

    public List<GameObject> slots = new List<GameObject>();

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable(){
        RefreshItem();
        instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string itemdescription)
    {
        instance.itemInformation.text = itemdescription;
    }

    /*
    public static void CreatNewItem(Items items)
    {
        slot newItem = Instantiate(instance.slotprefab,instance.slotGrid.transform.position,Quaternion.identity );
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = items;
        newItem.slotImage.sprite = items.itemImage;
        newItem.slotNum.text = items.itemHeld.ToString();
    }
    */

    public static void RefreshItem()
    {
        //循環刪除slot grid下的子集合
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();

        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreatNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<slot>().slotID = i;
            instance.slots[i].GetComponent<slot>().SetupSlot(instance.myBag.itemList[i]);

        }
    }
}
