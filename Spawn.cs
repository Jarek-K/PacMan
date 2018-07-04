// I copied this part straight out of generic unity tutorial thing because it does exactly what I want


using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	public float spawnTime = 5f;        // The amount of time between each spawn.
	public float spawnDelay = 3f;       // The amount of time before spawning starts.
	public GameObject[] enemies;        // Array of enemy prefabs.
	public int[] alive;					//array of states of enemies

	void Start()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawner", spawnDelay, spawnTime);
		alive = new int[enemies.Length]; // I'm pretty sure unity initializes to 0 automatically
		
	}


	void Spawner()
	{
		for (int i = 0; i < alive.Length; i++)
		{
			if (alive[i] == 0)
			{
				GameObject enemy = Instantiate(enemies[i], transform.position, transform.rotation);
				enemy.GetComponent<Character>().spawn = this;
				enemy.GetComponent<Character>().ID = 0;
				alive[i] = 1;
				break;
			}
		}


	}
}
