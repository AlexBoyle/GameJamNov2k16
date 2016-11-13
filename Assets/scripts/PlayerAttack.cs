using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject bomb;
	public GameObject whip;
	public GameObject torch;
	public GameObject waterBucket;
	public GameObject mainWeapon;
	PlayerInventory inventory;
	InputScript input;
	PlayerMovementScript PMS;

	bool attacking = false;

	// Use this for initialization
	void Start () {
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
		float a = PMS.getFacingDegree () == 180 ? 180 : 0; 
		mainWeapon.transform.eulerAngles = new Vector3 (a, 0, PMS.getFacingDegree ());

		mainWeapon.SetActive (true);
		yield return new WaitForSeconds (.2f);
		mainWeapon.SetActive (false);
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
		torch.transform.eulerAngles = new Vector3 (0, 0, PMS.getFacingDegree ());

		torch.SetActive (true);
		yield return new WaitForSeconds (.2f);
		torch.SetActive (false);
		attacking = false;
	}
    void UseBomb(){
		if (bomb.activeSelf == false) {
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
		whip.transform.eulerAngles = new Vector3 (0, 0, PMS.getFacingDegree ());

		whip.SetActive (true);
		yield return new WaitForSeconds (.2f);
		whip.SetActive (false);
		attacking = false;
	}
	void UseBucket(){
		if (!attacking) {
			StartCoroutine (BucketEnumer());
		}
	}
	IEnumerator BucketEnumer(){
		attacking = true;
		waterBucket.transform.eulerAngles = new Vector3 (0, 0, PMS.getFacingDegree ());

		waterBucket.SetActive (true);
		yield return new WaitForSeconds (.2f);
		waterBucket.SetActive (false);
		attacking = false;
	}

}
