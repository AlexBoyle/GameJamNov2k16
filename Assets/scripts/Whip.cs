﻿using UnityEngine;
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
			if (other.tag == "Player") {
				other.GetComponent<PlayerMovementScript> ().DisableMovementTimed ( .3f);
			}
			Vector2 direction =  transform.parent.position - other.transform.position;
			other.GetComponent<Rigidbody2D> ().AddForce (Vector3.Normalize( direction) * speed);
		}

	}

}
