using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Beginning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddToMessageQueue("You can trick or treat anywhere you want with one exception.", 4.5f);
        GameManager.Instance.AddToMessageQueue("Dont go on Meredith Street.", 4.5f);
        GameManager.Instance.AddToMessageQueue("", 2.5f);
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(4.5f + 4.5f + 3.0f);
        SceneManager.LoadScene("Street");
    }
}
