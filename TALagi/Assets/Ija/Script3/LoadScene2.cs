using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene2 : MonoBehaviour
{
    public string sceneNama;
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(sceneNama, LoadSceneMode.Single);
        Cursor.visible = true;
    }

}
