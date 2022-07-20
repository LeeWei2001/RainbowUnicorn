using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        Invoke("fungusopen", 0.5f);
        if (collider.tag == "Player")
        {
            Invoke("fungusopen", 0.5f);
            Flowchart.BroadcastFungusMessage("www");
            PlayerPrefs.SetInt("HP", 100);
        }
    }
    public void fungusfinish()
    {
        SelectionManager.FungusOn = false;
        
    }
    void fungusopen()
    {
        SelectionManager.FungusOn = true;
        Destroy(this.gameObject);
    }
   
}
