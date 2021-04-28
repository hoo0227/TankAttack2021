using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public TMP_Text roomNameText;
    public TMP_Text connectInfoText;
    public Button exitButton;
    public TMP_Text messageText;
    //싱글턴 변수
    public static GameManager instance = null;

    void Awake()
    {
        instance = this;
        
        //PhotonNetwork.IsMessageQueueRunning = true;
        Vector3 pos = new Vector3(Random.Range(-200.0f, 200.0f), 5.0f, Random.Range(-200.0f, 200.0f));

        //통신이 가능한 주인공 캐릭터(탱크) 생성
        PhotonNetwork.Instantiate("Tank", new Vector3(0, 0.5f, 0), Quaternion.identity, 0);
    }


    void Start()
    {
        SetRoomInfo();
    }



    void SetRoomInfo()
    {
        Room currentRoom = PhotonNetwork.CurrentRoom;
        roomNameText.text = currentRoom.Name;
        connectInfoText.text = $"{currentRoom.PlayerCount} / {currentRoom.MaxPlayers}";
    }

    public void OnExitClick()
    {
        PhotonNetwork.LeaveRoom();
    }


    //Clean Up이 끝난 후에 호출되는 콜백
    public override void OnLeftRoom()
    {
        //Lobby 씬으로 돌아가기
        SceneManager.LoadScene("Lobby");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        SetRoomInfo();
        string msg = $"\n<color=#00ff00>{newPlayer.NickName}</color> is joined room";
        messageText.text += msg;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        SetRoomInfo();
        string msg = $"\n<color=#ff0000>{otherPlayer.NickName}</color> left room";
    }
}
