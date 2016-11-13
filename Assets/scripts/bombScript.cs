using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour {
	public float timeToDetonate;
	public GameObject explostion;
	public Sprite def;
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
		gameObject.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (.2f);
		gameObject.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (.5f);
		gameObject.GetComponent<Animator> ().enabled = false;
		gameObject.GetComponent<Animator> ().aniStep = 0;
		gameObject.SetActive (false);
		gameObject.GetComponent<SpriteRenderer> ().sprite = def;

	}
}
