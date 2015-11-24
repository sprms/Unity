using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {

    public float carSpeed;
    Vector2 position;
    public float maxPos = 2.2f;
    public int life = 3;
    public GameObject prefab;

	// Use this for initialization
	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // 키 입력 방향 만큼 carSpeed의 속도로 이동
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

        // 밖으로 빠져나가지 못하게
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);

        // 현재 포지션값을 객체의 위치로 지정
        transform.position = position;
	}

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Enemy Car")
        {

            Destroy(gameObject);

        }
    }
}
