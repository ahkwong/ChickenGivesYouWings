using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public bool swordistouched = false;
    public string target = null;
    public bool readyToBeDamage = true;
    public bool jump = false;

    void Awake()
    {
        health = 10f;
    }

    void FixedUpdate()
    {
        if ((target == "Monster" || target == "BigMonster" || target == "Chicken") && readyToBeDamage)
        {
            health -= 10f;
            Debug.Log("PLAYER TOOK DAMAGE");
            readyToBeDamage = false;
            Invoke("ResetDamageCounter", 1f);
        }
        if (target == "Sword")
        {
            swordistouched = true;
            target = null;
        }
        else
        {
            swordistouched = false;
        }
    }

    void ResetDamageCounter()
    {
        readyToBeDamage = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        target = col.tag;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        target = null;
    }

}
