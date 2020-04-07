using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public Rigidbody2D space;
    public Transform spnPos; 
    public float speed = -10f;
    bool trig = true;
    float followY = 0f;
    Rigidbody2D clone;
    void Start()
    {
        clone = Instantiate(space, spnPos.position, Quaternion.identity) as Rigidbody2D;
        clone.transform.position = new Vector2(clone.position.x, clone.position.y);

    }
    void Update()
    {
        space.velocity = transform.TransformDirection(spnPos.up * speed);
        space.transform.up = spnPos.up;
        clone.velocity = transform.TransformDirection(spnPos.up * speed);
        clone.transform.up = spnPos.up;
        if (space.position.y <= -15)
        {
            space.transform.position = new Vector3(0, 15f, 0);
            
        }
        if (clone.position.y <= -15)
        {
            clone.transform.position = new Vector3(0, 15f, 0);

        }

    }


}