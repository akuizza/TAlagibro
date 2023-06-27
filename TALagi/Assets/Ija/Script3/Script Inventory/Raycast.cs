using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range;
    public LayerMask interactedMask;

    public Inventory inventory;
    public Text textNotification;

    private void Start()
    {
        
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, interactedMask))
        {
            OnRaycast or = hit.transform.gameObject.GetComponent<OnRaycast>();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               if(or.requirementItem != null)
                {
                    if (inventory.searchItem(or.requirementItem))
                    {
                        DataItem searchedItem = inventory.searchItem(or.requirementItem);
                        or.OnUseItem();
                        inventory.RemoveItem(searchedItem);
                    }
                    else
                    {
                        or.OnInteract();
                    }
                }
            }
        }
        

    }
}
