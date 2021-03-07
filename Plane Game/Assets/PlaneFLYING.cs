using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFLYING : MonoBehaviour
{
    

    //speeds
    public float forwardSpeed=25f;
    public float strafeSpeed=7f;
    public float hoverSpeed=5f;

    //Activators
    private float activeForwardSpeed;
    private float activeStrafeSpeed;
    private float activeHoverSpeed;


    // Start is called before the first frame update
    void Start()
    {
    

    }
     void Update()
    {
        activeForwardSpeed = Input.GetAxisRaw("Horizontal")* forwardSpeed;
        activeStrafeSpeed = Input.GetAxisRaw("Vertical")*strafeSpeed;
        activeHoverSpeed = Input.GetAxisRaw("Hover") * hoverSpeed;

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
       transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
      transform.position += transform.right* activeStrafeSpeed*Time.deltaTime;
    }
}
