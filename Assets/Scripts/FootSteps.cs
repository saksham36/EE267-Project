using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{   
    CharacterController characterController;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
     characterController = GetComponent<CharacterController>();   
     audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("IsGrounded: "+ characterController.isGrounded);
        // Debug.Log("Speed: "+ characterController.velocity);
        if(characterController.isGrounded == true &&characterController.velocity.magnitude>= 0.2f && audio.isPlaying == false)
        {   
            // Debug.Log("Play footstep sound");
            audio.volume = Random.Range(0.8f, 1);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
    }
}
