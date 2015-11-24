using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class brick : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "ball")
        {
            Destroy(gameObject);

        }
    }


}
