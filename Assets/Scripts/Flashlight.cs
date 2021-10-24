using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Flashlight : MonoBehaviour
{
    [SerializeField] UnityEvent OnChangeLightState;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Light l = GetComponent<Light>();
            l.enabled = !l.enabled;

            OnChangeLightState.Invoke();

            GetComponent<AudioSource>().Play(); //play the click sound effect
        }
    }
}
