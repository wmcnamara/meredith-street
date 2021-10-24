using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Porch : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 5.0f;
    [SerializeField] private UnityEvent OnCollectCandy;

    private Transform player = null;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        displayedMessage = false;
    }

    private bool displayedMessage = false;

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
                GetComponent<AudioSource>().Play();

                return;
            }

            if (!displayedMessage)
            {
                GameManager.Instance.AddToMessageQueue("Press F to collect candy", 3.0f);
                displayedMessage = true;
            }
        }
    }
}
