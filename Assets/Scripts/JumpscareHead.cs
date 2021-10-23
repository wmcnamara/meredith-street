using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpscareHead : MonoBehaviour
{
    [SerializeField] private float threshold = 0.2f;
    [SerializeField] private UnityEvent OnJumpscare;

    [SerializeField] private float clockwiseOffset = 0.0f;
    [SerializeField] private float counterClockwiseOffset = 0.0f;

    [SerializeField] private Vector3 endPos = Vector3.zero;

    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.SetActive(false);
    }


    void Update()
    {
        //if (player.transform.eulerAngles.y < threshold + clockwiseOffset || player.transform.eulerAngles.y > 360 - threshold + counterClockwiseOffset) 
        float d = Vector3.Dot(player.transform.forward, transform.forward);

        if (d < -1.0f + threshold || (d > -1.0f + threshold && d < -1.0f + threshold)) {
            TriggerJumpScare();
        }
    }

    void TriggerJumpScare()
    {
        StartCoroutine(Move());
        OnJumpscare.Invoke();
        Destroy(gameObject, 1.5f);
    }

    private IEnumerator Move()
    {
        for (float i = 0; i <= 1; i += 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, endPos, i * Time.deltaTime);
            yield return null;
        }
    }
}
