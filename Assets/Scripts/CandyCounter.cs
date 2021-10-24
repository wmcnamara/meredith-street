using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CandyCounter : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPickupCandy;
    [SerializeField] private UnityEvent OnCompleteCandyGoal;

    private TextMeshProUGUI candyText;
                      
    private const int requiredCandy = 10;
    private int currentCandy = requiredCandy;


    private static CandyCounter instance = null;

    public static CandyCounter Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CandyCounter>();

                //If the manager doesnt already exist, spawn it
                if (instance == null)
                {
                    GameObject obj = new GameObject("Candy Counter");
                    CandyCounter candy = obj.AddComponent<CandyCounter>();
                    instance = candy;

                    return instance;
                }

                return instance;
            }

            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddToMessageQueue("Collect 10 pieces of candy", 5.0f);

        currentCandy = 0;

        candyText = GameObject.FindGameObjectWithTag("CandyCounterText").GetComponent<TextMeshProUGUI>();
        candyText.text = CreateCandyText(currentCandy, requiredCandy);
    }

    public void CollectCandy()
    {
        currentCandy++;
        OnPickupCandy.Invoke();


        if (currentCandy >= requiredCandy)
        {
            OnCompleteCandyGoal.Invoke();
            SceneManager.LoadScene("Transition");
        }

        candyText.text = CreateCandyText(currentCandy, requiredCandy);

        Debug.Log("Candy Collected");
        Debug.Log($"Candy Left: {requiredCandy - currentCandy}");
    }
    public IEnumerator FadeScreenToBlack()
    {
        Image panel = GameObject.FindGameObjectWithTag("BackPanel").GetComponent<Image>();

        for (float i = 0; i <= 1.0f; i += 1.0f * Time.deltaTime)
        {
            Color newCol = panel.color;
            newCol.a = i;

            panel.color = newCol;
            yield return null;
        }
    }

    private string CreateCandyText(int currentCandy, int maxCandy)
    {
        return $"Candy: {currentCandy}/{maxCandy}";
    }
}
