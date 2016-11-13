using UnityEngine;
using System.Collections;

public class SingleAnimation : MonoBehaviour {
	public Sprite[] current;
	public int aniSpeed = 2;
	private int anicount = 0;
	public int aniStep = 0;


	void OnEnable() {
		aniStep = 0;
	}
	void FixedUpdate () {
		if ((anicount++) >= aniSpeed) {
			anicount = 0;
			aniStep++;
		}
		if (current.Length > 0) {
			if (aniStep < current.Length)
				gameObject.GetComponent<SpriteRenderer> ().sprite = current [aniStep];
		}	
	}
}
