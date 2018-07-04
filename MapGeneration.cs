using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
	//Create levels 

	// I need 
	private int[][] levels = new int[][] {new int[]
	{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
	0,2,2,2,2,2,2,2,2,2,2,2,2,4,2,0,
	0,2,2,2,2,2,0,2,2,2,0,2,2,0,2,0,
	0,2,0,0,2,0,0,2,0,2,0,0,0,0,2,0,
	1,2,2,2,2,2,2,2,0,2,2,2,2,2,2,1,
	0,2,0,0,3,0,0,2,0,2,0,0,2,0,0,0,
	0,2,2,2,2,2,2,2,2,2,2,2,2,0,5,0,
	0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		new int[]
	{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
	2,2,2,2,2,2,2,2,2,2,2,2,0,4,2,2,
	0,2,2,0,2,0,2,2,2,2,0,2,2,2,0,0,
	0,2,0,0,2,0,0,0,2,3,0,0,0,2,0,0,
	0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,
	0,2,0,0,3,0,0,0,2,0,0,0,0,0,0,0,
	0,2,2,0,2,0,2,0,2,0,2,0,2,0,5,0,
	0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,
	0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
	};//two last numbers are dimmensions


	public Transform points;
	public int selectedLevel;
	public int pointNumber;

	//0-wall
	//1-path
	//2-regular pick up
	//3-special pick up
	//4- spawn point
	//public Object[] levelBlocks;
	//public Object[] pickups;
	//public Object[] spawns;
	public Object blockWall;
	public Object blockPath;
	public Object pickRegular;
	public Object pickSpecial;
	public Object spawn;
	public Object playerSpawn;
	// Use this for initialization
	void Start()
	{
		selectedLevel = PlayerPrefs.GetInt("Level", 0);
		if (selectedLevel > levels.Length - 1)
		{
			PlayerPrefs.SetInt("Level", 0);
			selectedLevel = 0;
		}
		for (int y = 0; y < 9; y++)
		{
			for (int x = 0; x < 16; x++)
			{
				int type = levels[selectedLevel][x + 16 * y];// hardcoded 16 stands for map width
				//create wall or floor and the add other stuff on top
				if (type == 0)
					Object.Instantiate(blockWall, new Vector3(x, y, 0), Quaternion.identity, transform);
				else
					Object.Instantiate(blockPath, new Vector3(x, y, 0), Quaternion.identity, transform);

				if (type == 4)
					Object.Instantiate(spawn, new Vector3(x, y, 0), Quaternion.identity, transform);
				else if (type == 5)
					Object.Instantiate(playerSpawn, new Vector3(x, y, 0), Quaternion.identity, transform);

				else if (type == 2)
				{
					pointNumber++;
					Object.Instantiate(pickRegular, new Vector3(x, y, 0), Quaternion.identity, points);
				}
				else if (type == 3)
				{
					pointNumber++;
					Object.Instantiate(pickSpecial, new Vector3(x, y, 0), Quaternion.identity, points);
				}
			}
		}
		GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().pointsNum = pointNumber;
	}


}
