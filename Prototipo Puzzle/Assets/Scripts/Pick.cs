using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    public Transform Dest;
   
    private void Start()
    {
        Dest = GameObject.Find("PickUp").transform;
        
    }
    public void Recoger()
    {
       
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        

        this.transform.position = Dest.position;
        this.transform.parent = GameObject.Find("PickUp").transform;
        

    }
    public void Soltar()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        this.transform.parent = null;
        
        
    }
}
