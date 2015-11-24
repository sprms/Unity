using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shopping : MonoBehaviour {

    public GameObject Stage;
    public GameObject Store;

    

    public Text coin;
	// Use this for initialization
	void Start () {
        //coin.text = PlayerPrefs.GetInt("coin").ToString();

       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (Store.active)
        {
            GUI.color = Color.black;

            GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.02f, Screen.width / 2, Screen.height / 2), "<size=20>" + PlayerPrefs.GetInt("coin").ToString() + "</size>");
        }
        
    }

    public void Upgrade()
    {
        Stage.SetActive(false);
        Store.SetActive(true);

    }
}
