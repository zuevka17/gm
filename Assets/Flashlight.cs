using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D l2d;
    public AudioSource flashLightSound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Flash"))
        {
            l2d.enabled = !l2d.enabled;
            flashLightSound.Play();
        }
    }
}
