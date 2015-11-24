using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class barrack_HP : MonoBehaviour {

    public float maxHP;
    float currentHP;
    float timespan;
    float checktime;

    public GameObject _effect;

    bool isEnd = true;
    GameObject temp;
    Image[] hpBar;

    int current_level;

    public GameObject[] GameEnd;

    // Use this for initialization
    void Start () {
        timespan = 0f;
        checktime = 2.0f;

        maxHP = 500;
        currentHP = maxHP;
        hpBar = GetComponentsInChildren<Image>();

        current_level = PlayerPrefs.GetInt("Complete");

        
    }
	
	// Update is called once per frame
	void Update () {

        hpBar[1].fillAmount = currentHP / maxHP;



        if (currentHP <= 0)
        {


            int coin = PlayerPrefs.GetInt("coin");

            coin += PlayerPrefs.GetInt("current_Complete") * 1000;

            PlayerPrefs.SetInt("coin", coin);

            Destroy(gameObject);

            if (gameObject.name == "Enemy_barrack")
            {
                GameEnd[0].SetActive(true);
                PlayerPrefs.SetInt("Complete", current_level + 1);
            }
            else
                GameEnd[1].SetActive(true);

        }

        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 3), new Vector2(gameObject.transform.position.x - 0.8f, gameObject.transform.position.y - 3));


        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[0].gameObject.name);


            if (colliders[i].gameObject.name == "Fireball(Clone)")
            {
                Destroy(colliders[i].gameObject);

                temp = Instantiate(_effect, new Vector3(colliders[i].gameObject.transform.position.x, colliders[i].gameObject.transform.position.y, colliders[i].gameObject.transform.position.z), colliders[i].gameObject.transform.rotation) as GameObject;

             //   StartCoroutine("effect", temp);

                currentHP -= 50;
            }

            if (colliders[i].gameObject.name == "bullet(Clone)")
            {

                currentHP -= 50;
                Destroy(colliders[i].gameObject);
            }

            
        }
    }


    void HpDown(float daemage)
    {
        timespan += Time.deltaTime;

        if (timespan > checktime)
        {
            currentHP -= daemage;
            timespan = 0;


        }
    }

    public void Exit()
    {
        Time.timeScale = 1;
        Application.LoadLevel("level");
    }


    
}
