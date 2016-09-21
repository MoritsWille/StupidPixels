using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerControl : MonoBehaviour {
    float SpeedperTick = 0;
    float HighestSPT = 0;
    float BeforePos = 0;
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
    bool Dead = false;
    Text ScoreText;
    public GameObject Text;
    string ScorePath;
    string HighScorePath;
    string CPPath;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    // Use this for initialization
    void Start () {

        if (Application.platform == RuntimePlatform.Android)
        {
            ScorePath = Application.persistentDataPath + @"Score.txt";
            HighScorePath = Application.persistentDataPath + @"HighScore.txt";
            CPPath = Application.persistentDataPath + @"CurrentPlayer.txt";
        }
        else
        {
            ScorePath = Directory.GetCurrentDirectory() + @"\Score.txt";
            HighScorePath = Directory.GetCurrentDirectory() + @"\HighScore.txt";
            CPPath = Directory.GetCurrentDirectory() + @"CurrentPlayer.txt";
        }

        switch (File.ReadAllText(CPPath))
        {
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
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Still;
        ScoreText = Text.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Swipe();
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
        {
            for (int I = 0; I < 5; I++)
            {
                transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y, 0);
                WaitForSeconds wait = new WaitForSeconds(0.5f);
             
            }
        }
    }

    public void Right()
    {
        if (transform.position.x == 0 || transform.position.x == -12.5f)
            transform.position = new Vector3(transform.position.x + 12.5f, transform.position.y, 0);
    }

    public void Swipe()
{
     if(Input.touches.Length > 0)
     {
         Touch t = Input.GetTouch(0);
         if(t.phase == TouchPhase.Began)
         {
              //save began touch 2d point
             firstPressPos = new Vector2(t.position.x,t.position.y);
         }
         if(t.phase == TouchPhase.Ended)
         {
              //save ended touch 2d point
             secondPressPos = new Vector2(t.position.x,t.position.y);
                           
              //create vector from the two points
             currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
               
             //normalize the 2d vector
             currentSwipe.Normalize();
 
             //swipe left
             if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                    Left();
             }
             //swipe right
             if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                    Right();
             }
         }
     }
}
}
