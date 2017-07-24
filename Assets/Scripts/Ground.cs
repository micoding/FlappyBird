using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public Transform deadZoneSpwan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Reposition();
	}

    void Reposition()
    {
        if(transform.position.x <= -deadZoneSpwan.position.x)
        {
            transform.position = deadZoneSpwan.position;
        }
    }
}
