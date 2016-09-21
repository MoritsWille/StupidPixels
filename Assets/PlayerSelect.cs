using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerSelect : MonoBehaviour {
    public Transform Pa;
    public Transform Pb;
    float TP = 0;
    int[] TS = {0,0};
    int CamPos = 0;
    public Transform Camera;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        

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
        TP = +0.25F;
    }

    public void Left()
    {
        TP = -025f;
    }
}
