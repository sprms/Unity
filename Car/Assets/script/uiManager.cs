using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class uiManager : MonoBehaviour {

    public Text scoreText;
    int score;

	// Use this for initialization
	void Start () {
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if(scoreText != null)
        scoreText.text = "Score : " + score;
	}

    void scoreUpdate()
    {
        score += 10;
    }
    
    public void Play()
    {
        Application.LoadLevel("main");
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

    }
}
