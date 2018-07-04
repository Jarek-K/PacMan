using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


	public int moveDirection; //4 - standing still 0-up clockwise
	public int strength; 
	public float speed;
	public bool pick;
	public LayerMask wall;
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
			{
				if (Physics2D.Raycast(transform.position, Vector2.up, 0.52f, wall.value).collider == null)

					newPos.y += speed;
				else
				{
					transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
					moveDirection = 4;
				}
			}
			else if (moveDirection == 1)
			{
				if (Physics2D.Raycast(transform.position, Vector2.right, 0.52f, wall.value).collider == null)
					newPos.x += speed;
				else
				{
					transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
					moveDirection = 4;
				}
			}
			else if (moveDirection == 2)
			{
				if (Physics2D.Raycast(transform.position, Vector2.down, 0.52f, wall.value).collider == null)
					newPos.y -= speed;
				else
				{
					transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
					moveDirection = 4;
				}
			}
			else
			{
				if (Physics2D.Raycast(transform.position, Vector2.left, 0.52f, wall.value).collider == null)
					newPos.x -= speed;
				else
				{
					transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
					moveDirection = 4;
				}
			}
			if (newPos.x < -1)
				newPos.x = 16f;
			else if (newPos.x > 16)
				newPos.x = -1f;
				transform.position = newPos;
		}

		
	}

	public void Die()
	{
	}
}
