using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet2D : MonoBehaviour
{

	void Start()
	{
		// уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
		Destroy(gameObject, 20);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!coll.isTrigger) // чтобы пуля не реагировала на триггер
		{
			switch (coll.tag)
			{
				case "Enemy_1":
					// что-то...
					break;
				case "Enemy_2":
					// что-то еще...
					break;
			}

			Destroy(gameObject);
		}
	}
}