using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Space : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        //уничтожить объект
        Destroy(gameObject);
    }

}
