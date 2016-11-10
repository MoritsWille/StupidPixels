using UnityEngine;
using System.Collections;
using System.IO;

public class ProfileLoader : MonoBehaviour {
    string CPPath;
    public Sprite Adam;
    public Sprite Benson;
    public Sprite Carl;
    public Sprite Donald;

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            CPPath = Application.persistentDataPath + @"/CurrentPlayer.txt";
        }
        else
        {
            CPPath = Directory.GetCurrentDirectory() + @"\CurrentPlayer.txt";
        }

        if (!File.Exists(CPPath))
        {
            File.Create(CPPath);
            File.WriteAllText(CPPath, "a");
        }

        switch (File.ReadAllText(CPPath))
        {
            case "a":
                gameObject.GetComponent<SpriteRenderer>().sprite = Adam;
                break;
            case "b":
                gameObject.GetComponent<SpriteRenderer>().sprite = Benson;
                break;
            case "c":
                gameObject.GetComponent<SpriteRenderer>().sprite = Carl;
                break;
            case "d":
                gameObject.GetComponent<SpriteRenderer>().sprite = Donald;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
