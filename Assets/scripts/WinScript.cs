using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScript : MonoBehaviour {
	public InputScript input;
	public TextMesh text;
	public int waitTime;
	public void win()
	{
		GetComponent<TextMesh> ().text = "Player " + (input.playerNumber + 1) + " Wins";
		StartCoroutine (restart());
	}
	IEnumerator restart()
	{
		yield return new WaitForSeconds (waitTime);
		string currentSceneName = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (currentSceneName);
	}

}
