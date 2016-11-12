using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour {
	public float timeToDetonate;
	public GameObject explostion;

	// Use this for initialization
	void Start () {
	
	}
	void OnEnable(){
		StartCoroutine (Detonate ());
	}
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator Detonate(){
		yield return new WaitForSeconds (timeToDetonate);
		explostion.SetActive (true);
		yield return new WaitForSeconds (.2f);
		gameObject.SetActive (false);

	}
}
