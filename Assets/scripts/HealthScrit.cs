using UnityEngine;
using System.Collections;

public class HealthScrit : MonoBehaviour {
	public int currentHealth = 0;
	int maxHealth =0;
	public delegate void voidDel();
	public voidDel deathFunction;
	public voidDel coindrop;
	public GameObject fireParticles;
	public ParticleSystem hitParticles;
	InputScript input;
	SoundPlayer sound;
	// Use this for initialization
	void Start () {
		sound = GameObject.Find ("Main Camera").GetComponent<SoundPlayer>();
		maxHealth = currentHealth;
		input = GetComponent<InputScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DealDamage(int amount){
		currentHealth -= amount;
		hitParticles.Emit (25);
		sound.PlayHit ();
		if (currentHealth <= 0) {
			if (deathFunction != null) {
				gameObject.SetActive (false);
				deathFunction ();
				coindrop ();
			}

		}
	}
	public void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.tag);
		if (other.tag == "Attack") {
			if (other.GetComponent<hitboxScript> ().playerNumber != input.playerNumber) {
				DealDamage (1);
			}
		} else if (other.tag == "Fire") {
			if (other.GetComponent<hitboxScript> ().playerNumber != input.playerNumber) {
				StartCoroutine (Ignite ());
			}
		} else if (other.tag == "Bomb") {
			DealDamage (3);
		}else if (other.tag == "Hazard") {
			DealDamage (3);
		}else if (other.tag == "Whip") {
			DealDamage (2);
		}


	}
	IEnumerator Ignite(){
		fireParticles.SetActive (true);
		yield return new WaitForSeconds (1);
		DealDamage (1);
		yield return new WaitForSeconds (1);
		DealDamage (1);
		yield return new WaitForSeconds (1);
		DealDamage (1);
		fireParticles.SetActive (false);

	}

	void OnDisable(){
		fireParticles.SetActive(false);
		currentHealth = maxHealth;
	}
}
