using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!target)
        {
            return;
        }
        if (Vector3.Distance(target.position, transform.position) > 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position,Time.deltaTime);
        }
        transform.LookAt(target);
	}
}
