using UnityEngine;
using System.Collections;

public class BigBossControl : MonoBehaviour {

    public bool start = false;
    private int counter = 0;
    private int currentcount = 0;
    private int stuncounter = 0;
    private int shootcounter = 1;
    private float multiplier = -1;
    public GameObject chickenbomb;
    private float rightwall = 7f;
    private float leftwall = -7f;
    private Animator anim;
    
    private enum State
    {
        Idle,
        ChargeRight,
        ChargeLeft,
        Stun,
        Attack,
        Dead
    }

    private State currentState = State.Idle;

    void StateMachine()
    {
        switch (currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.ChargeRight:
                ChargeRightState();
                break;
            case State.ChargeLeft:
                ChargeLeftState();
                break;
            case State.Stun:
                StunState();
                break;
            case State.Attack:
                AttackState();
                break;
            case State.Dead:
                DeadState();
                break;
        }
    }

    void Start()
    {
        InvokeRepeating("Counter", 0f, 1f);
        anim = GetComponent<Animator>();
    }

    void Counter()
    {
        if (start)
            counter++;
        Debug.Log(counter);
    }

	void FixedUpdate ()
    {
        if (start)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            StateMachine();
            Debug.Log(currentState);
        }
        if (gameObject.tag == "BigMonster" && GetComponentInChildren<MonsterHealth>().BigMonsterGotHurt)
        {
            anim.SetBool("isAttacked", true);
        }
        if (gameObject.tag == "BigMonster" && !GetComponentInChildren<MonsterHealth>().BigMonsterGotHurt)
        {
            anim.SetBool("isAttacked", false);
        }
	}

    void IdleState()
    {
        if (counter == 6)
        { currentState = State.Attack;
        anim.SetBool("isShooting", true);
        }
    }
    void ChargeRightState()
    {
        if (counter >= currentcount+3)
        {
            anim.SetBool("isWalking", true);
            transform.position += (new Vector3(5f, 0f, 0f) * Time.deltaTime);
            if (transform.position.x >= rightwall)
            {
                currentState = State.Stun;
                ResetCounter();
                anim.SetBool("isWalking", false);
            }
        }
    }
    void ChargeLeftState()
    {
        if (counter >= currentcount+3)
        {

            transform.position -= (new Vector3(5f, 0f, 0f) * Time.deltaTime);
            if (transform.position.x <= leftwall)
            {
                currentState = State.Stun;
                ResetCounter();
            }
        }
    }
    void StunState()
    {
        anim.SetBool("isStunned", true);
        if (counter == currentcount+5)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            ResetCounter();
            currentState = State.Attack;
            anim.SetBool("isStunned", false);
        }
    }
    void AttackState()
    {
        multiplier *= -1;
        for (int i = 0; i < shootcounter; i++)
        {
            Vector3 location = transform.position;
            location += new Vector3(0.5f*multiplier, 1.4f, 0f);
            GameObject cb = Instantiate(chickenbomb, location, Quaternion.identity) as GameObject;
            float randomnumber = Random.Range(200f, 400f);
            float randomnumber2 = Random.Range(200f, 400f);
            cb.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomnumber*multiplier, randomnumber2));
        }
        if (multiplier==1)
            currentState = State.ChargeRight;
        if (multiplier==-1)
            currentState = State.ChargeLeft;
        ResetCounter();
        stuncounter++;
        shootcounter++;
        anim.SetBool("isShooting", false);
    }
    void DeadState()
    {
        Destroy(gameObject);
    }
    void ResetCounter()
    {
        currentcount = counter;
    }
}
