using UnityEngine;
using System.Collections;

public class Buy : MonoBehaviour {

    int coin;
    float energy;
    float mana;

    public GameObject[] sprite;

    public Sprite[] img;

   
	// Use this for initialization
	void Start () {
        coin = PlayerPrefs.GetInt("coin");
        energy = PlayerPrefs.GetFloat("energy");
        mana = PlayerPrefs.GetFloat("mana");

        PlayerPrefs.SetInt("coin", 30000);

        if (PlayerPrefs.HasKey("penguin"))
        {
            sprite[0].transform.position = new Vector2(sprite[0].transform.position.x, sprite[0].transform.position.y);
            sprite[0].transform.localScale = new Vector3(0.4969344f, 0.6263769f, 0.3635373f);
            sprite[0].GetComponent<SpriteRenderer>().sprite = img[0];
        }

        if (PlayerPrefs.HasKey("pikachu"))
        {
            sprite[1].transform.position = new Vector2(sprite[1].transform.position.x, sprite[1].transform.position.y);
            sprite[1].transform.localScale = new Vector3(0.3357221f, 0.3357385f, 0.3635373f);
            sprite[1].GetComponent<SpriteRenderer>().sprite = img[1];
        }

        if (PlayerPrefs.HasKey("acuma"))
        {
            sprite[2].transform.position = new Vector2(sprite[2].transform.position.x, sprite[2].transform.position.y);
            sprite[2].transform.localScale = new Vector3(0.4505435f , 0.3634371f , 0.3635373f);
            sprite[2].GetComponent<SpriteRenderer>().sprite = img[2];
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void potition_buy(string name)
    {
        switch (name)
        {
            case "Energy":
                if(coin >= 2000)
                {
                    energy += 1;
                    coin -= 2000;
                    PlayerPrefs.SetInt("coin", coin);
                    PlayerPrefs.SetFloat("energy", energy);
                }
                break;
            case "Mana":
                if(coin >= 2500)
                {
                    mana += 1;
                    coin -= 2500;
                    PlayerPrefs.SetInt("coin", coin);
                    PlayerPrefs.SetFloat("mana", mana);
                }
                break;
        }
    }

    public void character_buy(string name)
    {
        switch (name)
        {
            case "penguin":
                if (coin >= 3000 && !PlayerPrefs.HasKey("penguin"))
                {
                    PlayerPrefs.SetString("penguin", "true");
                    coin -= 3000;
                    PlayerPrefs.SetInt("coin", coin);
                    sprite[0].transform.position = new Vector2(sprite[0].transform.position.x, sprite[0].transform.position.y);
                    sprite[0].transform.localScale = new Vector3(0.4969344f, 0.6263769f, 0.3635373f);
                    sprite[0].GetComponent<SpriteRenderer>().sprite = img[0];
                }

                
                
                break;
            case "pikachu":
                if (coin >= 5000 && !PlayerPrefs.HasKey("pikachu"))
                {
                    PlayerPrefs.SetString("pikachu", "true");
                    coin -= 5000;
                    PlayerPrefs.SetInt("coin", coin);
                    sprite[1].transform.position = new Vector2(sprite[1].transform.position.x, sprite[1].transform.position.y);
                    sprite[1].GetComponent<SpriteRenderer>().sprite = img[1];
                    sprite[1].transform.localScale = new Vector3(0.3257783f, 0.3341953f, 0.3369743f);
                }

               
                break;
            case "acuma":
                if (coin >= 10000 && !PlayerPrefs.HasKey("acuma"))
                {
                    PlayerPrefs.SetString("acuma", "true");
                    coin -= 10000;
                    PlayerPrefs.SetInt("coin", coin);
                    sprite[2].GetComponent<SpriteRenderer>().sprite = img[2];
                    sprite[2].transform.position = new Vector2(sprite[2].transform.position.x, sprite[2].transform.position.y);
                    sprite[2].transform.localScale = new Vector3(0.4568598f, 0.3635373f, 0.3635373f);
                }

               
                break;
        }
    }
}
