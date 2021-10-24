using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chair : MonoBehaviour
{
    Transform player;
    [SerializeField] Transform cameraPos;
    [SerializeField] Transform cameraPosEnd;

    [SerializeField] UnityEvent OnSit;
    [SerializeField] UnityEvent OnScare;
    [SerializeField] public UnityEvent OnScareEnd;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    bool displayed = false;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 5)
        {
            if (!displayed)
            { 
                GameManager.Instance.AddToMessageQueue("Press F to sit down", 2.0f);
                displayed = true;
            }
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Sit Down");
                Sit();
                StartCoroutine(Scare());
            }
        }
    }

    void Sit()
    {
        Transform cam = Camera.main.transform;
        player.position = cam.position;
        cam.position = cameraPos.position;
        cam.rotation = cameraPos.rotation;
        cam.localScale = cameraPos.localScale;

        Destroy(FindObjectOfType<Movement>());
        Destroy(FindObjectOfType<Look>());
        StartCoroutine(LookDown());
        OnSit.Invoke();
    }

    IEnumerator Scare()
    {
        yield return new WaitForSeconds(4.20f);
        OnScare.Invoke();
        FindObjectOfType<Knife>().Trigger();

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
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator LookDown()
    {
        Transform cam = Camera.main.transform;

        for (float i = 0; i <= 1.0f; i += 0.01f * Time.deltaTime)
        {
            cam.rotation = Quaternion.Slerp(cam.rotation, cameraPosEnd.rotation, i);
            yield return null;
        }

        SceneManager.LoadScene("MainMenu");
    }
}
