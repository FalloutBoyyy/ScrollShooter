using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyBullet : MonoBehaviour
{
	float time = 0f;
	float waitTime = 10f;
	void Start()
	{

	}



	void OnCollisionEnter2D(Collision2D obj)
	{

		if (obj.gameObject.name == "DBorder" || obj.gameObject.name == "UBorder" && gameObject.name != "EnemyLaser")
		{
			Destroy(gameObject);

		}

		if (obj.gameObject.name == "Player")
		{
			Debug.Log("Coll");
			Destroy(obj.gameObject);
			Destroy(gameObject);
		}

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{

	}


}