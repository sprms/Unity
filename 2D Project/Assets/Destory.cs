using UnityEngine;
using System.Collections;

public class Destory : MonoBehaviour {


	// Use this for initialization
	void Start () {
        StartCoroutine("delete");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator delete()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
