using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform Player;
    // stats
    float SpeedperTick = 0;
    float BeforePos = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       SpeedperTick = (transform.position.y - BeforePos) + 0.0005f;
       BeforePos = transform.position.y;
       transform.position = new Vector3(0, transform.position.y + SpeedperTick, -10);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Application.LoadLevel("GameOver");
    }
}
