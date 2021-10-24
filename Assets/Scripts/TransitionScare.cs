using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScare : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadDungeon());
        GameManager.Instance.AddToMessageQueue("Hi.", 2.0f);
        GameManager.Instance.AddToMessageQueue("Trick or Treat!", 3.0f);
        GameManager.Instance.AddToMessageQueue("....", 2.5f);
        GameManager.Instance.AddToMessageQueue("You know, I have quite a bit of candy in my house. Just come in.", 3.5f);
        GameManager.Instance.AddToMessageQueue("I dont think I should....", 3.0f);
        GameManager.Instance.AddToMessageQueue("Just come in. Cmon.", 2.5f);
        GameManager.Instance.AddToMessageQueue("", 3.5f);
    }

    IEnumerator LoadDungeon()
    {
        yield return new WaitForSeconds(18f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Dungeon");
    }
}
