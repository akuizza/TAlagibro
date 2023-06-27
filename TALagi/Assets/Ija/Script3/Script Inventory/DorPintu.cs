using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorPintu : OnRaycast
{
    [SerializeField] private float openAngle;
    [SerializeField] private float closeAngle;

    [SerializeField] private float speed;
    [SerializeField] Collider col;

    public bool isOpen;
    Quaternion newRotation;

    private void Update()
    {
        if (isOpen)
        {
            newRotation = Quaternion.Euler(transform.localRotation.x, openAngle, transform.localRotation.y);
        }
        else
        {
            newRotation = Quaternion.Euler(transform.localRotation.x, closeAngle, transform.localRotation.y);
        }

        col.enabled = transform.localRotation == newRotation;
    }

    public override void OnUseItem()
    {
        Debug.Log("pintu kunci  terbuka");
        removeRequirement();
    }
    public override void OnInteract()
    {
        isOpen = !isOpen;
    }
}
