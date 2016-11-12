using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	Item currentItem;
	int currentIngredients;
	//void OnCollisionEnter2D(Collider2D col){
	//	Debug.Log (col.tag);
	//}
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
			// eject current item
		}
		currentItem = newItem;
	}
	public Item getCurrentItem(){
		return currentItem;
	}
}


public enum Item{
	Bomb = 0,
	Torch = 1,
	Whip =2 ,
	Buckets =3,
	none=4
}