using UnityEngine;
using System.Collections;

public class waterPush : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "bombParent" || other.tag == "Player" || other.tag == "Ingredient" || other.tag ==  "Item") {
			if (other.tag == "Player") {
				other.GetComponent<PlayerMovementScript> ().DisableMovement ( .3f);
			}
			Vector2 direction =  other.transform.position - transform.parent.position;
			other.GetComponent<Rigidbody2D> ().AddForce (Vector3.Normalize( direction) * speed);
		}

	}
}
