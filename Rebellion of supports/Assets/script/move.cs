using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public float speed = 1f;
   // public Animator ani;
    float horizontalMove;
    Vector2 position;
    public float maxPos;
    public float minPos;
    float radius = 5.0f;
    public float bullet_speed;
    public float daemage;
    bool isshot;

    public float power;

    public GameObject bullet;

    GameObject temp;

    int length;

    public bool _Oncheck;

    public GameObject button;

    // Use this for initialization
    void Awake() { 
      //  ani = GetComponent<Animator>();  

	}

    void Start()
    {
        isshot = true;
        _Oncheck = true;
        minPos = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {


        position = transform.position;

        if (GetComponent<Collider2D>().IsTouching(button.GetComponent<Collider2D>())){
            Debug.Log("true");
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);

        position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, minPos, maxPos);

        if (_Oncheck)
            transform.position = position;
        else
        //    ani.SetBool("walk_check", true);


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)  )
        {
         //   ani.SetBool("walk_check", true);
        }
        else
        {
         //   ani.SetBool("walk_check", false);
        }

        if (Input.GetKey(KeyCode.Space) && isshot)
        {
           // ani.SetBool("attack_check", true);

            temp = Instantiate(bullet, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.75f, transform.position.z), transform.rotation) as GameObject;
            StartCoroutine("shot", temp);
            StartCoroutine("Wait");
            isshot = false;

        }
        else
        {
          //  ani.SetBool("attack_check", false);
        }
    }

    void AnimationUpdate()
    {
        if(horizontalMove == 0)
        {
          //  ani.SetBool("isRunning", false);
        }
        else
        {
           // ani.SetBool("isRunning", true);
        }
    }

    IEnumerator shot(GameObject temp)
    {
        while (true)
        {

            if (temp == null)
                break;


            temp.transform.Translate(Time.deltaTime * 10.0f, 0, 0);
            yield return new WaitForEndOfFrame();

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(bullet_speed);
        isshot = true;
        Destroy(temp);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("trigger: " + col.gameObject.name);
    }
}
