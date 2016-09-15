﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerControl : MonoBehaviour {
    float SpeedperTick = 0;
    float HighestSPT = 0;
    float BeforePos = 0;
    bool WalkRight = true;
    public Sprite WalkLeftS;
    public Sprite WalkRightS;
    public Sprite Still;
    bool Dead = false;
    Text ScoreText;
    public GameObject Text;
    string ScorePath;
    string HighScorePath;
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;
    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

	// Use this for initialization
	void Start () {
        if (Application.platform == RuntimePlatform.Android)
        {
            ScorePath = Application.persistentDataPath + @"Score.txt";
            HighScorePath = Application.persistentDataPath + @"HighScore.txt";
        }
        else
        {
            ScorePath = Directory.GetCurrentDirectory() + @"\Score.txt";
            HighScorePath = Directory.GetCurrentDirectory() + @"\HighScore.txt";
        }
        ScoreText = Text.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score: " + Convert.ToInt16(Math.Round(transform.position.y)).ToString();
        if (Dead == false)
        {
            if (SpeedperTick > 0.001f)
            {
                SpeedperTick = SpeedperTick - 0.0050f;
            }
            else SpeedperTick = 0;

            transform.position = new Vector3(transform.position.x, transform.position.y + SpeedperTick, 0);

            if (Input.GetKeyDown("w"))
            {
                if (WalkRight == true)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = WalkLeftS;
                    WalkRight = false;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = WalkRightS;
                    WalkRight = true;
                }

                transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
            }

            if (Input.GetKeyDown("a"))
            {
                if (transform.position.x == 0 || transform.position.x == 12.5f)
                    transform.position = new Vector3(transform.position.x - 12.5f, transform.position.y, 0);
            }

            if (Input.GetKeyDown("d"))
            {
                if (transform.position.x == 0 || transform.position.x == -12.5f)
                    transform.position = new Vector3(transform.position.x + 12.5f, transform.position.y, 0);
            }

            SpeedperTick = transform.position.y - BeforePos;

            BeforePos = transform.position.y;

            if (SpeedperTick > HighestSPT)
            {
                HighestSPT = SpeedperTick;
            }
        }


        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // MOVE RIGHT
                                    Right();
                                }
                                else
                                {
                                    // MOVE LEFT
                                    Left();
                                }
                            }

                        }

                        break;
                }
            }
        }

	}

    void OnCollisionEnter2D()
    {
        SpeedperTick = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        Dead = true;
        File.WriteAllText(ScorePath, Convert.ToInt32(Math.Round(transform.position.y)).ToString());
        if (Convert.ToInt32(File.ReadAllText(HighScorePath)) < Convert.ToInt32(File.ReadAllText(ScorePath)) || new FileInfo(HighScorePath).Length == 0)
        {
            File.WriteAllText(HighScorePath, File.ReadAllText(ScorePath));
        }
    }

    void DeadText ()
    {

    }

    void OnMouseDown()
    {
        Forward();
    }

    public void Forward()
    {
        if (WalkRight == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = WalkLeftS;
            WalkRight = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = WalkRightS;
            WalkRight = true;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
    }

    public void Left()
    {
        if (transform.position.x == 0 || transform.position.x == 12.5f)
            transform.position = new Vector3(transform.position.x - 12.5f, transform.position.y, 0);
    }

    public void Right()
    {
        if (transform.position.x == 0 || transform.position.x == -12.5f)
            transform.position = new Vector3(transform.position.x + 12.5f, transform.position.y, 0);
    }
}
