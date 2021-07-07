using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSource : MonoBehaviour {

    //Variaveis

    AudioSource audioMaster;

	// Use this for initialization
	void Start () {
        audioMaster = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioMaster.mute = !audioMaster.mute;
        }
	}
}
