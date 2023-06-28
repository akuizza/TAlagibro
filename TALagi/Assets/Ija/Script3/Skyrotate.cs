using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyrotate : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
    }

}
