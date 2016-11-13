using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	public bool canRespawn;
	public float respawnDelay = 5;
	public Item counterType;
	GameObject obstacle;
	// Use this for initialization
	void Start () {
		obstacle = transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.tag);
		if ((other.tag =="Bomb" && counterType == Item.Bomb) || (other.tag =="Fire" && counterType == Item.Torch)
			|| (other.tag =="Bucket" && counterType == Item.Buckets)) {
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
