using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    //target 
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if no target, do nothing
        if (!target)
        {
            return;
        }
        //if the targe distance is greater than 10, move towards it
        if (Vector3.Distance(target.position, transform.position) > 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position,Time.deltaTime);
        }
        //look at the target
        transform.LookAt(target);
	}
}
