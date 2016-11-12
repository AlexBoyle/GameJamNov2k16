using UnityEngine;
using System.Collections;

public class MasterItemList : MonoBehaviour {
	public GameObject[] Items;
	public GameObject Ingredient;
	private GameObject[] Ingredients;


	public void Start(){
		Ingredients = new GameObject[5];
		for (int i = 0; i < 5; i++) {
			Ingredients [i] = Instantiate (Ingredient);
			Ingredients [i].SetActive (false);
		}
	}

	public void spawnIngredient(Vector3 a){
		GameObject temp = null;
		foreach (GameObject ing in Ingredients) {
			if (!ing.activeSelf) {
				temp = ing;
				break;
			}
		}

		temp.transform.position = a + (new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f) ,0));
		temp.SetActive (true);
	}
	public ItemScript getItem(Item a){
		foreach (GameObject b in Items) {
			if (b.GetComponent<ItemScript> ().item == a)
				return b.GetComponent<ItemScript>();
		}
		return null;
	}
}
