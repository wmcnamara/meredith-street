using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpscareHead : MonoBehaviour
{
    [SerializeField] private float threshold = 30f;
    [SerializeField] private UnityEvent OnJumpscare;

    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.SetActive(false);
    }


    void Update()
    {
        if (player.transform.eulerAngles.y < threshold || player.transform.eulerAngles.y > 360 - threshold) 
            TriggerJumpScare();
    }

    void TriggerJumpScare()
    {
        OnJumpscare.Invoke();
    }
}
