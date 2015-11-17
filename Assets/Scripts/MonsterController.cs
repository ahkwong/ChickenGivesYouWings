using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

    public float health;
    public string target;
    private Vector3 move = new Vector3(1, 0, 0);
    private float speed = 2f;
    private float randomstart, randomtravel;
    private Animator anim;
    public bool allowtowalk = true;

    void Awake()
    {
        randomstart = Random.Range(0f, 3f);
        randomtravel = Random.Range(1f, 3f);
        InvokeRepeating("Flip", randomstart, randomtravel);
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (allowtowalk)
            transform.position += (move * speed * Time.deltaTime);
        health = GetComponentInChildren<MonsterHealth>().health;
        if (health <= 0)
        {
            Dead();
        }
        target = GetComponentInChildren<MonsterHealth>().target;
        if (gameObject.tag == "Chicken" && target == "PlayerBodyHitBox")
        {
            anim.SetBool("isDead", true);
            allowtowalk = false;
            Invoke("Dead", 1f);
        }
        if (gameObject.tag == "BigMonster" && GetComponentInChildren<MonsterHealth>().BigMonsterGotHurt)
        {
            anim.SetBool("isDamaged", true);
        }
        if (gameObject.tag == "BigMonster" && !GetComponentInChildren<MonsterHealth>().BigMonsterGotHurt)
        {
            anim.SetBool("isDamaged", false);
        }
    }

    void Dead()
    {
        allowtowalk = true;
        if (gameObject.tag == "Untouchable")
            anim.SetBool("isDead", false);
        Destroy(gameObject);
    }
    void Flip()
    {
        move *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
