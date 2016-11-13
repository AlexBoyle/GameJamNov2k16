using UnityEngine;
using System.Collections;

public class waterPush : MonoBehaviour {
	public float speed;
	public InputScript input;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.tag);
		if (other.tag == "Player") {
			Vector2 direction = other.transform.position - transform.parent.position;
			if (other.tag == "Player" && other.GetComponent<InputScript> ().playerNumber != input.playerNumber) {
				other.GetComponent<PlayerMovementScript> ().DisableMovementTimed (.3f);
				other.GetComponent<Rigidbody2D> ().AddForce (Vector3.Normalize (direction) * speed);
			} else if (other.tag != "Player") {
				other.GetComponentInChildren<Rigidbody2D> ().AddForce (Vector3.Normalize( direction) * speed);

			}
		}

	}
}
