using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	public bool canRespawn;
	public float respawnDelay = 5;
	GameObject obstacle;
	// Use this for initialization
	void Start () {
		obstacle = transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == gameObject.tag) {
			// if object is permenantly destroyed
			obstacle.SetActive (false);
			if (canRespawn){
				StartCoroutine (ReswpanEnumerator());
			}

		}
	}
	IEnumerator ReswpanEnumerator(){
		yield return new WaitForSeconds (respawnDelay);
		obstacle.SetActive (true);
	}
}
