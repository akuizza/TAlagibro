using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : OnRaycast
{
    public GameObject key;
    public GameObject CamRender;
    public GameObject Cutscene;

    // Start is called before the first frame update
    private void Start()
    {
        key.SetActive(false);
    }
    public override void OnuseItem()
    {
        TrigerCutscene();
        //audioSource.PlayOneShot(audioClip);
        key.SetActive(true);
        removeRequirement();
    }

    public void Awake ()
    {

        
        // 
    }
    public void TrigerCutscene()
    {
        Cutscene.SetActive(true);
        CamRender.SetActive(true);
    }
}
