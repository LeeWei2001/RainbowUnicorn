using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;


public class EnemySlime : MonoBehaviour
{
    public float health = maxHealth;
    public const float  maxHealth = 40;

    public GameObject gethit;

    float Atime = 5;//1.彈跳攻擊：造成8點傷害
    float Btime = 8;//2.黏液攻擊：造成6點傷害，玩家下一次傷害量減半
    float Ctime = 10;//3.光合作用：回復16點血量

    public Transform cam;
    //血量條
    public RectTransform HealthBar, Hurt;

    public Text healthvalue;
    //public sp

    

    public static int A_damage = 8;
    public static int B_damage = 6;
    public static int C_heal = 10;

    public static bool A_attack = false;//1.彈跳攻擊：5秒。
    public static bool B_attack = false;//2.黏液攻擊：8秒。
                                        //3.光合作用：10秒。

    /*public RectTransform SheildBar, SheildHurt;
    public float sheild = maxsheild;
    public const float maxsheild = 100;*/

    float A_curProgressValue = 5;
    float B_curProgressValue = 8;
    float C_curProgressValue = 10;

    public Image progressImg;
    public Text timetext;

    public GameObject split;

    public GameObject slimehalo;

    public GameObject[] Cards = new GameObject[25];

    float timecheck;

    bool timecheckA = true;
    bool timecheckB = false;
    bool timecheckC = false;

    public int timer_i = 0;
    bool start_Timer = true;

    public Animator animator;


    IEnumerator timer()//計時器寫法1
    {
        yield return new WaitForSeconds(1);
        timer_i++;
        Attack();
        start_Timer = true;

        switch (timer_i)
        {
            case 5:
                timecheckA = false;
                timecheckB = true;
                break;
            case 13:
                timecheckB = false;
                timecheckC = true;
                break;
            case 23:
                timecheckC = false;
                timecheckA = true;
                timer_i = 0;
                break;
            default:
                break;
        }
        time();

        /*if (health <= 0)
        { 

        }*/
    }

