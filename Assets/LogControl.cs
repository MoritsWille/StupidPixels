﻿using UnityEngine;
using System.Collections;

public class LogControl : MonoBehaviour {
    public Sprite Fall;
    public Transform Player;
    public Transform Log1;
    public Transform Log2;

	// Use this for initialization
	void Start () {
        NewPos();
	}
	
	// Update is called once per frame
	void Update () {
	if (Player.position.y - 17 > transform.position.y)
    {
        NewPos();
    }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = Fall;
        yield return new WaitForSeconds(5);
        Application.LoadLevel("GameOver");
    }

    void NewPos()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(50, 200), 0);
        if (Log1.position.y < transform.position.y + 30 || Log1.position.y > transform.position.y - 30)
        {
            if (Log2.position.y < transform.position.y + 30 || Log2.position.y > transform.position.y - 30)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 80,0);
            }
        }
    }
}
