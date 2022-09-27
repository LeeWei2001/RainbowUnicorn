using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playingarea2 : MonoBehaviour
{
    public float special;
    public  float card;
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;
    public GameObject defense1;
    public GameObject defense2;
    public GameObject defense3;
    public GameObject special1;
    public GameObject special2;
    public GameObject special3;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (card == 0)
        {
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
        if (card == 3)
        {
            Invoke("play", 2);
        }

    }
    void play()
    {
        if (card == 3)
        {
            card = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "attack")
        {
            if (card == 0)
            {
                attack1.SetActive(true);
                card += 1;
            }
            else if (card == 1)
            {
                attack2.SetActive(true);
                card += 1;
            }
            else if (card == 2)
            {
                attack3.SetActive(true);
                card += 1;
            }
        }
        if (collision.tag == "defense")
        {
            if (card == 0)
            {
                defense1.SetActive(true);
                card += 1;
            }
            else if (card == 1)
            {
                defense2.SetActive(true);
                card += 1;
            }
            else if (card == 2)
            {
                defense3.SetActive(true);
                card += 1;
            }
        }
        if (collision.tag == "fire")
        {
            handarea.Attributes = 1;
        }
        if (collision.tag == "grass")
        {
            handarea.Attributes = 2;
        }
        if (collision.tag == "water")
        {
            handarea.Attributes = 3;
        }
        if (collision.tag == "special")
        {
            if (card == 0)
            {
                special1.SetActive(true);
                card += 1;
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
