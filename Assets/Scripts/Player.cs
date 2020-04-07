using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// Контроллер и поведение игрока ///
public class Player : MonoBehaviour
{ ///
  /// 1 - скорость движения ///
    float time = 0f;
    public Vector2 speed = new Vector2(20, 20);
    // 2 - направление движения 
    private Vector2 movement;
    Rigidbody2D body2d;

    void Awake()
    {

        body2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    { // 3 - извлечь информацию оси
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical"); // 4 - движение в каждом направлении 
        movement = new Vector2(speed.x * inputX * Time.deltaTime, speed.y * inputY * Time.deltaTime);

      

        body2d.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    void FixedUpdate()
    { // 5 - перемещение игрового объекта 


        GetComponent<Rigidbody2D>().velocity = movement;

    }
}