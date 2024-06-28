using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class lobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField input_create;
    public TMP_InputField input_Join;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(input_create.text, new RoomOptions() {MaxPlayers = 4, IsVisible = true, IsOpen = true}, TypedLobby.Default, null);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input_Join.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("FPS_Map");
    }
}
