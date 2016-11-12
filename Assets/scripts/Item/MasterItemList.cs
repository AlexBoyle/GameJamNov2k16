using UnityEngine;
using System.Collections;

public class MasterItemList : MonoBehaviour {
	public GameObject[] Items;


	public ItemScript getItem(Item a){
		foreach (GameObject b in Items) {
			if (b.GetComponent<ItemScript> ().item == a)
				return b.GetComponent<ItemScript>();
		}
		return null;
	}
}
