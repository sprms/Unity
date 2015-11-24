using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpFriends : MonoBehaviour {

    public float speed;
    Animator animation;
    public float daemage;
    bool attack_check;


    float temp;

    Image[] hpBar;
    Collider2D col;

    // Use this for initialization
    void Start()
    {


        daemage += PlayerPrefs.GetFloat(gameObject.name.Substring(0, gameObject.name.IndexOf('(')) + "_power") * 20;

        speed += PlayerPrefs.GetFloat(gameObject.name.Substring(0, gameObject.name.IndexOf('(')) + "_speed") / 2;

        temp = speed;

        animation = GetComponent<Animator>();
        attack_check = false;
        hpBar = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {


   

    
        
        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 3), new Vector2(gameObject.transform.position.x + 0.8f, gameObject.transform.position.y - 3));


        if (!attack_check)
        {
            speed = temp;

            //hpBar[0].enabled = false;
            //hpBar[1].enabled = false;

            animation.SetBool("attack_check", false);
            animation.SetBool("attack_check", false);
            animation.SetBool("attack_check", false);

            animation.SetBool("walk_check", true);
            
            transform.Translate(new Vector3(0.5f, 0, 0) * speed * Time.deltaTime);

            Debug.Log("friends help");
        }


        
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("Friend: " + colliders[i].gameObject.name);

            if (colliders[i].gameObject.tag == "Enemy")
            {
                speed = 0;

                animation.SetBool("walk_check", false);
                animation.SetBool("attack_check", true);
                if(colliders[i].gameObject.tag != "Player")
                     colliders[i].gameObject.SendMessage("HpDown", daemage);
                attack_check = true;
            }
            else if (colliders[0].gameObject.tag != "Enemy")
                attack_check = false;
        }

        
        /*
        foreach (Collider2D col in colliders)
        {


            if (col.gameObject.CompareTag("Enemy"))
            {
                speed = 0;

                animation.SetBool("walk_check", false);
                animation.SetBool("attack_check", true);

                timestop();

                col.gameObject.SendMessage("HpDown", daemage);

                Debug.Log("friends crashing " + col.gameObject.tag);
                attack_check = true;

            }
            else
            {
                attack_check = false;
            }
                
      
        }
        */
        
    }





    IEnumerator timestop()
    {
        yield return new WaitForEndOfFrame();
    }

}
