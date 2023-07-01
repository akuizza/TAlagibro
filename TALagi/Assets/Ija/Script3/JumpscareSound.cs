using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareSound : MonoBehaviour
{
    public AudioSource audioJumpscare;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            audioJumpscare.Play();
            Debug.Log("audio is playing : " + audioJumpscare.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
