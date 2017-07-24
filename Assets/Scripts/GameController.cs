using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject pipePrefab;
    public Transform pipeSpawn;
    public float minTime;
    public float maxTime;
    public float timer;
    public PlayerController pc;
    public Text score;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (timer <= 0 && pc.isStrart)
        {
            PipeSpawner();
        }
        timer -= Time.deltaTime;
        ScoreFunction();
    }
    

    void PipeSpawner()
    {
        Instantiate(pipePrefab, pipeSpawn.position, pipeSpawn.rotation);
        timer = Random.Range(minTime, maxTime);
    }

    void ScoreFunction()
    {
        score.text = pc.score.ToString();
    }

    public void ReplayFunction()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenuFunction()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
