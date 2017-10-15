using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    
    Rigidbody rb;
    AudioSource audioSrc;

    //shot instance
    public GameObject shot;
    //area the shots will be created
    public Transform shotSpawn;

    //speed of the ship
    public float speed;
    //the fire rate
    public float fireRate;
    //when the next fire can be shot
    private float nextFire;

    //control the inputs
    float moveHorizontal;
    float moveVertical;
    float yaw;

    private void Start()
    {
        //asign the rigidbody
        rb = GetComponent<Rigidbody>();
        //asign the audio source
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if fire button is pressed and the if it is possible to fire again
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //update when the next fire can be shot
            nextFire = Time.time + fireRate;
            // create a shot 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //randomily change the sound pitch
            audioSrc.pitch = Random.Range(0.1f, 3f);
            //play the audio
            audioSrc.Play();
        }
        //update the inputs 
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        yaw = Input.GetAxis("Yaw"); //custom input

        //rotate the ship acording to the inputs
        transform.Rotate(new Vector3(moveVertical, yaw, -moveHorizontal) * speed * Time.deltaTime);

        //constant speed foward
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
}
