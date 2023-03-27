using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject titleText, shipSprite;
    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update() 
    {
        titleText.transform.position = new Vector3(transform.position.x, 450 + Mathf.PingPong(Time.time * 10, 20) , transform.position.z);
        shipSprite.transform.position = new Vector3(-5 + Mathf.PingPong(Time.time * 5, 10), -4.5f, transform.position.z);
    }
}
