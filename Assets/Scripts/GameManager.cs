using UnityEngine;
using System.Collections;

//Class for handling game-wide content.
public class GameManager : MonoBehaviour {
    //Class variables
    GameObject[] ColorChangingObjects;
    public Player localPlayer;

	// Use this for initialization
	void Start () {
        //Get all objects in the scene that are tagged for color fade.
        ColorChangingObjects = GameObject.FindGameObjectsWithTag("ColorChanging");    
	}
	
	// Update is called once per frame
	void Update () {
        if(localPlayer != null) {
            //Grabs the renderer for each object and updates the color.
            //Only affects local client's environment.
            foreach (GameObject envPiece in ColorChangingObjects) {
                Renderer renderer = envPiece.GetComponent<Renderer>();
                renderer.material.color = Color.Lerp(Color.blue, Color.red, localPlayer.AnxietyLevel);
            }
        }
	}

    //Method for setting local client for management.
    public void SetLocalPlayer(Player player) {
        localPlayer = player;
    }
}
