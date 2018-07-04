using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
	public Object player;
	// Use this for initialization
	public void Start()
	{
		GameObject playerObj = (GameObject)Instantiate(player, transform.position, transform.rotation);
		playerObj.GetComponent<PlayerControl>().spawn = this;
	}

	// Update is called once per frame
	public void Spawn()
	{
	GameObject playerObj =(GameObject)	Instantiate(player, transform.position, transform.rotation);
		playerObj.GetComponent<PlayerControl>().spawn = this;
	}
}
