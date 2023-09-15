using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public Movement player;
    public Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D enteredCollider) 
    {
        if(playerCollider == enteredCollider)
        {
             player.animator.SetBool("isShooting", true);
        }
    }
}
