using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextWhenClose : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer textToShow;
    public Collider2D playerCollider;
    private bool alreadySaw = false;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D enteredCollider) 
    {
        if((playerCollider == enteredCollider) && alreadySaw == false)
        {
            textToShow.enabled = !textToShow.enabled; 
        }

    }
    void OnTriggerExit2D(Collider2D enteredCollider) 
    {
        if(playerCollider == enteredCollider && alreadySaw == false)
        {
            textToShow.enabled = !textToShow.enabled;
            alreadySaw = true;
        }
    }
}
