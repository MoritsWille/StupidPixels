using UnityEngine;
using System.Collections;

public class PlayerSelect : MonoBehaviour {
    public Transform Pa;
    public Transform Pb;
    int TP = 0;
    int[] TS = {0,0};
    int CamPos = 0;
    public Transform Camera;


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
            // Dont move of boundraries
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

        if (Input.GetKeyDown("d"))
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
}
