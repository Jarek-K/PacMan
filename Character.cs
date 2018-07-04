using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


	public int moveDirection; //4 - standing still 0-up clockwise
	public int strength; 
	public float speed;
	public bool pick;
	// Use this for initialization
	void Start () {
		speed = speed * Time.fixedDeltaTime; // make nicer numbers for speed
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moveDirection != 4)
		{
			Vector3 newPos = transform.position;
			if (moveDirection == 0)
				newPos.y += speed;
			else if (moveDirection == 1)
				newPos.x += speed;
			else if (moveDirection == 2)
				newPos.y -= speed;
			else
				newPos.x -= speed;
				transform.position = newPos;
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Pickup" &&pick)
		{
			//collect pickup
		}
		else if (collision.transform.tag == "Wall")
		{
			moveDirection = 4; //stop
			transform.position = new Vector3((int)transform.position.x, (int)transform.position.y, 0);//adjust position to center of square

		}
	
	}
	public void Die()
	{
	}
}
