using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWord : MonoBehaviour
{
	//Class
	words words;

	//Public variables
	public Image buttonBG; //Background do botão
	public Text label; //Texto do botão
	
	//Counts
	int count;


	void Start ()
	{
		words = GetComponent<words>();		
	}

	public void SetupLabel()
	{
		count = words.count;
		label.text = words.sprite[count].name;
	}
}
