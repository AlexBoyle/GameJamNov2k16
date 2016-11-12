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
}


public enum Item{
	Bomb = 0,
	Torch = 1,
	Whip =2 ,
	Buckets =3,
	none=4
}