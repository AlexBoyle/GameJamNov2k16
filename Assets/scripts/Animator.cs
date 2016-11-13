using UnityEngine;
using System.Collections;

public class Animator : MonoBehaviour {
	public arr[] Animations;
	public Sprite[] current;
	public int aniSpeed = 2;
	private int anicount = 0;
	public int aniStep = 0;
	void Start(){
		foreach(arr item in Animations){
			item.set();
		}
		current = Animations[0].getAnimation();
	}
	public void currentSprite(int a){
		if (a == -1)
			current = null;
		current = Animations[a].getAnimation();
	}
	
	public void clear(){	
		gameObject.GetComponent<SpriteRenderer> ().sprite = null;
	}
	
	void FixedUpdate () {
		if ((anicount++) >= aniSpeed) {
			anicount = 0;
			aniStep++;
		}
		if (current.Length > 0) {
			if ((aniStep % current.Length) == 0)
				aniStep = 0;
			gameObject.GetComponent<SpriteRenderer> ().sprite = current [aniStep % current.Length];
		}	
	}
}

[System.Serializable]
public class arr{
	public string Name;
	public Texture2D sheet;
	private Sprite[] ani;

	public Sprite[] getAnimation(){
		return ani;
	}
	
	public void set() {
		if(sheet)
			ani = Resources.LoadAll<Sprite> (sheet.name);
	}
}