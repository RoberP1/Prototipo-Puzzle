using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    
    public GameObject PuertaI;
    public GameObject PuertaD;

    public GameObject Button;

    public Material Rojo;
    public Material Verde;
    
    //public Animator AnimI;
    //public Animator AnimD;

    void Start()
    {
        //AnimI = GetComponent<Animator>();
        //AnimD = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recogible"))
        {
            //AnimI.Play("AbrirI");
            // AnimI.Play("AbrirD");

            PuertaD.gameObject.SetActive(false);
            PuertaI.gameObject.SetActive(false);
            Button.GetComponent<MeshRenderer>().material = Verde;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Recogible"))
        {
            //AnimI.Play("AbrirI");
            // AnimI.Play("AbrirD");

            PuertaD.gameObject.SetActive(true);
            PuertaI.gameObject.SetActive(true);
            Button.GetComponent<MeshRenderer>().material = Rojo;
        }
    }
}
