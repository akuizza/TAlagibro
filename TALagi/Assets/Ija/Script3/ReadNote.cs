using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNote : MonoBehaviour
{
     FPScript fpsPlayer;

    public GameObject player;
    public GameObject noteUI;
    public GameObject pickUpText;

    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        noteUI.SetActive(false);
        pickUpText.SetActive(false);

        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            noteUI.SetActive(true);
            player.GetComponent<FPScript>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }else{
            if(Input.GetKeyDown(KeyCode.Q)){
                ExitButton();
            }
        }
        
    }

    public void Note()
    {
        
    }


    public void ExitButton()
    {
        noteUI.SetActive(false);
        player.GetComponent<FPScript>().enabled = true;
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.None;
        
    }
}
