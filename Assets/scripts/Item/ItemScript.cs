using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {
	public Item item;
	public Item pickUp(){
		transform.parent.gameObject.SetActive (false);
		return item;
	}
	public void drop(Vector3 a){
		transform.parent.gameObject.transform.position = a;
		transform.parent.gameObject.SetActive (true);
	}
}
