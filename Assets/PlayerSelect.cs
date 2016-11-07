using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerSelect : MonoBehaviour {
    public Transform Pa;
    public Transform Pb;
    public Transform Pc;
    bool TwasTouch = false;
    public Transform CameraPos;
    Vector2 TouchStart;
    Vector2 TouchDelta;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount == 1 && CameraPos.position.x < Pc.position.x + 0.25f && CameraPos.position.x > Pa.position.x - 0.25f)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 WorldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            if (!TwasTouch)
            {
                TouchStart = WorldTouch;
                TwasTouch = true;
            }
            CameraPos.position = new Vector3(CameraPos.position.x - (WorldTouch.x - TouchStart.x), 0, -10);
        }
        else
        {
            TwasTouch = false;
        }
    }
}
