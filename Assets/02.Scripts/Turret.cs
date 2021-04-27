using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Turret : MonoBehaviour
{
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        this.enabled = photonView.IsMine;
    }

    void Update()
    {
        float r = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * Time.deltaTime * r * 200.0f);
    }
}
