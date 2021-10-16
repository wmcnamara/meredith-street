using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CandyCounter : MonoBehaviour
{
    [SerializeField] UnityEvent OnPickupCandy;
    [SerializeField] UnityEvent OnCompleteCandyGoal;

    private const int RequiredCandy = 10;
    private int currentCandy = RequiredCandy;


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
        GameManager.AddToMessageQueue("Collect 10 pieces of candy", 5.0f);

        currentCandy = RequiredCandy;
    }
    
    public void CollectCandy()
    {
        currentCandy++;
        OnPickupCandy.Invoke();


        if (currentCandy >= RequiredCandy)
        {
            OnCompleteCandyGoal.Invoke();
        }
    }
}
