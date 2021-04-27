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
            PhotonNetwork.JoinRandomRoom(); //랜덤한 룸에 접속 시도
        }

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"code={returnCode}, msg={message}");
       
        //룸 생성
        PhotonNetwork.CreateRoom("My Room");
    }

    //룸 생성 완료 콜백
    public override void OnCreatedRoom()
    {
        Debug.Log("방 생성 완료");
        
    }

    //룸에 입장했을 때 호출되는 콜백
    public override void OnJoinedRoom()
    {
        Debug.Log("방 입장 완료");
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
    }











    
}
