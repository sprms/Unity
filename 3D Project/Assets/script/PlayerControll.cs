﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour {

    #region Variables;

    public GameObject pr;

    public bool AiCharacter;

    public int PlayerNumber = 1;
    public Transform enemy;

    Rigidbody2D rig2d;
    Animator anim;

    public float horizontal;
    public float vertical;
    public float maxSpeed = 25;
    Vector3 movement;
    bool crouch;

    public float JumpForce = 20;
    public float JumpDuration = 0.1f;
    float jmpDuration;
    float jmpForce;
    public bool jumpKey;
    bool falling;
    bool onGround;

    public float attackRate = 0.3f;
    public bool[] attack = new bool[2];
    float[] attacktimer = new float[2];
    int[] timePreseed = new int[2];

    public bool damage;
    public float noDamage = 1;
    float noDameageTimer;

    public bool specialAttack;
    public GameObject projectile;

    public bool blocking;

    public float maxHP;
    public float currentHP;
    public Image hp_bar;
    #endregion;

    // Use this for initialization
    void Start () {


        rig2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        jmpForce = JumpForce;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject p1 in players)
        {
            if(p1.transform != this.transform)
            {
                enemy = p1.transform;
            }
        }

        if (AiCharacter)
        {
            if (!GetComponent<AICharacter>())
            {
                gameObject.AddComponent<AICharacter>();
            }
        }

        StartCoroutine("HPSpeed");
    }

    void Update()
    {

        hp_bar.fillAmount = currentHP / maxHP;
        AttackInput();
        ScaleCheck();
        OnGroundCheck();
        Damage();
        SpecialAttack();
        UpdateAnimator();

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (!AiCharacter) {
            horizontal = Input.GetAxis("Horizontal" + PlayerNumber.ToString());
            vertical = Input.GetAxis("Vertical" + PlayerNumber.ToString());
        }
       

        Vector3 movement = new Vector3(horizontal, 0,0);

        crouch = (vertical < -0.1f);

        if (vertical > 0.1f)
        {
            if (!jumpKey)
            {
                jmpDuration += Time.deltaTime;
                jmpForce += Time.deltaTime;

                if(jmpDuration < JumpDuration)
                {
                    rig2d.velocity = new Vector2(rig2d.velocity.x , jmpForce);
                }else
                {
                    jumpKey = true;
                }
            }
        }

        if (!onGround && vertical < 0.1f)
        {
            falling = true;
        }

        if (attack[0] && !jumpKey || attack[1] && !jumpKey)
        {
            movement = Vector3.zero;

        }

        if (!crouch && !damage && !blocking)
            rig2d.AddForce(movement * maxSpeed);
        else
            rig2d.velocity = Vector3.zero;


	}

    void ScaleCheck()
    {
        if (transform.position.x < enemy.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }

    void AttackInput()
    {
        if (Input.GetButtonDown("Attack" + PlayerNumber.ToString()))
        {
            attack[0] = true;
            attacktimer[0] = 0;
            timePreseed[0]++; 
        }

        if (attack[0])
        {
            attacktimer[0] += Time.deltaTime;

            if(attacktimer[0] >  attackRate || timePreseed[0] >= 4)
            {
                attacktimer[0] = 0;
                attack[0] = false;
                timePreseed[0] = 0;
            }
        }

        if (Input.GetButtonDown("Attack" + PlayerNumber.ToString()))
        {
            attack[1] = true;
            attacktimer[1] = 0;
            timePreseed[1]++;
        }

        if (attack[1])
        {
            attacktimer[1] += Time.deltaTime;

            if (attacktimer[1] > attackRate || timePreseed[1] >= 4)
            {
                attacktimer[1] = 0;
                attack[1] = false;
                timePreseed[1] = 0;
            }
        }

        
    }

    void Damage()
    {
        if (damage)
        {
            noDameageTimer += Time.deltaTime;

            if(noDameageTimer > noDamage)
            {
                damage = false;
                noDameageTimer = 0;
            }
        }

       /* if (!onGround)
        {
            rig2d.gravityScale = 10;
            Vector3 dir = enemy.position - transform.position;
            rig2d.AddForce(-dir * 25);
        }*/
    }

    void SpecialAttack()
    {
        if (specialAttack)
        {
            pr = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            Vector3 nrDir = new Vector3(enemy.position.x, transform.position.y, 0);
            Vector3 dir = nrDir - transform.position;
            pr.GetComponent<Rigidbody2D>().AddForce(dir * 10, ForceMode2D.Impulse);

            specialAttack = false;
        }
    }

    void OnGroundCheck()
    {
        if (!onGround)
        {
            rig2d.gravityScale = 5;
        }
        else
        {
            rig2d.gravityScale = 1;
        }
    }

    void UpdateAnimator()
    {
        anim.SetBool("Crouch", crouch);
        anim.SetBool("OnGround", this.onGround);
        anim.SetBool("Falling", this.falling);
        anim.SetFloat("Movement", Mathf.Abs(horizontal));
        anim.SetBool("Attack1", attack[0]);
        anim.SetBool("Attack2", attack[1]);
        anim.SetBool("Blocking", blocking);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = true;

            jumpKey = false;
            jmpDuration = 0;
            jmpForce = JumpForce;
            falling = false;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = false;
        }

    }

    IEnumerable HPSpeed()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();




        }

    }
}
