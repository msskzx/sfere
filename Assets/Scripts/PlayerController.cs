using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private int region;
    private int score;
    public Text scoreText;

    void Start()
    {
        speed = 10.0f;
        region = 1;
        score = 0;
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0.0f, 0.0f));
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "RedSfere" && region == 1 || gameObject.tag == "BlueSfere" && region == 2 || gameObject.tag == "GreenSfere" && region == 3)
        {
            Destroy(gameObject);
            score++;
        }
        else
        {
            if (gameObject.tag != "Region")
            {
                GameOver();
            }
        }
        
 
    }

    private void GameOver()
    {
    }
}
