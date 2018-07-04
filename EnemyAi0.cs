using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi0 : MonoBehaviour
{
	public Character character;
	private IEnumerator coroutine;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (character.moveDirection == 4)
			character.moveDirection = Random.Range(0, 4);//basically when it hits a wall it goes in random direction
		else
		{
			//coroutine = Wait(2);
			//	StartCoroutine(coroutine);
		}
	}
	private IEnumerator Wait(int waitTime)
	{

		yield return new WaitForSeconds(waitTime);
		character.moveDirection = Random.Range(0, 4);


	}
}
