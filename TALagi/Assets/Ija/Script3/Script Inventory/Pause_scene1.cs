using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_scene1 : MonoBehaviour
{
	public GameObject pauseMenu;
	public bool isPaused;
	//public GameObject player;
	//FPScript playerFPS;

	void Start()
	{
		pauseMenu.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
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
		//player.GetComponent<FPScript>().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		//player.GetComponent<FPScript>().enabled = true;
		Time.timeScale = 1f;
		isPaused = false;
		Cursor.visible = false;
	}
}
