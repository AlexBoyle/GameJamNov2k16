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
}


public enum Item{
	Bomb,
	Torch,
	Whip,
	Buckets,
	none
}