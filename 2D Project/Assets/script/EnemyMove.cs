using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public float speed = 2.0f;
    Animator animation;
    public float daemage;
    float radius = 3.0f;
    bool attack_check;

    public GameObject _effect;

    GameObject temp;

	// Use this for initialization
	void Start () {
        animation = GetComponent<Animator>();
        attack_check = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        
        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y +3), new Vector2(gameObject.transform.position.x -0.8f, gameObject.transform.position.y -3));

     
        if (!attack_check)
        {
            speed = 2;

           
            animation.SetBool("attack_check", false);
            animation.SetBool("walk_check", true);

            timestop();
            transform.Translate(new Vector3(-0.5f, 0, 0) * speed * Time.deltaTime);

        }

        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[0].gameObject.name);


            if(colliders[i].gameObject.name == "Fireball(Clone)")
            {
                Destroy(colliders[i].gameObject);

                temp = Instantiate(_effect, new Vector3(colliders[i].gameObject.transform.position.x, colliders[i].gameObject.transform.position.y, colliders[i].gameObject.transform.position.z), colliders[i].gameObject.transform.rotation) as GameObject;

                gameObject.GetComponent<HPManager>().currentHP -= 50;
            }

            if (colliders[i].gameObject.name == "bullet(Clone)")
            {
                   
                gameObject.GetComponent<HPManager>().currentHP -= 10;
                Destroy(colliders[i].gameObject);
            }

            if (colliders[i].gameObject.tag == "Player")
            {
                speed = 0;

                animation.SetBool("walk_check", false);
                animation.SetBool("attack_check", true);

                colliders[i].gameObject.SendMessage("HpDown", daemage);

                Debug.Log("Player: " + colliders[i].gameObject.name);
                attack_check = true;

            }
            else
                attack_check = false;
        }


        /*
        foreach (Collider2D col in colliders)
        {




            if (col.gameObject.CompareTag("Player"))
            {
                speed = 0;

                animation.SetBool("walk_check", false);
                animation.SetBool("attack_check", true);

                timestop();


                col.gameObject.SendMessage("HpDown", daemage);

                Debug.Log("Player: " + col.gameObject.name);
                attack_check = true;

            }
            else
                attack_check = false;
         
        }

        */
    }

        IEnumerator timestop()
    {
        yield return new WaitForEndOfFrame();
    }
    

}
