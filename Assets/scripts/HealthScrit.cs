using UnityEngine;
using System.Collections;

public class HealthScrit : MonoBehaviour {
	public int currentHealth = 0;
	public delegate void voidDel();
	public voidDel deathFunction;
	public voidDel coindrop;
	public GameObject fireParticles;
	InputScript input;
	// Use this for initialization
	void Start () {
		input = GetComponent<InputScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DealDamage(int amount){
		currentHealth -= amount;
		if (currentHealth <= 0) {
			if (deathFunction != null) {
				gameObject.SetActive (false);
				deathFunction ();
				coindrop ();
			}

		}
	}
	public void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Attack") {
			if (other.GetComponent<hitboxScript> ().playerNumber != input.playerNumber) {
				DealDamage (1);
			}
		} else if (other.tag == "Fire") {
			if (other.GetComponent<hitboxScript> ().playerNumber != input.playerNumber) {
				StartCoroutine (Ignite ());
			}
		} else if (other.tag == "Bomb") {
			DealDamage (1);
		}

	}
	IEnumerator Ignite(){
		fireParticles.SetActive (true);
		yield return new WaitForSeconds (1);
		fireParticles.SetActive (false);
		DealDamage (1);
	}
	void OnDisable(){
		fireParticles.SetActive(false);
	}
}
