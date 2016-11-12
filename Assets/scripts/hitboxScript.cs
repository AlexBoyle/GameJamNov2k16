using UnityEngine;
using System.Collections;

public class hitboxScript : MonoBehaviour {
	[SerializeField]
	public Item type;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Item GetType(){
		return type;

	}
}
