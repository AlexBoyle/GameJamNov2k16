using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public HealthScrit playerHealth;
	public float waitTime = 1f;
	public GameObject player;
	public GameObject[] spawnPoints;

	void Start()
	{
		//Spawn ();
		spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
		playerHealth.deathFunction = Respawn;
	}
		

	void Update()
	{

	}

	//use spawn function if we need to make player start at the spawn point instead of just setting them there.
	/*void Spawn()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (player, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
	*/

	void Respawn(){
		StartCoroutine (RespawnEnumerator());
	}


	IEnumerator RespawnEnumerator(){
		yield return new WaitForSeconds (waitTime);
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		player.transform.position = spawnPoints [spawnPointIndex].transform.position;
		player.gameObject.SetActive (true);
	}
}
