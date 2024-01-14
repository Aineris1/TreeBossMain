using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PrototypeMove : MonoBehaviour
{

    PlayerInput playerInput;
    PlayerInput.MainActions input;

    CharacterController controller;
    Animator animator;
    AudioSource audioSource;

    [Header("Controller")]
    public float moveSpeed = 5;
    public float gravity = -9.8f;
    public float jumpHeight = 1.2f;

    Vector3 _PlayerVelocity;

    bool isGrounded;

    [Header("Camera")]
    public Camera cam;
    public float sensitivity;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
     


    }

    // Update is called once per frame
    void Update()
    {

      
    }

    
}
