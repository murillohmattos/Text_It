using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	
	public static bool gameIsPaused = false;

	public GameObject instantiated;
	public GameObject pauseMenuUI;

	words words;

	void Start()
	{
		words = GetComponent<words>();		
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			if (gameIsPaused)
			{
				Resume();				 
			}

			else
			{
				Pause();
			}
		}		
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
		words.stringToEdit.Select();
	}

	public void Pause()
	{		
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void ExitToMenu ()
	{
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1f;
	}

	public void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1f;
	}
}
