using UnityEngine;
using System.Collections;

public class HealthScrit : MonoBehaviour {
	public int currentHealth = 0;
	public delegate void voidDel();
	public voidDel deathFunction;
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
			}

		}
	}
	public void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Attack") {
			DealDamage (1);
		}
	}
}
