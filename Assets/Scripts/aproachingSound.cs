using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aproachingSound : MonoBehaviour {

    //sound 
    AudioSource audioSource;
    //target
    Transform target;
    //minimum distance from target to start the sound
    public int minimumDistance;

	// Use this for initialization
	void Start () {
        //load audio
        audioSource = GetComponent<AudioSource>();
        //find target transform
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        //must  have a target
        if (target)
        {
            //get the distance bettween 2 vectors
            float currentDistance = Vector3.Distance(transform.position, target.position);
            //if distance is less them the minimum play the audio
            if (currentDistance < minimumDistance)
            {
                //the closer to the player, higher is the volume
                audioSource.volume = 1 - (currentDistance / minimumDistance);
                //play sound
                audioSource.Play();

            }
            else
            {
                //stop audio if too far away
                audioSource.Stop();
            }
        }
	}
           
}
