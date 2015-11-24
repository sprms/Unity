using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour {

    public GameObject player;
    bool _OnCheck = true;
    Animator animation;

    // Use this for initialization
    void Start()
    {
        animation = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("down");
        _OnCheck = true;
        StartCoroutine("buttonOn");
    }

    void OnMouseUp()
    {
        Debug.Log("up");
        _OnCheck = false;
        animation.SetBool("walk_check", false);
    }

    IEnumerator buttonOn()
    {
        while (_OnCheck)
        {

            Debug.Log("move");
            animation.SetBool("walk_check", true);
            player.transform.Translate(-Time.deltaTime * 2.0f, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
