using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public Animator animator;
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    public HealthBarScript healthBar;
    public GameObject healthBarGO;

    public void Start()
    {
        healthBar.SetMaxHealth(health);
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("isDeath", true);
        Destroy(rb);
        Destroy(bc);  
        Destroy(healthBarGO);
    }
}
