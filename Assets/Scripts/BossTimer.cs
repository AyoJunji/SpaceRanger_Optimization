using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimer : MonoBehaviour
{

    public float timerDuration;
    public bool timerOn = false;
    public Text timerText;
    public Text bossText;

    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            if(timerDuration > 0)
            {
                timerDuration -= Time.deltaTime;
                UpdateTimer(timerDuration);
            }
        }
        else
        {
            bossText.transform.position = Vector3.Lerp(bossText.transform.position, bossText.transform.position - new Vector3(0,100,0), Time.deltaTime * 30);
            timerDuration = 0;
            timerOn = false;
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
