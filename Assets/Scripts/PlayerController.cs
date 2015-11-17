using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float movespeed = 5f;
    private Vector3 movement;

    private Rigidbody2D rb;
    private Animator anim;

    private bool jump;
    private Vector2 jumpforce = new Vector2(0f, 300f);
    private bool readyToJump = true;

    public float health;

    public bool swordtrigger;
    private float attack;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Application.LoadLevel(0);

        horizontal = Input.GetAxisRaw("Horizontal");
        Move();

        jump = Input.GetKey(KeyCode.X);
        if (jump && readyToJump)
            Jump();

        health = GetComponentInChildren<PlayerHealth>().health;
        if (health <= 0)
            Dead();

        swordtrigger = GetComponentInChildren<PlayerHealth>().swordistouched;
        if (swordtrigger)
        {
            transform.FindChild("WeaponHitBox").gameObject.SetActive(true);
            anim.SetBool("isSword", true);
        }
        else
            anim.SetBool("isSword", false);

        if (Input.GetKey(KeyCode.Z))
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);

        if (GetComponentInChildren<PlayerHealth>().target=="Jumper")
        {
            anim.SetBool("isJumping", true);
            Debug.Log("PLAYER JUMPED2");
            rb.velocity = Vector2.zero;
            rb.AddForce(jumpforce*2);
            readyToJump = false;
        }
    }

    void Move()
    {
        if (horizontal != 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
        movement.Set(horizontal, 0f, 0f);
        movement = movement * movespeed * Time.deltaTime;
        transform.localPosition += movement;
        if (horizontal == 1)
            transform.localScale = new Vector3(1f, 1f, 1f);
        if (horizontal == -1)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    void Jump()
    {
        anim.SetBool("isJumping", true);
        Debug.Log("PLAYER JUMPED");
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpforce);
        readyToJump = false;
    }

    void Dead()
    {
        Destroy(gameObject);
        Application.LoadLevel(0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            readyToJump = true;
            anim.SetBool("isJumping", false);
        }
    }
}
