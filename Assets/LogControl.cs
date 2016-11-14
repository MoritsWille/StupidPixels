using UnityEngine;
using System.Collections;

public class LogControl : MonoBehaviour {
    public Transform Camera;
    public Transform Log1;
    public Transform Log2;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(50, 200), 0);
        if (transform.position.y < Log1.position.y + 45 && transform.position.y > Log1.position.y - 45)
        {
            if (transform.position.y < Log2.position.y + 45 && transform.position.y > Log2.position.y - 45)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 90, 0);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	if (Camera.position.y - 46 > transform.position.y)
    {
            transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(100, 300), 0);
            if (transform.position.y < Log1.position.y + 45 && transform.position.y > Log1.position.y - 45)
            {
                if (transform.position.y < Log2.position.y + 45 && transform.position.y > Log2.position.y - 45)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 90, 0);
                }
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Application.LoadLevel("GameOver");
    }
}
