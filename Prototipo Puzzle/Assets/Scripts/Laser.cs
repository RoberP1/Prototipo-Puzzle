using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    LineRenderer lr;
    RaycastHit hit;
    
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);

 

        if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.collider)
        {
            lr.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("Player"))
            {

                SceneManager.LoadScene("Example_01", LoadSceneMode.Single);
            }

        }
        else lr.SetPosition(1, transform.forward * 5000);
    }
}
