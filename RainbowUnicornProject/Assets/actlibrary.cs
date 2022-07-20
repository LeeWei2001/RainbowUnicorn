using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actlibrary : MonoBehaviour
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
        if(collision.tag == "attack")
        {
            uicontrol.m_attacklibrary--;
        }
    }
}
