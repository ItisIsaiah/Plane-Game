using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFLYING : MonoBehaviour
{

    //
    public Rigidbody rb;
    //speeds
    public float forwardSpeed=25f;
    public float strafeSpeed=7f;
    public float hoverSpeed=5f;

    //Activators
    private float activeForwardSpeed;
    private float activeStrafeSpeed;
    private float activeHoverSpeed;


    //ACCERATION
    float forwardAcl=2.5f;
    float sideAcl = 2f;
    float hoverAcl = 2f;

    //Camera
    public float lookSenitivity = 90f;
    private Vector2 lookInput;
    private Vector2 screenCenter;
    private Vector2 mouseDistance;

    //roll
    private float rollInput;
    public float rollSpeed = 90f;
    public float rollAcl;


    Vector3 ourRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;



        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        ourRotation = GetComponent<Vector3>();

    }
     void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x)/screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput=0;

        transform.Rotate(mouseDistance.y * lookSenitivity*Time.deltaTime, mouseDistance.x * lookSenitivity*Time.deltaTime, 0f,Space.Self);

        Quaternion quaternion = Quaternion.Euler(ourRotation.x, ourRotation.y, ourRotation.z);
        //quaternion.rotation.z = 0f;
       // transform.rotation += new Vector3 (0,0,-transform.rotation.z).;
        



      activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Horizontal")*forwardSpeed, forwardAcl * Time.deltaTime);
      activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Vertical")*strafeSpeed, sideAcl*Time.deltaTime);
      activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcl * Time.deltaTime);

      transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
      transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
      transform.position += transform.right* activeStrafeSpeed*Time.deltaTime;
    }
}
