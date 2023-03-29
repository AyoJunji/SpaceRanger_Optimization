using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Parallax : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);

        if(transform.position.y < -11)
        {
            transform.position = new Vector3(transform.position.x, 11);
        }
    }
}