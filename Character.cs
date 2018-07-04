using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{


	public int moveDirection; //4 - standing still 0-up then clockwise

	public float speed;
	public int ID;//only for enemies, different ais should have different ids
	public LayerMask wall;
	public Spawn spawn; // only for enemies
						// Use this for initialization
	void Start()
	{
		speed = speed * Time.fixedDeltaTime; // make nicer numbers for speed
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (moveDirection != 4)
		{
			Vector3 newPos = transform.position;

			//Movement used for player and enemies, In the future  add requested direction and more
			if (moveDirection == 0)
			{
				//raycast for collision checing
				if (Physics2D.Raycast(transform.position, Vector2.up, 0.52f, wall.value).collider == null)
				{
					transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180)); //rotate in movemnt direction
					newPos.y += speed;
				}
				else
				{
					transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
					moveDirection = 4;
				}
			}
			else if (moveDirection == 1)
			{
				if (Physics2D.Raycast(transform.position, Vector2.right, 0.52f, wall.value).collider == null)
				{
					transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
					newPos.x += speed;
				}
				else
				{
					transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
					moveDirection = 4;
				}
			}
			else if (moveDirection == 2)
			{
				if (Physics2D.Raycast(transform.position, Vector2.down, 0.52f, wall.value).collider == null)
				{
					transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
					newPos.y -= speed;
				}
				else
				{
					transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
					moveDirection = 4;
				}
			}
			else
			{
				if (Physics2D.Raycast(transform.position, Vector2.left, 0.52f, wall.value).collider == null)
				{
					transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
					newPos.x -= speed;
				}
				else
				{
					transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
					moveDirection = 4;
				}
			}

			//checking if out of bounds to loop back
			if (newPos.x < -0.7)
				newPos.x = 15.7f; //instead of 16 should be width of level
			else if (newPos.x > 15.7)
				newPos.x = -0.7f;
			transform.position = newPos;
		}


	}
	public void Kill() // kill is only used for enemies, since playercontrol already knows when its dead bcause it does the trigger check
	{
		spawn.alive[ID] = 0;
		Destroy(gameObject);
	}

}
