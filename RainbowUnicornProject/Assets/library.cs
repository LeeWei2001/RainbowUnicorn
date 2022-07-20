using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class library : MonoBehaviour
{

    public GameObject card = null;
    public GameObject[] Cards = new GameObject[25];
    public Transform[] handcard;

    public List<GameObject> handcards;

    public static bool fungusGo = true;

    public static int i;
    public static int c;

    public static int CountPosition = 0;

    /*public static bool[] cardt;*/
    public static bool a;
    public int timer_i = 0;
    bool start_Timer = true;

    void Start()
    {
        a = true;
    }
    /*IEnumerator timer()//計時器寫法1
    {
        yield return new WaitForSeconds(1);
        timer_i++;
        start_Timer = true;
    }*/

    void Update()
    {
        /*if (start_Timer)
        {
            StartCoroutine("timer");
            start_Timer = false;
            Debug.Log(timer_i);
        }*/

        if (i < 0)
        {
            i = 0;
        }

        if (i <= 9)
        {
            RuneCreate();
            //RemoveCardFromHand();
        }


    }

    /*void CardDisk()
    {
        if (a == true && )
        {
            int lenArray = PlayerCardBattle.Cards.Length;
            card = PlayerCardBattle.Cards[Random.Range(0, lenArray)];
            Instantiate(card, handcard[i].transform.position, handcard[i].transform.rotation);
            playingarea.card = 0;
            i += 1;
        }
        else
        {
            Instantiate(card, handcard[c].transform.position, handcard[c].transform.rotation);
            playingarea.card = 0;
            a = true;
            i += 1;
        }
    }*/

     public void RemoveCardFromHand()
    {
        handcards.Remove(cardmovetxt.del);
        for (int x = 0; x <= i; x++)
        {
            Debug.Log("換位子" + x);
            handcards[x].transform.position = handcard[x].transform.position;

        }
        /*if (cardmovetxt.CardUse == true)
        {
            handcards.Remove(cardmovetxt.del);
            for (int x = 0; x <= i; x++)
            {
                Debug.Log("換位子" + x);
                handcards[x].transform.position = handcard[x].transform.position;

            }
            cardmovetxt.CardUse = false;
        }*/
    }

    void RuneCreate()
    {
        //加判斷式 判斷目前符文合成
        if (playingarea.card == 3 && playingarea.attackcard == true)
        {
            switch (playingarea.attackrune)
            {

                case 3:
                    card = Cards[0];
                    break;

                case 2:
                    card = Cards[1];
                    break;

                case 1:
                    card = Cards[2];
                    break;
            }

            if (a == true)
            {
                
                GameObject NewCard = Instantiate(card, handcard[i].transform.position, handcard[i].transform.rotation);
                handcards.Add(NewCard);
                playingarea.card = 0;
                i += 1;
            }
        }

        if (playingarea.card == 3 && playingarea.defendcard == true)
        {
            switch (playingarea.defendrune)
            {
                case 3:
                    card = Cards[3];
                    break;
                case 2:
                    card = Cards[4];
                    break;
                case 1:
                    card = Cards[5];
                    break;
            }
            if (a == true)
            {

                GameObject NewCard = Instantiate(card, handcard[i].transform.position, handcard[i].transform.rotation);
                handcards.Add(NewCard);
                playingarea.card = 0;
                i += 1;
            }
        }

        if (playingarea.card == 3 && playingarea.changecard == true)
        {
            switch (playingarea.attackrune)
            {
                case 2:
                    card = Cards[6];
                    break;
                case 0:
                    card = Cards[7];
                    break;
                case 1:
                    card =  Cards[8];
                    break;
            }
            if (a == true)
            {

                GameObject NewCard = Instantiate(card, handcard[i].transform.position, handcard[i].transform.rotation);
                handcards.Add(NewCard);
                playingarea.card = 0;
                i += 1;
            }
        }
    }
    public void AddCard()
    {
        switch (cardmovetxt.del.name)
        {
            case "7(Clone)":
                    GameObject card = Instantiate(PlayerCardBattle.Gen, handcard[i].transform.position, handcard[i].transform.rotation);
                    handcards.Add(card);
                    i += 1;
                    Instantiate(PlayerCardBattle.Gen, handcard[i].transform.position, handcard[i].transform.rotation);
                    handcards.Add(card);
                    i += 1;
                break;
            case "8(Clone)":
                    GameObject card1 = Instantiate(PlayerCardBattle.Gen, handcard[i].transform.position, handcard[i].transform.rotation);
                    handcards.Add(card1);
                    i += 1;
                    Instantiate(PlayerCardBattle.Gen, handcard[i].transform.position, handcard[i].transform.rotation);
                    handcards.Add(card1);
                    i += 1;
                break;
            case "9(Clone)":
                    GameObject gen = Instantiate(PlayerCardBattle.Gen, handcard[i].transform.position, handcard[i].transform.rotation);
                    handcards.Add(gen);
                    i += 1;
                    GameObject gen1 = Instantiate(PlayerCardBattle.Gen1, handcard[i].transform.position, handcard[i].transform.rotation);
                    handcards.Add(gen1);
                    i += 1;
                break;

        }
        
    }

    public void randomcard()
    {
        GameObject gen = Instantiate(PlayerCardBattle.random, handcard[i].transform.position, handcard[i].transform.rotation);
        handcards.Add(gen);
        i += 1;
    }


    public void Reward1()
    {
        fungusGo = true;
        PlayerCardBattle.health += 20;
        PlayerPrefs.SetInt("HP", PlayerCardBattle.health);
    }

    public void Reward2()
    {
        fungusGo = true;
        runebutton.Starte++;
    }

    public void Reward3()
    {
        fungusGo = true;
        runebutton.Startq++;
        runebutton.Startw++;
    }

}
