using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    //speed
    public float speed;
    //rigidbody
    Rigidbody rb;
    //target position
    public Vector3 targetPostion;
    //check if object will go for original direction
    public bool originalDirection;
    // Use this for initialization
    void Start () {
        //get rigidbody
        rb = GetComponent<Rigidbody>();
        //will the direction be the original one?
        if (!originalDirection)        
        {
            //direct it to the player position + a random area around it
            Vector3 direction = (targetPostion + (Random.onUnitSphere * 10) - transform.position);
            //normalize the direction
            direction = Vector3.Normalize(direction);
            //change foward to new direction
            transform.forward = direction;
        }
       //add speed to foward
        rb.velocity = transform.forward * speed;
    }

}
