using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Plays foosteps from a pool of footstep sounds at a specified interval.
[RequireComponent(typeof(AudioSource))]
public class Footstep : MonoBehaviour
{
    [SerializeField] float stepInterval = .75f; //time in seconds between each footsep sound
    [SerializeField] LayerMask stepMask = 0;
    [SerializeField] Transform footPos = null;

    AudioSource src;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    float timeUntilNextStep = 0;
    void Update()
    {     
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            //Countdown the delay
            timeUntilNextStep -= Time.deltaTime;

            if (timeUntilNextStep <= 0)
            {
               //Raycast downwards
               if (Physics.Raycast(footPos.position, -footPos.up, out RaycastHit hit, 1.0f, stepMask))
               {
                   //Are we stepping on a foostep surface?
                   if (hit.transform.TryGetComponent(out FootstepSurface surface))
                   {
                       //Get the clips
                       List<AudioClip> footstepClips = surface.GetFootsteps(); 

                       //Play a random sound from the clips array
                       int index = Random.Range(0, footstepClips.Count);
                       src.PlayOneShot(footstepClips[index]);
                   }
               }

                timeUntilNextStep = stepInterval;
            }
        }    
    }
}
