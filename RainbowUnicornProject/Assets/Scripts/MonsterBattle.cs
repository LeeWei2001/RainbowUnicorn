using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterBattle : MonoBehaviour
{
    public static bool Alive = true;

    public void Start()
    {
        if (Alive == false)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }


}
