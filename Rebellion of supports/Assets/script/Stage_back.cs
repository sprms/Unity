using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage_back : MonoBehaviour {

    public GameObject Stage;
    public GameObject Store;
    public GameObject upgrade;
    public GameObject item;
    public GameObject up_back;
    public GameObject menu;
    public GameObject character;

    public Image power_progress;
    public Image armor_progress;
    public Image heart_progress;
    public Image speed_progress;

    string select_char;

    int coin;

    // Use this for initialization
    void Start () {
        //PlayerPrefs.SetInt("coin", 3000);

        coin = PlayerPrefs.GetInt("coin");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void back()
    {
        Store.SetActive(false);
        Stage.SetActive(true);
    }

    public void Upgrade()
    {
        item.SetActive(false);
        character.SetActive(true);
        upgrade.SetActive(true);
    }

    public void Item()
    {
        upgrade.SetActive(false);
        character.SetActive(false);
        item.SetActive(true);
    }

    public void bacuya()
    {
        select_char = "bacuya";
        up_back.SetActive(true);
        menu.SetActive(false);
        character.SetActive(false);

        power_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_power") / 5;
        armor_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_armor") / 5;
        heart_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_heart") / 5;
        speed_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_speed") / 5;
    }

    public void rupi()
    {
        select_char = "rupi";
        up_back.SetActive(true);
        menu.SetActive(false);
        character.SetActive(false);

        power_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_power") / 5;
        armor_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_armor") / 5;
        heart_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_heart") / 5;
        speed_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_speed") / 5;
    }

    public void ken()
    {
        select_char = "ken";
        up_back.SetActive(true);
        menu.SetActive(false);
        character.SetActive(false);

        power_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_power") / 5;
        armor_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_armor") / 5;
        heart_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_heart") / 5;
        speed_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_speed") / 5;
    }

    public void rukia()
    {
        select_char = "rukia";
        up_back.SetActive(true);
        menu.SetActive(false);
        character.SetActive(false);


        power_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_power") / 5;
        armor_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_armor") / 5;
        heart_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_heart") / 5;
        speed_progress.fillAmount = PlayerPrefs.GetFloat(select_char + "_speed") / 5;

    }

    public void up_background_bk()
    {
        select_char = "";
        up_back.SetActive(false);
        menu.SetActive(true);
        character.SetActive(true);

        power_progress.fillAmount = 0;
        armor_progress.fillAmount = 0;
        heart_progress.fillAmount = 0;
        speed_progress.fillAmount = 0;
        
    }

    public void states(string name)
    {
        Debug.Log(select_char);
        switch (name)
        {
            case "power_plus":
                Debug.Log(power_progress.fillAmount);

                if(power_progress.fillAmount != 1 && coin >= 500)
                {
                    power_progress.fillAmount += 0.2f;
                    PlayerPrefs.SetFloat(select_char + "_power", power_progress.fillAmount * 5);

                    coin -= 500;

                    PlayerPrefs.SetInt("coin", coin);
                }
                
                
                
                break;
            case "power_minus":
                if(power_progress.fillAmount != 0)
                {
                    power_progress.fillAmount -= 0.2f;
                    PlayerPrefs.SetFloat(select_char + "_power", power_progress.fillAmount * 5);

                    coin += 500;

                    PlayerPrefs.SetInt("coin", coin);
                }

               
                break;
            case "armor_plus":
                if (armor_progress.fillAmount != 1 && coin >= 500)
                {
                    armor_progress.fillAmount += 0.2f;
                    PlayerPrefs.SetFloat(select_char + "_armor", armor_progress.fillAmount * 5);

                    coin -= 500;

                    PlayerPrefs.SetInt("coin", coin);
                }

               
                break;
            case "armor_minus":
                if (armor_progress.fillAmount != 0)
                {
                    armor_progress.fillAmount -= 0.2f;
                    PlayerPrefs.SetFloat(select_char + "_armor", armor_progress.fillAmount * 5);

                    coin += 500;

                    PlayerPrefs.SetInt("coin", coin);
                }

                
                break;
            case "heart_plus":
                if (heart_progress.fillAmount != 1 && coin >= 500)
                {
                    heart_progress.fillAmount += 0.2f;
                    PlayerPrefs.SetFloat(select_char + "_heart", heart_progress.fillAmount * 5);

                    coin -= 500;

                    PlayerPrefs.SetInt("coin", coin);
                }
               
                break;
            case "heart_minus":
                if (heart_progress.fillAmount != 0)
                {
                    heart_progress.fillAmount -= 0.2f;
                    PlayerPrefs.SetFloat(select_char + "_heart", heart_progress.fillAmount * 5);

                    coin += 500;

                    PlayerPrefs.SetInt("coin", coin);
                }

                break;
            case "speed_plus":
                if (speed_progress.fillAmount != 1 && coin >= 500)
                {
                    speed_progress.fillAmount += 0.2f;
                    PlayerPrefs.SetFloat(select_char + "_speed", speed_progress.fillAmount * 5);

                    coin -= 500;

                    PlayerPrefs.SetInt("coin", coin);
                }
                    
                break;
            case "speed_minus":
                if (speed_progress.fillAmount != 0)
                {
                    speed_progress.fillAmount -= 0.2f;
                    PlayerPrefs.SetFloat(select_char + "_speed", speed_progress.fillAmount * 5);

                    coin += 500;

                    PlayerPrefs.SetInt("coin", coin);
                }
                   
                break;
            
        }


           
    }
}
