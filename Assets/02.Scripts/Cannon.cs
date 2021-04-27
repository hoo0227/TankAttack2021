using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float speed = 2000.0f;
    Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
         rb.AddRelativeForce(Vector3.forward * speed);
    }

    void Update()
    {
        
    }
}
