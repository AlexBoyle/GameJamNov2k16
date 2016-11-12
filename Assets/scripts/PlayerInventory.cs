using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	Item currentItem;
	int currentIngredients;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
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