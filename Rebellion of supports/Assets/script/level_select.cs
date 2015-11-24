using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class level_select : MonoBehaviour {

    public GameObject[] stage;
    public Sprite sprite;

    public GameObject[] text;
	// Use this for initialization
	void Start () {

        //PlayerPrefs.DeleteAll();

        int Length = PlayerPrefs.GetInt("Complete");

                for (int i = 0; i < Length; i++)
                {
                    stage[i].GetComponent<Image>().sprite = sprite;
                    text[i].SetActive(true);
                }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
