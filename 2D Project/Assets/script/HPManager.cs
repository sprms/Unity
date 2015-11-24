using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPManager : MonoBehaviour {

    int coin;
    public float maxHP;
    public float currentHP;
    public float armor;
    float timespan;
    float checktime;
    Animator animation;

    GUIText text;

    //public Canvas HP;
    Image[] hpBar;


    // Use this for initialization
    void Start () {

        armor = 5;

        if (gameObject.name.IndexOf('(') != -1)
        {
            maxHP = PlayerPrefs.GetFloat(gameObject.name.Substring(0, gameObject.name.IndexOf('(')) + "_heart") * 100 <= 0 ? 100 : PlayerPrefs.GetFloat(gameObject.name.Substring(0, gameObject.name.IndexOf('(')) + "_heart") * 100;
            armor += PlayerPrefs.GetFloat(gameObject.name.Substring(0, gameObject.name.IndexOf('(')) + "_armor") * 5;
        }
        else if (gameObject.name == "gunman")
        {
            maxHP = 100;
        }

            

        currentHP = maxHP;

        text = gameObject.AddComponent<GUIText>();

        timespan = 0f;
        checktime = 2.0f;

        //HP = Instantiate(HP, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation) as Canvas;
        
        animation = GetComponent<Animator>();

        hpBar = GetComponentsInChildren<Image>();

    }


    // Update is called once per frame
    void Update () {

        hpBar[1].fillAmount = currentHP / maxHP;

	    if(currentHP <= 0)
        {
            coin = PlayerPrefs.GetInt("coin");

            if (gameObject.name == "gunman")
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                Time.timeScale = 0;
            }else
                Destroy(gameObject);

            
            Destroy(hpBar[0]);

            if(gameObject.tag == "Enemy")
            {
                

                switch (gameObject.name)
                {
                    case "enemy_dog(Clone)":
                        coin += 10;
                        break;
                    case "enemy_boomman(Clone)":
                        coin += 20;
                        break;
                    case "enemy_dragon(Clone)":
                        coin += 40;
                        break;
                    case "enemy_warrior(Clone)":
                        coin += 80;
                        break;


                }

                PlayerPrefs.SetInt("coin", coin);
                text.text = "+10";

            }

            Debug.Log("coin: " + PlayerPrefs.GetInt("coin"));
            
        }
	}

    void HpDown(float daemage)
    {


        Debug.Log("hpdown");
        

        timespan += Time.deltaTime;

        if(timespan > checktime)
        {
            if(armor > daemage)
            {
                daemage = daemage / 2;
            }

            daemage -= armor;
            currentHP -= daemage;
            timespan = 0;
            
            
        }

    
    }


}
