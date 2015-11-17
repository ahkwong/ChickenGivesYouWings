using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private GameObject playerobject;
    //private Player playerscript;

    public int monstersize = 3;
    public GameObject monster;
    private GameObject monsterobject;
    private Monster[] monsterscript;

    void Awake()
    {
        playerobject = Instantiate(player, Vector3.right, Quaternion.identity) as GameObject;
        playerobject.name = "Player";
        //playerscript = (Player)playerobject.GetComponent(typeof(Player));

        monsterscript = new Monster[monstersize];
        for (int i = 0; i < monstersize; i++)
        {
            monsterobject = Instantiate(monster, Vector3.left, Quaternion.identity) as GameObject;
            monsterobject.name = "Monster"+(i+1);
            monsterscript[i] = (Monster)monsterobject.GetComponent(typeof(Monster));
        }
    }



    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
            playerscript.TakeDamaged();
        if (Input.GetKeyDown(KeyCode.Keypad1))
            monsterscript[0].TakeDamaged();
        if (Input.GetKeyDown(KeyCode.Keypad2))
            monsterscript[1].TakeDamaged();
        if (Input.GetKeyDown(KeyCode.Keypad3))
            monsterscript[2].TakeDamaged();*/
    }
}
