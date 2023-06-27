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
        textNotification.gameObject.SetActive(false);
    }
    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, range, interactedMask))
        {
            OnRaycast or = hit.transform.gameObject.GetComponent<OnRaycast>();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(or.requirementItem != null)
                {
                    if (inventory.searchItem(or.requirementItem))
                    {
                        DataItem searchedItem = inventory.searchItem(or.requirementItem);
                        or.OnuseItem();
                        inventory.RemoveItem(searchedItem);
                    }
                    else
                    {
                        StartCoroutine(UINotification(or));
                    }
                }
                else
                {
                    or.OnInteract();
                }
                
            }
        }
    }

    IEnumerator UINotification(OnRaycast or)
    {
        textNotification.gameObject.SetActive(true);
        textNotification.text = or.gameObject.name + "Membutuhkan item " + or.requirementItem.item.m_name;
        yield return new WaitForSeconds(5);
        textNotification.gameObject.SetActive(false); 
    }
}
