using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimer : MonoBehaviour
{

    public float timerDuration;
    public static bool timerOn = false;
    public Text timerText;
    public Text bossText;
    public GameObject bossObj;

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
            else
            {
                StartCoroutine(DestroyText());
                timerDuration = 0;
                timerOn = false;
            }
        }
        else
        {
            bossText.rectTransform.position = Vector2.Lerp(bossText.rectTransform.position, bossText.rectTransform.position - new Vector3(0f,5f,0f), Time.deltaTime * 50);
        }
        
    }

    IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(5);
        Destroy(bossText);
        Instantiate(bossObj, new Vector2(0f, 7.5f), Quaternion.identity);
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
