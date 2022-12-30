using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    const string VERSION = "v0.0.2";
    public string roomName = "VVR";
    public string playerPrefabName = "Car";
    public Transform spawnPoint;

	void Start () {
        PhotonNetwork.ConnectUsingSettings(VERSION);
	}

    void OnJoinedLobby() {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = false, MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom() {
        PhotonNetwork.Instantiate(playerPrefabName, spawnPoint.position, spawnPoint.rotation, 0);
    }

}
