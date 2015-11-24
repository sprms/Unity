using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ken()
    {
       gameObject.transform.Translate(new Vector3(1, 0, 0));
    }
}
