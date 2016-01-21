using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerControl : MonoBehaviour {
    float SpeedperTick = 0;
    float BeforePos = 0;
    bool WalkRight = true;
    public Sprite WalkLeftS;
    public Sprite WalkRightS;
    public Sprite Still;
    bool Dead = false;
    Text ScoreText;
    public GameObject Text;

	// Use this for initialization
	void Start () {
        ScoreText = Text.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score: " + Convert.ToInt32(Math.Ceiling(transform.position.y)).ToString();
        if (Dead)
        {

        }
        else
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

                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
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
        }
	}

    void OnCollisionEnter2D()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        Dead = true;
    }

    void DeadText ()
    {

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
