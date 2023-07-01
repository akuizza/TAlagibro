using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEntry : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject TimeLine;
    public GameObject CamRender;
    public GameObject CanvasText;
    public GameObject Canvas;


    private void OnTriggerEnter(Collider other)
    {
        CanvasText.SetActive(true);
        CamRender.SetActive(true);
        TimeLine.SetActive(true);
        thePlayer.SetActive(false);
        Canvas.SetActive(false);

    }

}
