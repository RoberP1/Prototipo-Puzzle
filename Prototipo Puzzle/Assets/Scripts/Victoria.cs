using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victoria : MonoBehaviour
{
    public GameObject Vic;
   

    public GameObject Button;

    public Material Verde;


    void Start()
    {
        Vic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recogible"))
        {
            Vic.gameObject.SetActive(true);
            Button.GetComponent<MeshRenderer>().material = Verde;
        }
    }
  
}
