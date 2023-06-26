using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<DataItem> items = new List<DataItem>();
    public int maxSlotItem;

    public void AddItem(DataItem new_item)
    {
        items.Add(new_item);
        Debug.Log("item ditambahkan: " + new_item.item.m_name);
    }

    public void RemoveItem(DataItem removed_item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].item.m_name == removed_item.item.m_name)
            {
                Debug.Log("item dihapus: " + items[i].item.m_name);
                items.RemoveAt(i);
            }
        }
    }
}
