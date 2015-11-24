using UnityEngine;
using System.Collections;

public class firework : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Animator>().SetTrigger("firework");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
