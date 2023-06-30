using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
//public GameObject Player;
public GameObject pauseMenu;
public bool isPaused;

void Start()
{
	pauseMenu.SetActive(false);
}

void Update()
{
	if(Input.GetKeyDown(KeyCode.Escape))
	{
		if(isPaused)
		{
			ResumeGame();
		}
		else
		{
			PauseGame();
		}
	}
}

public void PauseGame()
{
	pauseMenu.SetActive(true);
	Time.timeScale = 0f;
	isPaused = true;
	//Player.GetComponent<FPController>().enabled = false;
	Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
}

public void ResumeGame()
{
	pauseMenu.SetActive(false);
	//Player.GetComponent<FPController>().enabled = true;
	Time.timeScale = 1f;
	isPaused = false;
	Cursor.visible = false;
}
}



