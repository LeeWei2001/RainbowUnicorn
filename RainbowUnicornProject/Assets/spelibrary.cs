using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spelibrary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "special")
        {
            uicontrol.m_speciallibrary--;
        }
    }
}