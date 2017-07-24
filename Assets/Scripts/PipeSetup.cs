using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSetup : MonoBehaviour {

    public float minSpace;
    public float maxSpace;
    public GameObject top;
    public GameObject bottom;
    SpriteRenderer renTop;
    SpriteRenderer renBottom;

    // Use this for initialization
    void Start () {
        Setup();
	}
	
	// Update is called once per frame
	void Update () {
        PipeRemover();
	}

    void Setup()
    {
        renTop = top.GetComponent<SpriteRenderer>();
        renBottom = bottom.GetComponent<SpriteRenderer>();
        float tmp = Random.Range(-3.3f + maxSpace, 5);
        top.transform.position = new Vector2(transform.position.x, tmp);
        float tmp2 = Random.Range(minSpace, maxSpace);
        bottom.transform.position = new Vector2(transform.position.x, tmp-tmp2);
    }

    void PipeRemover()
    {
        if(transform.position.x<0)
        {
            if(!renTop.isVisible && !renBottom.isVisible)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
