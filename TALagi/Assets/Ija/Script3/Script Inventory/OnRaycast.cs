using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnRaycast : MonoBehaviour
{
    public DataItem requirementItem;
    public virtual void OnInteract() { }

    public virtual void OnuseItem() { }

    public void removeRequirement()
    {
        Debug.Log("Hapus persyaratan yang ada di objek: " + gameObject.name);
        requirementItem = null;
    }

}
