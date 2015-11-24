using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill : MonoBehaviour {
    
    GameObject[] Enemys;

    public GameObject[] skills;
    public Image img;
    public GameObject target;
    GameObject temp;
    public GameObject rota;

    public float maxMana = 100;
    static float currentMana = 100;
    public int _current;

    bool isEnemy;

    float mana;

	// Use this for initialization
	void Start () {
        mana = PlayerPrefs.GetFloat("mana");

        Debug.Log(mana);

       // mana = PlayerPrefs.GetFloat("mana");
        StartCoroutine("mana_auto");
        isEnemy = false;
	}
	
	// Update is called once per frame
	void Update () {
        _current = (int)currentMana;
        img.fillAmount = currentMana / 100f;
        
        if (temp != null)
        {

            if (temp.name == "Fireball(Clone)")
            {
                
            }
        }
            
    }


    public void mana_drinking()
    {
        if (mana > 0)
        {
            mana -= 1;
            PlayerPrefs.SetFloat("mana", mana);
            currentMana = maxMana;
        }

    }

    public void Fireball()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentMana >= 30){
            temp = Instantiate(skills[1], new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), rota.transform.rotation) as GameObject;
            StartCoroutine("speed", temp);
            currentMana -= 30;
        }
        
    }

    void OnGUI()
    {
        int current = (int)currentMana;
        GUI.color = Color.gray;
        GUI.Label(new Rect(Screen.width * 0.85f, Screen.height * 0.03f , Screen.width / 2 , Screen.height / 2), "<size=14>" + current.ToString() + " / " + maxMana.ToString() + "</size>" );
    }

    public void Lightning()
    {

        Enemys = GameObject.FindGameObjectsWithTag("Enemy");


        if(currentMana >= 100)
        {
            foreach (GameObject Enemy in Enemys)
            {
                if(Enemy.name != "Enemy_barrack")
                {
                    Enemy.GetComponent<HPManager>().currentHP -= 500;

                    temp = Instantiate(skills[0], new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + 2.5f, Enemy.transform.position.z), Enemy.transform.rotation) as GameObject;

                    temp.GetComponent<Animator>().SetTrigger("Idle2");

                    StartCoroutine("playing", temp);

                    isEnemy = true;
                }
                

            }

            if(isEnemy)
                currentMana -= 100;

            isEnemy = false;
        }
            

        
    }

    IEnumerator playing(GameObject temp)
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(temp);
    }

    IEnumerator mana_auto()
    {
        while (true)
        {
            yield return null;

            if (maxMana > currentMana)
            {
                currentMana += 0.02f;
            }


            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator speed(GameObject temp)
    {
        Vector2 position = temp.transform.position;


        while (true)
        {

            if (temp == null)
                break;
                

            temp.transform.Translate(0, -Time.deltaTime * 3.0f, 0);

            yield return new WaitForEndOfFrame();
        }
    }
}
