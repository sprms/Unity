using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public GameObject pause;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MainMenu()
    {
        Application.LoadLevel("level");
        Time.timeScale = 1;
    }

    public void ReStart()
    {
        pause.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }

    public void ReSume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}
