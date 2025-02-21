using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WitchTime : MonoBehaviour
{
    public AudioClip parrySound;
    private float currTime = -1f;                      // Always starts below 0 so it never starts in slo.Mo
    private float audioLength = 5.05f;                 // Amount of time the audio lasts

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))       // If right click pressed
        {
            currTime = audioLength;
            AudioManager.instance.PlayAudio(parrySound, "witchTime");   // Play slow motion sound
        }
        if (currTime > 0)
        {
            currTime -= Time.unscaledDeltaTime;     // If currTime is more than 0, reduce currTime at a steady rate, unaffected by Time.timeScale
            Time.timeScale = 0.25f;                 // Make game go 1/4 of normal velocity
        }
        else
        {
            Time.timeScale = 1;                     // If currTime not bigger than 0, return to normal time
        }
    }
}






































    
    
    
    

                            // Im sorry no corroutine but they hard :( and this easy, simple, efficient solution :D please at least some points :3