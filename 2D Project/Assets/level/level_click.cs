using UnityEngine;
using System.Collections;

public class level_click : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Btn_click(int stage)
    {
        Debug.Log(PlayerPrefs.GetInt("Complete"));

        if (!PlayerPrefs.HasKey("Complete") || PlayerPrefs.GetInt("Complete") == 0)
        {
            PlayerPrefs.SetInt("Complete", 1);
        }

        if(stage <= PlayerPrefs.GetInt("Complete"))
        {
            PlayerPrefs.SetInt("current_Complete", stage);
            Application.LoadLevel("scene");
        }
        
    }
}
