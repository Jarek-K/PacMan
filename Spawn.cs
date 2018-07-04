// I copied this part straight out of generic unity tutorial thing because it does exactly what I want


using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	public float spawnTime = 5f;        // The amount of time between each spawn.
	public float spawnDelay = 3f;       // The amount of time before spawning starts.
	public GameObject[] enemies;        // Array of enemy prefabs.


	void Start()
	{
		// Start calling the Spawn function repeatedly after a delay .
		//InvokeRepeating("Spawner", spawnDelay, spawnTime);
		Spawner();
	}


	void Spawner()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

		// Play the spawning effect from all of the particle systems.
		foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}
