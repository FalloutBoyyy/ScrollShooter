using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody2D))]

public class BulletScript : MonoBehaviour
{
	float time = 0f;
	float waitTime = 10f;
	void Start()
	{
		if(name != "Laser")
		{
			Destroy(gameObject, 5);
		}
	}


	private void Update()
	{
		time += Time.deltaTime;
		if (waitTime <= time)
		{

			time = time - waitTime;
		}

		void OnCollisionEnter2D(Collision2D obj)
		{
			if (obj.collider.isTrigger)
				Destroy(gameObject);
		}

	}	
}