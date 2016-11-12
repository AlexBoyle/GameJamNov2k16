using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject bomb;
	public GameObject whip;
	public GameObject torch;
	public GameObject waterBucket;
	public GameObject mainWeapon;
	PlayerInventory inventory;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UseItem(){
		if (inventory.getCurrentItem () == Item.Bomb) {
			UseBomb ();
		}else if (inventory.getCurrentItem () == Item.Buckets) {
			
		}else if (inventory.getCurrentItem () == Item.Torch) {
			
		}else if (inventory.getCurrentItem () == Item.Whip) {
			
		}
	}

    void UseBomb(){
		if (bomb.activeSelf == false) {
			bomb.transform.position = transform.position;
			bomb.SetActive (true);
		}
	}
}
