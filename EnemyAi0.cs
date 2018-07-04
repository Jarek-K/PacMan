using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi0 : MonoBehaviour {
	public Character character;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (character.moveDirection == 4)
			character.moveDirection = Random.Range(0, 4);
	}
}
