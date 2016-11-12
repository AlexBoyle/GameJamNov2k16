using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	public Item currentItem;
	int currentIngredients;
	private MasterItemList itemMaster;
	public int buffer = 0;
	public void Start(){
		itemMaster = GameObject.Find ("ItemMaster").GetComponent<MasterItemList> ();
	}
	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Ingredients") {

		}
		if (buffer <= 0 && col.tag == "Item") {
			ChangeItem (itemMaster.getItem (col.gameObject.GetComponent<ItemScript> ().item).pickUp ());
		}
	}
	public void AddIngredient(){
		currentIngredients++;
		if (currentIngredients >= 3) {
			// TODO call alex script
		}
	}
	public void RemoveIngredients(){
		currentIngredients = 0;
	}
	public void ChangeItem(Item newItem){
		if (currentItem != Item.none) {
			itemMaster.getItem (currentItem).drop (transform.position- (new Vector3(0,0,0)));
		}
		buffer = 30;
		currentItem = newItem;
	}
	public Item getCurrentItem(){
		return currentItem;
	}
	void FixedUpdate () {
		if (buffer > 0)
			buffer--;
	}
}


public enum Item{
	Bomb = 0,
	Torch = 1,
	Whip =2 ,
	Buckets =3,
	none=4
}