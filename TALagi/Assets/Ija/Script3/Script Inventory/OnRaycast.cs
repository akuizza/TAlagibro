using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnRaycast : MonoBehaviour
{
    public DataItem requirementItem;

    public virtual void OnInteract() { }

    public virtual void OnUseItem() { }

    public void removeRequirement()
    {
        Debug.Log("hapus persyaratan yang ada di objek: " + gameObject.name);
        requirementItem = null;
    }
}
