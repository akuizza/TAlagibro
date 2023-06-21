using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public PlayableDirector playable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            playable.Play();
            Debug.Log("Playable is playing: " + playable.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
