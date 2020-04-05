using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{

	public float speed = 10; // скорость пули
	public Rigidbody2D bullet; // префаб нашей пули
	public Transform gunPoint; // точка рождения
	public float fireRate = 1; // скорострельность


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
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
		else
		{
			curTimeout = 100;
		}
	}

	void Fire()
	{
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