using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
     Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isAttackingHash;
    int isWalkingBackHash;
    int isRunningBackHash;
    int LeftStrafeHash;
    int RightStrafeHash;
    int WalkLeftStrafeHash;
    int WalkRightStafeHash;
    void Start()
    {
       
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isAttackingHash = Animator.StringToHash("isAttacking");
        isWalkingBackHash = Animator.StringToHash("isWalkingBack");
        isRunningBackHash = Animator.StringToHash("isRunningBack");
        LeftStrafeHash = Animator.StringToHash("LeftStrafe");
        RightStrafeHash = Animator.StringToHash("LeftStrafe");
        //WalkLeftStrafeHash =
        //WalkRightStafeHash =
    }

    void Update()
    {
        walk();
        run();
        Attack();
        //walkBack();
        //runBack();
    }

/*
    private void runBack()
    {
        bool PressedShift = Input.GetKey("left shift");
        bool isRunningBack = animator.GetBool("isRunningBack");
        bool isBackPressed = Input.GetKey("s");

        //if player presses S + shift
        if (!isRunningBack && (PressedShift && isBackPressed))
        {
            animator.SetBool(isRunningBackHash, true);
        }
        //if player dosent press S + shift
        if (isRunningBack && (!PressedShift && !isBackPressed))
        {
            animator.SetBool(isRunningBackHash, false);
        }
    }
*/




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
    private void Attack()
    {
        bool isAttacking = animator.GetBool("isAttacking");
        bool AttackPressed = Input.GetMouseButtonDown(0); //Input.GetMouseButtonDown(0)

        //if player presses mouse 1
        if (AttackPressed)
        {
            animator.SetBool(isAttackingHash, true);
        }
        //if player doesent press mouse 1
        if (!AttackPressed)
        {
            animator.SetBool(isAttackingHash, false);
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

        bool isWalkingback = animator.GetBool("isWalkingBack");
        bool isBackPressed = Input.GetKey("s");
        //if player presses s key 
        if (isBackPressed && !isWalkingback)
        {
            animator.SetBool(isWalkingBackHash, true);
        }
        //if player doesent press s key 
        if (isWalkingback && !isBackPressed)
        {
            animator.SetBool(isWalkingBackHash, false);
        }
    }
}
//5:28 How to animate unity charcters