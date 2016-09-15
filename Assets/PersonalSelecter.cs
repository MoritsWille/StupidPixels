using UnityEngine;
using System.Collections;
using System.IO;

public class PersonalSelecter : MonoBehaviour
{
    string CPPath;

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

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (gameObject.name == "Adam")
        {
            File.WriteAllText(CPPath, "a");
        }
        else if (gameObject.name == "Benson")
        {
            File.WriteAllText(CPPath, "b");
        }
        Application.LoadLevel("Menu");
    }
}
