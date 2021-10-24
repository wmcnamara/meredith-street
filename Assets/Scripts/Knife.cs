using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] Transform endPos;

    private void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }
    public void Trigger()
    {
        Debug.Log("Triggered Knife");
        GetComponent<Renderer>().enabled = true;
        StartCoroutine(MoveIn());
        StartCoroutine(FindObjectOfType<Chair>().FadeScreenToBlack());
    }

    private IEnumerator MoveIn()
    {
        FindObjectOfType<Chair>().OnScareEnd.Invoke();

        for (float i = 0; i < 1.0f; i += 0.1f * Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, endPos.position, i);
            yield return null;
        }
    }
}
