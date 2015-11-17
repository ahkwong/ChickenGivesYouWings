using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

    public bool zonetrigger;
    private float lerpspeed = 10f;
    private Vector3 currentlocation;
    private Vector3 nextlocation;

    void Awake()
    {
        currentlocation = transform.position;
    }

    void FixedUpdate()
    {
        if (zonetrigger)
        {
            nextlocation = currentlocation + new Vector3(0f, 10f, 0f);
            transform.position = Vector3.Lerp(transform.position, nextlocation, lerpspeed * Time.deltaTime);
        }
        if (transform.position == nextlocation)
        {
            zonetrigger = false;
            currentlocation = nextlocation;
        }
    }
}
