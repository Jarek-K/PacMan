﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {
	//Create levels 
	
	// I need 
	private int[][] levels = new int[][] {new int[]
	{ 3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
	0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
	0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
	0,2,0,0,2,0,0,0,0,0,0,0,0,0,0,0,
	0,2,0,0,3,0,0,0,0,0,0,0,0,0,0,0,
	0,2,0,0,3,0,0,0,0,0,0,0,0,0,0,0,
	0,2,0,0,2,0,0,0,0,0,0,0,0,0,0,0,
	0,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0} } ;//two last numbers are dimmensions

	public int selectedLevel;
	public bool buildLevel;
	//0-wall
	//1-path
	//2-regular pick up
	//3-special pick up
	//4- spawn point
	public Object[] levelBlocks;
	public Object[] pickups;
	public Object[] spawns;
	public Object blockWall;
	public Object blockPath;
	public Object pickRegular;
	public Object pickSpecial;
	public Object spawn;
	public Object playerSpawn;
	// Use this for initialization
	void Start () {
		
		for (int y = 0; y < 9; y++)
		{
			for (int x = 0; x < 16; x++)
			{
				int type = levels[selectedLevel][x + 16 * y];
				if (buildLevel) //on simple restarts there's no need to reload all blocks
				{
					if(type ==0)
					Object.Instantiate(blockWall, new Vector3(x, y, 0), Quaternion.identity, transform);
					else
						Object.Instantiate(blockPath, new Vector3(x, y, 0), Quaternion.identity, transform);
					if(type ==4)
						Object.Instantiate(spawn, new Vector3(x, y, 0), Quaternion.identity, transform);
					if(type == 5)
						Object.Instantiate(playerSpawn, new Vector3(x, y, 0), Quaternion.identity, transform);
				}
				if (type == 2)
				{

					Object.Instantiate(pickRegular, new Vector3(x, y, 0), Quaternion.identity, transform);
				}
				else if (type == 3)
				{
					Object.Instantiate(pickSpecial, new Vector3(x, y, 0), Quaternion.identity, transform);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
