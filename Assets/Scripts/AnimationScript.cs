using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
     Animator animator;
    int isWalkingHash;

    void Start()
    {
       
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    void Update()
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