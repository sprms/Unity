using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class main : MonoBehaviour {

    int _current;

    public GameObject canvas;

    public Text tt;
    
    GameObject image_temp;

    public GameObject back;

    int btn_num = 1;
    int enter = 0;
    int set = 0;

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("coin", 30000);

        Screen.SetResolution(Screen.width , (Screen.width/3) * 2, true);

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        /*

        tt.text = PlayerPrefs.GetInt("coin").ToString();


        Debug.Log(PlayerPrefs.GetInt("coin"));

        if(Application.loadedLevelName == "level")
        {

            if (PlayerPrefs.HasKey("Complete") == true)
            {
                _current = PlayerPrefs.GetInt("Complete");
                Debug.Log("load: " + _current);
            }


            else
                _current = 0;


            btn_num = 1;

            for (int i = 0; i < 10; i++)
            {
                image_temp = Instantiate(back, new Vector3(-160 + (110 * (set + 1)), 100f - enter, back.transform.position.z), back.transform.rotation) as GameObject;

                image_temp.transform.parent = canvas.transform;

                image_temp.GetComponentInChildren<Text>().fontSize = 40;
                image_temp.GetComponentInChildren<Text>().text = btn_num.ToString();

                

                if (i % 4 == 0 &&  set != 0)
                {
                    enter = 100;
                    set = 0;
                }

                set++;
                btn_num++;

            }
        }
        */


    }

    // Update is called once per frame
    void Update () {
      
	}

    public void main_start()
    {
        Application.LoadLevel("level");
    }

    public void level()
    {
        Application.LoadLevel("scene");
    }

    IEnumerator hide(GameObject temp1)
    {
        while (true)
        {


            if (canvas.GetComponentsInChildren<Image>()[0].GetComponent<Image>().fillAmount == 0)
            {
                break;
            }

            yield return new WaitForEndOfFrame();
            
            Debug.Log(btn_num);

        }


    }
}
