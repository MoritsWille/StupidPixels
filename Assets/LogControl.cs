using UnityEngine;
using System.Collections;

public class LogControl : MonoBehaviour {
    public Sprite Fall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = Fall;
    }
}
