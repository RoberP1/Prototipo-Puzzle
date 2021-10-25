using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private bool MouseVisible;

    Rigidbody rb = new Rigidbody(); //jugador

    public float vel = 1; //velocidad movimiento

    public float sensivilidad = 1; //sensivilidad del mouse

    [SerializeField] private Camera FPSCamera; //cabeza
    
    //imputs
    private float horizontalInput;
    private float verticalInput;
    private float x;
    private float y;
    private float xRotacion;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MouseVisible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    { 
        //obtener 
        //imput movimiento personaje
        horizontalInput = Input.GetAxis("Horizontal")  ;
        verticalInput = Input.GetAxis("Vertical")  ;

        //movimiento personaje
        rb.AddRelativeForce(new Vector3(horizontalInput, 0, verticalInput).normalized * vel * Time.deltaTime * 500f);

        //imputs movimiento camara
        x = Input.GetAxis("Mouse X") * sensivilidad;
        y = Input.GetAxis("Mouse Y") * sensivilidad;
        xRotacion -= y;
        
        xRotacion = Mathf.Clamp(xRotacion, -90f, 60f);  //limitador de movimiento de camara

        //movimiento camara
        FPSCamera.transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);
        rb.transform.Rotate(0, x, 0);


        if (Input.GetKeyDown("escape"))
        {
            if (MouseVisible)
            {
                Cursor.lockState = CursorLockMode.None;
                MouseVisible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                MouseVisible = true;
            }
        }
    }

}
