using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System;
//using GooglePlayGames;

public class MenuControl : MonoBehaviour {
    public int Score;
    public int HighScore;
    string ScorePath;
    string CPPath;
    string HighScorePath;

    // Use this for initialization
    void Start() {
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

        if (!File.Exists(ScorePath))
        {
            File.Create(ScorePath);
        }

        if (!File.Exists(HighScorePath))
        {
            File.Create(HighScorePath);
            File.WriteAllText(HighScorePath, "0");
        }
        //if (!File.Exists(OrangeBoxPath)) File.Create(OrangeBoxPath);
        //if (!File.Exists(GreenBoxPath)) File.Create(GreenBoxPath);

        Score = Convert.ToInt16(File.ReadAllText(ScorePath));
        HighScore = Convert.ToInt16(File.ReadAllText(HighScorePath));

        //PlayGamesPlatform.Activate();

        //Social.localUser.Authenticate((bool success) =>
        //{
        //    // handle success or failure
        //});

	}

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeCharacter()
    {
        SceneManager.LoadScene("PlayerMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GotoMenu()
    {
        Application.LoadLevel("Menu");
    }

    public void ShowAchievements()
    {
        Social.ShowAchievementsUI();
    }

    //public void ShowLeaderboard()
    //{
    //    PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIy_2dy-UJEAIQBw");
    //}
    // Update is called once per frame
    void Update () {
	
	}
}
