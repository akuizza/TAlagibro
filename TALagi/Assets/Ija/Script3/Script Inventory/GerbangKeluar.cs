using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerbangKeluar : OnRaycast
{
    public float openGatePosition;
    public float closeGatePosition;
    public float speedPosition;

    public GameObject key;
    public GameObject gerbang;

    //public AudioSource audioSource;
    //public AudioClip audioClip;

    bool isOpen;
    float currentGatePosition;

    private void Start()
    {
        key.SetActive(false);
    }

    private void Update()
    {
        if (isOpen)
        {
            currentGatePosition = openGatePosition;
        }
        else
        {
            currentGatePosition = closeGatePosition;
        }

        gerbang.transform.localPosition = Vector3.MoveTowards(gerbang.transform.localPosition, new Vector3(gerbang.transform.localPosition.x, currentGatePosition, gerbang.transform.localPosition.z), speedPosition * Time.deltaTime);

    }

    public override void OnuseItem()
    {
        isOpen = true;
        //audioSource.PlayOneShot(audioClip);
        key.SetActive(true);
        removeRequirement();
    }
}
