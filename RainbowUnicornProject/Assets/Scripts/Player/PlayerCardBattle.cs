using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCardBattle : MonoBehaviour
{
    public GameObject[] Cards = new GameObject[25];// 數組用於存放 prefab  

    public GameObject[] CardDisk;

    public GameObject gethit;
    public GameObject getsheild;
    public GameObject useattack;

    public static GameObject Gen;//生成卡牌指定
    public static GameObject Gen1;

    public static GameObject random;

    public Text healthvalue;

    public Text Sheildvalue;

    //public static int third = 0;

    public static int health;
    public const int maxHealth = 100;
    //生命

    public Transform cam;
    //血量條
    public RectTransform HealthBar, Hurt;
    public RectTransform SheildBar, SheildHurt;

    public int sheild;
    public static int maxsheild = 15;

    public static bool weak = false;

    public int timer_i = 0;
    bool start_Timer = true;

    public Animator animator;

    IEnumerator timer()//計時器寫法1
    {
        yield return new WaitForSeconds(1);
        timer_i++;
        start_Timer = true;
    }
    void Start()
    {
        
        health = PlayerPrefs.GetInt("HP");
        PlayerPrefs.SetInt("HP", health);
        if (health==0)
        {
            health = maxHealth;
        }
        CardDisk = Cards;
        int c = Random.Range(0, 14);
        /*for (int i = 0; i < 3; i++)
        {
            int lenArray = Cards.Length; // 獲取數組長度
            random = Cards[Random.Range(9, 13)]; // 隨機序號
            GameObject.Find("UI").GetComponent<library>().randomcard(); ;//能調用public和private類型函數
        }*/
    }

    public void CardEffect()
    {
        
        switch (cardmovetxt.del.name)
        {
            case "4(Clone)":
                getsheild.SetActive(true);
                Invoke("Getsheild", 1);
                if (sheild < maxsheild)
                    sheild += 8;
                if (sheild > maxsheild)
                    sheild = maxsheild;
                break;
            case "5(Clone)":
                getsheild.SetActive(true);
                Invoke("Getsheild", 1);
                if (sheild < maxsheild)
                    sheild += 4;
                if (sheild > maxsheild)
                    sheild = maxsheild;
                break;
            case "6(Clone)":
                getsheild.SetActive(true);
                Invoke("Getsheild", 1);
                if (sheild < maxsheild)
                    sheild += 2;
                if (sheild > maxsheild)
                    sheild = maxsheild;
                runebutton.w += 2;
                break;

            case "7(Clone)":
                Gen = Cards[1];//生成五葉草馬芬炸彈
                GameObject.Find("UI").GetComponent<library>().AddCard(); ;//能調用public和private類型函數
                break;
            case "8(Clone)":
                Gen = Cards[4];//生成五葉草護盾
                GameObject.Find("UI").GetComponent<library>().AddCard(); ;//能調用public和private類型函數
                break;
            case "9(Clone)":
                Gen = Cards[1];//生成
                Gen1 = Cards[4];
                GameObject.Find("UI").GetComponent<library>().AddCard(); ;//能調用public和private類型函數
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //health = PlayerPrefs.GetInt("HP");
        PlayerPrefs.SetInt("HP", health);
        //Debug.Log("HP" + health.ToString());
        if (start_Timer)
        {
            StartCoroutine("timer");

            /*if (timer_i % 10 == 0)
            {
                int lenArray = Cards.Length; // 獲取數組長度
                random = Cards[Random.Range(9, 13)]; // 隨機序號
                GameObject.Find("UI").GetComponent<library>().randomcard(); ;//能調用public和private類型函數
            }*/
            start_Timer = false;
        }

        HealthBar.sizeDelta = new Vector2(health, HealthBar.sizeDelta.y);
        //呈現傷害量
        healthvalue.text = health.ToString() /*+ "/" + maxHealth*/;
        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)
        {
            //讓傷害量(紅色血條)逐漸追上當前血量
            Hurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 100;
        }

        SheildBar.sizeDelta = new Vector2(sheild, SheildBar.sizeDelta.y);
        //呈現傷害量
        Sheildvalue.text = sheild.ToString()  /*"/" + maxsheild*/;
        if (SheildHurt.sizeDelta.x > SheildBar.sizeDelta.x)
        {
            //讓傷害量(紅色血條)逐漸追上當前血量
            SheildHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 100;
        }

        if (health <= 0)
        {
            GameOver();
        }
    }

    public void EnemyAttackSlime()
    {
        if (EnemySlime.A_attack == true)
        {
            gethit.SetActive(true);
            Invoke("Gethit", 0.3f);
            int damage = EnemySlime.A_damage;
            if (sheild > 0)
            {
                int damage2 = damage - sheild;
                if (damage2 > 0)
                {
                    health -= damage2;
                    sheild = 0;
                }
                if (damage2 == 0)
                {
                    sheild = 0;
                }
                if (damage2 < 0)
                {
                    sheild = -damage2;
                }
            }
            else
            {
                health -= damage;
                sheild = 0;
            }
        }
        if (EnemySlime.B_attack == true)
        {
            gethit.SetActive(true);
            Invoke("Gethit", 0.3f);
            weak = true;
            int damage = EnemySlime.B_damage;
            if (sheild > 0)
            {
                int damage2 = damage - sheild;
                if (damage2 > 0)
                {
                    health -= damage2;
                    sheild = 0;
                }
                if (damage2 == 0)
                {
                    sheild = 0;
                }
                if (damage2 < 0)
                {
                    sheild = -damage2;
                }
            }
            else
            {
                health -= damage;
                sheild = 0;
            }
        }
    }

    public void EnemyAttackDog()
    {
        if (EnemyDog.A_attack == true)
        {
            gethit.SetActive(true);
            Invoke("Gethit", 0.3f);
            int damage = EnemyDog.A_damage;
            if (sheild > 0)
            {
                int damage2 = damage - sheild;
                if (damage2 > 0)
                {
                    health -= damage2;
                    sheild = 0;
                }
                if (damage2 == 0)
                {
                    sheild = 0;
                }
                if (damage2 < 0)
                {
                    sheild = -damage2;
                }
            }
            else
            {
                health -= damage;
                sheild = 0;
            }
        }
        if (EnemyDog.B_attack == true)
        {
            gethit.SetActive(true);
            Invoke("Gethit", 0.3f);
            weak = true;
            int damage = EnemyDog.B_damage;
            if (sheild > 0)
            {
                int damage2 = damage - sheild;
                if (damage2 > 0)
                {
                    health -= damage2;
                    sheild = 0;
                }
                if (damage2 == 0)
                {
                    sheild = 0;
                }
                if (damage2 < 0)
                {
                    sheild = -damage2;
                }
            }
            else
            {
                health -= damage;
                sheild = 0;
            }
        }
    }

    public void EnemyAttackSlimeDog()
    {
        if (EnemySlimeDog.A_attack == true)
        {
            gethit.SetActive(true);
            Invoke("Gethit", 0.3f);
            int damage = EnemySlimeDog.A_damage;
            if (sheild > 0)
            {
                int damage2 = damage - sheild;
                if (damage2 > 0)
                {
                    health -= damage2;
                    sheild = 0;
                }
                if (damage2 == 0)
                {
                    sheild = 0;
                }
                if (damage2 < 0)
                {
                    sheild = -damage2;
                }
            }
            else
            {
                health -= damage;
                sheild = 0;
            }
        }
        if (EnemySlimeDog.B_attack == true)
        {
            gethit.SetActive(true);
            Invoke("Gethit", 0.3f);
            weak = true;
            int damage = EnemySlimeDog.B_damage;
            if (sheild > 0)
            {
                int damage2 = damage - sheild;
                if (damage2 > 0)
                {
                    health -= damage2;
                    sheild = 0;
                }
                if (damage2 == 0)
                {
                    sheild = 0;
                }
                if (damage2 < 0)
                {
                    sheild = -damage2;
                }
            }
            else
            {
                health -= damage;
                sheild = 0;
            }
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
        PlayerPrefs.SetInt("HP", 100);
    }



    public void Gethit()
    {
        gethit.SetActive(false);
    }
    public void Getsheild()
    {
        getsheild.SetActive(false);
    }
}
