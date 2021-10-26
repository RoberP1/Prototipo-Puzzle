using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    Rigidbody plataforma;

    public Transform parada1;
    public Transform parada2;
    private float vel;
    public float realVel;
    void Start()
    {
        plataforma = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        plataforma.AddForce(Vector3.forward * vel * realVel * Time.deltaTime, ForceMode.Acceleration);
        float dist1 = Vector3.Distance(transform.position, parada1.position);
        float dist2 = Vector3.Distance(transform.position, parada2.position);
        if (Mathf.Abs(dist1) < 0.1f)
        {
            StartCoroutine(Esperar(3,1));
        }

        if (Mathf.Abs(dist2) < 0.1f)
        {
            StartCoroutine(Esperar(3,-1));
        }
    }
    IEnumerator Esperar(float delay, float direccion)
    {
        vel = 0;
        plataforma.AddForce(Vector3.forward * 0, ForceMode.VelocityChange);
        yield return new WaitForSeconds(delay);
        vel = direccion;
    }
}

