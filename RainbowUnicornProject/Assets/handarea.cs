using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handarea : MonoBehaviour
{
    public static float Attributes;
    public bool fire;
    public bool grass;
    public bool water;
    // Start is called before the first frame update
    void Start()
    {
        fire = false;
        grass = false;
        water = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Attributes == 1)
        {
            fire = true;
            grass = false;
            water = false;
        }
        else if (Attributes == 2)
        {
            fire = false;
            grass = true;
            water = false;
        }
        else if (Attributes == 3)
        {
            fire = false;
            grass = false;
            water = true;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "defense")
        {
            //uicontrol.m_library -= 1;
            cardmove.tmp = 1;
            //cardmove2.isMove = false;
        }
    }
}
