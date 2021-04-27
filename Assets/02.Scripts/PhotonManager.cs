using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{

    private readonly string gameVersion = "v1.0";
    private string userId = "Clarke";

    public TMP_InputField userIdText;
    public TMP_InputField roomNameText;

    void Awake ()
    {
        //게임버전지정
        PhotonNetwork.GameVersion = gameVersion;
        //유저id설정
        //PhotonNetwork.NickName = userId;


        //서버접속
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        userId = PlayerPrefs.GetString("USER_ID", $"USER_{Random.Range(0, 100):00}");
        userIdText.text = userId;
        PhotonNetwork.NickName = userId;
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        {
            Debug.Log("Connected to Photon Server!!!");
            //PhotonNetwork.JoinRandomRoom(); //랜덤한 룸에 접속 시도

            //로비에 접속
            PhotonNetwork.JoinLobby();
            
            
        }

    }



    public override void OnJoinedLobby()
    {
        Debug.Log("joined lobby");
    }



    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"code={returnCode}, msg={message}");
       
        //
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 30;

        //룸 생성
        PhotonNetwork.CreateRoom("My Room", ro);
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

        //통신이 가능한 주인공 캐릭터(탱크) 생성
        PhotonNetwork.Instantiate("Tank", new Vector3(0, 0.5f, 0), Quaternion.identity, 0);
    }

    public void OnLoginClick()
    {
        if (string.IsNullOrEmpty(userIdText.text))
        {
            userId = $"USER_{Random.Range(0, 100):00}";
            userIdText.text = userId;
        }

        PlayerPrefs.SetString("USER_ID", userIdText.text);
        PhotonNetwork.NickName = userIdText.text;
        PhotonNetwork.JoinRandomRoom();
    }

}
