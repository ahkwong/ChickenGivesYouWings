using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public float health;
    private bool button;

    void Awake()
    {
        health = 100f;
    }
    void FixedUpdate()
    {
        button = Input.GetKeyDown(KeyCode.F);
    }

    public void TakeDamaged()
    {
        health -= 10f;
        Debug.Log("MONSTER TOOK DAMAGE");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (button && col.tag == "PlayerWeaponHitBox")
        {
            TakeDamaged();
        }
    }
}
