using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porch : MonoBehaviour
{
    private Transform playerPosition = null;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
