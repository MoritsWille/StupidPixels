using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class CountDown : MonoBehaviour {
    public Sprite Adam;
    public Sprite Benson;
    public Sprite Carl;
    public Sprite Donald;
    bool countDown = false;
    float time;
    public GameObject text;
    int timeLeft = 3;
    string ScorePath;
    string HighScorePath;
    string CPPath;
    Sprite Still;

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

        if (File.ReadAllText(HighScorePath) == "")
        {
            File.WriteAllText(HighScorePath, "0");
        }

        switch (File.ReadAllText(CPPath))
        {
            case "":
                File.WriteAllText(CPPath, "a");
                Still = Adam;
                break;
            case "a":
                break;
            case "b":
                Still = Benson;
                break;
            case "c":
                Still = Carl;
                break;
            case "d":
                Still = Donald;
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Still;
    }
	
	// Update is called once per frame
	void Update () {
        if (countDown)
        {
            time += Time.deltaTime;
        }

        if (time > 0.75f)
        {
                timeLeft--;
                if (timeLeft == -1)
                {
                    GotoGame();
                }
                else
                {
                    text.gameObject.GetComponent<Text>().text = timeLeft.ToString();
                }

                time = 0;
        }
	}

    void GotoGame()
    {
        SceneManager.LoadScene("Game");
    }

    void OnMouseDown()
    {
        countDown = true;
    }

    void OnMouseUp()
    {
        countDown = false;
    }
}
