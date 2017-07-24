using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour {

    public Sprite up;
    public Sprite down;

    public int whichOne;

    public int frame;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (frame >= 20)
        {
            Bird();
            frame = 0;
        }
        frame++;
    }

    void Bird()
    {
        if (whichOne == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = down;
            whichOne++;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = up;
            whichOne = 0;
        }
    }
}