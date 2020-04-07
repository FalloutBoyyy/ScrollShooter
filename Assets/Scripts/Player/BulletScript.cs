using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody2D))]

public class BulletScript : MonoBehaviour
{

	void Start()
	{

	}



	void OnCollisionEnter2D(Collision2D obj)
	{

		if (obj.gameObject.name == "UBorder" && gameObject.name != "Laser")
		{
			Destroy(gameObject);
		}


	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Enemy")
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}


}