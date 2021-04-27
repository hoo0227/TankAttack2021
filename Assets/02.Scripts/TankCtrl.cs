using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TankCtrl : MonoBehaviour
{
    private Transform tr;
    public float speed = 10.0f;
    private PhotonView pv;

    void Start()
    {
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void Update()
    {
        if (pv.IsMine)
        {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        tr.Translate(Vector3.forward * Time.deltaTime * speed * v);
        tr.Rotate(Vector3.up * Time.deltaTime * 100.0f * h);
        }
    }
}
