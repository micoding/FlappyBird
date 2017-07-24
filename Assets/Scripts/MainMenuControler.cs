using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControler : MonoBehaviour {

    public GameObject player;

    public void PlayButton()
    {
        player.GetComponent<Movement>().enabled = true;
    }

    void Update()
    {
        if (player.transform.position.x <= -1.5)
        {
            SceneManager.LoadScene(1);
        }
    }
}
