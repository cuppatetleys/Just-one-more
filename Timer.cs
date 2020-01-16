using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer;
    public static bool timeStarted = false;

    private Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        timer = 0f;
        timeStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStarted == true)
        {
            timer += Time.deltaTime;
        }
        DisplayTime();

        if(timer > 180)
        {
            SceneManager.LoadScene("Win");
        }

    }

    public void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        //float fraction = timer * 1000;
        //fraction = fraction % 1000;
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds); ;

        timerText.text = niceTime;
    }
}
