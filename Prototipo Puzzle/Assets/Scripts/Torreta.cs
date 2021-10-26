using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{

    Rigidbody torreta;
    public float velRot;
    bool DebeGirar2;
    bool stop;

    
    void Start()
    {
        DebeGirar2 = false;
        stop = true;
        torreta = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!DebeGirar() || DebeGirar2)
        {
            transform.Rotate(0, velRot, 0);
            DebeGirar2 = false;
        }
        else
        {
           
            if (stop)
            {
                
                StartCoroutine(DelayGirar(3));
            }
            
            
        }
        
            
    }

    private bool DebeGirar()
    {
        float Angle0 = Quaternion.Angle(transform.rotation, Quaternion.identity);
        float Angle1 = Quaternion.Angle(transform.rotation, Quaternion.Euler(0,90,0));
        float Angle2 = Quaternion.Angle(transform.rotation, Quaternion.Euler(0,180,0));
        float Angle3 = Quaternion.Angle(transform.rotation, Quaternion.Euler(0,270,0));

        bool sameRotation0 = Mathf.Abs(Angle0) < 1e-3f;
        bool sameRotation1 = Mathf.Abs(Angle1) < 1e-3f;
        bool sameRotation2 = Mathf.Abs(Angle2) < 1e-3f;
        bool sameRotation3 = Mathf.Abs(Angle3) < 1e-3f;


        bool Debogirar = sameRotation0 || sameRotation1 || sameRotation2 || sameRotation3;
        Debug.Log("Angulos iguales" + Debogirar);

        return sameRotation0 || sameRotation1 || sameRotation2 || sameRotation3;
    }

    IEnumerator DelayGirar(int delay)
    {
        stop = false;
        
        
        yield return new WaitForSeconds(delay);
        DebeGirar2 = true;
        stop = true;
        
    }
}
