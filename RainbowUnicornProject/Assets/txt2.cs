using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;


public class txt2 : MonoBehaviour
{

    

    public BoxCollider trigger;
    // Start is called before the first frame update
    void Start()
    {
        
        trigger = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            Flowchart.BroadcastFungusMessage("ccc");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Flowchart.BroadcastFungusMessage("end");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Flowchart.BroadcastFungusMessage("bbb");
        }*/
    }
   
    void OnTriggerEnter(Collider collider)
    {
        Invoke("fungusopen", 0.5f);
        if (collider.tag == "Player")
        {
            
            Flowchart.BroadcastFungusMessage("aaa");
            
        }
    }

    void fungusopen() 
    {
        SelectionManager.FungusOn = true;
    }

    public void fungusfinish()
    {
        
        Destroy(trigger);
        SelectionManager.FungusOn = false;
    } 
}

