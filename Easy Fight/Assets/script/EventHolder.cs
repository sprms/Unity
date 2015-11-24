using UnityEngine;
using System.Collections;

public class EventHolder : MonoBehaviour {

    PlayerControll p1;

	// Use this for initialization
	void Start () {
       p1 = transform.root.GetComponent<PlayerControll>();
	}
	
    public void ThrowProjectile()
    {
        p1.specialAttack = true;
        Destroy(p1.pr);
    }
}
