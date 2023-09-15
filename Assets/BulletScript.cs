using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;  
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D isEnemy) 
    {
        EnemyScript enemy = isEnemy.GetComponent<EnemyScript>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(isEnemy.tag == "Trigger")
        {
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
