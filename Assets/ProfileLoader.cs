using UnityEngine;
using System.Collections;
using System.IO;

public class ProfileLoader : MonoBehaviour {
    
    string ScorePath;
    string CPPath;
    string HighScorePath;
    public Sprite Adam;
    public Sprite Benson;

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            CPPath = Application.persistentDataPath + @"CurrentPlayer.txt";
        }
        else
        {
            CPPath = Directory.GetCurrentDirectory() + @"CurrentPlayer.txt";
        }

        switch (File.ReadAllText(CPPath))
        {
            case "a":
                gameObject.GetComponent<SpriteRenderer>().sprite = Adam;
                break;
            case "b":
                gameObject.GetComponent<SpriteRenderer>().sprite = Benson;
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
