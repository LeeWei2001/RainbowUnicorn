using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playingarea: MonoBehaviour
{
    public static float special;
    public static float card;
    public static float attack;
    public static float defense;

    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;

    public GameObject defense1;
    public GameObject defense2;
    public GameObject defense3;

    public GameObject special1;
    public GameObject special2;
    public GameObject special3;

    public static int attackrune, defendrune, changerune;

    public static int runetype;

    public static bool attackcard,defendcard,changecard;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && runebutton.q > 0)
        {
            Invoke("act", 0);
        }
        if (Input.GetKeyDown(KeyCode.W) && runebutton.w > 0)
        {
            Invoke("def", 0);
        }
        if (Input.GetKeyDown(KeyCode.E) && runebutton.e > 0 && card == 0)
        {
            Invoke("spe", 0);
        }

        if (card == 3)
        {
            switch (runetype)
            {
                case 1:
                    attackcard = true;
                    break;
                case 2:
                    defendcard = true;
                    break;
                case 3:
                    changecard = true;
                    break;
            }
            Invoke("play", 0.5f);
        }
    }
    void play()
    {
        
        runetype = 0;
        attackrune = 0;
        defendrune = 0;
        changerune = 0;
        attackcard = false;
        defendcard = false;
        changecard = false;

        card = 0;

        attack1.SetActive(false);
        attack2.SetActive(false);
        attack3.SetActive(false);
        defense1.SetActive(false);
        defense2.SetActive(false);
        defense3.SetActive(false);
        special1.SetActive(false);
        special2.SetActive(false);
        special3.SetActive(false);
    }
    public void act()
    {
        if (runebutton.q >= 0)
        {
            if (card == 0)
            {
                attack1.SetActive(true);
                card += 1;
                attackrune += 1;
                runetype = 1;
            }
            else if (card == 1)
            {
                attack2.SetActive(true);
                card += 1;
                attackrune += 1;
            }
            else if (card == 2)
            {
                attack3.SetActive(true);
                card += 1;
                attackrune += 1;
            }
        }
        
    }
    public void def()
    {
        if (runebutton.w >=0)
        {
            if (card == 0)
            {
                defense1.SetActive(true);
                card += 1;
                defendrune += 1;
                runetype = 2;
            }
            else if (card == 1)
            {
                defense2.SetActive(true);
                card += 1;
                defendrune += 1;
            }
            else if (card == 2)
            {
                defense3.SetActive(true);
                card += 1;
                defendrune += 1;
            }
        }
       
    }
    public void spe()
    {
        if (runebutton.e >= 0 && card == 0)
        {
            if (card == 0)
            {
                special1.SetActive(true);
                card += 1;
                runetype = 3;
                changerune += 1;

            }
            else if (card == 1)
            {
                special2.SetActive(true);
                card += 1;
            }
            else if (card == 2)
            {
                special3.SetActive(true);
                card += 1;
            }
        }
    }
}
