using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth = 200;
    public int CurrentHealth;

    public HealthBar HealthBar;
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(20); 
        }

    }

    public void SetHealth(int health)
    {
        CurrentHealth = health;
        HealthBar.SetHealth(CurrentHealth);
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        FindObjectOfType<AudioManager>().Play("Hit");
        HealthBar.SetHealth(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            FindObjectOfType<GameOver>().end();
        }
    }
}
