using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

    public GameObject position_bar;
    bool toggle;
    float mana;

    public TextMesh[] text;

	// Use this for initialization
	void Start () {
        toggle = true;    
        
    }
	
	// Update is called once per frame
	void Update () {
        text[0].text = "x " + PlayerPrefs.GetFloat("energy").ToString();
        text[1].text = "x " + PlayerPrefs.GetFloat("mana").ToString();
    }

    public void position_toggle()
    {
        if (toggle)
        {
            position_bar.SetActive(true);
            toggle = !toggle;
        }
        else
        {
            position_bar.SetActive(false);
            toggle = !toggle;
        }
          
    }

   
   



}
