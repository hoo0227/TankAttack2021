using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float speed = 2000.0f;
    Rigidbody rb;

    public string shooter;

    public GameObject expEffect;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
         rb.AddRelativeForce(Vector3.forward * speed);
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject obj = Instantiate(expEffect,transform.position, Quaternion.identity);
        Destroy(obj, 3.0f);
    }
}
