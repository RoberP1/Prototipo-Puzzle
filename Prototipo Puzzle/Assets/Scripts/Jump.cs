using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpHeight = 7f;
    public bool isGrounded;
    public float NumberJumps = 0f;
    public float MaxJumps = 2;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (NumberJumps > MaxJumps - 1)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight,ForceMode.Impulse);
                NumberJumps++;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.name);
        if (other.collider.name.Contains("Floor") || other.collider.name.Contains("Plataforma"))
        {
            
            isGrounded = true;
            NumberJumps = 0;
        }
        
    }

}
