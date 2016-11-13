using UnityEngine;
using System.Collections;

public class hitboxScript : MonoBehaviour {
	public int playerNumber;
	public bool useKnockback;
	public float knockbackAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && useKnockback) {
			
			if (other.GetComponent<InputScript> ().playerNumber != playerNumber) {
				Vector2 direction = other.transform.position - transform.parent.position;
				other.GetComponent<PlayerMovementScript> ().DisableMovementTimed (.3f);
				other.GetComponent<Rigidbody2D> ().AddForce (Vector3.Normalize (direction) * knockbackAmount);
			}
		}
	}

}
