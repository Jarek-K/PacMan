using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	public Text scoreTxt;
	int score;
	int counter;
	public int pointsNum;
	//should make it less cluttered but I forgot the command for space and whatnot
	public int pointBasic; // points amounts for different things
	public int pointPick;
	public int pointBird;

	// Use this for initialization
	void Start()
	{

		score = PlayerPrefs.GetInt("Score", 0);
		scoreTxt.text = "Score: " + score;
	}

	// Update is called once per frame
	public void Increment(int i)
	{
		if (i == 0)
		{
			counter++;
			score += pointBasic;
			scoreTxt.text = "Score: " + score;
		}
		else if (i == 1)

		{
			counter++;
			score += pointPick;
			scoreTxt.text = "Score: " + score;
		}
		else if (i == 2)

		{
			score += pointBird;
			scoreTxt.text = "Score: " + score;
		}
		if (counter == pointsNum) // all points collected
		{
			PlayerPrefs.SetInt("Lives", GetComponent<Lives>().lives); // Save current stats, and load a new level
			PlayerPrefs.SetInt("Score", score);
			PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
