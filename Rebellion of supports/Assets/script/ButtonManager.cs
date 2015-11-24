using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public GameObject target;
    public float speed = 2f;
    public Animator animation;

    void Awake()
    {
        animation = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void OnMouseDown()
    {
        target.transform.Translate(Vector2.left);
        Debug.Log("left");
    }

    public void left()
    {
        target.transform.Translate(Vector2.left);
        Debug.Log("left");
    }

    public void right()
    {
        target.transform.Translate(Vector2.right);
        Debug.Log("right");
    }
}
