using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerStay2D(Collider2D checkPlayer) 
    {
        if(Input.GetButton("Use"))
        {
            Movement player = checkPlayer.GetComponent<Movement>();
            if(player != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
