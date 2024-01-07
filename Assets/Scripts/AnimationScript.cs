using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
     Animator animator;
    int isWalkingHash;
    int isRunningHash;
    void Start()
    {
       
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        walk();
        run();
    }

    private void run()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool PressedShift = Input.GetKey("left shift");
        bool forwardPressed = Input.GetKey("w");

        //if player presses shift + w key 
        if (!isRunning && (forwardPressed && PressedShift))
        {
            animator.SetBool(isRunningHash, true);
        }
        //if player doesent press shift + w key 
        if (isRunning && (!forwardPressed  && !PressedShift))
        {
            animator.SetBool(isRunningHash, false);
        }
    }


    private void walk()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("w");

        //if player presses w key 
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        //if player doesent press w key 
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
//5:28 How to animate unity charcters