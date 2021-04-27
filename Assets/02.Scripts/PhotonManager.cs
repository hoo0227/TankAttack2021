using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{

    private readonly string gameVersion = "v1.0";
    private string UserId = "Clarke";

    void Awake ()
    {
        //게임버전지정
        PhotonNetwork.GameVersion = gameVersion;
        //유저id설정
        PhotonNetwork.NickName = UserId;
        //서버접속
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        {
            Debug.Log("Connected to Photon Server!!!");
        }

    }

    
}
