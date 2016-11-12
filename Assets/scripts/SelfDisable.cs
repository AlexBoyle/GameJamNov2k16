using UnityEngine;
using System.Collections;

public class SelfDisable : MonoBehaviour {
	public float delay;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnEnable(){
		StartCoroutine (SelfTurnOff ());
	}

	IEnumerator SelfTurnOff(){
		yield return new WaitForSeconds (delay);
		gameObject.SetActive (false);
	
	}
}
