using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    
    public float speed;
    public float turnSpeed;
    

    /*
    CharacterController characterController;
    */
    void Start()
    {
        /*
        characterController = GetComponent<CharacterController>();
        */
    }



    // Update is called once per frame
    void Update()
    {
        MovePlayerRelativeToCamera();
        /*
        characterController.Move(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime);
        */


        /*
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3 (horizontalInput, 0, verticalInput);

        //normalize movementDirection so it has a magnitude of one
        movementDirection.Normalize ();

        //change the posistion of the charcter based on the movement direction
        //Delta time makes sure the movement is the same regardless of frame rate
        transform.Translate (movementDirection * speed * Time.deltaTime, Space.World);


        //TODO make charcter  stay on the direction its facing when pressing W
        //change character to face towards the direction its moving in
        if (movementDirection != Vector3.zero) 
        {
            //Quaternions are for storing rotation variables
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = 
            Quaternion.RotateTowards
            (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } 
        */
    }

    void MovePlayerRelativeToCamera()
    {
        // Get Player Input
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        // Get Camera Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        //Create direction-relative-input vectors
        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeHorizantalInput = playerHorizontalInput * right;

        //Create and apply camera relative movement
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput +
            rightRelativeHorizantalInput;
        this.transform.Translate(cameraRelativeMovement * speed, Space.World);
    }
}
