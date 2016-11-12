using UnityEngine;
using System.Collections;

public class Whip : MonoBehaviour {
	
	public float speed;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("we did");
		if (other.tag == "bombParent" || other.tag == "Player" || other.tag == "Ingredient" || other.tag ==  "Item") {
			
			Vector2 direction =  transform.parent.position - other.transform.position;
			other.GetComponent<Rigidbody2D> ().AddForce (direction * speed);
		}

	}
}
