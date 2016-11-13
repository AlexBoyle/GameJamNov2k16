using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject bomb;
	public GameObject whip;
	public GameObject torch;
	public GameObject waterBucket;
	public GameObject mainWeapon;
	public GameObject mainWeapon1;
	public GameObject mainWeapon2;
	public GameObject mainWeapon3;
	PlayerInventory inventory;
	InputScript input;
	PlayerMovementScript PMS;
	SoundPlayer sound;

	bool attacking = false;

	// Use this for initialization
	void Start () {
		sound = GameObject.Find ("Main Camera").GetComponent<SoundPlayer>();
		inventory = GetComponent<PlayerInventory> ();
		input = GetComponent<InputScript> ();
		PMS = GetComponent<PlayerMovementScript> ();
		input.assignXButton (UseItem , null);
		input.assignAButton (Attack, null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDisable(){
		whip.SetActive (false);
		torch.SetActive (false);
		mainWeapon.SetActive (false);
		waterBucket.SetActive (false);
		attacking = false;
	}
	public void Attack(){
		if (!attacking) {

			StartCoroutine (AttackEnumer ());
		}

	}
	IEnumerator AttackEnumer(){
		attacking = true;
		PMS.DisableMovement();
		yield return new WaitForSeconds (.05f);
		float a = PMS.getFacingDegree () == 180 ? 180 : 0; 
		mainWeapon.transform.eulerAngles = new Vector3 (a, 0, PMS.getFacingDegree ());

		mainWeapon.SetActive (true);
		mainWeapon1.SetActive (true);
		mainWeapon2.SetActive (false);
		mainWeapon3.SetActive (false);
		yield return new WaitForSeconds (.05f);
		mainWeapon2.SetActive (true);
		mainWeapon1.SetActive (false);
		yield return new WaitForSeconds (.05f);
		mainWeapon3.SetActive (true);
		mainWeapon2.SetActive (false);
		yield return new WaitForSeconds (.05f);
		mainWeapon.SetActive (false);
		yield return new WaitForSeconds (.15f);
		PMS.canMove = true;
		attacking = false;
	}
	public void UseItem(){
		if (inventory.getCurrentItem () == Item.Bomb) {
			UseBomb ();
		}else if (inventory.getCurrentItem () == Item.Buckets) {
			UseBucket ();
		}else if (inventory.getCurrentItem () == Item.Torch) {
			UseTorch ();
		}else if (inventory.getCurrentItem () == Item.Whip) {
			UseWhip ();
		}
	}
	public void UseTorch(){
		if (!attacking) {

			StartCoroutine (TorchEnumer ());
		}

	}
	IEnumerator TorchEnumer(){
		attacking = true;
		PMS.DisableMovement();
		yield return new WaitForSeconds (.1f);
		torch.transform.eulerAngles = new Vector3 (0, 0, PMS.getFacingDegree ());

		torch.SetActive (true);
		sound.PlayFire ();
		yield return new WaitForSeconds (.1f);
		torch.SetActive (false);
		yield return new WaitForSeconds (.2f);
		PMS.canMove = true;
		attacking = false;
	}
    void UseBomb(){
		if (bomb.activeSelf == false) {
			sound.PlayBombLay ();
			bomb.transform.position = transform.position;
			bomb.SetActive (true);
		}
	}
	void UseWhip(){
		if (!attacking) {
			StartCoroutine (WhipEnumer());
		}
	}
	IEnumerator WhipEnumer(){
		attacking = true;
		PMS.DisableMovement();
		yield return new WaitForSeconds (.1f);
		whip.transform.eulerAngles = new Vector3 (0, 0, PMS.getFacingDegree ());
		whip.SetActive (true);
		sound.PlayWhip();
		yield return new WaitForSeconds (.2f);
		whip.SetActive (false);
		yield return new WaitForSeconds (.1f);
		PMS.canMove = true;
		attacking = false;
	}
	void UseBucket(){
		if (!attacking) {
			StartCoroutine (BucketEnumer());
		}
	}
	IEnumerator BucketEnumer(){
		attacking = true;
		PMS.DisableMovement();
		yield return new WaitForSeconds (.1f);
		waterBucket.transform.eulerAngles = new Vector3 (0, 0, PMS.getFacingDegree ());
		//TODO: add water sound and uncomment
		//sound.PlayWater ();
		waterBucket.SetActive (true);
		yield return new WaitForSeconds (.5f);
		waterBucket.SetActive (false);
		yield return new WaitForSeconds (.1f);
		PMS.canMove = true;
		attacking = false;
	}

}
