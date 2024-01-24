using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BossAttack : MonoBehaviour
{

    Animator animator;
    int AttackHash;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayer;
    public int attackDamage = 5;


    public Transform target; // target you want to damage

    public float detectionRange = 5f;  // The range within which you want to detect the target

    private float timer = 0f;
    private float activationInterval = 4f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        AttackHash = Animator.StringToHash("Attack");
        
    }


    // Update is called once per frame
    void Update()
    {

        // Update the timer every frame
        timer += Time.deltaTime;

        // Check if the timer has reached the activation interval
        if (timer >= activationInterval)
        {
            // Call  method 
            attack();

            // Reset the timer
            timer = 0f;
        }


    }


    void attack()
    {
        // Check the distance between this object and the target
        float distance = Vector3.Distance(transform.position, target.position);



        //if player is in range
        bool isAttack = animator.GetBool("Attack");
        if (!isAttack && (distance <= detectionRange))
        {
                //attack animation
                animator.SetBool(AttackHash, true);
                // do damage
                Debug.Log("Target is in range!");
                Damage();

                StartCoroutine(DeactivateScriptForSeconds(4f));
        }
        //if Player is out range
        if (isAttack && (distance > detectionRange))
        {
            animator.SetBool(AttackHash, false);
        }
    }

    IEnumerator DeactivateScriptForSeconds(float seconds)
    {
        // Your script logic before deactivation

        // Deactivate the script
        GetComponent<Boss>().enabled = false;

        // Wait for the specified time
        yield return new WaitForSeconds(seconds);

        // Reactivate the script
        GetComponent<Boss>().enabled = true;

        // Your script logic after reactivation
    }

    void Damage()
    {
        //Generates shpere that can detect when enemy is in range 
        Collider[] hitEnemies =
        Physics.OverlapSphere(attackpoint.position, attackRange, PlayerLayer);

        //damage Them
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<FirstPersonMovement>().TakeDamage(attackDamage);
            
        }
        
        
    }
}
