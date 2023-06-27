using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public Image itemImage;
    public int m_Index;

    public Inventory inventory;
    public bool isCanDrop;

   /* public void Drop()
    {
        if (isCanDrop == false) return;

        inventory.DropItem(m_Index);
    }*/
}
