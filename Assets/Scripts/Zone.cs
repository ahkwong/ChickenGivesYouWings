using UnityEngine;
using System.Collections;

public class Zone : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<CameraControll>().zonetrigger = true;
            gameObject.GetComponentInParent<MeshRenderer>().enabled = true;
            Destroy(gameObject);
            if (gameObject.name == "finalzone")
            {
                GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
                for (int i = 0; i < monsters.Length; i++)
                    Destroy(monsters[i]);
                GameObject.Find("BigBoss").GetComponent<BigBossControl>().start = true;
            }
        }
    }
}
