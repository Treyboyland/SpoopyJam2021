using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySO : MonoBehaviour
{
    [SerializeField]
    List<ItemSO> currentInventory;

    public List<ItemSO> CurrentInventory { get { return currentInventory; } }

    public bool ContainsItem(ItemSO item)
    {
        return currentInventory.Contains(item);
    }
}
