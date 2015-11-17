using UnityEngine;
using System.Collections;

public class Zone2 : MonoBehaviour {

    void FixedUpdate()
    {
        if (GetComponent<MeshRenderer>().enabled == true)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
