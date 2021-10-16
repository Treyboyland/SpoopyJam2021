using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    string itemName;

    public string ItemName { get { return itemName; } }

    [SerializeField]
    uint cost;

    public uint Cost { get { return cost; } }
}
