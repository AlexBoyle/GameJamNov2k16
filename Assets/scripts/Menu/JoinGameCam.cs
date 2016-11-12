using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class JoinGameCam : MonoBehaviour {
	public int players = 0;
	public int readyPlayers = 0;
	private bool[] playersClasses = {false ,false ,false,false};
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (readyPlayers > 0 && players == readyPlayers) {
			//send info to an objec that is not destroyed to move info to the next scene
			//num of players
			GameObject.Find("Immortal").GetComponent<ImmortalObjectScript>().setPlayers(playersClasses);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
			Debug.Log("good");
		}
	}
	public void playerJoin(){
		players++;
	}
	public void playerLeave(){
		players--;
	}
	public void playerReady(int a){
		readyPlayers++;
		playersClasses[a] = true;
	}
	public void playerNotReady(int a){
		readyPlayers--;
		playersClasses [a] = false;
	}
}
