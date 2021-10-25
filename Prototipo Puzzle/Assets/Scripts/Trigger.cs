using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PuertaI;
    public GameObject PuertaD;


    public GameObject Button;


    public Material Rojo;
    public Material Verde;
    //public Material MButton;


    public Animator AnimI;
    public Animator AnimD;

    void Start()
    {
        AnimI = GetComponent<Animator>();
        AnimD = GetComponent<Animator>();
        //MButton = Button.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
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
