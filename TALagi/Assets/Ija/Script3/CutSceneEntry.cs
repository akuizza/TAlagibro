using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEntry : MonoBehaviour
{
    public GameObject thePlayer;
    public int WaitCutScene;
    public GameObject CutsceneCam;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        CutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(WaitCutScene);
        thePlayer.SetActive(true);
        CutsceneCam.SetActive(false);
    }
}
