using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 3f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //自分が右にいるとき左右でそれぞれ進む
        if(transform.position.x > 0)
        {
            rb2d.velocity = Vector3.left * speed;
        }
        else
        {
            rb2d.velocity = Vector3.right * speed;

        }
    }

    void Update()
    {
        
    }
}
