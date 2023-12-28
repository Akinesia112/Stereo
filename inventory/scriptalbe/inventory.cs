using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Items> itemList = new List<Items>();
}
