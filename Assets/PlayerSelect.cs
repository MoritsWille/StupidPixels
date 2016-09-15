using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;

public class PlayerSelect : MonoBehaviour {
    public Transform Pa;
    public Transform Pb;
    int TP = 0;
    int[] TS = {0,0};
    int CamPos = 0;
    public Transform Camera;
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;
    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (TP > 0)
        {
            Camera.position = new Vector3(Camera.position.x + 0.2f, 0, -10);
            TP--;
        }
        if (TP < 0)
        {
            Camera.position = new Vector3(Camera.position.x - 0.2f, 0, -10);
            TP++;
        }

        if (TS[0] > 0)
        {
            Pb.localScale = new Vector3(Pb.localScale.x + 0.5f, Pb.localScale.y + 0.5f, 1);
            TS[0]--;
        }
        if (TS[0] < 0)
        {
            Pb.localScale = new Vector3(Pb.localScale.x - 0.5f, Pb.localScale.y - 0.5f, 1);
            TS[0]++;
        }

        if (TS[1] > 0)
        {
            Pa.localScale = new Vector3(Pa.localScale.x + 0.5f, Pa.localScale.y + 0.5f, 1);
            TS[1]--;
        }
        if (TS[1] < 0)
        {
            Pa.localScale = new Vector3(Pa.localScale.x - 0.5f, Pa.localScale.y - 0.5f, 1);
            TS[1]++;
        }

	    if (Input.GetKeyDown("a"))
        {
            Right();
        }

        if (Input.GetKeyDown("d"))
        {
            Left();
        }


        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // MOVE RIGHT
                                    Right();
                                }
                                else
                                {
                                    // MOVE LEFT
                                    Left();
                                }
                            }

                        }

                        break;
                }
            }
        }

    }

    void Right()
    {
        if (CamPos != 0)
        {

            Camera.position = new Vector3(CamPos * 2.6f, 0, -10);
            if (CamPos < 2 || CamPos > -1)
            {
                TS[CamPos] = -16;
                TS[CamPos - 1] = +16;
            }
            TP = -13;
            CamPos--;
        }
    }

    void Left()
    {
        if (CamPos != 1)
        {
            if (CamPos < 2 || CamPos > -1)
            {
                TS[CamPos] = -16;
                TS[CamPos + 1] = +16;
            }
            TP = +13;
            CamPos++;
        }
    }
}
