using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {
	public AudioClip hit;
	public AudioClip bombLay;
	public AudioClip whip;
	public AudioClip fire;
	public AudioClip pickupItem;
	public AudioClip pickupIngredient;
	public AudioClip water;
	public AudioClip bombExplosion;

	AudioSource audioS;
	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PlayHit(){
		audioS.PlayOneShot (hit);
	}
	public void PlayBombLay(){
		audioS.PlayOneShot (bombLay);
	}
	public void PlayBombExplosion(){
		audioS.PlayOneShot (bombExplosion);
	}
	public void PlayWater(){
		audioS.PlayOneShot (water);
	}
	public void PlayPickupItem(){
		audioS.PlayOneShot (pickupItem);
	}
	public void PlayPickupIngredient(){
		audioS.PlayOneShot (pickupIngredient);
	}
	public void PlayWhip(){
		audioS.PlayOneShot (whip);
	}
	public void PlayFire(){
		audioS.PlayOneShot (fire);
	}

}
