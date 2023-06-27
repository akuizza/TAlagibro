using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<DataItem> items = new List<DataItem>();
    public int maxSlotItem;
    public ItemUI[] itemUI;

    private void Update()
    {
        for(int i = 0; i < itemUI.Length; i++)
        {
            if(i < items.Count)
            {
                itemUI[i].itemImage.sprite = items[i].item.sprite;
                itemUI[i].itemImage.enabled = true;
                itemUI[i].m_Index = 1;
                itemUI[i].inventory = this;
                //itemUI[i].isCanDrop = true;
            }
            else
            {
                //itemUI[i].isCanDrop = false;
                itemUI[i].itemImage.enabled = false;
            }
        }
    }
    public void AddItem(DataItem new_item)
    {
        items.Add(new_item);
        Debug.Log("item ditambahkan: " + new_item.item.m_name);
    }

    public void RemoveItem(DataItem removed_item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].item.m_name == removed_item.item.m_name)
            {
                Debug.Log("Item dihapus: " + items[i].item.m_name);
                items.RemoveAt(i);
            }
        }
    }

    public DataItem searchItem(DataItem searchItem)
    {
        for(int i =0; i<items.Count; i++)
        {
            if(items[i].item.m_name == searchItem.item.m_name)
            {
                return items[i];
            }
        }
        return null;
    }

    /*public void DropItem(int m_index)
    {
        Instantiate(Resources.Load("ItemObject" + items[m_index].item.m_name), transform.position, Quaternion.identity);
        Debug.Log("Drop item : " + items[m_index].item.m_name);
        RemoveItem(items[m_index]);
    }*/
}
