using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBodyHitBox")
        {
            Destroy(gameObject);
        }
    }
}
