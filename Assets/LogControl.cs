using UnityEngine;
using System.Collections;

public class LogControl : MonoBehaviour {
    public Sprite Fall;
    public Transform Player;
    public Transform Log1;
    public Transform Log2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Player.position.y - 15 > transform.position.y)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(75, 150),0);
        if (Log1.position.y + 5 < transform.position.y || Log1.position.y - 5 > transform.position.y)
        {
            if (Log2.position.y + 5 < transform.position.y || Log2.position.y - 5 > transform.position.y)
            {
            transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(30, 100), 0);
            }
        }
    }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = Fall;
    }
}
