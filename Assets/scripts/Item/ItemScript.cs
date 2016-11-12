using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {
	public Item item;
	public Item pickUp(){
		gameObject.SetActive (false);
		return item;
	}
	public void drop(Vector3 a){
		gameObject.transform.position = a;
		gameObject.SetActive (true);
	}
}
