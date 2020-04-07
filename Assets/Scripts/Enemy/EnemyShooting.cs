using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShooting : MonoBehaviour
{
	float time = 0f;
	public float waitTime = 0.5f;

	public float speed = -10f; // скорость пули
	public Rigidbody2D bullet; // префаб нашей пули
	public Transform gunPoint; // точка рождения
	public float fireRate = 1; // скорострельность

	private Transform pos;
	float addForce = 10f;
	// ограничение вращения
	public float minAngle = -40;
	public float maxAngle = 40;

	private float curTimeout;

	void Start()
	{
	}



	void Update()
	{
		time += Time.deltaTime;
		if (waitTime <= time)
		{
			Fire();
			time = time - waitTime;
		}
		else
		{
			curTimeout = 100;
		}
	}

	void Fire()
	{
		pos = gunPoint;
		curTimeout += Time.deltaTime;
		if (curTimeout > fireRate)
		{
			curTimeout = 0;
			Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
			clone.velocity = transform.TransformDirection(gunPoint.up * speed);
			clone.transform.up = gunPoint.up;
		}
	}
}