using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    public NavMeshAgent agent;
    public float speed;


    public Transform target; // The target you want to follow

   

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();

    }
    
    void Update()
    {
        agent.destination = target.position;
       
    }
     
 

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) 
        {
            Die();
        }
        animator.SetTrigger("hurt");
    }

    void Die() 
    {
        Debug.Log("Enemy died!");

        animator.SetBool("isdead", true);

        // disable enemy
        this.enabled = false;
        GetComponent<Collider>().enabled = false;

    }
}
