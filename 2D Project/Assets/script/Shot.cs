using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public GameObject bullet;
    public GameObject target;
    public float bullet_speed;
    Animator ani;

    GameObject temp;

    bool isshot;

	// Use this for initialization
	void Start () {
        isshot = true;
        ani = target.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Shotting()
    {
        if (isshot)
        {
            ani.SetBool("attack_check", true);

            temp = Instantiate(bullet, new Vector3(target.transform.position.x + 0.5f, target.transform.position.y + 0.75f, target.transform.position.z), target.transform.rotation) as GameObject;
            StartCoroutine("shot", temp);
            StartCoroutine("Wait");
            isshot = false;
        }

    }

    IEnumerator shot(GameObject temp)
    {
        while (true)
        {

            if (temp == null)
                break;


            temp.transform.Translate(Time.deltaTime * 10.0f, 0, 0);
            yield return new WaitForEndOfFrame();

        }
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(0.5f);
        ani.SetBool("attack_check", false);
        yield return new WaitForSeconds(bullet_speed);
        isshot = true;
        
        Destroy(temp);
    }
}
