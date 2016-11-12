using UnityEngine;
using System.Collections;

public class HealthScrit : MonoBehaviour {
	public int currentHealth = 0;
	public delegate void voidDel();
	public voidDel deathFunction;
	public voidDel coindrop;
	public GameObject fireParticles;
	// Use this for initialization
	void Start () {
	
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
			DealDamage (1);
		} else if (other.tag == "Fire") {
			StartCoroutine (Ignite ());
		}

	}
	IEnumerator Ignite(){
		fireParticles.SetActive (true);
		yield return new WaitForSeconds (1);
		fireParticles.SetActive (false);
		DealDamage (1);
	}
}
