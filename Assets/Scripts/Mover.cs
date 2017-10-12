using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed;
    Rigidbody rb;
    public Vector3 targetPostion;
    public int inverter = 1;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        Vector3 direction = (targetPostion + (Random.onUnitSphere * 5) - transform.position);
        direction = Vector3.Normalize(direction);
        transform.forward = direction * inverter;
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update () {
    }
}
