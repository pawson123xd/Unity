using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovePlayer : MonoBehaviour
{
    public float speed = 2.0f;
    public float force = 10.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            Vector3 velocity = new Vector3(mH, 0, mV);
            velocity = velocity.normalized * 10 * Time.deltaTime;
            // wykonujemy przesunięcie Rigidbody z uwzględnieniem sił fizycznych
            rb.MovePosition(transform.position + velocity);
        }
        else
        {
            // tworzymy wektor prędkości
            Vector3 velocity = new Vector3(mH, 0, mV);
            velocity = velocity.normalized * 10 * Time.deltaTime;
            // wykonujemy przesunięcie Rigidbody z uwzględnieniem sił fizycznych
            rb.MovePosition(transform.position + velocity);
        }
    }
}