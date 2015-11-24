using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

    public GameObject player;
    bool _OnCheck = true;
    public float minPos;
    public float maxPos;
    Vector2 position;

    // Use this for initialization
    void Start()
    {
        position = player.transform.position;
        minPos = player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        _OnCheck = true;
        player.GetComponent<move>()._Oncheck = false;
        player.GetComponent<Animator>().SetBool("walk_check", true);
        StartCoroutine("buttonOn");
    }

    void OnMouseUp()
    {
        _OnCheck = false;
        player.GetComponent<move>()._Oncheck = true;
        player.GetComponent<Animator>().SetBool("walk_check", false);
        StartCoroutine("buttonOn");
    }

    IEnumerator buttonOn()
    {
        while (_OnCheck)
        {

            player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, minPos, maxPos), player.transform.position.y, 0);
            player.transform.Translate(Time.deltaTime * 2.0f, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
