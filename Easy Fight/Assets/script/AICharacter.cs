using UnityEngine;
using System.Collections;

public class AICharacter : MonoBehaviour {

    #region Variables;
    PlayerControll pc;
    PlayerControll en;

    public float changeStateTolerance = 3;

    public float normalRate = 1;

    float nrmTimer;

    public float closeRate = 0.5f;
    float clTimer;

    public float blockingRate = 1.5f;
    float blTimer;

    public float aiStateLife = 1;
    float aiTimer;

    bool initiateAI;
    bool closeCombat;

    bool gotRandom;
    float storeRandom;

    bool checkForBlocking;
    bool blocking;
    float blockMultiplier;

    bool randomizeAttacks;
    int numberOfAttacks;
    int curNumAttacks;

    public float JumpRate = 1;
    float jRate;
    bool jump;
    float jtimer;

    #endregion

    public enum AIstate
    {
        closeState,
        normalState,
        resetAI
    }

    public AIstate aiState;

	// Use this for initialization
	void Start () {
        pc = GetComponent<PlayerControll>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(!en)
        {
            en = pc.enemy.GetComponent<PlayerControll>();
        }

        CheckDistance();
        States();
        AIAgent();
	}

    void States()
    {
        switch (aiState)
        {
            case AIstate.closeState:
                CloseState();
                break;
            case AIstate.normalState:
                NormalState();
                break;
            case AIstate.resetAI:
                ResetAI();
                break;
         }
        Blocking();
        Jumping();
    }

    void AIAgent()
    {

        if (initiateAI)
        {
            aiState = AIstate.resetAI;

            float multipier = 0;

            if (!gotRandom)
            {
                storeRandom = RetureRandom();
                gotRandom = true;
            }

            if (!closeCombat)
            {
                multipier += 30;
            }
            else
            {
                multipier -= 30;

            }

            if (storeRandom + multipier < 50)
            {
                Attack();
            } else
                Movement();
        }
    }

    void Attack()
    {
        if (!gotRandom){
            storeRandom = RetureRandom();
            gotRandom = true;
        }

        if(storeRandom < 75)
        {
            if (!randomizeAttacks)
            {
                numberOfAttacks = (int)Random.Range(1, 4);
                randomizeAttacks = true;
            }

            if(curNumAttacks < numberOfAttacks)
            {
                int attackNumber = Random.Range(0, pc.attack.Length);

                pc.attack[attackNumber] = true;

                curNumAttacks++;
            }
        }
        else
        {
            if (curNumAttacks < 1)
            {
                pc.specialAttack = true;
                curNumAttacks++;
            }
        }


    }

    void Movement()
    {

        if (!gotRandom)
        {
            storeRandom = RetureRandom();
            gotRandom = true;
        }

        if(storeRandom < 90)
        {
            if (pc.enemy.position.x < transform.position.x)
            {
                pc.horizontal = -1;
            }
            else
                pc.horizontal = 1;

        }
        else
        {

            if (pc.enemy.position.x < transform.position.x)
            {
                pc.horizontal = 1;
            }
            else
                pc.horizontal = -1;
        }

      
    }

    void ResetAI()
    {
        aiTimer += Time.deltaTime;

        if(aiTimer > aiStateLife)
        {
            initiateAI = false;
            pc.horizontal = 0;
            pc.vertical = 0;
            aiTimer = 0;
            
            gotRandom = ralse;
            storeRandom = RetureRandom();

            if (storeRandom < 50)
                aiState = AIstate.normalState;
            else
                aiState = AIstate.closeState;

            curNumAttacks = 1;
            randomizeAttacks = false;
        }
    }
    
    void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, pc.enemy.position);

        if(distance > changeStateTolerance)
        {
            if(aiState != AIstate.resetAI)
            {
                aiState = AIstate.closeState;
            }

            closeCombat = true;
        }
        else
        {
            if(aiState != AIstate.resetAI)
            {
                aiState = AIstate.normalState;
            }

             if (closeCombat)
             {
                if (!gotRandom)
                {
                    storeRandom = RetureRandom();
                    gotRandom = true;
                }

                if(storeRandom < 60)
                {
                    Movement();
                }
             }

            closeCombat = false;
        }
    }

    void Blocking()
    {
        if (pc.damage)
        {
            if (!gotRandom)
            {
                storeRandom = RetureRandom();
                gotRandom = true;
            }

            if(storeRandom < 50)
            {
                blocking = true;
                pc.damage = false;
                pc.blocking = true;
            }
        }

        if (blocking)
        {
            blTimer += Time.deltaTime;

            if(blTimer > blockingRate)
            {
                pc.blocking = false;
                blTimer = 0;
            }
        }
    }

    void NormalState()
    {
        nrmTimer += Time.deltaTime;

        if(nrmTimer > normalRate)
        {
            initiateAI = true;
            nrmTimer = 0;
        }
    }
    
    void CloseState()
    {
        clTimer += Time.deltaTime;

        if(clTimer > closeRate)
        {
            clTimer = 0;
            initiateAI = true;
        }
    }

    void Jumping()
    {
        if(en.jumpKey || jump)
        {
            pc.vertical = 1;

            jump = false;
        }
        else
        {
            pc.vertical = 0;
        }

        jtimer += Time.deltaTime;

        if(jtimer > JumpRate * 10)
        {
            jRate = RetureRandom();

            if (jRate < 50)
            {
                jump = true;

            }
            else
            {
                jump = false;
            }

            jtimer = 0;
        }
    }

    float RetureRandom()
    {
        float retVal = Random.Range(0, 101);
        return retVal;
    }
}
