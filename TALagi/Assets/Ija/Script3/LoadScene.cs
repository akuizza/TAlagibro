using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   
    public string NamaScene;
    void OnEnable()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
