using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public Transform backgroundSpawn;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Reposition();
    }

    void Reposition()
    {
        if (transform.position.x <= -backgroundSpawn.position.x)
        {
            transform.position = backgroundSpawn.position;
        }
    }
}
