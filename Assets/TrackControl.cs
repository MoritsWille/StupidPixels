using UnityEngine;
using System.Collections;

public class TrackControl : MonoBehaviour {
    public Transform Player;
    public Transform Track1;
    public Transform Track2;
    bool T1 = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   if (T1)
       {
            if (Player.position.y > Track2.position.y - 30)
            {
                Track1.position = new Vector3(0, Track2.position.y + 99, 0);
                T1 = false;
            }
       }
       else
       {
           if (Player.position.y > Track1.position.y - 30)
           {
               Track2.position = new Vector3(0, Track1.position.y + 99, 0);
               T1 = true;
           }
       }
	}
}
