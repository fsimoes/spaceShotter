using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPitch : MonoBehaviour {

    //audio Source 
    AudioSource audioSrc;
	// Use this for initialization
	void Awake () {
        //get audio Source component
        audioSrc = GetComponent<AudioSource>();
        //change pitch in a random bettewen 0.1 and 3
        audioSrc.pitch = Random.Range(0.1f, 3f);
        //play the audio on awake
        audioSrc.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
