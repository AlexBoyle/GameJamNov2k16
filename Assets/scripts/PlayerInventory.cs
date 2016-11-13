using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour {

	public Item currentItem;
	public int currentIngredients;
	public GameObject winnerWraper;
	private MasterItemList itemMaster;
	public int buffer = 0;
	public void Start(){
		itemMaster = GameObject.Find ("ItemMaster").GetComponent<MasterItemList> ();
		gameObject.GetComponent<HealthScrit> ().coindrop = RemoveIngredients;
	}
	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Finish") {
			col.GetComponent<ingredient>().pickUp ();
			AddIngredient ();
		}
		else if(buffer <=  0 && col.tag == "Item")
			ChangeItem (itemMaster.getItem(col.gameObject.GetComponent<ItemScript> ().item).pickUp());
	}
	public void AddIngredient(){
		currentIngredients++;
		if (currentIngredients >= 3) {
			StartCoroutine (win ());
		}
	}

	IEnumerator win(){
		winnerWraper.SetActive (true);
		winnerWraper.GetComponentInChildren<TextMesh>().text = "Player " + gameObject.GetComponent<InputScript>().playerNumber + " Wins";
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
	public void RemoveIngredients(){
		ChangeItem (Item.none);
		for (int i = 0; i < currentIngredients; i++) {
			itemMaster.spawnIngredient (transform.position);
		}
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