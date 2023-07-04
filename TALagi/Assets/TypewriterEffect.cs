using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.1f; // Kecepatan pengetikan
    private string fullText;
    private string currentText = "";
    public string targetSceneName;
    private bool isTextAnimationComplete = false;

    private void Start()
    {
        fullText = GetComponent<TextMeshProUGUI>().text; // Untuk TextMeshPro
        // fullText = GetComponent<Text>().text; // Untuk Text sebelum Unity 2018.2.0
        StartCoroutine(ShowText());
    }

    private void Update()
    {
        if (isTextAnimationComplete)
        {
            Invoke("LoadTargetScene", 5f); ;
        }
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            GetComponent<TextMeshProUGUI>().text = currentText; // Untuk TextMeshPro
            // GetComponent<Text>().text = currentText; // Untuk Text sebelum Unity 2018.2.0
            yield return new WaitForSeconds(typingSpeed);
        }
        isTextAnimationComplete = true;
    }
    private void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
