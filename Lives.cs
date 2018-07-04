using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Lives : MonoBehaviour
{
	public int lives = 3;
	public Text livesTxt;

	// Use this for initialization
	void Start()
	{
		livesTxt.text = "Lives: " + lives;
	}

	// Update is called once per frame
	public void Die()
	{
		lives--;
		if (lives == -1)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			//reload level
		}
		else
		{
			livesTxt.text = "Lives: " + lives;
			
			//	Spawn and whatnot
		}
	}
}
