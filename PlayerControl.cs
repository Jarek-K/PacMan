using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public Character character;
	public int requestedDirection=4;
	public float turnMargin;
	public LayerMask wall;
	//I use requested direction to make game more fuent
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update () {

	
		if (Input.GetAxis("Vertical")>0)
			{
			requestedDirection = 0;
			//character.moveDirection = 0;
		}
		else if (Input.GetAxis("Vertical") <0)
		{
			requestedDirection = 2;
		//	character.moveDirection = 2;
		}
		else if (Input.GetAxis("Horizontal") >0)
		{
			requestedDirection = 1;
		//	character.moveDirection = 1;
		}
		else if (Input.GetAxis("Horizontal") <0)
		{
			requestedDirection = 3;
			//character.moveDirection = 3;
		}

		if (requestedDirection != 4)
		{
			if (Mathf.Abs(transform.position.x - Mathf.Round(transform.position.x)) < turnMargin && Mathf.Abs(transform.position.y -Mathf.Round(transform.position.y)) < turnMargin)
			{
				if (requestedDirection == 0)
				{
					RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up,1f, wall.value);
					Debug.DrawRay(transform.position, Vector2.up,Color.red,0.5f);
					if (hit.collider == null)
					{
						print("What");
						transform.position = new Vector3(Mathf.Round(transform.position.x),transform.position.y,0);
							character.moveDirection = requestedDirection;
						requestedDirection = 4;
					}
				}
				else if (requestedDirection == 1)
				{
					RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, wall.value);
					Debug.DrawRay(transform.position, Vector2.right, Color.red, 1f);
					//print(hit.collider.tag);
					if (hit.collider == null )
					{
						
						transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), 0);
						character.moveDirection = requestedDirection;
						requestedDirection = 4;
					}
				}
				else if (requestedDirection == 2)
				{
					RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, wall.value);
					Debug.DrawRay(transform.position, Vector2.down, Color.red, 1f);
					if (hit.collider == null )
					{
						transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), 0);
						character.moveDirection = requestedDirection;
						requestedDirection = 4;
					}
				}
				else if (requestedDirection == 3)
				{
					Debug.DrawRay(transform.position, Vector2.left, Color.red, 1f);
					RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 1f, wall.value);
					if (hit.collider == null )
					{
						transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, 0);
						character.moveDirection = requestedDirection;
						requestedDirection = 4;
					}
				}
				
			}
		}
	}
	
	public void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.transform.tag == "Pickup")
		{
			//collect pickup
		}
		
		else // enemy
		{

		}
	}

}
