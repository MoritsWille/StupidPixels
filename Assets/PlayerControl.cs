using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerControl : MonoBehaviour {
    //Sprites
    bool WalkRight = true;
    Sprite WalkLeftS;
    Sprite WalkRightS;
    Sprite Still;
    public Sprite aWalkLeftS;
    public Sprite aWalkRightS;
    public Sprite aStill;
    public Sprite bWalkLeftS;
    public Sprite bWalkRightS;
    public Sprite bStill;
    public Sprite cWalkLeftS;
    public Sprite cWalkRightS;
    public Sprite cStill;
    public Sprite dWalkLeftS;
    public Sprite dWalkRightS;
    public Sprite dStill;
    //game functions
    int I = 0;
    bool Dead = false;
    Text ScoreText;
    public GameObject Text;
    //files
    string ScorePath;
    string HighScorePath;
    string CPPath;
    //touch
    Vector2 WorldTouch = new Vector2(0,0);
    bool touchReady;

    // Use this for initialization
    void Start () {

        if (Application.platform == RuntimePlatform.Android)
        {
            ScorePath = Application.persistentDataPath + @"/Score.txt";
            HighScorePath = Application.persistentDataPath + @"/HighScore.txt";
            CPPath = Application.persistentDataPath + @"/CurrentPlayer.txt";
        }
        else
        {
            ScorePath = Directory.GetCurrentDirectory() + @"\Score.txt";
            HighScorePath = Directory.GetCurrentDirectory() + @"\HighScore.txt";
            CPPath = Directory.GetCurrentDirectory() + @"\CurrentPlayer.txt";
        }

        if(File.ReadAllText(HighScorePath) == "")
        {
            File.WriteAllText(HighScorePath, "0");
        }

        switch (File.ReadAllText(CPPath))
        {
            case "":
                File.WriteAllText(CPPath, "a");
                WalkLeftS = aWalkLeftS;
                WalkRightS = aWalkRightS;
                Still = aStill;
                break;
            case "a":
                WalkLeftS = aWalkLeftS;
                WalkRightS = aWalkRightS;
                Still = aStill;
                break;
            case "b":
                WalkLeftS = bWalkLeftS;
                WalkRightS = bWalkRightS;
                Still = bStill;
                break;
            case "c":
                WalkLeftS = cWalkLeftS;
                WalkRightS = cWalkRightS;
                Still = cStill;
                break;
            case "d":
                WalkLeftS = dWalkLeftS;
                WalkRightS = dWalkRightS;
                Still = dStill;
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Still;
        ScoreText = Text.GetComponent<Text>();
        gameObject.GetComponent<SpriteRenderer>().sprite = WalkRightS;
    }
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = Convert.ToString(Math.Round(transform.position.y));
        if (!Dead)
        {

            if (Input.touchCount == 1 && touchReady)
            {
                Touch touch = Input.GetTouch(0);
                WorldTouch = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Ended)
                {
                    touchReady = false;
                }
            }

            if (WorldTouch.x < 21 && WorldTouch.x > -21)
            {
                transform.position = new Vector3(WorldTouch.x, WorldTouch.y, 0);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, WorldTouch.y, 0);
            }
            

            if (I == 100)
            {
                if (WalkRight)
                {
                    WalkRight = false;
                    gameObject.GetComponent<SpriteRenderer>().sprite = WalkLeftS;
                }
                else
                {
                    WalkRight = true;
                    gameObject.GetComponent<SpriteRenderer>().sprite = WalkRightS;
                }
                I = 0;
            }
            else
            {
                I++;
            }

        }
	}

    void OnCollisionEnter2D()
    {
        Dead = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        File.WriteAllText(ScorePath, Convert.ToInt32(Math.Round(transform.position.y)).ToString());
        if (Convert.ToInt32(File.ReadAllText(HighScorePath)) < Convert.ToInt32(File.ReadAllText(ScorePath)) || new FileInfo(HighScorePath).Length == 0)
        {
            File.WriteAllText(HighScorePath, File.ReadAllText(ScorePath));
        }
    }
    
    void OnMouseDown()
    {
        touchReady = true;
    }
}
