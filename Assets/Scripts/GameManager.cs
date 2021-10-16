using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public struct ScreenMessage
    {
        public ScreenMessage(string message, float timeInSeconds) 
        {
            this.message = message;
            this.timeInSeconds = timeInSeconds;
        }

        public string message;
        public float timeInSeconds;
    }

    private TextMeshProUGUI globalText = null;
    private Queue<ScreenMessage> messageQueue = new Queue<ScreenMessage>();

    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                //If the manager doesnt already exist, spawn it
                if (instance == null)
                {
                    GameObject obj = new GameObject("Candy Counter");
                    GameManager candy = obj.AddComponent<GameManager>();
                    instance = candy;

                    return instance;
                }

                return instance;
            }

            return instance;
        }
    }

    void Start()
    {
        globalText = GameObject.FindGameObjectWithTag("GlobalText").GetComponent<TextMeshProUGUI>();

    }

    bool previousMessageCompleted = true;

    void Update()
    {
        if (messageQueue.Count > 0 && previousMessageCompleted)
        {
            StartCoroutine(DisplayMessageInQueue(globalText, messageQueue));
        }
    }

    //Waits a specified amount of time, then clears textObject and dequeues an object
    private IEnumerator DisplayMessageInQueue(TextMeshProUGUI textObject, Queue<ScreenMessage> queue)
    {
        ScreenMessage msg = queue.Peek();
        textObject.text = msg.message;
        previousMessageCompleted = false;

        yield return new WaitForSeconds(msg.timeInSeconds);


        previousMessageCompleted = true;
        textObject.text = "";
        queue.Dequeue();
    }



    public void AddToMessageQueue(ScreenMessage message)
    {
        messageQueue.Enqueue(message);
    }

    public void AddToMessageQueue(string message, float time)
    {
        messageQueue.Enqueue(new ScreenMessage(message, time));
    }

    public void ClearMessageQueue()
    {
        StopAllCoroutines();
        globalText.text = "";
        previousMessageCompleted = true;
        messageQueue.Clear();
    }
}
