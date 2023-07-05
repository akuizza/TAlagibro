using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LogoController : MonoBehaviour
{
    public float logoDuration = 10f;
    public string nextScene;

    void Start()
    {
        Invoke("LoadNextScene", logoDuration);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

}
