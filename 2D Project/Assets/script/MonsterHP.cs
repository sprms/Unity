using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour {

    public Image hpBar;
    public Image hpBack;

    public HPManager[] player;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        foreach (HPManager hp in player)
        {
            hpBar.fillAmount = (float)hp.currentHP / (float)hp.maxHP;

            if(hp.currentHP < 0)
            {
                Destroy(hpBack);
                
            }
        }


    }
}
