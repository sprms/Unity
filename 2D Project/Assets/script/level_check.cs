using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class level_check : MonoBehaviour {

    public Sprite[] background;
    public GameObject pause;
    int _current;

    public bool[] check;

    public GameObject[] btn;


	// Use this for initialization
	void Start () {

        check = new bool[3];

        for (int i = 0; i < 3; i++)
            check[i] = false;

        if (PlayerPrefs.HasKey("penguin"))
        {

            check[0] = true;

            btn[0].SetActive(true);
            
        }

        if (PlayerPrefs.HasKey("pikachu"))
        {
            check[1] = true;
            btn[1].SetActive(true);
        }

        if (PlayerPrefs.HasKey("acuma"))
        {
            check[2] = true;
            btn[2].SetActive(true);
        }


        if (PlayerPrefs.HasKey("Complete"))
        {
            _current = PlayerPrefs.GetInt("current_Complete");
        }

        switch (_current)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = background[0];
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = background[1];
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = background[2];
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = background[3];
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().sprite = background[4];
                break;

        }
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(), );
    }
	
	// Update is called once per frame
	void Update () {
	    if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // 취소 버튼
                Time.timeScale = 0;
                pause.SetActive(true);
            }
        }
	}
}
