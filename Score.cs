using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text scoreTxt;
	int score;

	// Use this for initialization
	void Start () {
		scoreTxt.text = "Score: " + 0;
	}

	// Update is called once per frame
	public void Increment(int i)
	{
		score += i;
		scoreTxt.text = "Score: " + score;
	}
}
