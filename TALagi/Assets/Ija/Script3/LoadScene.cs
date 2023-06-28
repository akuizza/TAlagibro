using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        //SceneManager.LoadScene("3", LoadSceneMode.Single);
    }
}
