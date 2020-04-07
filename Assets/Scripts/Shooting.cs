using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour
{
	float time = 0f;
	public float waitTime = 0.5f;

	public float speed = 10; // скорость пули
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

	void SetRotation()
	{
		Vector3 mousePosMain = Input.mousePosition;
		mousePosMain.z = Camera.main.transform.position.z;
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
		lookPos = lookPos - transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		angle = Mathf.Clamp(angle, minAngle, maxAngle);
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
			clone.transform.position = new Vector2(clone.position.x, clone.position.y + 0.9f);
		}
	}
}