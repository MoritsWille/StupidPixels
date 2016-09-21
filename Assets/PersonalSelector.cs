using UnityEngine;
using System.Collections;
using System.IO;

public class PersonalSelector : MonoBehaviour
{
    public Transform Camera;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Camera.position.x - transform.position.x + 1, Camera.position.x - transform.position.x + 1, 0);
    }
}
