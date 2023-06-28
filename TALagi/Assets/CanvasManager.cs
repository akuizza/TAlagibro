using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject FadeEffect;
    public GameObject InvetoryItem;

    // Start is called before the first frame update
    void Start()
    {
        FadeEffect.SetActive(true);
        InvetoryItem.SetActive(false);
    }

   
}
