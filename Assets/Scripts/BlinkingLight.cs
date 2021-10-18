using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    [SerializeField] private float minBlinkDelay = 1.0f;
    [SerializeField] private float maxBlinkDelay = 2.0f;

    float timeToNextBlink = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeToNextBlink = Random.Range(minBlinkDelay, maxBlinkDelay);
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextBlink -= Time.deltaTime;

        if (timeToNextBlink <= 0.0f)
        {
            StartCoroutine(Blink());
            timeToNextBlink = Random.Range(minBlinkDelay, maxBlinkDelay);
        }
    }


    private IEnumerator Blink()
    {
        GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(Random.Range(0.23f, 0.4f));
        GetComponent<Light>().enabled = true;
    }
}
