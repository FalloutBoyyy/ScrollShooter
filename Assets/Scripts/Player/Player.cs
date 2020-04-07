using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{ 
    float time = 0f;
    public Vector2 speed = new Vector2(20, 20);
    private Vector2 movement;
    Rigidbody2D body2d;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical"); 
        movement = new Vector2(speed.x * inputX * Time.deltaTime, speed.y * inputY * Time.deltaTime);

        body2d.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    void FixedUpdate()
    { 
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}