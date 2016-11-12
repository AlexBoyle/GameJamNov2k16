using UnityEngine;
using System.Collections;

public class numberSetterScript : MonoBehaviour {
	int playerNumber;
	public InputScript input;
	// Use this for initialization
	void Start () {
		playerNumber = input.playerNumber;
		foreach (hitboxScript h in GetComponentsInChildren<hitboxScript>(true)) {
			h.playerNumber = playerNumber;
		}
	}
}
