using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ballmove : MonoBehaviour {

    public float force;
    public Text scoreText;
    int score;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0.5f) * Time.deltaTime * force);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "brick")
        {
            score += 100;

            scoreText.text = "Score : " + score;
        }
    }

}
