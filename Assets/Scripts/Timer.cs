using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;


    void Start()
    {
        startTime = Time.time;
        DontDestroyOnLoad(timerText);

                if (SceneManager.GetActiveScene().name == "GameOver")
                {
                    Debug.Log("Timer should destroy (GO)");
                    Destroy(gameObject);
                }

                if (SceneManager.GetActiveScene().name == "WinScene")
                {
                    Finish();
                }

                if (SceneManager.GetActiveScene().name == "MainMenu")
                {
                    Debug.Log("Timer should destroy (MM)");
                    Destroy(gameObject);
                }

    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "WinScene")
        {
            Finish();
        }

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Debug.Log("Timer should destroy (MM)");
            Destroy(gameObject);
        }



        if (finished)
            return;

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;





    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;

    }



}
