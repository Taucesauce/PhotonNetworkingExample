using UnityEngine;
using Photon;
using System.Collections;

//Networked player class for instantiation post-login.
public class Player : Photon.MonoBehaviour {
    //Class variables
    float anxietyLevel = 0;
    Color playerColor;
    PlayerController controller;
    public int SpawnPosition;

    //Property used for adjusting colors in scene.
    public float AnxietyLevel {
        get { return anxietyLevel; }
        set { anxietyLevel = value; }
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //If this instance is not the local player, set this player's color to match their environment on the local client's copy.
        if (!photonView.isMine) {
            Renderer renderer = this.GetComponent<Renderer>();
            renderer.material.color = Color.Lerp(Color.blue, Color.red, this.AnxietyLevel);
        }  
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            // We own this player: send the others our data
            stream.SendNext(anxietyLevel);
        }
        else {
            // Network player, receive data
            anxietyLevel = (float)stream.ReceiveNext();
        }
    }
}
