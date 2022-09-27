using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject SelectionSystem;
    public GameObject Slime;

    public static bool playerON = false;

    public static bool MonsterON = false;



    private void Start()
    {
        //Slime.position.x = Vector3(2.82f, 0.4, 0.18);

        if (playerON == false)
        {
            Instantiate(player, transform.position, transform.rotation);

            playerON = true;
        }

        if(MonsterON == false)
        {
            Instantiate(Slime, transform.position, transform.rotation);

            MonsterON = true;
        }
    }
}
