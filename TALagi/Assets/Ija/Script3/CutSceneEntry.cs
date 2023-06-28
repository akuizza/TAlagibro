using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEntry : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject TimeLine;
    public GameObject CamRender;

    private void OnTriggerEnter(Collider other)
    {

        CamRender.SetActive(true);
        TimeLine.SetActive(true);
        thePlayer.SetActive(false);

    }

}