    void Start()
    {
        //split = GameObject.Find("split");
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            health = 0;
        }
        if (start_Timer)
        {
            StartCoroutine("timer");
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

        if (health <= 0)
        {
            start_Timer = false;
            StopCoroutine("timer");
            animator.SetBool("dead", true);
            FungusStageClear();
        }

        /*SheildBar.sizeDelta = new Vector2(sheild, SheildBar.sizeDelta.y);
        //呈現傷害量
        Sheildvalue.text = sheild + "/" + maxsheild;
        if (SheildHurt.sizeDelta.x > SheildBar.sizeDelta.x)
        {
            //讓傷害量(紅色血條)逐漸追上當前血量
            SheildHurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 100;
        }*/


        
    }
    public void Gethit()
    {
        gethit.SetActive(false);
    }
    public  void CardUse()
    {
        gethit.SetActive(true);
        switch (cardmovetxt.del.gameObject.name)
        {

            case "1(Clone)":
                if (PlayerCardBattle.weak == true)
                {
                    health -= 4;
                    PlayerCardBattle.weak = false;
                    break;

                }
                else
                {
                    health -= 8;
                    break;
                }
            case "2(Clone)":
                if (PlayerCardBattle.weak == true)
                {
                    health -= 5;
                    PlayerCardBattle.weak = false;
                    break;
                }
                else
                {
                    health -= 4;
                    break;
                }
            case "3(Clone)":
                if (PlayerCardBattle.weak == true)
                {
                    health -= 1;
                    PlayerCardBattle.weak = false;
                    runebutton.q += 2;
                    break;
                }
                else
                {
                    health -= 2;
                    runebutton.q += 2;
                    break;
                }
            case "10(Clone)":
                if (PlayerCardBattle.weak == true)
                {
                    health -= 5;
                    PlayerCardBattle.weak = false;
                    break;
                }
                else
                {
                    health -= 10;
                    break;
                }
        }
        Invoke("Gethit", 0.3f);
    }
    //三種攻擊
    /*void Attack()
    {
        timecheckA = timer_i % Atime;
        timecheckB = timer_i % Btime;
        timecheckC = timer_i % Ctime;

        switch (timecheckA)
        {
            case 0:
                A_attack = true;
                GameObject.Find("Player").GetComponent<PlayerCardBattle>().EnemyAttack();
                Debug.Log("1.彈跳攻擊：造成8點傷害：5秒");
                A_curProgressValue = Atime;
                A_attack = false;
                break;
            default:
                break;
        }

        switch (timecheckB)
        {
            case 0:
                B_attack = true;
                GameObject.Find("Player").GetComponent<PlayerCardBattle>().EnemyAttack();
                B_curProgressValue = Btime;
                split.SetActive(true);
                Invoke("splitattackoff", 1);
                Debug.Log("2.黏液攻擊：造成6點傷害，玩家下一次傷害量減半：8秒");
                B_attack = false;
                break;
            default:
                break;
        }


        switch (timecheckC)
        {
            case 0:
                Debug.Log("3.光合作用：回復16點血量：10秒");
                C_curProgressValue = Ctime;
                health += 16;
                if(health >40)
                {
                    health = 40;
                }
                break;
            default:
                break;
        }

        
    }*/
    //三種攻擊合併
    void Attack()
    {
        switch (timer_i)
        {
            case 5:
                A_attack = true;
                GameObject.Find("Player").GetComponent<PlayerCardBattle>().EnemyAttackSlime();
                Debug.Log("1.彈跳攻擊：造成8點傷害：5秒");
                animator.SetTrigger("Hit");
                A_curProgressValue = Atime;
                A_attack = false;
                break;

            case 13:
                B_attack = true;
                GameObject.Find("Player").GetComponent<PlayerCardBattle>().EnemyAttackSlime();
                animator.SetTrigger("Split");
                B_curProgressValue = Btime;
                split.SetActive(true);
                Invoke("splitattackoff", 1);
                Debug.Log("2.黏液攻擊：造成6點傷害，玩家下一次傷害量減半：8秒");
                B_attack = false;
                break;

            case 23:
                Debug.Log("3.光合作用：回復8點血量：10秒");
                C_curProgressValue = Ctime;

                slimehalo.SetActive(true);
                Invoke("slimehalooff", 5);

                health += 8;
                if (health > 40)
                {
                    health = 40;
                }

                

                break;

            default:
                break;
        }
    }  
    
    void time()
    {
        if(timecheckA == true)
        {
            timetext.text = "衝撞攻擊：" + A_curProgressValue.ToString();
            if (A_curProgressValue <= Atime)
            {
                if (A_curProgressValue >= 0)
                {
                    A_curProgressValue -= 1;
                }
            }
            progressImg.fillAmount = A_curProgressValue / Atime;
        }
        if(timecheckB == true)
        {
            timetext.text = "黏液噴射：" + B_curProgressValue.ToString();
            if (B_curProgressValue <= Btime)
            {
                if (B_curProgressValue >= 0)
                {
                    B_curProgressValue -= 1;
                }
            }
            progressImg.fillAmount = B_curProgressValue / Btime;
        }
        if(timecheckC == true)
        {
            timetext.text = "光合作用：" + C_curProgressValue.ToString();
            if (C_curProgressValue <= Ctime)
            {
                if (C_curProgressValue >= 0)
                {
                    C_curProgressValue -= 1;
                }
            }
            progressImg.fillAmount = C_curProgressValue / Ctime;
        }
    }

    void splitattackoff()
    {
        split.SetActive(false);
    }
    void slimehalooff()
    {
        slimehalo.SetActive(false);
    }

    public void StageClear()
    {
        library.i = 0;
        Destroy(this.gameObject);
        SceneManager.LoadScene(2);
       
    }

    void FungusStageClear()
    {
        if (library.fungusGo == true)
        Flowchart.BroadcastFungusMessage("StageClear");
        library.fungusGo = false;
    }
}
