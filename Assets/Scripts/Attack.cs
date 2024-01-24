using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Attack : MonoBehaviour
{

    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    
  

    public AudioSource wooosh, EnemyHit;


    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetMouseButtonDown(0))
            {

                Swing();
                
            }
        
        
    }
    void Swing()
    {
        //Generates shpere that can detect when enemy is in range 
        Collider[] hitEnemies = 
        Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayers);

        //damage Them
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            EnemyHit.Play();
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

}
