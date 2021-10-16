using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Porch : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 5.0f;
    [SerializeField] private UnityEvent OnCollectCandy;

    private Transform player = null;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < interactionRadius)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.E))
            {
                CandyCounter.Instance.CollectCandy();

                OnCollectCandy.Invoke();
                GameManager.Instance.ClearMessageQueue();
                Destroy(this);
                return;
            }

            GameManager.Instance.AddToMessageQueue("Press F to collect candy", 0.03f);
        }
    }
}
