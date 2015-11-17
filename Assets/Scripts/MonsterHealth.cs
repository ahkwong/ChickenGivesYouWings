using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour {

    public float health;
    public string target = null;
    public bool readyToBeDamage = true;
    public bool AttackButton = false;
    public bool BigMonsterGotHurt;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AttackButton = true;
            Invoke("AttackDuration", 0.5f);
        }
        if ((target == "PlayerWeaponHitBox" && readyToBeDamage && AttackButton)||target=="BigMonster")
        {
            health -= 10f;
            GetComponentInParent<MonsterController>().allowtowalk = false;
            Debug.Log("MONSTER TOOK DAMAGE");
            readyToBeDamage = false;
            if (gameObject.tag == "BigMonster"||gameObject.tag=="BigBossWeakness")
                BigMonsterGotHurt = true;
            Invoke("ResetDamageCounter", 0.5f);
        }
    }
    void AttackDuration()
    {
        AttackButton = false;
    }

    void ResetDamageCounter()
    {
        readyToBeDamage = true;
        GetComponentInParent<MonsterController>().allowtowalk = true;
        BigMonsterGotHurt = false;
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
