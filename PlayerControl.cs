using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public Character character;
	public int requestedDirection = 4;
	public float turnMargin;
	public LayerMask wall;
	public int pickupTime;
	private Lives lives;
	private Score score;
	private bool invulnerable = false;
	private IEnumerator coroutine;
	public PlayerSpawn spawn;
	//I use requested direction to make game more fuent
	void Start()
	{
		lives = GameObject.FindGameObjectWithTag("Score").GetComponent<Lives>();
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
	}


	// Update is called once per frame
	void Update()
	{


		if (Input.GetAxis("Vertical") > 0)
		{
			requestedDirection = 0;
			//character.moveDirection = 0;
		}
		else if (Input.GetAxis("Vertical") < 0)
		{
			requestedDirection = 2;
			//	character.moveDirection = 2;
		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			requestedDirection = 1;
			//	character.moveDirection = 1;
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			requestedDirection = 3;
			//character.moveDirection = 3;
		}

		if (requestedDirection != 4)
		{
			if (Mathf.Abs(transform.position.x - Mathf.Round(transform.position.x)) < turnMargin && Mathf.Abs(transform.position.y - Mathf.Round(transform.position.y)) < turnMargin)
			{
				if (requestedDirection == 0)
				{
					RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f, wall.value);
					Debug.DrawRay(transform.position, Vector2.up, Color.red, 0.5f);
					if (hit.collider == null)
					{

						transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, 0);
						character.moveDirection = requestedDirection;
						requestedDirection = 4;
					}
				}
				else if (requestedDirection == 1)
				{
					RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, wall.value);
					Debug.DrawRay(transform.position, Vector2.right, Color.red, 1f);
					//print(hit.collider.tag);
					if (hit.collider == null)
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
					if (hit.collider == null)
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
					if (hit.collider == null)
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
			invulnerable = true;
			gameObject.GetComponent<SpriteRenderer>().color = Color.black;
			coroutine = Wait(pickupTime);
			StartCoroutine(coroutine);
			character.speed = character.speed * 1.5f;
			Destroy(collision.gameObject);
			score.Increment(100);
		}
		else if (collision.transform.tag == "Point")
		{
			Destroy(collision.gameObject);
			score.Increment(50);
		}
		else if (collision.transform.tag == "Enemy")// enemy
		{
			if (invulnerable)
			{
				score.Increment(250);
				collision.transform.GetComponent<Character>().Kill();
			}
			else
			{
				
				lives.Die();
				
					spawn.Spawn();
					Destroy(gameObject);
				
			}
		}
	}
	private IEnumerator Wait(int waitTime)
	{

		yield return new WaitForSeconds(waitTime);
		
		character.speed = character.speed / 1.5f;
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		invulnerable = false;
	}
}
