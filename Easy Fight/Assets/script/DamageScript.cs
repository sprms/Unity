﻿using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.root != transform.root && col.tag != "Ground" && !col.isTrigger){

            if (!col.transform.GetComponent<PlayerControll>().damage && !col.transform.GetComponent<PlayerControll>().blocking)
            {
                col.transform.GetComponent<PlayerControll>().damage = true;

                col.transform.root.GetComponentInChildren<Animator>().SetTrigger("Damage");

                col.transform.GetComponent<PlayerControll>().currentHP -= 10;

                if (col.transform.GetComponent<PlayerControll>().currentHP <= 0)
                {
                    Destroy(col.gameObject);
                }
                
            }
        }
    }
}
