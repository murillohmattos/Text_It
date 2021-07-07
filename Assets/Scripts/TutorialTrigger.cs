using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialTrigger : MonoBehaviour
{
			
	public Tutorial tutorial;
	words words;

	//Janelas de tutorial
	public GameObject tutorialBG1;
	public GameObject tutorialBG2;
	public GameObject tutorialBG3;
	public GameObject tutorialBG4;

	//Icone airplane tutorial
	public GameObject airplane;

	public Text text;

	int count = 0;

	void Start()
	{
		text.text = tutorial.sentences[count];
		Time.timeScale = 0;
	}

	public void TutorialButton()
	{
		count++;

		if (count == 1)//Segunda mensagem
		{
			text.text = tutorial.sentences[count];
		}

		if (count == 2)//Terceira mensagem
		{
			text.text = tutorial.sentences[count];
		}

		if (count == 3)
		{
			tutorialBG1.SetActive(false);
			tutorialBG2.SetActive(true);
			Time.timeScale = 1;
		}

		if (count == 4)
		{
			tutorialBG2.SetActive(false);
			tutorialBG3.SetActive(true);
			airplane.SetActive(true);
			Time.timeScale = 0;
		}

		if (count == 5)
		{
			tutorialBG3.SetActive(false);
			tutorialBG4.SetActive(true);
		}

		if (count == 6)
		{			
			SceneManager.LoadScene("MainMenu");			
		}
	}
	
}
