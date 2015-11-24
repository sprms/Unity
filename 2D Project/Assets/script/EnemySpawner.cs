using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemys;
    int enemyNo;
    public float maxPos = 2.2f;
    public float delayTimer = 2.0f;
    float timer;

    // Use this for initialization
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 enemyPos = new Vector3(Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z);
            enemyNo = Random.Range(0, 6);

            Instantiate(enemys[enemyNo], enemyPos, transform.rotation);

            timer = delayTimer;
        }


    }
}
