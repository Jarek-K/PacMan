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
		lives = PlayerPrefs.GetInt("Lives", 3);

		livesTxt.text = "Lives: " + lives;
	}

	// Update is called once per frame
	public void Die()
	{
		lives--;
		PlayerPrefs.SetInt("Lives", lives);
		if (lives == -1)
		{
			PlayerPrefs.SetInt("Lives", 3);
			PlayerPrefs.SetInt("Score", 0);
			PlayerPrefs.SetInt("Level", 0);
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
