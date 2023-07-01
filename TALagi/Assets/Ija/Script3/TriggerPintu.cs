using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPintu : MonoBehaviour
{
    
    public bool inReach;
    public GameObject openText;

    void Start()
    {
        //noteUI.SetActive(false);
        
         inReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
      
    }
     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }


    

    

}
