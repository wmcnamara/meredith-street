using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Porch : MonoBehaviour
{
    private Transform player = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.AddToMessageQueue("Press F to collect candy", 2.0f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if(Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.E))
        {
            CandyCounter.Instance.CollectCandy();
        }
    }
}
