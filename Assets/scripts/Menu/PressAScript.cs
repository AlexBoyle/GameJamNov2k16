using UnityEngine;
using System.Collections;
using XInputDotNetPure; 
public class PressAScript : MonoBehaviour {
	public int playerNumber;
	private PlayerIndex playerIndex;
	private GamePadState state;
	private GamePadState pre;
	private JoinGameCam cam;
	private bool playerjoin = false;
	private bool playerReady = false;
	private bool pressedB = false;
	public GameObject background;
	private ImmortalObjectScript immortal;
	// Use this for initialization
	void Start () {
		playerIndex = (PlayerIndex)playerNumber;
		cam = GameObject.Find ("Main Camera").GetComponent<JoinGameCam> ();
		immortal = GameObject.Find ("Immortal").GetComponent<ImmortalObjectScript> ();
		background.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		state = GamePad.GetState (playerIndex, GamePadDeadZone.None);

		//join game
		if (state.Buttons.A == ButtonState.Pressed && !playerjoin) {
			background.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,.9f);
			cam.playerJoin ();
			playerjoin = true;
		}
		//ready
		if (playerjoin && state.Buttons.Start == ButtonState.Pressed && !playerReady) {
			background.GetComponent<SpriteRenderer> ().color = new Color(.3f,.8f,.4f,.9f);
			cam.playerReady (playerNumber);
			playerReady = true;
		}
		if (state.Buttons.B == ButtonState.Released) {
			pressedB = false;
		}
		//go back one 
		if (!pressedB) {
			if (state.Buttons.B == ButtonState.Pressed) {
				pressedB = true;
				if (playerReady) {
					playerReady = false;
					cam.playerNotReady (playerNumber);
					background.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,.9f);
				} else if (playerjoin) {
					playerjoin = false;
					cam.playerLeave ();
					background.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
				}
			}
		}
		pre = state;
	}
	public void setPlayerNumber(int a){
		playerNumber = a;
		playerIndex = (PlayerIndex)playerNumber;
	}
}