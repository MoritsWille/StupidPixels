using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerSelect : MonoBehaviour {
    public Transform Pa;
    public Transform Pb;
    float TP = 0;
    int CamPos = 0;
    public Transform Camera;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.position.x < TP)
        {
            Camera.position = new Vector3(Camera.position.x + 0.01f, 0, -10);
        }
        else if (Camera.position.x > TP)
        {
            Camera.position = new Vector3(Camera.position.x - 0.01f, 0, -10);
        }

        if (Input.GetKeyDown("a"))
        {
            Right();
        }

        if (Input.GetKeyDown("d"))
        {
            Left();
        }


    }

    public void Right()
    {
        TP = Camera.position.x - 0.25f;
    }

    public void Left()
    {
        TP = Camera.position.x + 025f;
    }
}
