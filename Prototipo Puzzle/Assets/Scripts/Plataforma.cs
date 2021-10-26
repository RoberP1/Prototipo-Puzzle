using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    Rigidbody plataforma;

    public Transform[] paradas;
    
    public float vel = 200;
    public bool IrPrimera;
    public bool PuedeMoverse;
    public Vector3 direccion;

    void Start()
    {
        vel = 10;
        IrPrimera = false;
        PuedeMoverse = true;
        
        plataforma = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = Gonext(paradas, plataforma, IrPrimera);

        Debug.Log(transform.position == paradas[0].position);

        plataforma.AddForce(direccion * vel, ForceMode.Force);
        if (EstaEnParada(transform.position, paradas) )
        {
            IrPrimera = (IrPrimera ? false : true);
            
            StartCoroutine(Esperar(3f));
        }
        
        
    }

    private Vector3 Gonext(Transform[] paradas, Rigidbody plataforma, bool IrPrimera)
    {
        Vector3 direccion = paradas[0].position - paradas[1].position;
        if (IrPrimera)
        {

            return direccion.normalized;
        } else
        {
            
            return -direccion.normalized;
        }
    }

    private bool EstaEnParada(Vector3 posicion, Transform[] paradas)
    {
        bool Stop = false;
        foreach (Transform parada in paradas)
        {
            if (posicion == parada.position)
            {
                Stop = true;
            }
        }

        //Debug.Log("esta en parada" + Stop);
        return Stop;
    }

    IEnumerator Esperar(float delay)
    {
        plataforma.AddForce(Vector3.zero, ForceMode.VelocityChange);
        
        yield return new WaitForSeconds(delay);
        vel = 10;
    }
}
