using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : OnRaycast
{
    public DataItem GetItem;
    //public AudioClip takeSoundEffect;

    public override void OnInteract()
    {
        //AudioSource soundEffect = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
        Inventory inventory = FindObjectOfType<Inventory>();

        if(inventory.items.Count >= inventory.maxSlotItem)
        {
            Debug.Log("Saku penuh");
            return;
        }
        inventory.AddItem(GetItem);
       // soundEffect.PlayOneShot(takeSoundEffect);
        Destroy(this.gameObject);
    }
}
