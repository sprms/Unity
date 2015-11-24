using UnityEngine;
using System.Collections;

public class EnemyCreate : MonoBehaviour {

    public GameObject[] Enemys;
    float random;
    int level;
    float minRandom;
    float maxRandom;

    int instances;

    float maxMineral = 100f;
    float currentMineral;
    float increaseMineral = 0.1f;

    int Enemylength;

    bool Enemy = true;

    // Use this for initialization
    void Start () {
        level = PlayerPrefs.GetInt("Complete");
        
        switch (1)
        {
            case 1:
                minRandom = 3.0f;
                maxRandom = 5.0f;
                increaseMineral += 0.2f;
                break;
            case 2:
                minRandom = 5.0f;
                maxRandom = 9.5f;
                increaseMineral += 0.15f;
                break;
            case 3:
                minRandom = 5.0f;
                maxRandom = 9.0f;
                increaseMineral = 0.2f;
                break;
            case 4:
                minRandom = 5.0f;
                maxRandom = 8.5f;
                increaseMineral = 0.25f;
                break;
            case 5:
                minRandom = 5.0f;
                maxRandom = 8.0f;
                increaseMineral = 0.3f;
                break;
            case 6:
                minRandom = 4.5f;
                maxRandom = 7.5f;
                increaseMineral = 0.4f;
                break;
            case 7:
                minRandom = 4.4f;
                maxRandom = 7.0f;
                increaseMineral = 0.5f;
                break;
            case 8:
                minRandom = 4.3f;
                maxRandom = 6.5f;
                increaseMineral = 0.6f;
                break;
            case 9:
                minRandom = 4.2f;
                maxRandom = 6.0f;
                increaseMineral = 0.7f;
                break;
            case 10:
                minRandom = 4.1f;
                maxRandom = 5.5f;
                increaseMineral = 0.8f;
                break;
            case 11:
                minRandom = 4.0f;
                maxRandom = 5.0f;
                increaseMineral = 0.9f;
                break;
        }
        
        currentMineral = 0;
        StartCoroutine("auto");
        StartCoroutine("mineral");
       
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator auto()
    {
        

        while (true)
        {
          
            // 미네랄 상태 따라 뽑을 수 있는 몬스터 판단
            // currentMineral 100 70 50 30

            if(currentMineral >= 100)
            {
                Enemylength = Enemys.Length;
                Enemy = true;
                Debug.Log("100짜리: " + Enemylength);
            }
            else if(currentMineral >= 70)
            {
                Enemylength = Enemys.Length - 1;
                Enemy = true;
                Debug.Log("70짜리: " + Enemylength);
            }
            else if(currentMineral >= 50)
            {
                Enemylength = Enemys.Length - 2;
                Enemy = true;
                Debug.Log("50짜리: " + Enemylength);
            }
            else if(currentMineral >= 30)
            {
                Enemylength = Enemys.Length - 3;
                Enemy = true;
                Debug.Log("30짜리: " + Enemylength);
            }
            else
                Enemy = false;

            yield return new WaitForSeconds(Random.Range(minRandom, maxRandom));

            float position_x = gameObject.transform.position.x;
            float position_y = Random.Range(0.2f, 2.7f);
            float position_z = Random.Range(0, -Enemys.Length);

            instances = Random.Range(0, Enemylength);

            switch (instances)
            {
                case 0:
                    if(Enemy)
                      currentMineral -= 30;
                    break;
                case 1:
                    if (Enemy)
                        currentMineral -= 50;

                    break;
                case 2:
                    if (Enemy)
                        currentMineral -= 70;

                    break;
                case 3:
                    if (Enemy)
                        currentMineral -= 100;

                    break;
            }
           
            if(Enemy)
                Instantiate(Enemys[instances], new Vector3(position_x, position_y, position_z), gameObject.transform.rotation);
        }

        
    }

    IEnumerator mineral()
    {
        


        while (true)
        {
            //Debug.Log("current: " + currentMineral);

            if (maxMineral > currentMineral)
            {
                currentMineral += increaseMineral;
            }


            yield return new WaitForEndOfFrame();



        }

    }

}
