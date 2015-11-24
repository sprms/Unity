using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject player;
    bool _OnCheck = true;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        _OnCheck = true;
       // player.GetComponent<move>()._OnCheck = false;
        StartCoroutine("buttonOn");
    }


    IEnumerator buttonOn()
    {
        while (_OnCheck)
        {
            player.transform.Translate(Time.deltaTime * 2.0f, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
