using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    string MonsterType;

    public void Start()
    {
        LoadPlayer();
        Vector3 position = transform.position;
        
    }

    public void Awake()
    {
        /*DontDestroyOnLoad(this);*/
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        //level = data.level;
        //health = data.health;

        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Monster")
        {
            Invoke("SavePlayer",0.5f);

            MonsterType = other.gameObject.name;

            switch (MonsterType)
            {

                case "Slime":
                    Destroy(other.gameObject);
                    //MonsterBattle.Alive = false;
                    Invoke("MonsterFight", 0.5f);
                    break;

                case "Dog":
                    Destroy(other.gameObject);
                    //MonsterBattle.Alive = false;
                    Invoke("MonsterFight", 0.5f);
                    break;

                case "SlimeDog":
                    Destroy(other.gameObject);
                    //MonsterBattle.Alive = false;
                    Invoke("MonsterFight", 0.5f);
                    break;
                default:
                    break; 
            }
        }
    }

    void MonsterFight()
    {
        SceneManager.LoadScene(MonsterType);
    }
}
