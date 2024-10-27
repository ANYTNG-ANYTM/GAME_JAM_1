using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : MonoBehaviour
{
    public Transform attackpoint;
    public LayerMask enemyLayers;
    public float attackrange = 0.5f;
    public int attackDamage = 40;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        // Check for player input to attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemyLayers);

        // Damage enemies
        foreach (Collider2D hit in hitEnemies)
        {
            Debug.Log(hit.name);
            // Access the Enemy component from the collider's game object
            Enemy enemyAttack = hit.GetComponent<Enemy>();

            if (enemyAttack != null) // Check if the Enemy component is found
            {
                enemyAttack.TakeDamage(20);
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        // Draw attack range Gizmo
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }

    //   private void Die()
    //     {
    //         // Handle enemy death logic here
    //         Destroy(gameObject); // Example: Destroy the enemy game object when it dies
    //     } 

    void Die()
    {
        Debug.Log("enemy died");
        // die animation 
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;


    }

}
 
