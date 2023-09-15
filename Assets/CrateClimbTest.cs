using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateClimbTest : MonoBehaviour
{
    public SpriteRenderer sign;
    public Collider2D playerCollider;
    public Transform playerMove;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D enteredCollider) 
    {
        if(playerCollider == enteredCollider)
        {
            sign.enabled = !sign.enabled; 
        }

    }
    void OnTriggerExit2D(Collider2D enteredCollider) 
    {
        if(playerCollider == enteredCollider)
        {
            sign.enabled = !sign.enabled;   
        }
    }
}
