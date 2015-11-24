using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    Text[] text;
    public button hp;
    public Skill mp;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponentsInChildren<Text>();

	}
	
	// Update is called once per frame
	void Update () {
       // text[0].text = hp. _current.ToString() + " / " + hp.maxMineral.ToString();
        //text[1].text = mp._current.ToString() + " / " + mp.maxMana.ToString();
	}
}
