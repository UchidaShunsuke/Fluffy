using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rd2d;
    public float jampForce = 300f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rd2d.velocity = Vector3.zero;
            rd2d.AddForce(Vector3.up * jampForce);
        }
    }
}
