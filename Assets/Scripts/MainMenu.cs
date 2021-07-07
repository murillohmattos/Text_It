using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	void Start()
	{
		Time.timeScale = 1;
	}

	public void PlayTutorial()
	{
		SceneManager.LoadScene("Tutorial");
	}

	public void Level01()
	{
		SceneManager.LoadScene("Level01");
	}

	public void Level02()
	{
		SceneManager.LoadScene("Level02");
	}

	public void Level03()
	{
		SceneManager.LoadScene("Level03");
	}

	public void QuitGame()
	{
		Debug.Log("Seu jogo foi encerrado.");
		Application.Quit();
	}
}
