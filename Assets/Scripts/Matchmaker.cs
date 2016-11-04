using UnityEngine;
using Photon;
using System.Collections;

//Class to set up lobby for multiplayer testing.
public class Matchmaker : PunBehaviour {
    // Use this for initialization
    void Start() {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    //Display connection progress while logging player in.
    void OnGUI() {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    //Connect to room after successful lobby login.
    public override void OnJoinedLobby() {
        PhotonNetwork.JoinRandomRoom();
    }

    //Currently only supports two static positions for testing two players side by side.
    //TODO: Make dynamic for four players and adjust spawns based on currently filled positions when logging in.
    public override void OnJoinedRoom() {
        GameObject player = null;
        //Instantiates player based on current room size.
        //Since current build requires first client to come from executable and second from engine,
        //players will never overlap. Needs to be changed for multiple clients outside of editor.
        if (PhotonNetwork.room != null && PhotonNetwork.room.playerCount <= 1) {
            player = PhotonNetwork.Instantiate("Player", new Vector3(.55f, 2.86f, .31f), Quaternion.identity, 0);
        }
        else {
            player = PhotonNetwork.Instantiate("Player", new Vector3(.55f, 2.86f, -4.55f), Quaternion.identity, 0);
        }
        //Attaches components to newly logged in client.
        Camera camera = player.GetComponent<Camera>();
        camera.enabled = true;
        PlayerController controller = player.GetComponent<PlayerController>();
        controller.enabled = true;
        Player playerRef = player.GetComponent<Player>();
        controller.SetOwningPlayer(playerRef);
        //Manager should be Singleton, needs to be changed.
        GameObject manager = PhotonNetwork.Instantiate("Manager", Vector3.zero, Quaternion.identity, 0);
        GameManager managerRef = manager.GetComponent<GameManager>();
        managerRef.SetLocalPlayer(playerRef);
    }

    //If no rooms exist on random join, make one.
    void OnPhotonRandomJoinFailed() {
        PhotonNetwork.CreateRoom("Test Room");
    }
}
