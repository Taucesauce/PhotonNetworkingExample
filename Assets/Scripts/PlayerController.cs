using UnityEngine;
using System.Collections;

//Simple input management class for SoC
public class PlayerController : MonoBehaviour {
    //Class variables
    public Player owningPlayer;

	void Update () {
        //Use q and e keys to change anxiety value easily for testing.
        if(Input.GetKeyDown(KeyCode.Q) && owningPlayer != null) {
            owningPlayer.AnxietyLevel -= .05f;
            if(owningPlayer.AnxietyLevel <= 0) {
                owningPlayer.AnxietyLevel = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && owningPlayer != null) {
            owningPlayer.AnxietyLevel += .05f;
            if(owningPlayer.AnxietyLevel >= 1) {
                owningPlayer.AnxietyLevel = 1;
            }
        }
        //Use Unity's Horizontal input axis for rotating camera to simulate head movement.
        float rotationScale = 30.0f;
        float rotationAmount = Input.GetAxis("Horizontal") * Time.deltaTime * rotationScale;
        
        //Update rotation
        owningPlayer.transform.Rotate(0, rotationAmount, 0);
	}

    //Set focus of controller
    public void SetOwningPlayer(Player player) {
        owningPlayer = player;
    }
}
