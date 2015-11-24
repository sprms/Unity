using UnityEngine;
using System.Collections;

public class FiniteStateMachine : MonoBehaviour {

    Vector2 position;
    public float speed;
    public float minPos;
    public float maxPos;
    float radius;

    public enum EnemyStates
    {
        Idle        = 0,
        run         = 1,
        attack      = 2
    }

    private EnemyStates _state;
    private bool _alive = false;

	// Use this for initialization
	void Start () {

        position = transform.position;

        _state = EnemyStates.Idle;
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            _state = EnemyStates.run;
            _alive = true;
            StartCoroutine("FSM");
        }
            

    }

    void move()
    {
        position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, minPos, maxPos);

        transform.position = position;
    }

    // 상태 변환 할 때 _alive = true;  StartCoroutine("FSM") 호출
    // 상태 변환 종료 _alive = false;

    private IEnumerator FSM()
    {
        while (_alive)
        {
            switch (_state)
            {
                case EnemyStates.Idle :
                    SendMessage("Idle");
                    Idle();
                    break;

                case EnemyStates.run:
                    SendMessage("run");
                    move();
                    run();
                    break;

                case EnemyStates.attack:
                    SendMessage("attack");
                    attack();
                    break;
            }

            yield return null;
        }
    }

    private void Idle()
    {
        _state = EnemyStates.Idle;
    }

    private void run()
    {
        _state = EnemyStates.run;
    }

    private void attack()
    {
        _state = EnemyStates.attack;
    }
}
