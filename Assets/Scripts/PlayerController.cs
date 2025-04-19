using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float jampForce = 300f;
    public GameObject title;

    void Start()
    {
        rb2d.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(rb2d.isKinematic == true)
            {
                rb2d.isKinematic = false;
                Destroy(title);
            }
            rb2d.velocity = Vector3.zero;
            rb2d.AddForce(Vector3.up * jampForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
