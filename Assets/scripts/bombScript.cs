﻿using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour {
	public float timeToDetonate;
	public GameObject explostion;
	public Sprite def;
	bool canDetonate = false;
	SoundPlayer sound;
	// Use this for initialization
	void Start () {
		sound = GameObject.Find ("Main Camera").GetComponent<SoundPlayer>();
	}
	void OnEnable(){
		canDetonate = false;
		StartCoroutine (Detonate (timeToDetonate));
	}
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator Detonate(float delay){
		yield return new WaitForSeconds (.1f);
		canDetonate = true;
		yield return new WaitForSeconds (delay);
		explostion.SetActive (true);
		sound.PlayBombExplosion ();
		gameObject.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (.2f);
		gameObject.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (.5f);
		gameObject.GetComponent<Animator> ().enabled = false;
		gameObject.GetComponent<Animator> ().aniStep = 0;
		gameObject.SetActive (false);
		Debug.Log ("turoff");
		gameObject.GetComponent<SpriteRenderer> ().sprite = def;

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && canDetonate) {
			StopAllCoroutines ();
			StartCoroutine (Detonate (0));
		}
	}
}
