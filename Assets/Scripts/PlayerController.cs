using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float flapForce;
    Rigidbody2D rb;
    public bool isGO;//isGO = IS GAME OVER
    public bool isStrart;
    public int score;
    public GameObject gameOverPanel;

    public int record;
    public Text newRecord;

    public Sprite up;
    public Sprite down;

    public int whichOne;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && !isGO)
        {
            if(!isStrart)
            {
                rb.gravityScale = 1;
                isStrart = true;
            }
            Flap();
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
        if (isGO)
        {
            Record();
            NewRecord();
        }
    }

    void FixedUpdate()
    {
        if(isStrart && !isGO)
        {
            HeavyEnd();
        }

    }

    void Flap()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0,flapForce));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DeadZone")
        {
            isGO = true;
            StartCoroutine(WaitForGo());
        }

        if (collision.tag == "ScoreZone")
        {
            score++;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "DeadZone")
        {
            isGO = true;
            StartCoroutine(WaitForGo());
        }

    }

    IEnumerator WaitForGo()
    {
        yield return new WaitForSeconds(1/2);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void HeavyEnd()
    {
        float angle = 35;
        if(rb.velocity.y<0)
        {
            angle = Mathf.Lerp(35, -80, -(rb.velocity.y)/10);
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Record()
    {
        if (score > PlayerPrefs.GetInt("Record"))
        {
            record = score;
            PlayerPrefs.SetInt("Record", record);
            PlayerPrefs.Save();
        }
    }

    void NewRecord()
    {
        newRecord.text = PlayerPrefs.GetInt("Record").ToString();
    }
}